using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateLevelScript : MonoBehaviour
{
    public GameObject level1A1;
    public GameObject level1A2;
    public GameObject level1A3;
    public GameObject level2A1;
    public GameObject level2A2;
    public GameObject level2A3;
    public GameObject level3A1;
    public GameObject level3A2;
    public GameObject level3A3;
    // Start is called before the first frame update
    void Start()
    {
        int level1 = Random.Range(1, 4);
        switch (level1)
        {
            case 1:
                Instantiate(level1A1);
                break;
            case 2: Instantiate(level1A2); break;
            case 3: Instantiate(level1A3); break;
        }
        int level2 = Random.Range(1, 4);
        switch (level2)
        {
            case 1:
                Instantiate(level2A1);
                break;
            case 2: Instantiate(level2A2); break;
            case 3: Instantiate(level2A3); break;
        }
        int level3 = Random.Range(1, 4);
        switch (level3)
        {
            case 1:
                Instantiate(level3A1);
                break;
            case 2: Instantiate(level3A2); break;
            case 3: Instantiate(level3A3); break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
