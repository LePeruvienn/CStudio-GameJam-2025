using UnityEngine;

public class ResetAll : MonoBehaviour
{
	[SerializeField] private PlayerData playerData;
	[SerializeField] private NPCData[] npcDatas;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	playerData.Reset();

		for (int i = 0; i < npcDatas.Length; i++)
			npcDatas[i].Reset();
    }
}
