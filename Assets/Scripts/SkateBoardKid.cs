using UnityEngine;

public class SkateBoardKid : MonoBehaviour
{
	[Header("Follow Config")]
	[SerializeField] private int speed = 2;
	[SerializeField] private float rangeToTrigger = 5;
	[SerializeField] private float followRange = 5;

	[Header("Follow Boundaries")]
	[SerializeField] private Transform leftBoundary;
	[SerializeField] private Transform rightBoundary;

	[Header("References")]
	[SerializeField] private Transform playerTransform;

	private Rigidbody2D _rigidbody;
	private Animator _animator;

	private bool _haveToFollowPlayer = false;
	private int _direction = 0;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (_haveToFollowPlayer)
			followPlayer();
		else
			checkForFollowTrigger();
	}

	private void followPlayer()
	{
		float distance = Vector3.Distance(playerTransform.position, transform.position);

		// Stop if within follow range
		if (distance < followRange)
			return;

		// Determine direction toward player
		float directionToPlayer = Mathf.Sign(playerTransform.position.x - transform.position.x);
		_direction = 0;

		// Get current X position
		float posX = transform.position.x;

		// Prevent moving beyond boundaries
		bool isInRightBoundary = posX < rightBoundary.position.x;
		bool isInLeftBoundary = posX > leftBoundary.position.x;

		if (isInLeftBoundary && Input.GetKey(KeyCode.A) && directionToPlayer < 0)
			_direction = -1;
		else if (isInRightBoundary && Input.GetKey(KeyCode.D) && directionToPlayer > 0)
			_direction = 1;

		_animator.SetInteger("directionX", _direction);
		_rigidbody.linearVelocity = new Vector2(_direction * speed, 0);
	}

	private void checkForFollowTrigger()
	{

		float distance = Vector3.Distance(playerTransform.position, transform.position);

		if (distance < rangeToTrigger)
			_haveToFollowPlayer = true;
	}
}
