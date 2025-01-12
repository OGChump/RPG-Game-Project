using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior1 : MonoBehaviour
{
    public float movespeed;
    public Transform wayPoint1;
    public Transform wayPoint2;

    private Transform target;
    private Transform player;
    private bool facingRight = true;
    private bool isChasing = false;

    private void Start()
    {
        target = wayPoint1;
    }

    private void Update()
    {
        if (isChasing && player != null)
        {
            chasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
        //The enemy's position is updated to keep moving the enemy towards the current target
        //Vector2.MoveTowards() smoothly moves the enemy from its current position to the target
        //movespeed determines the speed and Time.deltaTime ensures smmoth movement over time

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == wayPoint1 ? wayPoint2 : wayPoint1;

            flip();
        }
    }

    private void chasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);

        if ((player.position.x > transform.position.x && !facingRight) ||
        (player.position.x < transform.position.x && facingRight))
        {
            flip();
        }
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

    private void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}