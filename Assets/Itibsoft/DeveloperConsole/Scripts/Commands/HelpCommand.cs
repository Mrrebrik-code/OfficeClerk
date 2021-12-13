using System;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	[Command]
	public class HelpCommand : ICommand
	{
		public string Name { get => "Help"; set { } }
		public string Description { get => "Info more command"; set { } }

		public void Execute()
		{

			var listCommands = Tools.GetColoredRichText("Commands:", TypeColor.Green) + Environment.NewLine;
			for (int i = 0; i < CommandsList.Instance.Commands.Count; i++)
			{
				listCommands += $"{i + 1}. {CommandsList.Instance.Commands[i].Name} - {CommandsList.Instance.Commands[i].Description}" + Environment.NewLine;
			}
			Logger.Instance.AddLog(listCommands, this);
		}
	}
}
