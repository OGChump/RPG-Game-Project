using UnityEngine;

public class EnemyBehavior : MonoBehaviour 
{
    public Transform Waypoint1;
    public Transform Waypoint2; 
    public float movespeed = 2f;

    private Transform target; 

    void Start()
    {
        target = Waypoint1; 
    }

    void Update()
    {
        Patrol(); 
    }

    void Patrol()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);

        
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == Waypoint1 ? Waypoint2 : Waypoint1;
        }
    }
}
