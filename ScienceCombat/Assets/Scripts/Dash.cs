using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour{

    [SerializeField] private string playerAlt;
    private RaycastHit[] hit;

    // Update is called once per frame
    void Update(){

        if (Input.GetButtonDown(playerAlt)) {
            hit = Physics.RaycastAll(transform.position, transform.forward, 10);
            Debug.DrawRay(transform.position, transform.forward * 10, Color.green, .1f);

            if (hit.Length > 0){

                foreach (RaycastHit hit in hit) {

                    if (hit.collider != null){

                        transform.position = hit.collider.gameObject.transform.position - transform.forward * 2;
                    }
                }
            }
            else
            {
                transform.position += transform.forward * 10;
            }
        }
    }
}
