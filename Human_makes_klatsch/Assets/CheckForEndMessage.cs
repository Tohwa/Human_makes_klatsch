using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForEndMessage : MonoBehaviour
{
    [SerializeField] GameObject win;
    [SerializeField] GameObject loose;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetWinCondition())
        {
            win.SetActive(true);
        }
        else if(GameManager.Instance.GetLooseCondition()) 
        { 
            loose.SetActive(true); 
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
