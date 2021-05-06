using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PathfindingDemoCameraManager : MonoBehaviour
{
    public static Camera pathfindingCamera;

    public float rotationSpeed = 50f;
    public float distanceToObject = 3f;
    public float zoomVelocity = 1f;

    private Camera myCamera;

    private Vector3 center;

    private bool centerLoaded = false;

    private void Awake()
    {
        myCamera = GetComponent<Camera>();
        pathfindingCamera = myCamera;
        StartCoroutine(WaitUntilModel());
    }

    IEnumerator WaitUntilModel()
    {
        yield return new WaitUntil(()=>OBJManager.file!=null);
        center = OBJManager.modelCenter;
        centerLoaded = true;
        transform.position = center + new Vector3(0, 0, -distanceToObject);
    }

    private void Update()
    {
        if (!centerLoaded) return;
        

        float yRot = Input.GetAxis("Horizontal");
        float xRot = Input.GetAxis("Vertical");
        float zoom = Input.GetAxis("Mouse ScrollWheel");


        float step = rotationSpeed * Time.deltaTime;
        float fOrbitCircumfrance = 2F * Mathf.PI;
        float fDistanceDegrees = (rotationSpeed / fOrbitCircumfrance) * 360;
        float fDistanceRadians = (rotationSpeed / fOrbitCircumfrance) * 2 * Mathf.PI;

        transform.RotateAround(center, transform.up, yRot* fDistanceRadians);
        transform.RotateAround(center, transform.right, xRot* fDistanceRadians);
        transform.Translate(transform.forward * 100 * zoomVelocity * Time.deltaTime * zoom, Space.World);
    }

}
