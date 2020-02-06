using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerDamage : MonoBehaviour
{

    private Text lifeText;
    private int lifeScoreCount;
    private bool canDamage;
    public bool IsDead;
    private Animator anim;
    private SpriteRenderer hit;
    void Awake()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        lifeScoreCount = 3;
        lifeText.text = "x " + lifeScoreCount;
        
        canDamage = true;
        IsDead=false;

    }
    void Start()
    {
        anim = GetComponent<Animator>();
        hit = GetComponentInChildren<SpriteRenderer>();
    }
    public void DealDamage()
    {
        if (canDamage)
        {
            lifeScoreCount--;
            print("hit");
            

            if (lifeScoreCount >= 0)
            {
                hit.gameObject.SetActive(true);
                lifeText.text = "x " + lifeScoreCount;
                
            }
             if (lifeScoreCount == 0)
            {
                anim.SetBool("IsDead", true);
                print("dead");


            }
            canDamage = false;
            

            StartCoroutine(WaitForDamage());
        }


    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }
}
