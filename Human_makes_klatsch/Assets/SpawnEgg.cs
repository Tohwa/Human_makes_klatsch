using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEgg : MonoBehaviour
{
    [SerializeField] GameEvent ResetPlayerHealth;

    [SerializeField]
    GameObject eggPrefab;

    [SerializeField]
    private List<GameObject> EggSpawns = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ResetPlayerHealth.Raise();


        int rnd = Random.Range(0, EggSpawns.Count);

        Transform spawnPos = EggSpawns[rnd].transform;

        Instantiate(eggPrefab, spawnPos.position, Quaternion.identity, null);
    
    
    }
}
