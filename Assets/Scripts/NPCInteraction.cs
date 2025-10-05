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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (npcData.isDead)
			Destroy(gameObject);
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

	public void GiveItem(string itemName) {
		
		playerData.AddItem(itemName);
	}

	public void GiveIitemAndDestroy(string itemName) {
		
		playerData.AddItem(itemName);
		Destroy(gameObject);
		npcData.isDead = true;
	}

	public void Die() {

		Debug.Log("Au secours de meurt");
	}
}
