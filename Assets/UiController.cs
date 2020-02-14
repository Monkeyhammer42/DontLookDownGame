using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public Canvas UiCanvas;
   
    public Button MainMenuButton,ControlsButton;
    public GameObject MainMenuPanel, AreyousurePanel,ControlsPanel,StoryPanelOne;


    void Start()
    {
        
        MainMenuButton.gameObject.SetActive(true);
        ControlsButton.gameObject.SetActive(true);
        StoryPanelOne.SetActive(true);
        MainMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        
    }
    public void PauseGame()
    {
        AreyousurePanel.SetActive(true);
        Time.timeScale = 0.00001f;
    }
    public void UnPauseGame()
    {
        AreyousurePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        StoryPanelOne.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        AreyousurePanel.SetActive(false);
        MainMenuButton.gameObject.SetActive(false);
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
}
