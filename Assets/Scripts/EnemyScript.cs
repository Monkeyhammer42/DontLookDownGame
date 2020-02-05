using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
