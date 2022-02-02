using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector2 camSize;
    public List<Camera> cameras;
    private Camera currentCam;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        currentCam = cameras[0];
        SetCameraSize();
        EShake(0.05f);
    }

    void SetCameraSize()
    {
        // bounds for 1920 x 1080 (19.2, 10.8)
        float orthoSize = 10.8f / 2;
        cameras[0].orthographicSize = orthoSize;
    }

    void EShake(float magnitude)
    {
        Vector3 camPos = new Vector3();
        if(currentCam.transform.position.x > 0) { camPos.x = magnitude * -1; }
        else { camPos.x = magnitude; }
        currentCam.transform.position = new Vector3(camPos.x, 
            currentCam.transform.position.y,
            currentCam.transform.position.z);
    }
}