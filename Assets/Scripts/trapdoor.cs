using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdoor : MonoBehaviour

{
    private Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            //add wait function
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


        }
    }
  
}
