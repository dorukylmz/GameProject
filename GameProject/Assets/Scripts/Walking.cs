using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;


public class Walking : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    [SerializeField]private float jumpPower = 5f;
    //Ridgidbody karakterin unity nin fizikleri ile etkile�en k�sm�
    private Rigidbody2D rigidbody2D;
    //Serialieze field d��ar�dan veriye eri�mek istiyor fakat hala bunu g�venlik i�in private tutmak istiyorsan kullanabilece�in bir alan
    //box coliderlara layer veriyorum ��nk� box colider lar birbiri ile �ak��mas�n.
    //ayn� zamanda ileride ba�ka bir colider ile �ak��t�rmak istersek de�i�tirebiliriz. 
    [SerializeField] private LayerMask layerMask;
    private BoxCollider2D boxCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D=transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
       

    }
    private bool IsGrounded()
    {
        //s�n�rs�z u�mas�n� istemedi�im i�in yere de�ip de�medi�ini anlamak i�in b�yle bir fonksiyon yazd�m Fakat kullan�c�n�n merezi 
        //d��ar�da kalabilir emin de�ilim
        //alttaki k�s�mda box colider kullan�c�n�n objesidir kar��t�r�lmas�n. Merkezi size � ve dokundu�u yeri anlamas� i�in vector2.down u kulland�m
        //Walljump yapmak i�in sa�daki soldaki coliderlar� da ald�m. 
        RaycastHit2D raycastHit2 = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down , 0.1f, layerMask);
        if (raycastHit2.collider == null)
        {
            raycastHit2 = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.right, .1f, layerMask);
            if (raycastHit2.collider == null)
            {
                raycastHit2 = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.left, .1f, layerMask);
                return raycastHit2.collider != null;    

            }
            return raycastHit2.collider!=null; 
            
        }
        
        return raycastHit2.collider!=null;
        
    }

    private void playerMovement()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2D.velocity = new Vector2(+speed, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * jumpPower;
        }
        
        }
        
        }
    
        

