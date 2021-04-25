using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    public float blinkRate = 0.5f;


    private float blinkTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

        blinkTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > blinkTime + blinkRate)
        {
            blinkTime = Time.time;
            GetComponent<Text>().enabled = !GetComponent<Text>().enabled;
        }
    }
}
