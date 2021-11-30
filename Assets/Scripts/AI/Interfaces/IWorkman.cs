using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public interface IWorkman
{
	NavMeshAgent Agent { get; }
	List<IWorkmanState> States { get; }
	IWorkmanState CurrentState { get; }

	WorkmanProperties Properties { get; }

	void OnCallBackHandler();
	void SetState(IWorkmanState state);

	void Start();
	void Update();

	void Move(Vector3 targetMove);
}
