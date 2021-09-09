using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviours : MonoBehaviour
{
    public Vector3 randPos;
    public Vector2 screen;

    public enum State
    {
        Wander,
        Stop,
        Chase,
    }

    public State state;
    public SpriteRenderer sprite;
    private WaypointAI waypointAI;
    public GameObject player;

    // Start is called before the first frame update

    private IEnumerator WanderState()
    {
        print("Entered wander state");
        waypointAI.isAIon = true;
        sprite.color = Color.green;

        while (state == State.Wander)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < 5.5f && player.activeSelf == true)
            {
                state = State.Chase;
            }
            print("Still wandering");
            yield return null;
        }
        print("Leaving wander state");
        NextState();

    }
    private IEnumerator StopState()
    {
        print("Stopped state");
        waypointAI.isAIon = false;
        sprite.color = Color.red;

        while (state == State.Stop)
        {
            yield return new WaitForSeconds(1.5f);
            waypointAI.CurrentGoal = waypointAI.pointList[Random.Range(0, 6)];
            state = State.Wander;
        }
        waypointAI.isAIon = true;
        print("Exiting stop state");
        NextState();

    }

    private IEnumerator ChaseState()
    {
        print("Chase state");

        sprite.color = new Color(0.75f, 0, 1, 1);

        while (state == State.Chase)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < waypointAI.speed * Time.deltaTime)
            {
                player.SetActive(false);
                state = State.Wander;
            }
            if (distance > 5.5f)
            {
                state = State.Stop;
            }
            waypointAI.target = player;
            waypointAI.isAIon = true;
            yield return null;
        }
        waypointAI.target = null;
        print("Exiting chase state");
        NextState();
    }


    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        if (sprite == null)
        {
            Debug.LogError("no sprite mate");
        }

        waypointAI = GetComponent<WaypointAI>();
        if (waypointAI == null)
        {
            Debug.LogError("no ai mate");
        }

        PlayerScript playerFound = FindObjectOfType<PlayerScript>();
        if (playerFound != null)
        {
            player = playerFound.gameObject;
        }

        NextState();

    }

    private void NextState()
    {
        switch (state)
        {
            case State.Wander:
                StartCoroutine(WanderState());
                break;

            case State.Stop:
                StartCoroutine(StopState());
                break;

            case State.Chase:
                StartCoroutine(ChaseState());
                break;

            default:
                StartCoroutine(StopState());
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
