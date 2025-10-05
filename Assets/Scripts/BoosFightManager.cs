using System;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
	[Header("REFERENCES")]
	[SerializeField] private PlayerData playerData;
	[SerializeField] private DialogUIManager dialogUIManager;
	
	[Header("SCENE ELEMENTS")]
	[SerializeField] private GameObject blackBg;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject boss;

	[Header("INTRO DIALOGS")]
	[SerializeField] private DialogData[] introDialogs;

	[Header("DEFAULT DIALOG")]
	[SerializeField] private DialogData defaultDialog;

	[Header("END DIALOGS")]
	[SerializeField] private DialogData[] winDialogs;
	[SerializeField] private DialogData[] loseDialogs;

	[Header("NEEDED ITEM TO WIN")]
	[SerializeField] private string[] itemsNeededForWin; // Items we need for win

	[Header("ITEM DIALOGS")]
	[SerializeField] private List<ItemDialog> itemDialogs = new();

	private int _currentIndex = 0;
	private bool _startFight = false;
	private string[] inventory;
	private int _currentItemIndex = 0;
	private bool _haveWin = false;

	private int _numberOfNeededItemsFounded = 0; // NUMBERS OF ITEMS FOUD FOR WIN IF itemsNeededForWin.Length is equal we win !

	private Dictionary<string, DialogData> _dialogDict;

	private void Start()
	{
		inventory = playerData.GetInventory().ToArray();
		
		// Construire le dictionnaire clé → dialogue
		_dialogDict = new Dictionary<string, DialogData>();
		foreach (var entry in itemDialogs)
		{
			if (!string.IsNullOrEmpty(entry.itemName) && entry.dialog != null)
				_dialogDict[entry.itemName] = entry.dialog;
		}
	}

	private void Update()
	{
		// Si un dialogue est en cours, on ne fait rien
		if (dialogUIManager.getIsDialogOn())
			return;

		// Étape 1 : intro dialogs
		if (!_startFight)
		{
			if (_currentIndex < introDialogs.Length)
			{
				dialogUIManager.StartDialog(introDialogs[_currentIndex], null, null);
				_currentIndex++;
				return;
			}

			// Une fois tous les dialogues d’intro terminés → lancer la phase de combat
			_startFight = true;
			_currentItemIndex = 0;
			return;
		}

		// Étape 2 : dialogues liés à l’inventaire
		bool hasEnded = handleFight();

		if (!hasEnded) return;

		// Étape 3 : vérifier la victoire ou la défaite
		_haveWin = _numberOfNeededItemsFounded >= itemsNeededForWin.Length;

		// Étape 4 : lancer le dialogue final
		DialogData[] finalDialogs = _haveWin ? winDialogs : loseDialogs;

		// Option simple : parcourir final dialogs un par un
		if (_currentIndex < introDialogs.Length + finalDialogs.Length)
		{
			dialogUIManager.StartDialog(finalDialogs[_currentIndex - introDialogs.Length], null, null);
			_currentIndex++;
		}
	}

	private bool handleFight()
	{
		// Tant qu'il reste des objets à traiter
		if (_currentItemIndex >= inventory.Length)
			return true;

		string currentItem = inventory[_currentItemIndex];

		// Vérifie si un dialogue est associé à cet item
		if (_dialogDict.TryGetValue(currentItem, out var dialog))
		{
			dialogUIManager.StartDialog(dialog, null, null);

		} else {

			dialogUIManager.StartDialog(defaultDialog, null, null);
		}

		// Vérifie si l'item est nécessaire pour gagner
		if (Array.Exists(itemsNeededForWin, item => item == currentItem))
		{
			_numberOfNeededItemsFounded++;
		}

		_currentItemIndex++;

		return false;
	}
}

[Serializable]
public struct ItemDialog
{
	public string itemName;     // Nom de l'objet dans l'inventaire
	public DialogData dialog;   // Dialogue associé
}
