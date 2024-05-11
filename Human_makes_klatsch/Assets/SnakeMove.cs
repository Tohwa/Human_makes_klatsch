using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 1.0f;

    private SnakeFrontCheck _frontCheck;
    private bool _isPlayerDetected = false;
    private Vector2 _startPosition;
    private Vector2 _playerPosition;

    private void Awake()
    {
        _frontCheck = GetComponentInChildren<SnakeFrontCheck>();
        _startPosition = new (transform.position.x, transform.position.y);
    }

    private void OnEnable()
    {
        _frontCheck.PlayerDetected += OnPlayerDetected;
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        _frontCheck.PlayerDetected -= OnPlayerDetected;
    }

    private void OnPlayerDetected(Transform playerTransformOnDetection)
    {
        Debug.LogFormat("Start Moving");
        _playerPosition = new (playerTransformOnDetection.position.x, playerTransformOnDetection.position.y);
        _isPlayerDetected = true;
    }
    private void Move()
    {
        Vector2 currentPosition = new(transform.position.x, transform.position.y);

        if (_isPlayerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerPosition, _movementSpeed * Time.deltaTime);
        }
        else if (!_isPlayerDetected && currentPosition != _startPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _frontCheck.transform.position, _movementSpeed * Time.deltaTime);
        }
    }
}
