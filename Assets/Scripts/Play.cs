using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
#if UNITY_EDITOR
	[SerializeField] private UnityEditor.SceneAsset sceneAsset;
#endif
	[SerializeField, HideInInspector] private string sceneName;

	private void OnValidate()
	{
#if UNITY_EDITOR
		if (sceneAsset != null)
			sceneName = sceneAsset.name;
#endif
	}

	public void loadScene()
	{
		if (!string.IsNullOrEmpty(sceneName))
			SceneManager.LoadScene(sceneName);
		else
			Debug.LogError($"No scene assigned on {name}");
	}
}
