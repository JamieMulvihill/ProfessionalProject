using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAttack : MonoBehaviour{
    public GameObject virus;
    [SerializeField] private string playerFire;
    [SerializeField] private float verticalVelocity;
    [SerializeField] private float horizontalVelocity;
    [SerializeField] private float fireRate = 1f;
    private float lastShot = 0.0f;
    GameObject inst;

    public void Update() {

        if (Mathf.Abs(Input.GetAxis(playerFire)) > 0.01f){
            if (Time.time > fireRate + lastShot) {
                Vector3 SpawnPoint = transform.position + (transform.forward * 2) + (transform.up * 2);

                inst = Instantiate(virus, SpawnPoint, Quaternion.LookRotation(transform.forward, transform.up));
                Rigidbody rigidBody = inst.GetComponent<Rigidbody>();
                rigidBody.transform.position = SpawnPoint;
                // rigidBody.velocity = new Vector3(horizontalVelocity * transform.forward.x, verticalVelocity * (transform.forward.y + 1), horizontalVelocity * transform.forward.z);
                rigidBody.AddRelativeForce(new Vector3(horizontalVelocity * transform.forward.x, verticalVelocity * (transform.forward.y + 1), horizontalVelocity * transform.forward.z), ForceMode.Impulse);
                lastShot = Time.time;
            }
        }
    }
    //private void OnCollisionEnter(Collision collision) {
    //   // Rigidbody rigidBody = inst.GetComponent<Rigidbody>();
    //   // rigidBody.velocity = new Vector3(0, 0, 0);
    //}
}
