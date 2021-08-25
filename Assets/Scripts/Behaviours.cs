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
    }

    public State state;
    public SpriteRenderer sprite;
    private WaypointAI waypointAI;

    // Start is called before the first frame update
    
    private IEnumerator WanderState()
    {
        print("Entered wander state");

        sprite.color = Color.green;

        while (state == State.Wander)
        {
            waypointAI.isAIon = true;
            print("Still wandering");
            yield return null;
        }

        print("Leaving wander state");
        NextState();

    }
    private IEnumerator StopState()
    {
        print("Stopped state");

        sprite.color = Color.red;

        while (state == State.Stop)
        {
           waypointAI.isAIon = false;
           yield return null;
        }

        print("Exiting stop state");
        NextState();
       
    }
    
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        if (sprite == null)
        {
            Debug.LogError("no sprite mate");
        }

        screen.x = Screen.width / 16;
        screen.y = Screen.height / 9;

        randPos = new Vector3(Random.Range(-screen.x, screen.x), Random.Range(-screen.y, screen.y), 0);

        waypointAI = GetComponent<WaypointAI>();
        if (waypointAI == null)
        {
            Debug.LogError("no ai mate");
        }
        NextState();

    }

    private void NextState()
    {
        switch(state)
        {
            case State.Wander:
                StartCoroutine(WanderState());
                break;

            case State.Stop:
                StartCoroutine(StopState());
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
