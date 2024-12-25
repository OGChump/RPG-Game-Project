using UnityEngine;
//This imports Unity's engine library

public class EnemyBehavior : MonoBehaviour
    //Declares the EnemyBehavior class (to control the enemy)
    //Inherits from MonoBehavior (enemy can be attached to GameObject)
{
    public Transform Waypoint1;
    public Transform Waypoint2;
    public float movespeed = 2f;
    //Public Variables store references (Theses one specifically store them to waypoints)
    //Waypoints define the enemies movement
    //Public float to determine enemy movement speed (f indicates it's a float)

    private Transform target;
    private bool isChasing = false;
    private Transform player;
    //Private variable to keep track of enemy's movement
    //Private bollean to track if the enemy is chasing the player
    //Private variable used to store the players position


    void Start()
        //Starts once the enemy is created in the game
    {
        target = Waypoint1;
        //At the start the enemies target is set to waypoint 1
    }

    void Update()
        //updates the method per frame (60 times per second)
    {
        if (isChasing && player != null)
            //Checks if the enemy is chasing the player and the player is moving
        {
            ChasePlayer(); // Fixed typo in method name
            //calls the ChasePlayer() method to move towards the player
        }
        else
        {
            Patrol();
            //If the enemy is not chasing the player call the Patorl() method and continues patrolling)
        }
    }

    void Patrol()
        //Patrol moves the enemy between the two waypoints
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
        //The enemy's position is updated to keep moving the enemy towards the current target
        //Vector2.MoveTowards() smoothly moves the enemy from its current position to the target
        //movespeed determines the speed and Time.deltaTime ensures smmoth movement over time

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
            //Checks if the enemy is very close to they waypoint
        {
            target = target == Waypoint1 ? Waypoint2 : Waypoint1;
            //If the enemy has reached the waypoint, switch to the other waypoint
            //This uses a ternary operator (this is a shorthand if-else statement that takes 3 inputs and give one output)
        }
    }

    void ChasePlayer()
        //The Chaseplayer method moves the enemy toward the player's position when the player is detected
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
        //The enemy position is updated towards the player's position
        //Vector2.MoveTowards() ensures the mvoement is smooth
    }

    private void OnTriggerEnter2D(Collider2D collision)
        //This method is triggered when another object enters the enemy's detection zone
    {
        if (collision.CompareTag("Player"))
            //If the object enters the detection zone and has the tag "Player"
        {
            isChasing = true;
            player = collision.transform;
            //Set isChasing to true to make the enemy start chasing the player when in range
            //Stoe the player's position in the player vatiable for the Chaseplayer
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
        //This method is triggered when and object leaves the enemy's dection zone
    {
        if (collision.CompareTag("Player"))
            //If the object leaves the detection zone
        {
            isChasing = false;
            player = null;
            //Set isChasing to false, indicating that the enemy should stop chasing the player
            //Clear the player's position since the player is no longer within the rangeSSSS
        }
    }
}
