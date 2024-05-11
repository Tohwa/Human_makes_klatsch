using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 7.0f;
    [SerializeField] private GameObject _birdObject;
    [SerializeField] private GameObject _pointA;
    [SerializeField] private GameObject _pointB;



    private GameObject _target;
    private SpriteRenderer _spriteRenderer;


    void Start()
    {
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
                if(_spriteRenderer is not null)
                {
                    _spriteRenderer.flipY = false;
                }

                return;
            }


            _target = _pointA;

            // Flip the sprite to match movement direction
            if(_spriteRenderer is not null)
            {
                _spriteRenderer.flipY = true;
            }
        }
    }



}
