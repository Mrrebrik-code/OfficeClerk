using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AI
{
	public class WorkState : MonoBehaviour, IWorkmanState
	{
		public Action CallBack { get; set; }
		public WorkmanAI AI { get; private set; }

		[SerializeField] private Transform _positionWork;

		private bool _isWorkDone = true;

		public void UpdateState()
		{
			if (_isWorkDone == true)
			{
				_isWorkDone = false;
				StartCoroutine(Working());
			}
		}

		public void SetPoint(Transform transform)
		{
			_positionWork = transform;
		}
		private IEnumerator Working()
		{
			yield return new WaitForSeconds(5f);

			if (AI.Properties.IsReady)
			{
				Debug.Log("Заработал одну печеньку!");
				AI.Properties.ThirstValue = -4;
				AI.Properties.HungryValue = -4;
				AI.Properties.DreamValue = -4;
			}
			else
			{
				CallBack?.Invoke();
			}

			_isWorkDone = true;
		}

		public void Execute(WorkmanAI ai)
		{
			Debug.Log("Рабоче состояние установлено!");
			AI = ai;
			AI.Move(_positionWork.position);
		}
	}
}
