using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [Header("Scripts")]
    private camManager camScript;
    private PipeLineWaypoints pipelineScript;

    [Header("Bools")]
    public bool orbitCam;
    public bool spawnItem;
    public bool activateItemParticles;

    [Header("Transparencies")]
    [Range(0, 1)]
    public float entrancePipe;
    [Range(0, 1)]
    public float floor;
    [Range(0, 1)]
    public float pipeline1;
    [Range(0, 1)]
    public float pipeline2;
    [Range(0, 1)]
    public float pipeline3;

    [Header("Floats")]
    public float itemSpawnDelay;

    private void Start()
    {
        orbitCam = false;
    }
}
