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
    //Ridgidbody karakterin unity nin fizikleri ile etkileþen kýsmý
    private Rigidbody2D rigidbody2D;
    //Serialieze field dýþarýdan veriye eriþmek istiyor fakat hala bunu güvenlik için private tutmak istiyorsan kullanabileceðin bir alan
    //box coliderlara layer veriyorum çünkü box colider lar birbiri ile çakýþmasýn.
    //ayný zamanda ileride baþka bir colider ile çakýþtýrmak istersek deðiþtirebiliriz. 
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
        //sýnýrsýz uçmasýný istemediðim için yere deðip deðmediðini anlamak için böyle bir fonksiyon yazdým Fakat kullanýcýnýn merezi 
        //dýþarýda kalabilir emin deðilim
        //alttaki kýsýmda box colider kullanýcýnýn objesidir karýþtýrýlmasýn. Merkezi size ý ve dokunduðu yeri anlamasý için vector2.down u kullandým
        //Walljump yapmak için saðdaki soldaki coliderlarý da aldým. 
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
    
        

