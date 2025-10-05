using UnityEngine;
using System;

[Serializable]
public struct Dialog
{
	public string text;
	public int nextIndex;
	public bool isChoice;
	public int indexNextIfYes;
	public int indexNextIfNo;
	public bool choiceTriggerAction;
}

[CreateAssetMenu(fileName = "DialogData", menuName = "DialogData")]
public class DialogData : ScriptableObject
{
	public string title;
	public float speed;
	public Dialog[] dialogs;
}
