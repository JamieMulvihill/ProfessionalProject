using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLineWaypoints : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject item;

    [Header("Bools")]
    public bool spawnItem;


    [Header("Waypoints")]
    public GameObject[] waypoints = new GameObject[32];
    public GameObject endPoint;
    void Start()
    {
        spawnItem = true;
    }

    private void Update()
    {
        if (spawnItem == true)
        {
            spawnItem = false;
            StartCoroutine(Delay());
        }
    }

    void SpawnItem()
    {
        GameObject newItem = Instantiate(item);
        print("item spawned");
    }

    IEnumerator Delay()
    {
        SpawnItem();
        yield return new WaitForSeconds(10f);
        spawnItem = true;
    }
}
