using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAttack : MonoBehaviour
{
    public GameObject vines;
    [SerializeField] private string playerFire;
    [SerializeField] private float verticalVelocity;
    [SerializeField] private float horizontalVelocity;
    [SerializeField] private float fireRate = 1f;
    private float lastShot = 0.0f;
    GameObject inst;

    public void Update()
    {

        if (Mathf.Abs(Input.GetAxis(playerFire)) > 0.01f)
        {
            if (Time.time > fireRate + lastShot)
            {
                Vector3 SpawnPoint = transform.position + (transform.forward * 2) + (transform.up * 2);

                inst = Instantiate(vines, SpawnPoint, Quaternion.LookRotation(transform.forward, transform.up));
                Rigidbody rigidBody = inst.GetComponent<Rigidbody>();
                rigidBody.transform.position = SpawnPoint;
                rigidBody.velocity = new Vector3(horizontalVelocity * transform.forward.x, verticalVelocity * (transform.forward.y + 1), horizontalVelocity * transform.forward.z);
                lastShot = Time.time;
            }
        }
    }
}
