using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject camHolder;
    public GameObject camPivot;


    [Header("Bools")]
    public bool orbitCam;

    [Header("Floats")]
    public float angle;

    void Start()
    {
        orbitCam = false;
    }


    void Update()
    {
        if(orbitCam == false)
        {
            this.transform.position = camHolder.transform.position;
            this.transform.rotation = camHolder.transform.rotation;
        } else if(orbitCam == true)
        {
            Orbit();
        }
    }

    void Orbit()
    {
        this.transform.RotateAround(camPivot.transform.position, Vector3.right, angle);
    }
}
