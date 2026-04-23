using UnityEngine;

public class Follow_Waypoint : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWaypoint = 0;

    public float speed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < 1)
            currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;

        this.transform.LookAt(waypoints[currentWaypoint].transform);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
