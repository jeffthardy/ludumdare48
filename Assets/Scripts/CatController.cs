using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float MovementSpeed = 1000;
    public float turnRate = 180.0f;
    public float moveTime = 5.0f;
    public float stopTime = 0.5f;


    private SpriteRenderer sprite;
    private float lastTime;
    private bool isMoving;
    private int dir;


    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        //GetComponent<Rigidbody2D>().rotation += turnRate * (Random.Range(1f, 3.1f) / 3);
        isMoving = true;
        sprite = GetComponent<SpriteRenderer>();
        dir = 1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            //Vector3 movement = new Vector3(0, 1.0f, 0).normalized ;
            GetComponent<Rigidbody2D>().AddForce(transform.right * MovementSpeed * dir * Time.fixedDeltaTime);

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

                //GetComponent<Rigidbody2D>().rotation += turnRate;
                sprite.flipX = !sprite.flipX;
                dir = -dir;
                //Debug.Log("Bug is rotating and moving");
            }

        }

    }
}
