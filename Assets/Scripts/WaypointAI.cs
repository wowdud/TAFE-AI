using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{

    public float speed = 10f;
    public GameObject waypoint;
    public GameObject waypoint2;
    public GameObject waypoint3;
    public GameObject waypoint4;
    public GameObject CurrentGoal;
    public int listPos = 0;
    public GameObject target;

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

        if (target == null)
        {
            Wander();
        }
        else
        {
            Chase(target, speed);
        }

    }

    void NextGoal()
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

    void Chase(GameObject goal, float currentSpeed)
    {
        Vector2 direction = goal.transform.position - transform.position;
        direction.Normalize();

        Vector2 aiPosition = transform.position;
        aiPosition.x += direction.x * currentSpeed * Time.deltaTime;
        aiPosition.y += direction.y * currentSpeed * Time.deltaTime;
        transform.position = aiPosition;
    }

    void Wander()
    {
        float distance = Vector2.Distance(transform.position, CurrentGoal.transform.position);

        if (distance >= 0.01f)
        {
            Chase(CurrentGoal, speed);
        }
        else
        {
            NextGoal();
        }

    }
}
