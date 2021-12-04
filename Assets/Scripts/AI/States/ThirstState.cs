using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
	public class ThirstState : MonoBehaviour, IWorkmanState
	{
		[SerializeField] private Transform _positionWater;
		public Action CallBack { get; set; }

		public WorkmanAI AI { get; private set; }

		public void Execute(WorkmanAI ai)
		{
			AI = ai;
			AI.Move(_positionWater.position);
		}

		public void UpdateState()
		{
			if (AI.Properties.ThirstValue != 100)
			{
				Thirst();
			}
		}

		private void Thirst()
		{
			if (AI.Agent.destination == _positionWater.position)
			{

			}
		}
	}
}
