using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForEndMessage : MonoBehaviour
{
    [SerializeField] GameObject win;
    [SerializeField] GameObject loose;

    // Update is called once per frame
    public void SetWin()
    {
        win.SetActive(true);
    }

    public void SetLoose()
    {
        loose.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
