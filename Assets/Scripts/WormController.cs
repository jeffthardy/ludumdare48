using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{

    public float MovementSpeed = 2000;
    public int WormSegments = 3;
    public GameObject WormPartObject;
    public GameObject WormMask;
    public GameObject WormMaskHolder;
    public float maxSegDistance = 1.0f;
    public float shiftMultiplier = 2.0f;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    bool shiftOn;
    Vector2 position;

    private int maxWormParts=10;
    private int maxWormMasks = 1000;
    private int wormMaskIndex;


    GameObject[] wormParts;
    GameObject[] wormMasks;

    // Start is called before the first frame update
    void Start()
    {
        wormMaskIndex = 0;
        shiftOn = false;
        wormParts = new GameObject[maxWormParts];
        wormMasks = new GameObject[maxWormMasks];
        rigidbody2d = GetComponent<Rigidbody2D>();
        position = transform.position;

        for (int i = 0; i < maxWormParts; i++)
        {
            wormParts[i] = Instantiate(WormPartObject, transform.position, transform.rotation);
            wormParts[i].transform.position = position;
            if (i > 0)
            {
                Destroy(wormParts[i].GetComponent<Rigidbody2D>());
                wormParts[i].GetComponent<CircleCollider2D>().enabled = false;
                wormParts[i].GetComponent<SpriteRenderer>().color = new Color(wormParts[i].GetComponent<SpriteRenderer>().color.r, Random.Range(0, 1.0f), wormParts[i].GetComponent<SpriteRenderer>().color.b);
            }
            else
            {
                // make the head a bit darker
                wormParts[i].GetComponent<SpriteRenderer>().color = new Color(wormParts[i].GetComponent<SpriteRenderer>().color.r * 0.5f, wormParts[i].GetComponent<SpriteRenderer>().color.g * 0.5f, wormParts[i].GetComponent<SpriteRenderer>().color.b* 0.5f);
            }
        }

        for (int i = WormSegments; i < maxWormParts; i++)
        {
            wormParts[i].GetComponent<SpriteRenderer>().enabled = false;
        }

        // Allocate all the hole masks ahead of time and just update locations
        for (int i = 0; i < maxWormMasks; i++)
        {
            wormMasks[i] = Instantiate(WormMask, transform.position, transform.rotation);
            wormMasks[i].transform.parent = WormMaskHolder.transform;
        }
        wormMaskIndex = 0;


    }

    void FixedUpdate()
    {

        float step;

        Vector3 movement = new Vector3(horizontal, vertical, 0).normalized;
        //position.Translate(movement * MovementSpeed * Time.deltaTime);

        //transform.position += movement * MovementSpeed * Time.deltaTime;
        //rigidbody2d.AddForce(movement * MovementSpeed * Time.fixedDeltaTime);
        //wormParts[0].transform.position = position;
        if (shiftOn)
            movement = movement * shiftMultiplier;
        wormParts[0].GetComponent<Rigidbody2D>().AddForce(movement * MovementSpeed * Time.fixedDeltaTime);
        transform.position = wormParts[0].transform.position;
        for (int i = 1; i < maxWormParts; i++)
        {
            step = Vector3.Distance(wormParts[i - 1].transform.position, wormParts[i].transform.position) - maxSegDistance;

            if (step > 0)
            {
                wormParts[i].transform.position = Vector3.MoveTowards(wormParts[i].transform.position, wormParts[i - 1].transform.position, step);
            }
        }


        step = Vector3.Distance(wormParts[0].transform.position, wormMasks[wormMaskIndex].transform.position) - (maxSegDistance);
        // Add Mask
        if (step > 0)
        {
            wormMaskIndex++;
            if (wormMaskIndex >= maxWormMasks)
                wormMaskIndex = 0;
            wormMasks[wormMaskIndex].transform.position = wormParts[0].transform.position;
        }
    }


        // Update is called once per frame
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
            vertical = Input.GetAxis("Vertical") * MovementSpeed;

            if (Input.GetButton("Shift") && !shiftOn)
            {
            shiftOn = true;
            }
            else
            {
            shiftOn = false;
            }


            if (Input.GetButton("Quit"))
            {
                Debug.Log("You have clicked the quit button!");
    #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBGL	
            //Application.OpenURL(webplayerQuitURL);
    #else
            Application.Quit();
    #endif
            }
        }

    
}
