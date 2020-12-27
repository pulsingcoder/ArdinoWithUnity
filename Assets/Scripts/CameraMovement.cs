using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 20f;
    float horizontalKey = 0f;
    float verticalKey = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {

            verticalKey = -1;
        }
        else if (Input.GetKey("down"))
        {
            verticalKey = 1;
        }
        else if (Input.GetKey("right"))
        {
            horizontalKey = 1;
        }
        else if (Input.GetKey("left"))
        {
            horizontalKey = -1;
        }
        else
        {
            horizontalKey = 0;
            verticalKey = 0;

        }
        
        Vector3 v3 = new Vector3(verticalKey, horizontalKey, 0.0f);
        transform.Rotate(v3 * speed * Time.deltaTime);
    }
}
