using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidAttack : MonoBehaviour
{
    public GameObject acid;
    [SerializeField] private string playerFire;
    [SerializeField] private float verticalVelocity;
    [SerializeField] private float horizontalVelocity;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float momentum;
    private float lastShot = 0.0f;
    GameObject inst;

    public void Update()
    {

        if (Mathf.Abs(Input.GetAxis(playerFire)) > 0.01f)
        {
            if (Time.time > fireRate + lastShot)
            {
                Vector3 SpawnPoint = transform.position + (transform.forward) + (transform.up);

                inst = Instantiate(acid, SpawnPoint, Quaternion.LookRotation(transform.forward, transform.up));
                Rigidbody rigidBody = inst.GetComponent<Rigidbody>();
                rigidBody.transform.position = SpawnPoint;

                rigidBody.velocity = new Vector3(horizontalVelocity * map(gameObject.GetComponent<Rigidbody>().velocity.magnitude, 0, 10, 1, momentum) * transform.forward.x, verticalVelocity, horizontalVelocity * map(gameObject.GetComponent<Rigidbody>().velocity.magnitude, 0, 10, 1, momentum) * transform.forward.z);

                lastShot = Time.time;
            }
        }
    }

    float map(float value, float istart, float istop, float ostart, float ostop)
    {
        return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
    }


    //private void OnCollisionEnter(Collision collision) {
    //   // Rigidbody rigidBody = inst.GetComponent<Rigidbody>();
    //   // rigidBody.velocity = new Vector3(0, 0, 0);
    //}
}