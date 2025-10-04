using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public struct Dialog
{
	public string text;
	public bool isChoice;
	public int indexNextIfYes;
	public int indexNextIfNo;
	public UnityEvent actionIfYes;
	public UnityEvent actionIfNo;
}

[CreateAssetMenu(fileName = "DialogData", menuName = "DialogData")]
public class DialogData : ScriptableObject
{
	public string dialogTitle;
	public Dialog[] dialogs;
}
