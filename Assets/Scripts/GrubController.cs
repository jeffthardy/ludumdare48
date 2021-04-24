using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubController : MonoBehaviour
{
    public float MovementSpeed = 1000;
    public float turnRate = 180.0f;
    public float moveTime = 4.0f;
    public float stopTime = 0.3f;


    private float lastTime;
    private bool isMoving;


    // Start is called before the first frame update
    void Start()
    {

        lastTime = Time.time - moveTime* Random.Range(0.1f, 1.0f);
        isMoving = true;
    }




    // Update is called once per frame
    void FixedUpdate()
    {

        if (isMoving)
        {
            //Vector3 movement = new Vector3(0, 1.0f, 0).normalized ;
            GetComponent<Rigidbody2D>().AddForce(transform.up * MovementSpeed * Random.Range(0.7f, 1.0f) * Time.fixedDeltaTime);

            if (Time.time > lastTime + moveTime)
            {
                isMoving = false;
                lastTime = Time.time;
                Debug.Log("Bug not moving");
            }

        }
        else
        {
            if (Time.time > lastTime + stopTime)
            {
                isMoving = true;
                GetComponent<Rigidbody2D>().rotation += turnRate * Random.Range(0.7f, 1.0f);
                Debug.Log("Bug is rotating and moving");
            }

        }
    }
}
