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
    private int entranceCounter;
    private int PLCounter;
    private int time;
    private int chosenPipeLine;

    [Header("Scripts")]
    private PipeLineWaypoints plw;
    private ParticleSystem particles;
    private Manager managerScript;

    [Header("Colours")]
    private Color lightBlue;
    private Color pink;
    private Color orange;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        managerScript = manager.GetComponent<Manager>();
        plw = manager.GetComponent<PipeLineWaypoints>();
        particles = this.gameObject.GetComponentInChildren<ParticleSystem>();

        T = this.transform;
        T.position = plw.entranceWPs[0].transform.position;
        goToT = plw.entranceWPs[1].transform;

        lightBlue = new Color(0,171,197);
        pink = new Color(253, 71, 255);
        orange = new Color(255, 154, 0);

        entranceCounter = 1;
        PLCounter = 0;
        time = 5;
        chosenPipeLine = 0;
    }

    void ChoosePipeLine()
    {
        chosenPipeLine = Random.Range(1, 4);

        if (managerScript.activateItemParticles == true)
        {
            switch (chosenPipeLine)
            {
                case 1:
                    particles.startColor = lightBlue;
                    break;
                case 2:
                    particles.startColor = pink;
                    break;
                case 3:
                    particles.startColor = orange;
                    break;
            }
        }
    }

    void Update()
    {
        T.position = Vector3.MoveTowards(T.position, goToT.position, time * Time.deltaTime);

        if (chosenPipeLine == 0 && T.position == goToT.position)
        {
            if (goToT == plw.conducter.transform)
            {
                ChoosePipeLine();
            }
            else
            {
                entranceCounter++;
            }

            if (goToT == plw.entranceWPs[2].transform)
            {
                goToT = plw.conducter.transform;
            }
            else if(goToT != plw.entranceWPs[2].transform && goToT != plw.conducter.transform)
            {
                goToT = plw.entranceWPs[entranceCounter].transform;
            }
        }
        else
        {
            CheckPathing();
        }
    }

    void CheckPathing()
    {
        switch (chosenPipeLine)
        {
            case 1:
                //PipeLine 1
                if (T.position == goToT.position && PLCounter != 29)
                {
                    goToT = plw.PL1WPs[PLCounter].transform;
                    PLCounter++;
                }
                else if (T.position == goToT.position && PLCounter == 29)
                {
                    time = 1;
                    goToT = plw.PL1endPoint.transform;
                }

                if (T.position == goToT.position && goToT == plw.PL1endPoint.transform)
                {
                    StartCoroutine(DestroyItem());
                }

                break;

            case 2:
                //PipeLine 2
                if (T.position == goToT.position && PLCounter != 24)
                {
                    goToT = plw.PL2WPs[PLCounter].transform;
                    PLCounter++;
                }
                else if (T.position == goToT.position && PLCounter == 24)
                {
                    time = 1;
                    goToT = plw.PL2endPoint.transform;
                }

                if (T.position == goToT.position && goToT == plw.PL2endPoint.transform)
                {
                    StartCoroutine(DestroyItem());
                }

                break;

            case 3:
                //PipeLine 3
                if (T.position == goToT.position && PLCounter != 27)
                {
                    goToT = plw.PL3WPs[PLCounter].transform;
                    PLCounter++;
                }
                else if (T.position == goToT.position && PLCounter == 27)
                {
                    time = 1;
                    goToT = plw.PL3endPoint.transform;
                }

                if (T.position == goToT.position && goToT == plw.PL3endPoint.transform)
                {
                    StartCoroutine(DestroyItem());
                }

                break;
        }
    }

    IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
