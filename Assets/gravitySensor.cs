using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitySensor : MonoBehaviour
{

    public GameObject WormController;
    public float gravityLevel = -9.81f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("Enabled Gravity?");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("Enabled Gravity");
            if (WormController.GetComponent<WormController>() != null)
                WormController.GetComponent<WormController>().SetGravity(true, gravityLevel);

            if (WormController.GetComponent<GrubGenerator>() != null)
                WormController.GetComponent<GrubGenerator>().SetGravity(true, gravityLevel);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Disabled Gravity?");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("Disabled Gravity");
            if(WormController.GetComponent<WormController>() != null)
                WormController.GetComponent<WormController>().SetGravity(false, gravityLevel);

            if (WormController.GetComponent<GrubGenerator>() != null)
                WormController.GetComponent<GrubGenerator>().SetGravity(false, gravityLevel);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Enabled Gravity?");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("Enabled Gravity");
            if (WormController.GetComponent<WormController>() != null)
                WormController.GetComponent<WormController>().SetGravity(true, gravityLevel);

            if (WormController.GetComponent<GrubGenerator>() != null)
                WormController.GetComponent<GrubGenerator>().SetGravity(true, gravityLevel);
        }

    }

}
