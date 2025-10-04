using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField] private float  interactionRange = 0.5f;

	private LayerMask interactableLayerMask;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Start()
	{
		interactableLayerMask = LayerMask.GetMask("Interactable");
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
			TryInteract();
	}

	private void TryInteract() {

		Collider2D hit = Physics2D.OverlapCircle(transform.position, interactionRange, interactableLayerMask);

		if (hit == null) return;

		NPCInteraction npc = hit.gameObject.GetComponent<NPCInteraction>();

		if (npc == null) return;

		npc.Interact();
	}

	// Draw the circle in the Scene view
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, interactionRange);
	}
}
