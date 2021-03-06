using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    private float xMin = -2, xMax = 98, yMin = 6f;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;
    private Vector3 smoothPos;
    private Transform camTransform;
    public float smoothSpeed = 0.5f;

    private void Start()
    {
        camTransform = transform;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = camOrthsize / 2.0f;
    }
    void FixedUpdate()
    {
        camY = (int)(Mathf.Max(followTransform.position.y + 2f - yMin/2f, 0) / yMin) * yMin + 2f;
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        //smoothPos = Vector3.Lerp(camTransform.position, new Vector3(camX, camY, camTransform.position.z), smoothSpeed);
        //camTransform.position = smoothPos;
        camTransform.position = Vector3.right * camX + Vector3.up * camY + camTransform.position.z * Vector3.forward;
    }
}
