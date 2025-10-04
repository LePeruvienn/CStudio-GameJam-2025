using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
	[SerializeField] DialogData dialogData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

	public void Interact()
	{
		Debug.Log ("HELLO I AM AN NPC!");
	}
}
