using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject topCamera;
    public GameObject orbitCamera;

    [Header("Bools")]
    public bool orbitCam;

    void Start()
    {
        orbitCam = false;
    }

    void Update()
    {
        if(orbitCam == false)
        {
            if(orbitCamera == true)
            {
                orbitCamera.SetActive(false);
                topCamera.SetActive(true);
            }
        } else if(orbitCam == true)
        {
            if(topCamera == true)
            {
                orbitCamera.SetActive(true);
                topCamera.SetActive(false);
            }
        }
    }
}