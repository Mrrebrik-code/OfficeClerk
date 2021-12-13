using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	[Command]
	public class ClearConsoleCommand : ICommand
	{
		public  string Name { get => "Clear"; set{ } }

		public string Description { get => "Clear console"; set { } }

		public void Execute()
		{
			Logger.Instance.ClearLog();
			HistoryCommands.Instance.ClearHistory();
		}
	}
}
