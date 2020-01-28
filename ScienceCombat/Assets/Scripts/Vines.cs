using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour
{
    private float lifeTime = 0f;
    private bool spawned = false;
    private float previousSpeed;
    private GameObject capturedPlayer;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "Biologist" && collision.gameObject.tag != "Ground")
        {
            capturedPlayer = collision.gameObject;
            spawned = true;
            previousSpeed = capturedPlayer.GetComponent<PlayerController>().Speed;
            capturedPlayer.GetComponent<PlayerController>().Speed = 0;
           
        }
    }
    private void Update(){
        if (spawned)
        {
            lifeTime += Time.deltaTime;
        }
        Death();
    }

    private void Death() {
        if (lifeTime > 10f) {
            capturedPlayer.GetComponent<PlayerController>().Speed = previousSpeed;
            Destroy(gameObject);
        }
    }
}
