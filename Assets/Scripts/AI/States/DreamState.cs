using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
	public class DreamState : MonoBehaviour, IWorkmanState
	{
		public Action CallBack { get; set; }

		public WorkmanAI AI { get; private set;}

		public void Execute(WorkmanAI ai)
		{

		}

		public void UpdateState()
		{

		}
	}
}
