using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField] private string name;

	public string getName() {

		return name;
	}
}
