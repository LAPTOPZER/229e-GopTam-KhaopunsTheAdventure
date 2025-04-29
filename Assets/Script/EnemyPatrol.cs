using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private Transform targetPoint;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        targetPoint = pointB;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }

        if (targetPoint.position.x > transform.position.x)
            spriteRenderer.flipX = false;
        else if (targetPoint.position.x < transform.position.x)
            spriteRenderer.flipX = true;
    }
}
