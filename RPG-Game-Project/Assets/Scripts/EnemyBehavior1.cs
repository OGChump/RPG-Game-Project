using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior1 : MonoBehaviour
{
    public float movespeed;
    public Transform wayPoint1;
    public Transform wayPoint2;

    private Transform target;
    private bool facingRight = true;

    private void start()
    {
        target = wayPoint1;
    }

    private void update()
    {
        Patrol();
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

    private void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}