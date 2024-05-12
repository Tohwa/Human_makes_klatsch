using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.collider.CompareTag("Egg"))
    //    {
    //        // Inform listeners that player was hit
    //        OnPlayerHit?.Invoke();
    //        GameManager.Instance.ApplyDamager();
    //        // Connect to event system here ...
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            // Inform listeners that player was hit
            OnPlayerHit?.Invoke();
            GameManager.Instance.ApplyDamager();
            // Connect to event system here ...
        }
    }

    public delegate void PlayerHit();

    /// <summary>
    /// Called when the bird hits a game object with the "Player" tag.
    /// </summary>
    public event PlayerHit OnPlayerHit;
}
