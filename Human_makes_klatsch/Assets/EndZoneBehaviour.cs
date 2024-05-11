using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneBehaviour : MonoBehaviour
{
    GameManager Instance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            Instance.SetWinCondition();
        }
    }
}
