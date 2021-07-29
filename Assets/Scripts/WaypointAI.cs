using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{

    public float speedX = 1f;
    public float speedY = 1f;
    public GameObject waypoint;
    public GameObject waypoint2;
    public GameObject CurrentGoal;
    public int waypointCount; 
    
    

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> pointList = new List<GameObject>();
        CurrentGoal = waypoint;
        while (waypointCount > 0)
        {
            pointList.Add(CurrentGoal);
            waypointCount -= 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, CurrentGoal.transform.position);
  

        //float distance = (waypoint.transform.position - transform.position).magnitude;
        

        if (distance >= 0.01f)
            {
            Vector2 direction = CurrentGoal.transform.position - transform.position;
            direction.Normalize();

            Vector2 aiPosition = transform.position;
            aiPosition.x += direction.x * speedX * Time.deltaTime;
            aiPosition.y += direction.y * speedY * Time.deltaTime;
            transform.position = aiPosition;
            }
        else
        {
            CurrentGoal = waypoint2;
        }

    }
}
