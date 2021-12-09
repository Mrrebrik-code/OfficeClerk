using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using Utils;

namespace Core
{
	public class GameManager : SingletonMono<GameManager>
	{
		private List<WorkmanAI> _workmans = new List<WorkmanAI>();

		public override void Awake()
		{
			base.Awake();
		}
		public void AddWorkman(WorkmanAI workman)
		{
			_workmans.Add(workman);
			Debug.Log("Добавлен новый работник в штаб!");
		}
	}
}

