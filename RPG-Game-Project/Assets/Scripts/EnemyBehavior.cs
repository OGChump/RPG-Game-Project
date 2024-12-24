using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform Waypoint1;
    public Transform Waypoint2;
    public float movespeed = 2f;

    private Transform target;
    private bool isChasing = false;
    private Transform player;

    void Start()
    {
        target = Waypoint1;
    }

    void Update()
    {
        if (isChasing && player != null)
        {
            ChasePlayer(); // Fixed typo in method name
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == Waypoint1 ? Waypoint2 : Waypoint1;
        }
    }

    void ChasePlayer()
    {
        // Now moves toward the player's position instead of the target (waypoints)
        transform.position = Vector2.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = true;
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
            player = null;
        }
    }
}
