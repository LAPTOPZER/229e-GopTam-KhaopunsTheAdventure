using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public TMP_Text hpText;

    float move;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isJump;

    [SerializeField] GameObject Win;
    [SerializeField] GameObject winSFX;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject loseSFX;

    [SerializeField] GameObject hurtSFX;
    [SerializeField] GameObject jumpSFX;

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
            GameObject jumpFX = Instantiate(jumpSFX, transform.position, Quaternion.identity);
            Destroy(jumpFX, jumpFX.GetComponent<AudioSource>().clip.length);
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
            GameObject hurtFX = Instantiate(hurtSFX, transform.position, Quaternion.identity);
            Destroy(hurtFX, hurtFX.GetComponent<AudioSource>().clip.length);
            TakeDamage(20);
        }
        if (other.gameObject.CompareTag("Spike"))
        {
            GameObject hurtFX = Instantiate(hurtSFX, transform.position, Quaternion.identity);
            Destroy(hurtFX, hurtFX.GetComponent<AudioSource>().clip.length);
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
                GameObject winFX = Instantiate(winSFX, transform.position, Quaternion.identity);
                Destroy(winFX, winFX.GetComponent<AudioSource>().clip.length);
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
            GameObject loseFX = Instantiate(loseSFX, transform.position, Quaternion.identity);
            Destroy(loseFX, loseFX.GetComponent<AudioSource>().clip.length);
            Lose.SetActive(true);
            Destroy(this.gameObject);
        }
        Debug.Log(hp);

        if (hpText != null)
            hpText.text = $"{hp}";
    }

}
