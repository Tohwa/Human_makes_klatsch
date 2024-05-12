using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    [SerializeField]
    private int _attackCounter = 1;

    [SerializeField]
    private float _impulseForce = 1.0f;

    [SerializeField]
    public GameEvent SnakeAttacked;

    public int SnakeAttackCounter => _attackCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_attackCounter <= 0)
            return;
        
        if (collision.gameObject.CompareTag("Egg"))
        {
            Debug.LogFormat("Dealt Damage!!!");
            GameManager.Instance.ApplyDamager();
            SnakeAttacked.Raise();

            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(_impulseForce * (collision.transform.position - this.transform.position).normalized, ForceMode2D.Impulse);

            _attackCounter--;
        }
    }
}
