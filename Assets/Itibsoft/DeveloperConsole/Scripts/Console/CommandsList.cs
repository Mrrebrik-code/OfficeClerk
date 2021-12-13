using Itibsoft.ConsoleDeveloper.Commands;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using System.Reflection;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class CommandsList : Singleton<CommandsList>
	{
		public List<ICommand> Commands = new List<ICommand>();
		

		public override void Awake()
		{
			IsDontDestroyOnLoad = true;
			base.Awake();
			Commands.AddRange(AddingCommands());
		}

		public ICommand GetCommand(string name)
		{
			if (Tools.IsNull(name)) return null;

			ICommand tempCommand = null;

			foreach (var command in Commands)
			{
				if (command.Name.ToLower() == name.ToLower().Trim('/'))
				{
					tempCommand = command;
					break;
				}
			}

			return tempCommand;
		}

		private List<ICommand> AddingCommands()
		{
			List<ICommand> commands = new List<ICommand>();

			IEnumerable<Type> typesWithMyAttribute =
			from type in Assembly.GetExecutingAssembly().GetTypes()
			where type.IsDefined(typeof(CommandAttribute), false)
			select type;

			typesWithMyAttribute.ToList().ForEach(type =>
			{
				commands.Add(Activator.CreateInstance(type) as ICommand);
			});

			UnityEngine.Object[] eventCommandsObjects = Resources.LoadAll("EventCommands", typeof(ICommand));

			eventCommandsObjects.ToList().ForEach(eventCommandObject => 
			{
				if (eventCommandObject is ICommand command) commands.Add(command);
			});

			return commands;
		}
	}
}
