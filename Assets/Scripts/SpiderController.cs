using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public GameObject body;
    public GameObject legs;

    public float legTwitchRate = 0.25f;
    public float sideMoveRate = 1.0f;
    public float sideMoveSpeed = 1000.0f;
    public float vertMoveSpeed = 500.0f;
    public int sideCountToSwitch = 5;

    private float twitchTimeCnt;
    private float moveTimeCnt;
    private bool right;
    private bool down;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        right = true;
        down = true;
        count = 0;
        twitchTimeCnt = Time.time;
        moveTimeCnt = Time.time + Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //// Leg twitcher
        //if (Time.time > twitchTimeCnt + legTwitchRate)
        //{
        //    twitchTimeCnt = Time.time;
        //    Vector3 rot = legs.transform.eulerAngles;
        //    rot.z = Random.Range(-2.0f, 2.0f);
        //    legs.transform.eulerAngles = rot;
        //    //legs.transform.rotation = new Quaternion(0, 0, Random.Range(-1.0f, 1.0f)/180.0f, 0);
        //}

        if (Time.time > moveTimeCnt + sideMoveRate)
        {
            moveTimeCnt = Time.time;
            right = !right;
            count++;
            if (count == sideCountToSwitch)
            {
                down = !down;
                count = 0;
                Vector3 rot = body.transform.eulerAngles;
                rot.z = rot.z+180;
                body.transform.eulerAngles = rot;
            }
        }
           
        float speed;
        // Body Mover
        if (right)
            speed = sideMoveSpeed;
        else
            speed = -sideMoveSpeed;
        body.GetComponent<Rigidbody2D>().AddForce(transform.right * speed * Time.fixedDeltaTime);

        if (down)
            speed = -vertMoveSpeed;
        else
            speed = vertMoveSpeed;
        body.GetComponent<Rigidbody2D>().AddForce(transform.up * speed * Time.fixedDeltaTime);
    }
}
