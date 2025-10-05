using UnityEngine;
using UnityEngine.Events;

public class TriggerDialogOnCollision : MonoBehaviour
{
	[Header("Dialogs References")]
	[SerializeField] private DialogData[] dialogs;
	[SerializeField] private DialogUIManager dialogUIManager;
	[SerializeField] private PlayerData playerData;

	[Header("Funtion to trigger if event")]
	[SerializeField] private UnityEvent actionIfYes;
	[SerializeField] private UnityEvent actionIfNo;

	private LayerMask playerLayerMask;
	private int _dialogIndex = 0;

	private void Start()
	{
		playerLayerMask = LayerMask.GetMask("Player");
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("COLLISION");
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		Debug.Log(other.gameObject);

		if (((1 << other.gameObject.layer) & playerLayerMask) == 0)
			return;

		if (dialogUIManager.getIsDialogOn())
			return;

		Debug.Log("Started Dialog");

		dialogUIManager.StartDialog(dialogs[_dialogIndex], actionIfYes, actionIfNo);

		if (_dialogIndex < dialogs.Length - 1)
			_dialogIndex++;
	}
}
