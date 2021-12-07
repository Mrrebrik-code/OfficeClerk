using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive.Things
{
	public class BurgerStand : MonoBehaviour
	{
		[SerializeField] private float _cookingTime;
		[SerializeField] private List<Burger> _burgers = new List<Burger>();
		private List<Burger> _doneBurgers = new List<Burger>();

		private void Awake()
		{
			_burgers.ForEach(burger =>
			{
				burger.OnEateBurger += EatBurger;
				burger.IsDone = false;
				burger.gameObject.SetActive(false);
			});
			CookingBurgers(5);
		}
		public void CookingBurgers(int count)
		{
			var burgers = new List<Burger>();
			foreach (var burger in _burgers)
			{
				if (burger.IsDone == false)
				{
					burgers.Add(burger);
				}
			}
			if(burgers != null)
			{
				StartCoroutine(DelayCooking(count, burgers));
			}
			
		}

		private IEnumerator DelayCooking(int count, List<Burger> burgers)
		{
			for (int i = 0; i < count; i++)
			{
				yield return new WaitForSeconds(_cookingTime);
				burgers[i].IsDone = true;
				burgers[i].gameObject.SetActive(true);
				_doneBurgers.Add(burgers[i]);
				_burgers.Remove(burgers[i]);
			}
		}

		public void EatBurger(Burger burger)
		{
			_burgers.Add(burger);
			_doneBurgers.Remove(burger);
			burger.gameObject.SetActive(false);
		}
	}
}
