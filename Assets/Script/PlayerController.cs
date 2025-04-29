using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    float move;
    [SerializeField] float speed;

    [SerializeField] float jumpForce;
    [SerializeField] bool isJump;

    [SerializeField]private GameObject Win;

    private void Awake()
    {
        Win.SetActive(false);
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
        if (other.CompareTag("House"))
        {
            ShowUI();
        }
    }

    private void ShowUI()
    {
        Time.timeScale = 0f;
        Win.SetActive(true);
    }
}
