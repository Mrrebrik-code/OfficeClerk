using Interactive.Things;
using System;
using UnityEngine;

namespace AI
{
	public class HungryState : MonoBehaviour, IWorkmanState
	{
		public Action CallBack { get; set; }
		public WorkmanAI AI { get; private set; }

		[SerializeField] private Transform _positionHungry;
		private BurgerStand _burgerStand;

		public void Execute(WorkmanAI ai)
		{
			AI = ai;
			AI.Move(_positionHungry.position);
		}

		public void UpdateState()
		{
			if (AI.Properties.HungryValue != 100)
			{
				Hungry();
			}
		}

		private void Hungry()
		{
			if(_burgerStand != null)
			{
				_burgerStand.EatBurger(null, AI);

				if(AI.Properties.HungryValue == 100)
				{
					Debug.Log("Я покушал! Спасибо!");
					_burgerStand = null;
					CallBack?.Invoke();
				}
				else
				{
					Debug.Log("Что-то похоже нет гамбургеров! Надо бы купить!");
				}
				
			}
		}

		public void SetPoint(Transform transform)
		{
			_positionHungry = transform;
		}
		public void SetBurgerStandUsing(BurgerStand burgerStand)
		{
			_burgerStand = burgerStand;
		}
	}
}
