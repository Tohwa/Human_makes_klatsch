using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    [SerializeField]
    private float _impulseForce = 1.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            //Debug.Log("Dealt Damage!!!");
            GameManager.Instance.ApplyDamager();
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 bounceDir = new Vector3(0.0f,1.0f,0.0f);
            playerRigidbody.AddForce(_impulseForce * ((collision.transform.position - this.transform.position) + bounceDir).normalized, ForceMode2D.Impulse);
        }
    }
}
