using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    //Vector2 moveInput;
    private SpriteRenderer spriteRenderer;

    float move;
    [SerializeField] float speed;

    [SerializeField] float jumpForce;
    [SerializeField] bool isJump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        FlipSprite();
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump");
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
}
