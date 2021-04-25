using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{

    public float MovementSpeed = 1000;
    public float turnRate = 45.0f;
    public float moveTime= 2.0f;
    public float stopTime = 1.0f;


    private float lastTime;
    private bool isMoving;
    

    // Start is called before the first frame update
    void Start()
    {

        lastTime = Time.time + moveTime*Random.Range(0.25f,1.0f);
        GetComponent<Rigidbody2D>().rotation += turnRate * (Random.Range(1f, 3.1f) / 3);
        isMoving = false;
    }




    // Update is called once per frame
    void FixedUpdate()
    {

        if (isMoving)
        {
            //Vector3 movement = new Vector3(0, 1.0f, 0).normalized ;
            GetComponent<Rigidbody2D>().AddForce(transform.up * MovementSpeed * Time.fixedDeltaTime);

            if (Time.time > lastTime + moveTime)
            {
                isMoving = false;
                lastTime = Time.time;
                //Debug.Log("Bug not moving");
            }

        }
        else
        {
            if (Time.time > lastTime + stopTime)
            {
                isMoving = true;
                GetComponent<Rigidbody2D>().rotation += turnRate;
                //Debug.Log("Bug is rotating and moving");
            }

        }
    }
}
