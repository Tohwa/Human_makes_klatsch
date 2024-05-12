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

    private bool hasJumped { get; set; }

    private bool grounded { get; set; }

    private bool hunterSpawned { get; set; }

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
        int rnd = Random.Range(0, EggSpawns.Count);

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

    public bool GetJumpStatus() { return hasJumped; }

    public void SetJumpStatus(bool _value)
    {
        hasJumped = _value;
    }

    public bool GetGroundedStatus() { return grounded; }

    public void SetGroundedStatus(bool _value)
    {
        grounded = _value;
    }

    public bool GetHunterStatus() { return hunterSpawned; }

    public void SetHunterStatus(bool _value)
    {
        hunterSpawned = _value;
    }
}
