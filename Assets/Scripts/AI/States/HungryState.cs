using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
	public class HungryState : MonoBehaviour, IWorkmanState
	{
		public Action CallBack { get; set; }
		public WorkmanAI AI { get; private set; }

		[SerializeField] private Transform _positionHungry;

		public void Execute(WorkmanAI ai)
		{
			AI = ai;
			AI.Move(_positionHungry.position);
		}

		public void UpdateState()
		{
			if (AI.Properties.HungryValue != 100)
			{
				Hungry();
			}
		}

		private void Hungry()
		{
			if (AI.Agent.destination == _positionHungry.position)
			{

			}
		}
	}
}
