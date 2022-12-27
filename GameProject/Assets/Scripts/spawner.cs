using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //d��ar�dan gelen tan�ml� obje
    [SerializeField] private GameObject newWall;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    //lenght de�ildi neydi la bunun ad� format atay�m ileride !!!!!!!!!!!!!!!!
    [SerializeField] private float maxLenght;
    [SerializeField] private float minLenght;
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
