using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Exit : MonoBehaviour
{
#if UNITY_EDITOR
	[SerializeField] private UnityEditor.SceneAsset sceneAsset;
#endif
	[SerializeField, HideInInspector] private string sceneName;

	private LayerMask playerLayerMask;

	private void Start()
	{
		playerLayerMask = LayerMask.GetMask("Player");
	}

	private void OnValidate()
	{
#if UNITY_EDITOR
		if (sceneAsset != null)
			sceneName = sceneAsset.name;
#endif
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (((1 << other.gameObject.layer) & playerLayerMask) == 0)
			return;

		if (!string.IsNullOrEmpty(sceneName))
			SceneManager.LoadScene(sceneName);
		else
			Debug.LogError($"No scene assigned on {name}");
	}
}
