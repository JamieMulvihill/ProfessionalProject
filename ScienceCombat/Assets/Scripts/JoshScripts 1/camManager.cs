using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject topCamera;
    [SerializeField] private GameObject orbitCamera;

    [Header("Scripts")]
    private Manager managerScript;


    void Start()
    {
        managerScript = this.gameObject.GetComponent<Manager>();
    }

    void Update()
    {
        if(managerScript.orbitCam == false)
        {
            if(orbitCamera == true)
            {
                orbitCamera.SetActive(false);
                topCamera.SetActive(true);
            }
        } else if(managerScript.orbitCam == true)
        {
            if(topCamera == true)
            {
                orbitCamera.SetActive(true);
                topCamera.SetActive(false);
            }
        }
    }
}