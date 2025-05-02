using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public TMP_Text hpText;

    float move;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isJump;

    [SerializeField] GameObject Win;
    [SerializeField] GameObject Lose;

    [SerializeField] int hp = 100;

    [SerializeField] int winScore = 10;

    private void Awake()
    {
        Win.SetActive(false);
        Lose.SetActive(false);
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        FlipSprite();
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Mace"))
        {
            TakeDamage(20);
        }
        if (other.gameObject.CompareTag("Spike"))
        {
            TakeDamage(10);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }

    void FlipSprite()
    {
        if (move > 0)
            spriteRenderer.flipX = false;
        else if (move < 0)
            spriteRenderer.flipX = true;
    }


    // Win UI
    private void OnTriggerEnter2D(Collider2D other)
    {
        int currentScore = Inventory.Instance.pointCount;
        if (other.CompareTag("House"))
        {
            if (currentScore == winScore)
            {
                Time.timeScale = 0f;
                Win.SetActive(true);
            }
        }
    }


    //Lose
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Time.timeScale = 0f;
            Lose.SetActive(true);
            Destroy(this.gameObject);
        }
        Debug.Log(hp);

        if (hpText != null)
            hpText.text = $"{hp}";
    }

}
