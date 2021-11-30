using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	}
}
