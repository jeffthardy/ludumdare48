using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWiggler : MonoBehaviour
{
    public float zRotMax = 5.0f;
    public float rate = 1.0f;

    private bool toMax;

    // Start is called before the first frame update
    void Start()
    {
        toMax = true;
        float initial_angle = Random.Range(-zRotMax, zRotMax);
        Vector3 rotationVector = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x, initial_angle);
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    // Update is called once per frame
    void Update()
    {
        if (toMax)
        {
            Vector3 rotationVector = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x, zRotMax);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationVector), Time.time * rate);
            if(transform.rotation == Quaternion.Euler(rotationVector))
            {
                toMax = false;
            }
        }
        else
        {
            Vector3 rotationVector = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x, -zRotMax);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationVector), Time.time * rate);
            if (transform.rotation == Quaternion.Euler(rotationVector))
            {
                toMax = true;
            }
        }        
    }
}
