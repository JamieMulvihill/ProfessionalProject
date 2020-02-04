using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float poisionDmg;
    public bool isPoisioned;
    private bool runningCoroutine = false;

    // Start is called before the first frame update
    void Start()
    {
        isPoisioned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoisionDamage() {

        if (!runningCoroutine && isPoisioned)  {
            runningCoroutine = true;  
            StartCoroutine(UpdatePoison());  
        }

    }

    IEnumerator UpdatePoison() {
        while (isPoisioned && poisionDmg >= 0)    {
            health -= poisionDmg;                  
            poisionDmg -= Time.deltaTime * 1f;    

            yield return new WaitForSeconds(Time.deltaTime); 
        }

        isPoisioned = false;
        runningCoroutine = false;
        yield break;
    }
}
