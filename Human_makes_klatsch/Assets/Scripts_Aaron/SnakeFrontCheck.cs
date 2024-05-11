using System;
using UnityEngine;

public class SnakeFrontCheck : MonoBehaviour
{
    public event Action<bool, Transform> PlayerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
            PlayerDetected?.Invoke(true, collision.gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
            PlayerDetected?.Invoke(false, collision.gameObject.transform);
    }
}
