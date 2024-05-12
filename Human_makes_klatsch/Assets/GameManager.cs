using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    GameObject eggPrefab;

    [SerializeField]
    private List<GameObject> EggSpawns = new List<GameObject>();

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

    private void Start()
    {
        int rnd = UnityEngine.Random.Range(0, EggSpawns.Count);

        Transform spawnPos = EggSpawns[rnd].transform;

        Instantiate(eggPrefab, spawnPos.position, Quaternion.identity, null);
    }

    private void Update()
    {
        if (winCondition)
        {
            SceneManager.LoadScene("EndScreen");
        }

        if(looseCondition)
        {
            SceneManager.LoadScene("EndScreen");
        }

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            SetLooseCondition();
        }

    }

    public float GetPlayerHealth() { return playerHealth; }

    public void ApplyDamager()
    {
        playerHealth = playerHealth - damageValue;
        PlayerDamaged?.Invoke(playerHealth);
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
}
