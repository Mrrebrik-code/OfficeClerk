using Interactive.Things;
using System;
using System.Collections;
using UnityEngine;


namespace AI
{
	public class DreamState : MonoBehaviour, IWorkmanState
	{
		public Action CallBack { get; set; }

		public WorkmanAI AI { get; private set; }

		[SerializeField] private Transform _positionDream;
		private Bed _bed;
		private bool _isDream = false;

		public void Execute(WorkmanAI ai)
		{
			AI = ai;
			AI.Move(_positionDream.position);
		}

		public void UpdateState()
		{
			if (AI.Properties.DreamValue != 100)
			{
				Dream();
			}
		}

		private void Dream()
		{
			if (_bed != null)
			{
				if (_isDream == false)
				{
					StartCoroutine(DelayDream());
				}
			}
		}

		private IEnumerator DelayDream()
		{
			_isDream = true;
			while (AI.Properties.DreamValue != 100)
			{
				yield return new WaitForSeconds(2f);
				AI.Properties.DreamValue = 20;
			}
			if (AI.Properties.DreamValue == 100)
			{
				_isDream = false;
				_bed = null;
				CallBack?.Invoke();
			}
		}
		public void SetPoint(Transform transform)
		{
			_positionDream = transform;
		}
		public void SetBedUsing(Bed bed)
		{
			_bed = bed;
		}
	}
}
