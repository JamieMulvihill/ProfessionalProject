using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Virus : MonoBehaviour
{
    private Collider[] hitObjecets;
    [SerializeField] private float damage;
    [SerializeField] private float damageRadius;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void AreaOfEffect(GameObject hitPlayer) {
        //Apply poisin to the health of hitPlayer;
        Health playerHealth = hitPlayer.GetComponent<Health>();
        if (playerHealth != null) {
            playerHealth.isPoisioned = true;
            playerHealth.PoisionDamage();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        rigidbody.velocity = Vector3.zero;
        hitObjecets = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (Collider hit in hitObjecets) {

            if (hit.tag != "Biologist") {
               AreaOfEffect(hit.gameObject);
               Destroy(gameObject);
            }
        }
        Destroy(gameObject, 0.2f);
    }

}
