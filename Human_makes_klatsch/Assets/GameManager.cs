using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] GameEvent winCon;
    [SerializeField] GameEvent loseCon;

    [SerializeField]
    private float playerHealth = 4;
    private float damageValue = 1;

    [SerializeField]
    private bool winCondition = false;

    [SerializeField]
    private bool looseCondition = false;

    public static event Action<float> PlayerDamaged;

    public bool HasJumped { get; set; }
    public bool Grounded { get; set; }
    public bool HunterSpawned { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void ChangeSceneToEnd()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public float GetPlayerHealth() { return playerHealth; }

    public void SetPlayerHealth(float _value)
    {
        if(_value != 4)
        {
            _value = 4;
            playerHealth = _value;
        }
    }
    public void ApplyDamager()
    {
        playerHealth = playerHealth - damageValue;
        PlayerDamaged?.Invoke(playerHealth);
    }

    public bool GetWinCondition() { return winCondition; }

    public void SetWinCondition()
    {
        winCon.Raise();
        winCondition = true;
    }

    public bool GetLooseCondition() { return looseCondition; }

    public void SetLooseCondition()
    {
        if (playerHealth == 0)
        {
            loseCon.Raise();
            looseCondition = true;
        }
    }

    public bool GetJumpStatus() { return HasJumped; }

    public void SetJumpStatus(bool _value)
    {
        HasJumped = _value;
    }

    public bool GetGroundedStatus() { return Grounded; }

    public void SetGroundedStatus(bool _value)
    {
        Grounded = _value;
    }

    public bool GetHunterStatus() { return HunterSpawned; }

    public void SetHunterStatus(bool _value)
    {
        HunterSpawned = _value;
    }

    public void SetPlayerHealth()
    {
        playerHealth = 4;
    }
}
