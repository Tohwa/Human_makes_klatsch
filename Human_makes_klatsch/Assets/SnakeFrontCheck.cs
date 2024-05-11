using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFrontCheck : MonoBehaviour
{
    public event Action<Transform> PlayerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogFormat("PlayerDetected");
            
            PlayerDetected?.Invoke(collision.gameObject.transform);
        }
    }
}
