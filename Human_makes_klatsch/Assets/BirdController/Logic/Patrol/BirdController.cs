using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GameObject _birdObject;
    [SerializeField] private GameObject _pointA;
    [SerializeField] private GameObject _pointB;

    [SerializeField]
    private float _impulseForce = 1.0f;

    private GameObject _target;
    private SpriteRenderer _spriteRenderer;


    void Start()
    {
        _movementSpeed = Random.Range(1, 10);

        // Set the current target to point A
        _target = _pointA;

        // Get the sprite renderer from game obj
        _spriteRenderer = _birdObject.GetComponent<SpriteRenderer>();  
    }

    void Update()
    {
        SwitchTarget();

        // Move the bird from current pos to target
        _birdObject.transform.position = Vector3.MoveTowards(_birdObject.transform.position, _target.transform.position, _movementSpeed * Time.deltaTime);

        // Improved Focus
        Vector3 direction = _target.transform.position - transform.position;
        direction.Normalize();

        // Get Z rotation from X and Y (using Mathf library)
        //float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set rotation on Z axis
        // results in heavy spinning objects
        // the use of sprite flip is recommended
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationZ - 90);
    }


    /// <summary>
    /// Switchs between targets, if current target is reached.
    /// </summary>
    private void SwitchTarget()
    {
        if(_birdObject.transform.position == _target.transform.position)
        {
            // Switch
            if(_target == _pointA)
            {
                _target = _pointB;


                // Flip the sprite to match movement direction
                if (_spriteRenderer is not null)
                {
                    _spriteRenderer.flipY = false;
                }


                return;
            }


            _target = _pointA;


            // Flip the sprite to match movement direction
            if (_spriteRenderer is not null)
            {
                _spriteRenderer.flipY = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            //Debug.Log("Dealt Damage!!!");
            GameManager.Instance.ApplyDamager();
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(_impulseForce * (collision.transform.position - this.transform.position).normalized, ForceMode2D.Impulse);
        }
    }

}
