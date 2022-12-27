using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //dýþarýdan gelen tanýmlý obje
    [SerializeField] private GameObject newWall;
    [SerializeField] private float maxHeight=1.0f;
    [SerializeField] private float minHeight=0.0f;
    //lenght deðildi neydi la bunun adý format atayým ileride !!!!!!!!!!!!!!!!
    [SerializeField] private float maxLenght=1.0f;
    [SerializeField] private float minLenght = 0.0f;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(Random.Range(minLenght, maxLenght), Random.Range(maxLenght, minLenght));
        //swapnlama Instantiate alýyor. bu yeni obje yarat demek gibi birþey.
        Instantiate(newWall, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
