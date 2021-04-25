using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubGenerator : MonoBehaviour
{
    public int genTotal = 1000;
    public float genDelay = 2.0f;
    public GameObject grub;
    public float gravityValue = -9.81f;

    private int genCount;
    private float genTime;
    private bool gravityOn;
    // Start is called before the first frame update
    void Start()
    {
        genCount = 0;
        genTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time > genTime + genDelay) && (genCount < genTotal))
        {
            genTime = Time.time;
            genCount++;
            Instantiate(grub, transform.position, transform.rotation);
        }
    }


    public void SetGravity(bool enabled, float level)
    {
        gravityOn = enabled;
        gravityValue = level;
    }
}
