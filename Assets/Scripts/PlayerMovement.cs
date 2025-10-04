using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private int speed = 2;

	private Rigidbody2D _rigidBody;

	private bool _canMove = true;
	private Vector2 _velocity = new Vector2(0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (_canMove == true)
			HandleMovement();
	}

	void HandleMovement() {

		if (Input.GetKey(KeyCode.W))
		{
			_velocity.y = speed;

		} else if (Input.GetKey(KeyCode.A))
		{
			_velocity.x = -speed;

		} else if (Input.GetKey(KeyCode.S))
		{
			_velocity.y = -speed;

		} else if (Input.GetKey(KeyCode.D))
		{
			_velocity.x = speed;
		}

		_rigidBody.linearVelocity = _velocity;
	}
}
