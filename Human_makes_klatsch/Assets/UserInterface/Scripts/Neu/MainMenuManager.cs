using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject mainSettings;
    [SerializeField] GameObject mainCredits;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseSettings;

    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject winScene;
    [SerializeField] GameObject loseScene;
    // [SerializeField] GameObject endSettings;

    [SerializeField] GameObject lvlChoiceMenu;
    [SerializeField] GameObject tutorialOne;
    [SerializeField] GameObject tutorialTwo;
    [SerializeField] GameObject tutorialThree;

    [SerializeField] GameObject buttonReact;
    [SerializeField] GameObject button;
    [SerializeField] GameObject buttonBase;

    public static MainMenuManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void OnClick_Play()
    {
        mainMenu.SetActive(false);
        lvlChoiceMenu.SetActive(true);
    }

    public void OnClick_Continue()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClick_MainSettings()
    {
        mainSettings.SetActive(true);
        mainMenu.SetActive(false);
    }

    //public void PauseMenuHandler()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        pauseMenu.SetActive(true);
    //    }
    //}

    public void OnClick_PauseSetting()
    {
        pauseSettings.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void OnClick_MainCredits()
    {
        mainCredits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnClick_PauseSettings()
    {
        pauseSettings.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void OnClick_NormalBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClick_BackToMain()
    {
        StartCoroutine(DelayBackToMain());
    }

    public void OnClick_BackToPause()
    {
        StartCoroutine(DelayBackToPause());
    }

    public void OnClick_DelayBackToMainLVLChoice()
    {
        StartCoroutine(DelayBackToMainLVLChoice());
    }

    // public void OnClick_DelayBackToEndScene()
    // {
    //     StartCoroutine(DelayBackToEndScene());
    // }

    private IEnumerator DelayBackToMain()
    {
        buttonReact.SetActive(true);
        yield return new WaitForSeconds(1f);
        mainMenu.SetActive(true);
        buttonReact.SetActive(false);
        buttonBase.SetActive(false);
        button.SetActive(false);
        mainSettings.SetActive(false);
    }

    private IEnumerator DelayBackToMainLVLChoice()
    {
        buttonReact.SetActive(true);
        yield return new WaitForSeconds(1f);
        mainMenu.SetActive(true);
        buttonReact.SetActive(false);
        buttonBase.SetActive(false);
        button.SetActive(false);
        lvlChoiceMenu.SetActive(false);
    }

    private IEnumerator DelayBackToPause()
    {
        buttonReact.SetActive(true);
        yield return new WaitForSeconds(1f);
        pauseMenu.SetActive(true);
        buttonReact.SetActive(false);
        pauseSettings.SetActive(false);
    }

    // private IEnumerator DelayBackToEndScene()
    // {
    //     buttonReact.SetActive(true);
    //     yield return new WaitForSeconds(1f);
    //     endSettings.SetActive(true);
    //     buttonReact.SetActive(false);
    //     winScene.SetActive(false);
    // }

    public void OnClick_LvlChoiceMenu()
    {
        lvlChoiceMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnClick_TutorialOne()
    {
        SceneManager.LoadScene("Level One");
    }

    public void OnClick_TutorialTwo()
    {
        SceneManager.LoadScene("Level Two");
    }

    public void OnClick_TutorialThree()
    {
        SceneManager.LoadScene("Level Three");
    }

    public void OnClick_QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void OnClick_QuitMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
