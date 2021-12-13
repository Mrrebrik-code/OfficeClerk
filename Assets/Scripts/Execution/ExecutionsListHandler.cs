using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace Execution
{
	public class ExecutionsListHandler : SingletonMono<ExecutionsListHandler>
	{
		[SerializeField] private ExecutionList _executionList;
		[SerializeField] private List<ExecutionsIcon> _executeonsIcon = new List<ExecutionsIcon>();
		private Dictionary<TypeExecutions, ExecutionsIcon> _dictionaryExecutionsIcon = new Dictionary<TypeExecutions, ExecutionsIcon>();
		public override void Awake()
		{
			base.Awake();
			_executeonsIcon.ForEach(execution =>
			{
				_dictionaryExecutionsIcon.Add(execution.Type, execution);
			});

		}
		public void AddExecution(TypeExecutions type, float time)
		{
			var execution = new ExecutionInfo(time, _dictionaryExecutionsIcon[type].Icon);
			_executionList.AddExecution(execution);
		}


		[Serializable]
		private class ExecutionsIcon
		{
			public TypeExecutions Type;
			public Sprite Icon;
		}
	}
}
