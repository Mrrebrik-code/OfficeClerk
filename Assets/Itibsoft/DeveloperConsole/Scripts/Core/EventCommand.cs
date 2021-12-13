using UnityEngine;
using UnityEngine.Events;

namespace Itibsoft.ConsoleDeveloper.Core
{
	[CreateAssetMenu(fileName = "EventCommand", menuName = "Itibsoft/ConsoleDeveloper/EventCommand")]
	public class EventCommand : ScriptableObject, ICommand
	{
		[SerializeField] private string _name;
		[SerializeField] private string _description;
		public UnityEvent EventExecute;
		public string Name { get { return _name; } set { _name = value; } }

		public string Description { get { return _description; } set { _description = value; } }

		public void Execute()
		{
			EventExecute?.Invoke();
		}
	}
}
