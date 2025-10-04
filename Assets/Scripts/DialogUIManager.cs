using UnityEngine;
using TMPro;
using System.Collections; // obligatoire pour IEnumerator

public class DialogUIManager : MonoBehaviour
{
	[SerializeField] private float textSpeed = 0.5f;
	[SerializeField] private GameObject dialogBox;
	[SerializeField] private TextMeshProUGUI textUI;
	[SerializeField] private PlayerMovement _playerMovement;

	private bool _isDialogOn = false;
	private bool _isTyping = false;
	private int _currentIndex = 0;
	private DialogData _currentData;

	private void Start()
	{
		dialogBox.SetActive(false);
	}

	private void Update()
	{
		if (!_isDialogOn || _isTyping || !Input.GetKeyDown(KeyCode.Space)) return;

		_currentIndex++;

		// TO END DIALOG
		if (_currentIndex == _currentData.dialogs.Length) {

			_isDialogOn = false;
			dialogBox.SetActive(false);
			_playerMovement.setCanMove(true);
			return;
		}

		_isTyping = true;
		StartCoroutine(TypeLine(_currentData.dialogs[_currentIndex].text));
	}

	public void StartDialog(DialogData data)
	{
		_playerMovement.setCanMove(false);
		_currentData = data;
		_isDialogOn = true;
		_currentIndex = 0;

		dialogBox.SetActive(true);

		_isTyping = true;
		StartCoroutine(TypeLine(_currentData.dialogs[_currentIndex].text));
	}

	private IEnumerator TypeLine(string text)
	{
		textUI.text = "";

		foreach (char c in text.ToCharArray())
		{
			textUI.text += c;
			yield return new WaitForSeconds(textSpeed);
		}

		_isTyping = false;
	}

	public bool getIsDialogOn() {

		return _isDialogOn;
	}
}
