using UnityEngine;
using UnityEngine.Events;

public class NPCInteraction : MonoBehaviour
{
	[Header("Dialogs References")]
	[SerializeField] private DialogData[] dialogs;
	[SerializeField] private DialogUIManager dialogUIManager;
	[SerializeField] private PlayerData playerData;
	[SerializeField] private NPCData npcData;

	[Header("Funtion to trigger if event")]
	[SerializeField] private UnityEvent actionIfYes;
	[SerializeField] private UnityEvent actionIfNo;

	[Header("Die Animation")]
	[SerializeField] private float deathJumpForce = 6f;
	[SerializeField] private float deathRotateSpeed = 2f;
	[SerializeField] private float deathDuration = 10f;
	[SerializeField] private ParticleSystem deathParticle;

	private Rigidbody2D _rigidbody;
	private Collider2D _collider;

	private bool _isDying = false;
	private float _deathElapsedTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
		// Get NPCs Components
		_rigidbody = GetComponent<Rigidbody2D>();
		_collider = GetComponent<Collider2D>();

		// FOR DEBUG !! TO DELETE AFTER
		// TODO MAKE ALL SCRIPTABLES OBJECTS RESET WHEN NEW GAME
		npcData.isDead = false;
		npcData.dialogIndex = 0;
		// END

        if (npcData.isDead)
			Destroy(gameObject);
    }

	private void Update()
	{
		// Return if player is not falling
		if (!_isDying || _rigidbody.velocity.y > 0) return;

		if (_deathElapsedTime > deathDuration)
			Destroy(gameObject);

		_deathElapsedTime += Time.deltaTime;

		// Make player rotate over time
		float z = deathRotateSpeed * Time.deltaTime * 1000;
		transform.Rotate (new Vector3(0, 0, z));
	}

	public void Interact()
	{
		if (dialogUIManager.getIsDialogOn())
			return;

		Debug.Log("Started Dialog");

		dialogUIManager.StartDialog(dialogs[npcData.dialogIndex], actionIfYes, actionIfNo);

		if (npcData.dialogIndex < dialogs.Length - 1)
			npcData.dialogIndex++;
	}

	public void KillNPC()
	{
		npcData.isDead = true;
		_isDying = true;

		// Disable collider
		_collider.enabled = false;

		// Make player jump & reset x velocity
		Vector2 velocity = _rigidbody.linearVelocity;
		velocity.y = deathJumpForce;
		velocity.x = 0;
		_rigidbody.constraints = RigidbodyConstraints2D.None;
		_rigidbody.linearVelocity = velocity;
		_rigidbody.gravityScale = 1f;

		// Play death ParticleSystem

		// Instantiate the particle system as a child of the specified parent
		ParticleSystem instantiatedParticles = Instantiate(deathParticle, transform.position, Quaternion.identity);
		instantiatedParticles.Play();
		// Optionally destroy it after a certain time
		float duration = instantiatedParticles.main.duration + instantiatedParticles.main.startLifetime.constant;
		Destroy(instantiatedParticles.gameObject, duration);
	}

	public void GiveItem(string itemName) {
		
		playerData.AddItem(itemName);
	}

	public void GiveIitemAndDestroy(string itemName) {
		
		playerData.AddItem(itemName);
		Destroy(gameObject);
		npcData.isDead = true;
	}
}
