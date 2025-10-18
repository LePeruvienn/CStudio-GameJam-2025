using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
	[SerializeField] private List<string> inventory = new List<string>();
	[SerializeField] private List<string> killedNpcs = new List<string>();
	[SerializeField] private bool haveSkateboard = false;

	public void Reset()
	{
		inventory.Clear();
		killedNpcs.Clear();
	}

	public void AddItem(string item)
	{
		inventory.Add(item);
	}

	public void AddKilledNPC(string npcName)
	{
		killedNpcs.Add(npcName);
	}

	public bool HasKilledNPC(string npcName)
	{
		return killedNpcs.Contains(npcName);
	}

	public List<string> GetKilledNPCs()
	{
		return killedNpcs;
	}

	public bool HasItem(string item)
	{
		return inventory.Contains(item);
	}

	public List<string> GetInventory()
	{
		return inventory;
	}

	public bool GetHaveASkateboard()
	{
		return haveSkateboard;
	}

	public void SetHaveSkateboard(bool val)
	{
		haveSkateboard = val;
	}
}
