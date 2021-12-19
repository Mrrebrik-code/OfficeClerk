using System.Collections.Generic;
using UnityEngine;


namespace Execution
{
	public class ExecutionList : MonoBehaviour
	{
		[SerializeField] private Execution _executionPrefab;
		private List<Execution> _executions = new List<Execution>();
		public void AddExecution(ExecutionInfo execution)
		{
			var tempExecution = Instantiate(_executionPrefab, transform);
			tempExecution.OnDestroyAction += OnDestroyExecutionHandler;
			tempExecution.Init(execution);
			_executions.Add(tempExecution);
		}

		private void OnDestroyExecutionHandler(Execution execution)
		{
			_executions.Remove(execution);
			Debug.LogError("Successful!");
		}
	}
}
