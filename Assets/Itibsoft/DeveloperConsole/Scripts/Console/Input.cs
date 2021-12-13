using UnityEngine;
using TMPro;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class Input : MonoBehaviour
	{
		[SerializeField] private TMP_InputField _inputField;
		public bool IsAllowInput { get; private set; }

		public void SetSelection(bool selection) => IsAllowInput = selection;
		public void SetInputText(string text) => _inputField.text = text;
		public void ClearInputField() => _inputField.text = "";

		public void TrimInputText()
		{
			if (!_inputField.text.Contains("/"))
			{
				var tempText = _inputField.text.Insert(0, "/");
				_inputField.text = tempText;
			}	
		}

		public string GetInputText()
		{
			return _inputField.text;
		}
	}
}