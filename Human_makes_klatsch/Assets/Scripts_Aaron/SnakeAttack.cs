using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    [SerializeField]
    private float _impulseForce = 100.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogFormat("Dealt Damage!!!");
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(_impulseForce * (collision.transform.position - this.transform.position).normalized, ForceMode2D.Impulse);
        }
    }
}
