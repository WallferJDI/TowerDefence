using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    
    private Transform target;
    private int waypointIndex = 0;

       void Start()
    {
        target = Waypoints.points[0];
    }
     void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWaypoint();

    }
    void GetNextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex == Waypoints.points.Length)
            Destroy(gameObject);
        else
            target = Waypoints.points[waypointIndex];

    }

}
