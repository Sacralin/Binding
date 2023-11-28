using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject isometricCamera;
    public GameObject topDownCamera;
    int camera = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        isometricCamera.SetActive(false);
        topDownCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            camera++;
            if (camera == 4) { camera = 0; }
        }

        
        switch (camera)
        {
            //case 0: 
            //    firstPersonCamera.enabled = true;  
            //    break;
            //case 1: thirdPersonCamera; break;
            //case 2: isometricCamera; break;
            //case 3: topDownCamera; break;
        }
    
    }
}
