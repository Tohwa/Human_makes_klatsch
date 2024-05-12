using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> birdSpawn = new List<GameObject>();

    [SerializeField] private GameObject bird;

    [SerializeField] private float timeToSpawn = 2.0f;
    [SerializeField] private float counter = 0f;

    [SerializeField] private bool isOccupied = false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isOccupied)
        {
            if (!GameManager.Instance.GetHunterStatus())
            {
                counter += Time.deltaTime;

                if (counter >= timeToSpawn)
                {
                    int rnd = Random.Range(0, birdSpawn.Count);
                    Transform spawnTransform = birdSpawn[rnd].transform;
                    Instantiate(bird, spawnTransform.position, Quaternion.identity, null);
                    GameManager.Instance.SetHunterStatus(true);
                }
            }
        }
        else
        {
            counter = 0.0f;
        }

        if(counter >= timeToSpawn)
        {
            counter = 0.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            isOccupied = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            isOccupied = false;
        }
    }
}
