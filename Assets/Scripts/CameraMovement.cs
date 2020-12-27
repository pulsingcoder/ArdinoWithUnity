using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CameraMovement : MonoBehaviour
{
    public float speed = 20f;
    float horizontalKey = 0f;
    float verticalKey = 0f;
    public int CMD;
    public SerialPort sp = new SerialPort("COM3", 5000000);
    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (sp.IsOpen)
        {
            try
            {
                ReadCom();
                Rotate_Camera();
            }
            catch (System.Exception)
            {

            }
        }
        else
        {
           Rotate_Camera();
        }

    }
    void Rotate_Camera()
    {
        if (Input.GetKey("up") || CMD == 128)
        {

            verticalKey = -1;
        }
        else if (Input.GetKey("down") || CMD == 24)
        {
            verticalKey = 1;
        }
        else if (Input.GetKey("right") || CMD == 120)
        {
            horizontalKey = 1;
        }
        else if (Input.GetKey("left") || CMD == 96)
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
    void ReadCom()
    {
        CMD = sp.ReadByte();
    }

    public void CloseCom()
    {
        sp.Close();
    }
}
