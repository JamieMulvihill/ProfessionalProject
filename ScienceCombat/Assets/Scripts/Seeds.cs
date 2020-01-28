using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    [SerializeField] private GameObject vines;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameObject inst;
        inst = Instantiate(vines, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
