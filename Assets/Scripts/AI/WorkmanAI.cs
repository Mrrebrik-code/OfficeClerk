using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class WorkmanAI : MonoBehaviour, IWorkman
	{
		[SerializeField] PropertiesInfo _info;
		private Animator _animator;

		public List<IWorkmanState> States { get; private set; }
		public IWorkmanState CurrentState { get; private set; }
		public NavMeshAgent Agent { get; private set; }

		public WorkmanProperties Properties { get; private set; }
		private bool _isInit = false;



		public void Start()
		{
			
		}

		private void Init()
		{
			_animator = GetComponent<Animator>();
			Properties = new WorkmanProperties(10, 10, 10);
			Properties.OnChange += OnChangePropertiesHandler;
			_info.SetInfo(Properties);
			Agent = GetComponent<NavMeshAgent>();
			

			SetState(HasStateType(TypeState.Work));
			_isInit = true;
		}

		public void SetPointToStates(Transform pointWork, Transform pointThirst, Transform pointHungry, Transform pointDream)
		{
			States = GetComponents<IWorkmanState>().ToList();
			//Сделать систему установки позиций для работника!
			foreach (var state in States)
			{
				if(state is WorkState work)
				{
					work.SetPoint(pointWork);
				}
				else if(state is ThirstState thirst)
				{
					thirst.SetPoint(pointThirst);
				}
				else if (state is HungryState hungry)
				{
					hungry.SetPoint(pointHungry);
				}
				else if (state is DreamState dream)
				{
					dream.SetPoint(pointDream);
				}
			}
			Init();
		}

		public void Update()
		{
			if (_isInit)
			{
				_animator.SetBool("Move", transform.position != Agent.destination);
				if (CurrentState != null)
				{
					CurrentState.UpdateState();
				}
			}
			
		}

		public void OnCallBackHandler()
		{
			CurrentState.CallBack -= OnCallBackHandler;
			CurrentState = null;
			IWorkmanState tempState = null;

			if (Properties.IsReady == false)
			{
				Debug.Log("Не могу работать, мои жизненные свойсва нужно восполнить!");
				if (Properties.ThirstValue == 0)
				{
					Debug.Log("Я хочу пить, пойду попью воды!");
					tempState = HasStateType(TypeState.Thirst);
				}
				else if (Properties.HungryValue == 0)
				{
					Debug.Log("Я проголадался, пойду покушаю!");
					tempState = HasStateType(TypeState.Hungry);
				}
				else
				{
					Debug.Log("Я устал, пойду посплю!");
					tempState = HasStateType(TypeState.Dream);
				}
			}
			else
			{
				Debug.Log("Готов к работе! Пошел работать!");
				tempState = HasStateType(TypeState.Work);
			}

			SetState(tempState);
		}

		private void OnChangePropertiesHandler()
		{
			_info.SetInfo(Properties);
		}

		private IWorkmanState HasStateType(TypeState type)
		{
			Type typeState;
			switch (type)
			{
				case TypeState.Work:
					typeState = typeof(WorkState);
					break;
				case TypeState.Thirst:
					typeState = typeof(ThirstState);
					break;
				case TypeState.Hungry:
					typeState = typeof(HungryState);
					break;
				case TypeState.Dream:
					typeState = typeof(DreamState);
					break;
				default:
					typeState = null;
					break;
			}
			if (typeState == null) return null;

			foreach (var state in States)
			{
				if (state.GetType() == typeState)
				{
					return state;
				}
			}

			return null;
		}

		public void Move(Vector3 targetMove)
		{
			Agent.SetDestination(targetMove);
		}

		public void SetState(IWorkmanState state)
		{

			if (state == null) return;

			Debug.Log("Установка состояния: " + state.GetType());
			CurrentState = state;
			CurrentState.Execute(this);
			CurrentState.CallBack += OnCallBackHandler;
		}
	}
}
