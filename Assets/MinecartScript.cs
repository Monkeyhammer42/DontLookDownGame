using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartScript : MonoBehaviour
{
    private AudioSource audio;
    private ParticleSystem sparks;
    private Rigidbody2D myBody;
    private Animator anim;

    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;


    public LayerMask playerLayer;
    private bool attacked;
    private bool canMove;
    private float speed = 20f;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        sparks = GetComponent<ParticleSystem>();
    }
    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;

        movePosition = transform.position;
        movePosition.x -= 6f;

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheBird();
        DropTheEgg();
    }

    void MoveTheBird()
    {

        if (canMove)
        {
            transform.Translate(moveDirection * speed * Time.smoothDeltaTime);
            if (transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;
                
            }
            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
               

            }
        }


    }

  


    void DropTheEgg()
    {
        if (!attacked)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer))
            {
                attacked = true;
                anim.Play("");
            }
        }

    }

    

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            print("hello");
             target.gameObject.GetComponent<PlayerDamage>().DealDamage();
            audio.Play();
            sparks.Stop();
            myBody.bodyType = RigidbodyType2D.Dynamic;
            canMove = false;
            
        }
    }
}