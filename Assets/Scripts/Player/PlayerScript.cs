using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            position.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += 1;
        }
        transform.position += position.normalized * speed * Time.deltaTime;
    }
}
