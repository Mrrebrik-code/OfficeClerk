using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WorkmanAI : MonoBehaviour, IWorkman
{
	[SerializeField] PropertiesInfo _info;
	private Animator _animator;

	public List<IWorkmanState> States { get; private set; }
	public IWorkmanState CurrentState { get; private set; }
	public NavMeshAgent Agent { get; private set; }

	public WorkmanProperties Properties { get; private set; }

	public void OnCallBackHandler()
	{
		CurrentState.CallBack -= OnCallBackHandler;
		CurrentState = null;
		foreach (var state in States)
		{
			if (state is ThirstState stateOut)
			{
				SetState(stateOut);
				break;
			}
		}
	}

	public void Start()
	{
		_animator = GetComponent<Animator>();
		Properties = new WorkmanProperties(10, 10, 10);
		Properties.OnChange += OnChangePropertiesHandler;
		_info.SetInfo(Properties);
		Agent = GetComponent<NavMeshAgent>();
		States = GetComponents<IWorkmanState>().ToList();
		
		foreach (var state in States)
		{
			if (state is WorkState stateOut)
			{
				SetState(stateOut);
				break;
			}
		}
	}

	private void OnChangePropertiesHandler()
	{
		_info.SetInfo(Properties);
	}

	public void Update()
	{
		_animator.SetBool("Move", transform.position != Agent.destination);
		if (CurrentState != null)
		{
			CurrentState.UpdateState();
		}
	}

	public void Move(Vector3 targetMove)
	{
		Agent.SetDestination(targetMove);
	}

	public void SetState(IWorkmanState state)
	{
		CurrentState = state;
		CurrentState.Execute(this);
		CurrentState.CallBack += OnCallBackHandler;
	}
}
