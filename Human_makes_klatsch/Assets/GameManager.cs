using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private float playerHealth = 4;
    private float damageValue = 1;

    private bool winCondition { get; set;} = false;

    private bool looseCondition { get; set;} = false;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
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
        looseCondition = true;
    }
}
