using System;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class Buffer : MonoBehaviour
	{
		[SerializeField] private TMP_Text _bufferText;
		[SerializeField] private Input _input;

		private string _tempBuffer = "";

		public void BufferUpdate()
		{
			if(!Tools.IsNull(_input.GetInputText()))
			{
				_tempBuffer = "";
				CommandsList.Instance.Commands.ForEach(command =>
				{
					string tempNameCommand = "";
					for (int i = 0; i < _input.GetInputText().Length; i++)
					{
						if (i < command.Name.Length) tempNameCommand += command.Name[i];
						else break;
					}

					Regex regex = new Regex(_input.GetInputText().ToLower().Trim('/'));
					MatchCollection matches = regex.Matches(tempNameCommand.ToLower());

					if (matches.Count > 0 && !Tools.Contains(_tempBuffer, tempNameCommand, toLower: true))
							_tempBuffer += $"{command.Name} - {command.Description}" + Environment.NewLine;
				});
			}
			else _tempBuffer = "";

			if(!Tools.Compare(_bufferText.text, _tempBuffer)) 
				_bufferText.text = _tempBuffer;
				
		}
	}
}