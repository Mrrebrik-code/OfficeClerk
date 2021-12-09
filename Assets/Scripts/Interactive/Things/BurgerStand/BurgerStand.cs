using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Interactive.Things
{
	public class BurgerStand : SingletonMono<BurgerStand>
	{
		[SerializeField] private InfoBurgerStand _infoBurgerStand;
		[SerializeField] private float _cookingTime;
		[SerializeField] private List<Burger> _burgers = new List<Burger>();
		private List<Burger> _doneBurgers = new List<Burger>();
		private bool _cooking = false;


		public override void Awake()
		{
			base.Awake();
			_burgers.ForEach(burger =>
			{
				burger.OnEateBurger += EatBurger;
				burger.IsDone = false;
				burger.gameObject.SetActive(false);
			});
		}
		public void CookingBurgers(int count)
		{
			if (_cooking == false)
			{
				var burgers = new List<Burger>();
				foreach (var burger in _burgers)
				{
					if (burger.IsDone == false)
					{
						burgers.Add(burger);
					}
				}
				if (burgers != null)
				{

					StartCoroutine(DelayCooking(count, burgers));
				}
				else
				{
					Debug.Log("Мы приготовили вам уже 5 гамбургеров! Нельзя готовить больше 5 штук на прилавок!");
				}
			}
			else
			{
				Debug.Log("Уже готовитя гамбургеры! Пожалуйста подождите!");
			}
		}

		private IEnumerator DelayCooking(int count, List<Burger> burgers)
		{
			_cooking = true;
			for (int i = 0; i < count; i++)
			{
				yield return new WaitForSeconds(_cookingTime);
				burgers[i].IsDone = true;
				burgers[i].gameObject.SetActive(true);
				_doneBurgers.Add(burgers[i]);
				_burgers.Remove(burgers[i]);
				_infoBurgerStand.SetCountBurgers(_doneBurgers.Count);
			}
			_cooking = false;
		}

		private Burger HasDoneBurger()
		{
			if (_doneBurgers.Count <= 0) return null;
			else
			{
				return _doneBurgers[0];
			}
		}

		public void EatBurger(Burger burger = null, WorkmanAI ai = null)
		{
			if(burger != null)
			{
				_burgers.Add(burger);
				_doneBurgers.Remove(burger);
				burger.gameObject.SetActive(false);
			}
			else
			{
				if (ai == null) return;

				Burger burgerTemp = HasDoneBurger();

				if(burgerTemp != null)
				{
					ai.Properties.HungryValue = 100;
					_burgers.Add(burgerTemp);
					_doneBurgers.Remove(burgerTemp);
					burgerTemp.gameObject.SetActive(false);
					_infoBurgerStand.SetCountBurgers(_doneBurgers.Count);
				}
			}
			
		}
	}
}
