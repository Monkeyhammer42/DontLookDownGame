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

    void Awake()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        lifeScoreCount = 3;
        lifeText.text = "x " + lifeScoreCount;

        canDamage = true;
    }
    void Start()
    {
        
    }
    public void DealDamage()
    {
        if (canDamage)
        {
            lifeScoreCount--;
            if (lifeScoreCount >= 0)
            {
                lifeText.text = "x " + lifeScoreCount;
            }
            if (lifeScoreCount == 0)
            {
                print("Dead");
              

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
