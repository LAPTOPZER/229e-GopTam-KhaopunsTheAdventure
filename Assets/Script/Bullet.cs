using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(fx, 1f);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
