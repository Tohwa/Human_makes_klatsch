using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    [SerializeField]
    private float _impulseForce = 100.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogFormat("Dealt Damage!!!");
            collision.rigidbody?.AddRelativeForce(Vector2.right * _impulseForce, ForceMode2D.Impulse);
        }
    }
}
