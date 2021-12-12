﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using Utils;

namespace Core
{
	public class GameManager : SingletonMono<GameManager>
	{
		private List<WorkmanAI> _workmans = new List<WorkmanAI>();
		[SerializeField] private List<TableWorkman> _tablesWorkman = new List<TableWorkman>();
		[SerializeField] private Transform _pointThirst;
		[SerializeField] private Transform _pointHugry;
		[SerializeField] private Transform _pointDream;
		public override void Awake()
		{
			base.Awake();
		}
		public void AddWorkman(WorkmanAI workman)
		{
			_workmans.Add(workman);

			foreach (var table in _tablesWorkman)
			{
				if(table.IsFree && table.IsBuy)
				{
					workman.SetPointToStates(table.GetPoint(), _pointThirst, _pointHugry, _pointDream);
					table.SetWorkman(workman);
					break;
				}
			}
			Debug.Log("Добавлен новый работник в штаб!");
		}
	}
}

