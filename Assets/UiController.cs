using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public Canvas UiCanvas;
   
    public Button MainMenuButton,ControlsButton, ResetButton;
    public GameObject MainMenuPanel, AreyousurePanel,ControlsPanel,StoryPanelOne, ResetPanel;

    public GameObject player;
    private Transform playerTransform;
    public Transform originReset;
    public bool playerReset;

    void Start()
    {
       
        MainMenuButton.gameObject.SetActive(true);
        ControlsButton.gameObject.SetActive(true);
        ResetButton.gameObject.SetActive(false);
        StoryPanelOne.SetActive(true);
        MainMenuPanel.SetActive(false);
        ResetPanel.gameObject.SetActive(false);

        player = GetComponent<GameObject>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (playerReset)
        {
            playerTransform.position = originReset.position;
        } 
    }
    public void PauseGame()
    {
        AreyousurePanel.SetActive(true);
        Time.timeScale = 0.00001f;
    }
    public void UnPauseGame()
    {
        ResetPanel.gameObject.SetActive(false);
        AreyousurePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        StoryPanelOne.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        ResetPanel.gameObject.SetActive(false);
        AreyousurePanel.SetActive(false);
        MainMenuButton.gameObject.SetActive(false);
        ResetButton.gameObject.SetActive(false);
        ControlsButton.gameObject.SetActive(false);
        MainMenuPanel.SetActive(true);
       
    }
    public void Controls()
    {
        ControlsPanel.SetActive(true);
        Time.timeScale = 0.00001f;

    }
        public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
    public void ResetPlayer()
    {

        ResetPanel.SetActive(true);
       
    }
    public void PlayerReset()
    {
        playerReset = true;
    }
}
