using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private int speed = 2;

	private Rigidbody2D _rigidBody;
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;

	private bool _canMove = true;
	private Vector2Int _direction = new Vector2Int(0, 0);
	private Vector2Int _lastDirection = new Vector2Int(0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
		if (_canMove == true)
			HandleMovement();
	}

	private void HandleMovement() {

		_direction = Vector2Int.zero;

		if (Input.GetKey(KeyCode.W))
		{
			_direction.y = 1;

		} else if (Input.GetKey(KeyCode.A))
		{
			_direction.x = -1;

		} else if (Input.GetKey(KeyCode.S))
		{
			_direction.y = -1;

		} else if (Input.GetKey(KeyCode.D))
		{
			_direction.x = 1;
		}

		if (_direction != Vector2Int.zero)
			_lastDirection = _direction;

		_animator.SetInteger("directionX", _lastDirection.x);
		_animator.SetInteger("directionY", _lastDirection.y);
		_animator.SetBool("isWalking", _direction != Vector2Int.zero);

		_spriteRenderer.flipX = (_lastDirection.x == -1);

		_rigidBody.linearVelocity = _direction * speed;

	}

	public void setCanMove(bool val) {

		_canMove = val;
	}
}
