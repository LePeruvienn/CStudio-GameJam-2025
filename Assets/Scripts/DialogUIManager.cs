using UnityEngine;
using TMPro;
using System.Collections; // obligatoire pour IEnumerator
using UnityEngine.Events;

public class DialogUIManager : MonoBehaviour
{
	[SerializeField] private GameObject dialogBox;
	[SerializeField] private TextMeshProUGUI textUI;
	[SerializeField] private TextMeshProUGUI titleUI;
	[SerializeField] private GameObject arrowEnd;

	[SerializeField] private GameObject menuChoice;
	[SerializeField] private GameObject yesArrow;
	[SerializeField] private GameObject noArrow;

	[SerializeField] private PlayerMovement _playerMovement;

	private bool _isDialogOn = false;
	private bool _isTyping = false;
	private bool _isChoosing = false;
	private int _currentIndex = 0;
	private float _currentSpeed;
	private bool _isChoiceYes;

	private UnityEvent _currentActionYes;
	private UnityEvent _currentActionNo;

	private DialogData _currentData;

	private int _currentResult;

	private void Start()
	{
		dialogBox.SetActive(false);
		arrowEnd.SetActive(false);
		menuChoice.SetActive(false);
		yesArrow.SetActive(false);
		noArrow.SetActive(false);
	}

	private void Update()
	{
		if (_isChoosing) {

			if (_isChoiceYes && Input.GetKeyDown(KeyCode.D)) {
				
				_isChoiceYes = false;
				noArrow.SetActive(true);
				yesArrow.SetActive(false);

			} else if (!_isChoiceYes && Input.GetKeyDown(KeyCode.A)) {

				_isChoiceYes = true;
				noArrow.SetActive(false);
				yesArrow.SetActive(true);

			} else if (Input.GetKeyDown(KeyCode.Space)) {

				Dialog oldDialog = _currentData.dialogs[_currentIndex];
				_currentIndex += (_isChoiceYes) ? oldDialog.indexNextIfYes : oldDialog.indexNextIfNo;
				_isChoosing = false;
				menuChoice.SetActive(false);
				yesArrow.SetActive(false);
				noArrow.SetActive(false);

				if (oldDialog.choiceTriggerAction) {

					if (_isChoiceYes) {

						_currentActionYes.Invoke();

					} else {

						_currentActionNo.Invoke();
					}
				}

				if (_currentIndex >= _currentData.dialogs.Length) {

					_isDialogOn = false;
					dialogBox.SetActive(false);
					_playerMovement.setCanMove(true);
					return;
				}

				_isTyping = true;
				Dialog nextDialog = _currentData.dialogs[_currentIndex];
				StartCoroutine(TypeLine(nextDialog.text, nextDialog.isChoice));
			}

			return;
		}

		if (!_isDialogOn || _isTyping || !Input.GetKeyDown(KeyCode.Space)) return;

		arrowEnd.SetActive(false);

		Dialog _oldDialog = _currentData.dialogs[_currentIndex];
		_currentIndex += _oldDialog.nextIndex;

		// TO END DIALOG
		if (_currentIndex >= _currentData.dialogs.Length) {

			_isDialogOn = false;
			dialogBox.SetActive(false);
			_playerMovement.setCanMove(true);
			return;
		}

		_isTyping = true;

		Dialog currentDialog = _currentData.dialogs[_currentIndex];
		StartCoroutine(TypeLine(currentDialog.text, currentDialog.isChoice));
	}

	public void StartDialog(DialogData data, UnityEvent actionYes, UnityEvent actionNo)
	{
		if (data.dialogs.Length == 0)
			return;

		if (_playerMovement != null )
			_playerMovement.setCanMove(false);

		_isDialogOn = true;
		_currentIndex = 0;

		_currentData = data;
		_currentSpeed = data.speed;
		titleUI.text = data.title;
		_currentActionYes = actionYes;
		_currentActionNo = actionNo;

		dialogBox.SetActive(true);

		_isTyping = true;

		Dialog currentDialog = _currentData.dialogs[_currentIndex];
		StartCoroutine(TypeLine(currentDialog.text, currentDialog.isChoice));
	}

	private IEnumerator TypeLine(string text, bool isChoice)
	{
		textUI.text = "";

		foreach (char c in text.ToCharArray())
		{
			textUI.text += c;
			yield return new WaitForSeconds(_currentSpeed);
		}

		_isTyping = false;

		if (isChoice) {

			_isChoosing = true;
			_isChoiceYes = true;

			menuChoice.SetActive(true);
			yesArrow.SetActive(true);

		} else {

			arrowEnd.SetActive(true);
		}
	}

	public bool getIsDialogOn() {

		return _isDialogOn;
	}
}
