using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fire_movement : MonoBehaviour
{
    public float projectilespeed =20;
    private Rigidbody2D rigbdy;
    private float faceing = 1;
       public AudioSource Pop;
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log(GetComponent<Transform.y>);
        rigbdy = GetComponent<Rigidbody2D>();
        rigbdy.velocity = transform.right * projectilespeed * faceing;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision){

           Pop.Play();
    if (collision.gameObject.tag == "Ground")
        {

              Destroy(gameObject);
        }

         if (collision.gameObject.tag == "enemy")
        {
              Destroy(gameObject);
                Destroy(collision.gameObject);
              
        }

    }


  
}


    