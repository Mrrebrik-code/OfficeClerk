using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public interface IWorkmanState 
{
	Action CallBack { get; set; }
	WorkmanAI AI { get; }
	void UpdateState();
	void Execute(WorkmanAI ai);

}
