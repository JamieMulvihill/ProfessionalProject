using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCam : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject camPivot;
    [SerializeField] private GameObject target;

    [Header("Floats")]
    [SerializeField] private float time;

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
