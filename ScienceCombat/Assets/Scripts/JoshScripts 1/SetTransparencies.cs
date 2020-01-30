using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransparencies : MonoBehaviour
{
    [Header("Renderer")]
    private Renderer rend;

    [Header("Game Objects")]
    [SerializeField] private GameObject manager;

    [Header("Scripts")]
    private Manager managerScript;

    //[SerializeField] private GameObject entrancepipe;
    //[SerializeField] private GameObject floor;
    //[SerializeField] private GameObject pipeline1;
    //[SerializeField] private GameObject pipeline2;
    //[SerializeField] private GameObject pipeline3;

    [Header("Materials")]
    [SerializeField] private Material entrancepipeMat;
    [SerializeField] private Material floorMat;
    [SerializeField] private Material pipeline1Mat;
    [SerializeField] private Material pipeline2Mat;
    [SerializeField] private Material pipeline3Mat;

    void Start()
    {
        managerScript = manager.GetComponent<Manager>();

        //entrancepipeMat = entrancepipe.GetComponent<Material>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //need to work on this

        Color epAlphaColour = entrancepipeMat.color;
        epAlphaColour.a = managerScript.entrancePipe;
        entrancepipeMat.color = epAlphaColour;

        Color floorAlphaColour = floorMat.color;
        floorAlphaColour.a = managerScript.floor;
        floorMat.color = floorAlphaColour;

        Color pl1AlphaColour = pipeline1Mat.color;
        pl1AlphaColour.a = managerScript.pipeline1;
        pipeline1Mat.color = pl1AlphaColour;

        Color pl2AlphaColour = pipeline2Mat.color;
        pl2AlphaColour.a = managerScript.pipeline2;
        pipeline2Mat.color = pl2AlphaColour;

        Color pl3AlphaColour = pipeline3Mat.color;
        pl3AlphaColour.a = managerScript.pipeline3;
        pipeline3Mat.color = pl3AlphaColour;
    }
}
