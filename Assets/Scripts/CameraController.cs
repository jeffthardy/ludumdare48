using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float zoomLevel = 10;

    public float cameraDistance = 2.0f;

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

    }

    void ChangeZoom(int newZoom)
    {
        zoomLevel = newZoom;
        GetComponent<Camera>().orthographicSize = zoomLevel;


    }
}
