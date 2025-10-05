using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "NPCData")]
public class NPCData : ScriptableObject
{
	public string NPCname;
	public int dialogIndex = 0;
	public bool isDead = false;

	public void Reset()
	{
		dialogIndex = 0;
		isDead = false;
	}
}
