using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeItems : MonoBehaviour
{
    [Header("WayPoints")]
    private GameObject goFrom;
    private GameObject goTo;

    private GameObject manager;

    [Header("Transform")]
    private Transform T;
    private Transform goFromT;
    private Transform goToT;

    [Header("Ints")]
    private int counter;
    private int time;

    [Header("Scripts")]
    private PipeLineWaypoints plw;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        plw = manager.GetComponent<PipeLineWaypoints>();

        T = this.transform;
        T.position = plw.waypoints[0].transform.position;
        goToT = plw.waypoints[1].transform;

        counter = 1;
        time = 5;
    }

    void Update()
    {
        //T.position = Vector3.Lerp(T.position, goToT.position, time * Time.deltaTime);
        T.position = Vector3.MoveTowards(T.position, goToT.position, time * Time.deltaTime);

        if (T.position == goToT.position && counter != 32)
        {
            goToT = plw.waypoints[counter].transform;
            counter++;
        }else if(T.position == goToT.position && counter == 32)
        {
            time = 1;
            goToT = plw.endPoint.transform;
        }

        if(T.position == goToT.position && goToT == plw.endPoint.transform)
        {
            StartCoroutine(DestroyItem());
        }



            //if (goFromT.transform.position == goToT.transform.position)
            //{ 
            //    if (goToT.transform != plw.waypoints[4].transform)
            //    {
            //        goFromT = plw.waypoints[counter].transform;
            //        counter++;
            //        goToT = plw.waypoints[counter].transform;

            //    }
            //}
    }

    //void SetChannel()
    //{

    //}

    IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
