using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject primaryMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseSettings;

    [SerializeField] GameObject buttonReact;
    [SerializeField] GameObject button;

    [SerializeField] GameObject pauseButton;

    public void OnClick_BackMain()
    {
        StartCoroutine(DelayBackMain());
    }

    private IEnumerator DelayBackMain()
    {
        buttonReact.SetActive(true);
        yield return new WaitForSeconds(1f);
        primaryMenu.SetActive(true);
        buttonReact.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void OnClick_BackPause()
    {
        pauseMenu.SetActive(true);
        pauseSettings.SetActive(false);
    }
}
