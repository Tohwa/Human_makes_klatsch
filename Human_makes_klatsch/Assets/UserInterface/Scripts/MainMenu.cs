using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject primaryMenu;
    [SerializeField] GameObject settingsMenu;

    public void OnClick_Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnClick_Settings()
    {
        //MenuManager.OpenMainMenu(Menu.SETTINGS, gameObject);
        settingsMenu.SetActive(true);
        primaryMenu.SetActive(false);
    }

    public void OnClick_Credits()
    {
        settingsMenu.SetActive(true);
        primaryMenu.SetActive(false);
    }

    public void OnClick_Quit()
    {
        Application.Quit();
    }
}
