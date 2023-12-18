using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public or private identify
    //data type ( int, float, bool, string )
    //every variable has a NAME
    //option value assigned
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //current pos = new positon
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertivcalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vertivcalInput * Time.deltaTime);

        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        else if (transform.position.x > 8.4f)
        {
            transform.position = new Vector3(8.4f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.4f)
        {
            transform.position = new Vector3(-8.4f, transform.position.y, 0);
        }

    }
}
