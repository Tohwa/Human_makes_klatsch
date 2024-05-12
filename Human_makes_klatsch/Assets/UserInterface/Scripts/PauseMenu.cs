using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
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
        pauseMenu.SetActive(true);
        buttonReact.SetActive(false);
        pauseSettings.SetActive(false);
    }
}
