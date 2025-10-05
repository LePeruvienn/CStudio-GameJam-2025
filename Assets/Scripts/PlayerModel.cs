using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
	// Singleton
	private static PlayerModel _instance;

	public static PlayerModel Instance
	{
		get
		{
			if (_instance == null)
			{
				// Cherche l'instance existante dans la scène
				_instance = FindObjectOfType<PlayerModel>();

				// Si aucune instance trouvée, crée-en une nouvelle
				if (_instance == null)
				{
					GameObject obj = new GameObject("PlayerModel");
					_instance = obj.AddComponent<PlayerModel>();
				}
			}
			return _instance;
		}
	}

	// Inventaire
	private List<string> inventory = new List<string>();

	// -----------------------------
	// Fonctions statiques accessibles directement
	// -----------------------------
	public static void AddItem(string item)
	{
		Instance.inventory.Add(item);
		Debug.Log("Added item: " + item);
	}

	public static bool HasItem(string item)
	{
		return Instance.inventory.Contains(item);
	}

	public static List<string> GetInventory()
	{
		return Instance.inventory;
	}

	// -----------------------------
	// Awake pour le singleton
	// -----------------------------
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject); // empêche les doublons
		}
		else
		{
			_instance = this;
			DontDestroyOnLoad(gameObject); // persiste entre les scènes
		}
	}
}
