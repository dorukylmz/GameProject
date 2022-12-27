using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //dýþarýdan gelen tanýmlý obje
    [SerializeField] private GameObject newWall;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    //lenght deðildi neydi la bunun adý format atayým ileride !!!!!!!!!!!!!!!!
    [SerializeField] private float maxLenght;
    [SerializeField] private float minLenght;
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
