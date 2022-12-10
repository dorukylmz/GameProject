using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;
    //Ridgidbody karakterin unity nin fizikleri ile etkileþen kýsmý
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        print(rigidbody2D);
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * jumpPower;
        }      

    }
}
