using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text PieTextScore;
    private AudioSource audioManager;
    public int scoreCount;
    void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Start()
    {
        PieTextScore = GameObject.Find("PieText").GetComponent<Text>();

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Pie")
        {

            IncrementScore();
            target.gameObject.SetActive(false);

        }
        
    }

    public void IncrementScore()
    {
        scoreCount++;
        PieTextScore.text = "x " + scoreCount.ToString();
        audioManager.Play();
    }

}
