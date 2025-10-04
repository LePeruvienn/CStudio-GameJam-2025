using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
	[SerializeField] private DialogData dialogData;
	[SerializeField] private DialogUIManager dialogUIManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

	public void Interact()
	{
		if (dialogUIManager.getIsDialogOn())
			return;

		dialogUIManager.StartDialog(dialogData);
	}
}
