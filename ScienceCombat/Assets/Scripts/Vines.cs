﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour
{
    private bool spawned = false;
    private float previousSpeed;
    private GameObject capturedPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Biologist" && collision.gameObject.tag != "Ground") {
            capturedPlayer = collision.gameObject;
            spawned = true;
            previousSpeed = capturedPlayer.GetComponent<PlayerController>().Speed;
            capturedPlayer.GetComponent<PlayerController>().Speed = 0;
            StartCoroutine(DEATH());
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag != "Biologist" && other.gameObject.tag != "Ground")
    //    {
    //        capturedPlayer = other.gameObject;
    //        spawned = true;
    //        previousSpeed = capturedPlayer.GetComponent<PlayerController>().Speed;
    //        capturedPlayer.GetComponent<PlayerController>().Speed = 0;
    //        StartCoroutine(DEATH());
    //    }
    //}

    IEnumerator DEATH() {
        yield return new WaitForSeconds(5);
        capturedPlayer.GetComponent<PlayerController>().Speed = previousSpeed;
        Destroy(gameObject);

    }


}
