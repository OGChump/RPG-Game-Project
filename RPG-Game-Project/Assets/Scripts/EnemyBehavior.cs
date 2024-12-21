using UnityEngine; 
//This imports the UnityEngine library. It lets you use the tools that Unity provides

public class EnemyBehavior : MonoBehaviour 
    //A class is the blueprint. EnemyBehavior is the name of the script. MonoBehavior is unity's parent class (meaning that it lets you controll GameObjects).
{
    public Transform Waypoint1;
    public Transform Waypoint2;
    //Transform is used for position, rotation, and size. Public means that these will appear in the unity editor.

    public float movespeed = 2f;
    //floats are used to store numbers with decimals, 2 indicates the speed while the f indicates the float.

    private Transform target; 
    //Private means that this variable is only used in the script and won't be shown in the unity editor. Target keeps track of enemy current destination.

    void Start()
    {
        target = Waypoint1; 
    }
    //Start is a function that runs once when the game begins, when the object first appears the taget is set to move torwards the waypoint.

    void Update()
    {
        Patrol(); 
    }
    //Update is a continous function that runs a single frame about 60 times per second. Patrol is the function that actually moves the enemy towards the waypoint.

    void Patrol()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
        //transform.position gets the enemy's current position. target.position is the position of the waypoint that the enemy is currently moving towards. movespeed * Time.deltaTime is the movement speed adjusted to be smooth.
        
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == Waypoint1 ? Waypoint2 : Waypoint1;
        }
        //Vector2.Distance calculates the distance between the enemy position and the waypoint.
        //<0.1f says if the distance is very small then the enemy has reached the waypoint.
        //target = target == Waypoint1 ? Waypoint2 : Waypoint1; is a if-else statement
    }
}
