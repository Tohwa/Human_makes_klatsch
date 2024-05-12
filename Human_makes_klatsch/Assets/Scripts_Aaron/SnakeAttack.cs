using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    [SerializeField]
    private int _attackCounter = 1;

    [SerializeField]
    private float _impulseForce = 10.0f;

    [SerializeField]
    public GameEvent SnakeAttacked;

    public int SnakeAttackCounter => _attackCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_attackCounter <= 0)
            return;
        
        if (collision.gameObject.CompareTag("Egg"))
        {
            GameManager.Instance.ApplyDamager();
            Debug.LogFormat("Dealt Damage!!!");

            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(_impulseForce * (Vector2.right * (collision.transform.position.x - this.transform.position.x)).normalized, ForceMode2D.Impulse);

            SnakeAttacked.Raise();
            _attackCounter--;
        }
    }
}
