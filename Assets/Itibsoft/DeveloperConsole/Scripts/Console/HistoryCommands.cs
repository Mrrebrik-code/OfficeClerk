using Itibsoft.ConsoleDeveloper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class HistoryCommands
	{
		public static HistoryCommands Instance;

		private List<ICommand> _historyCommands = new List<ICommand>();
		private int _index = default;

		public HistoryCommands() => Instance = this;

		public void AddHistory(ICommand command)
		{
			_historyCommands.Add(command);
			_index = _historyCommands.Count - 1;
		}

		public ICommand GetCommandFromHistory(bool vector)
		{
			if (_historyCommands.Count < 1) return null;

			if (vector) _index++;
			else _index--;

			if (_index < 0) _index = 0;
			else if (_index >= _historyCommands.Count) _index = _historyCommands.Count - 1;

			return _historyCommands[_index];
		}

		public void ClearHistory()
		{
			_historyCommands = new List<ICommand>();
			_index = default;
		}
	}
}
