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
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }

        if (winCondition)
        {
            SceneManager.LoadScene("EndScreen");
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
