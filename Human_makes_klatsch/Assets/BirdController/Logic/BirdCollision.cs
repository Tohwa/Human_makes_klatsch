using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            // Connect to event system here ...

            // Simple debug message
            Debug.Log(this + ": Hit player object.");
        }
    }
}
