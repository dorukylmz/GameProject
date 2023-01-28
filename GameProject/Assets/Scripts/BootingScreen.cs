using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BootingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float startTime = Time.realtimeSinceStartup;
        Debug.Log("Game started at " + startTime + " seconds.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
