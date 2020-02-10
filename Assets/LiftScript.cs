using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
   
    private bool isLift=true;
    public int speed=3;
    private Vector2 moveDirection;
    private Rigidbody2D mybody;
    public Vector2 origin;
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void RaiseLift()
    {
        
        moveDirection = Vector2.up;
        if (isLift) {
            mybody.transform.Translate(moveDirection * speed * Time.smoothDeltaTime);
        }
        AndLowerLift();
       
    }
    void LowerLift()
    {

        moveDirection = Vector2.down;
        if (isLift)
        {
            mybody.transform.Translate(moveDirection * speed * Time.smoothDeltaTime);
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.G))
            {
                RaiseLift();
            }
            
        }
    }
    IEnumerator AndLowerLift()
    {
        
        yield return new WaitForSeconds(5);
        LowerLift();
    }
}
