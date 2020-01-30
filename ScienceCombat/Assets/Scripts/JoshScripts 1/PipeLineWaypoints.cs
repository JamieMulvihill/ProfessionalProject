using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLineWaypoints : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject item;

    [Header("Waypoints")]
    public GameObject[] entranceWPs = new GameObject[3];
    public GameObject[] PL1WPs = new GameObject[29];
    public GameObject[] PL2WPs = new GameObject[24];
    public GameObject[] PL3WPs = new GameObject[27];
    public GameObject PL1endPoint;
    public GameObject PL2endPoint;
    public GameObject PL3endPoint;
    public GameObject conducter;

    [Header("Scripts")]
    private Manager managerScript;


    void Start()
    {
        managerScript = this.gameObject.GetComponent<Manager>();

        managerScript.spawnItem = true;
        managerScript.activateItemParticles = true;
    }

    private void Update()
    {
        if (managerScript.spawnItem == true)
        {
            managerScript.spawnItem = false;
            StartCoroutine(Delay());
        }
    }

    void SpawnItem()
    {
        GameObject newItem = Instantiate(item);
        //print("item spawned");
    }

    IEnumerator Delay()
    {
        SpawnItem();
        yield return new WaitForSeconds(managerScript.itemSpawnDelay);
        managerScript.spawnItem = true;
    }
}
