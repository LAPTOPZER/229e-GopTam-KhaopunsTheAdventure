using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
