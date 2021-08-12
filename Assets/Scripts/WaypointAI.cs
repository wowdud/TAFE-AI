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
    public GameObject waypoint3;
    public GameObject waypoint4;
    public GameObject CurrentGoal;
    public int listPos = 0;

    public bool isAIon = true;
        
    List<GameObject> pointList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        pointList.Add(waypoint);
        pointList.Add(waypoint2);
        pointList.Add(waypoint3);
        pointList.Add(waypoint4);

        CurrentGoal = pointList[0];
    }

    // Update is called once per frame
    void Update()
    {

        if (isAIon == false)
        {
            return;
        }

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
            listPos = listPos + 1;
            if (listPos < pointList.Count)
            {
                CurrentGoal = pointList[0 + listPos];
            }
            else
            {
                CurrentGoal = pointList[0];
                listPos = -1;
            }
        }
    }
}
