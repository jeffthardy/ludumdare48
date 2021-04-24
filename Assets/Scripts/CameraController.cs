using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float zoomLevel = 10;

    public float cameraDistance = 2.0f;
    public float mouseWheelMult = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        GetComponent<Camera>().orthographicSize = zoomLevel;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 adjustment;

        GetComponent<Camera>().orthographicSize = zoomLevel;
        float step = Vector3.Distance(new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), transform.position) - cameraDistance;

        if (step > 0)
        {
            adjustment = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), step);
            transform.position = new Vector3(adjustment.x, adjustment.y, -10);
        }



        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollWheelChange != 0)
        {
            //Debug.Log("Wheel changed by " + ScrollWheelChange);
            ChangeZoom(zoomLevel - ScrollWheelChange* mouseWheelMult);

        }


    }

    void ChangeZoom(float newZoom)
    {
        // Allow zoom within a set range
        if (newZoom > 70)
            newZoom = 70;
        if (newZoom < 5)
            newZoom = 5;
        zoomLevel = newZoom;
        GetComponent<Camera>().orthographicSize = zoomLevel;


    }
}
