using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCam : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject camPivot;
    public GameObject target;

    [Header("Floats")]
    [SerializeField] private float time;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(target.transform);
        Orbit();
    }

    void Orbit()
    {
        transform.RotateAround(camPivot.transform.position, Vector3.down, time * Time.deltaTime);
    }   
}
