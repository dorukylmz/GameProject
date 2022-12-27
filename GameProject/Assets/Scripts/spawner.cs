using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //d��ar�dan gelen tan�ml� obje
    [SerializeField] private GameObject newWall;
    [SerializeField] private float maxHeight=1.0f;
    [SerializeField] private float minHeight=0.0f;
    //lenght de�ildi neydi la bunun ad� format atay�m ileride !!!!!!!!!!!!!!!!
    [SerializeField] private float maxLenght=1.0f;
    [SerializeField] private float minLenght = 0.0f;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(Random.Range(minLenght, maxLenght), Random.Range(maxLenght, minLenght));
        //swapnlama Instantiate al�yor. bu yeni obje yarat demek gibi bir�ey.
        Instantiate(newWall, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
