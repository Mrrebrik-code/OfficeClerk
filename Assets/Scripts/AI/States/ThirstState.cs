using Interactive.Things;
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
		private WaterApparate _waterApparate;

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
			if (_waterApparate != null)
			{
				_waterApparate.WaterBox.Drank(AI);

				if (AI.Properties.ThirstValue == 100)
				{
					_waterApparate = null;
					StartCoroutine(ThirstDelay());
					
				}
			}
		}
		private IEnumerator ThirstDelay()
		{
			yield return new WaitForSeconds(1f);
			CallBack?.Invoke();
		}
		public void SetWatterApparateUsing(WaterApparate waterApparate)
		{
			_waterApparate = waterApparate;
		}
	}
}
