using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 2.0f;

    [SerializeField]
    private Sprite[] _spriteArray = new Sprite[2];

    [SerializeField]
    private SnakeAttack _snakeAttack;

    private SpriteRenderer _spriteRenderer;
    private SnakeFrontCheck _frontCheck;
    private Collider2D _frontCheckCollider;

    private bool _isPlayerDetected = false;
    private float _maxMoveDistance;
    private Vector2 _startPosition;
    private Vector2 _playerPosition;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _frontCheck = GetComponentInChildren<SnakeFrontCheck>();
        _frontCheckCollider = _frontCheck.GetComponent<Collider2D>();
        _startPosition = new(transform.position.x, transform.position.y);
    }

    private void OnEnable()
    {
        _frontCheck.PlayerDetected += OnPlayerDetected;
    }

    private void Start()
    {
        _maxMoveDistance = _frontCheckCollider.bounds.size.x;
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        _frontCheck.PlayerDetected -= OnPlayerDetected;
    }

    private void OnPlayerDetected(bool b, Transform t)
    {
        _playerPosition = new(t.position.x, t.position.y);
        _isPlayerDetected = b;
    }

    private void Move()
    {
        Vector2 currentPosition = new(transform.position.x, transform.position.y);

        Vector2 _maxDistance = new(_startPosition.x + _maxMoveDistance * Mathf.Sign(_playerPosition.x - _startPosition.x), _startPosition.y);

        if (_isPlayerDetected && _snakeAttack.SnakeAttackCounter > 0)
        {
            _spriteRenderer.sprite = _spriteArray[1];

            if (Vector2.Distance(currentPosition, _startPosition) >= _maxMoveDistance)
                return;
            else
                transform.position = Vector2.MoveTowards(currentPosition, _maxDistance, _movementSpeed * Time.deltaTime);
        }
        else if (!_isPlayerDetected && currentPosition != _startPosition)
        {
            _spriteRenderer.sprite = _spriteArray[0];
            transform.position = Vector2.MoveTowards(currentPosition, _startPosition, _movementSpeed * Time.deltaTime);
        }
    }
}
