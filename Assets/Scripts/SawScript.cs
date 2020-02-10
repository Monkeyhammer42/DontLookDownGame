using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private bool hasJumped;
    public float speed = 0.25f;
    private AudioSource SawSounds;
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        hasJumped = false;
        SawSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SawJump();
    }
    void SawJump()
    {
        if (!hasJumped)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, speed);
            Stopjump();
            hasJumped = true;
        }
    }
    IEnumerator Stopjump()
    {
        yield return new WaitForSeconds(0.5f);
        hasJumped=false;
        
    }
    IEnumerator DeleteSaw()
    {
        yield return new WaitForSeconds(0f);
        gameObject.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            print("hello");
            target.gameObject.GetComponent<PlayerDamage>().DealDamage();
            SawSounds.Play();
            DeleteSaw();

                       
        }
    }
}
