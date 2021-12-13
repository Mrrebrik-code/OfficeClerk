using Itibsoft.ConsoleDeveloper.Utils;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Core
{
	public interface ICommand
	{
		string Name { get; set; }
		string Description { get; set; }
		void Execute();
	}
}
