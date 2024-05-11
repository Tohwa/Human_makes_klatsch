using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private float playerHealth = 4;
    private float damageValue = 1;

    private bool winCondition { get; set; } = false;

    private bool looseCondition { get; set; } = false;

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

    private void Update()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }

        if (winCondition)
        {
            SceneManager.LoadScene("Endscreen");
        }

        if (looseCondition)
        {
            SceneManager.LoadScene("Endscreen");
        }
    }

    public float GetPlayerHealth() { return playerHealth; }

    public void ApplyDamager()
    {
        playerHealth = playerHealth - damageValue;
    }

    public bool GetWinCondition() { return winCondition; }

    public void SetWinCondition()
    {
        winCondition = true;
    }

    public bool GetLooseCondition() { return looseCondition; }

    public void SetLooseCondition()
    {
        if (playerHealth == 0)
        {
            looseCondition = true;
        }
    }
}
