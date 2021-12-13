using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;
using System;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class ConsoleDeveloper : MonoBehaviour
	{
		[SerializeField] private InputHandler _inputHandler;
		[SerializeField] private GameObject _consoleObject;
		[SerializeField] private Logger _logger;
		[SerializeField] private Buffer _buffer;
		[SerializeField] private Input _input;
		[SerializeField] private GameObject _fader;

		private HistoryCommands _history = new HistoryCommands();

		private void Start() => _inputHandler.KeyDownEvent += OnKeyHandler;

		private void OnKeyHandler(KeyCode key)
		{
			switch(key)
			{
				case KeyCode.BackQuote:
					var temp = !_consoleObject.activeInHierarchy;
					_consoleObject.SetActive(temp);
					Time.timeScale = Convert.ToInt32(!temp);
					_fader.SetActive(temp);
					break;
				case KeyCode.Return:
					Send();
					break;
				case KeyCode.UpArrow:
					GetHistoryCommandToInput(vector: true);
					break;
				case KeyCode.DownArrow:
					GetHistoryCommandToInput(vector: false);
					break;
			}
		}

		public void GetHistoryCommandToInput(bool vector)
		{
			if (_input.IsAllowInput)
			{
				ICommand command = _history.GetCommandFromHistory(vector);
				if (command != null) _input.SetInputText(command.Name);
			}
		}
		public void Send()
		{
			ICommand command = CommandsList.Instance.GetCommand(_input.GetInputText());

			if (command != null) ExecuteCommand(command);
			else Logger.Instance.AddLog(Tools.GetColoredRichText($"Error: ", TypeColor.Red) + _input.GetInputText() + " - " + Tools.GetColoredRichText("This command is not recognized", TypeColor.Yellow) + Environment.NewLine);

			_input.ClearInputField();
		}

		private void ExecuteCommand(ICommand command)
		{
			_history.AddHistory(command);
			command.Execute();
		}
	}
}
