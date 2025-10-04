using UnityEngine;
using System;

[Serializable]
public struct Dialog
{
	public string text;
	public int nextDialogId;
}

[CreateAssetMenu(fileName = "DialogData", menuName = "Dialogs/DialogData")]
public class DialogData : ScriptableObject
{
	public string dialogTitle;
	public Dialog[] dialogs;  // visible et éditable dans l’Inspector
}
