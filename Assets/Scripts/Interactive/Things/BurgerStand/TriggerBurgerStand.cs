using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive.Things
{
	public class TriggerBurgerStand : MonoBehaviour
	{
		[SerializeField] private BurgerStand _burgerStand;
		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("test");
			HungryState workman = other.GetComponentInChildren<HungryState>();

			if (workman != null)
			{
				Debug.Log("test3");
				workman.SetBurgerStandUsing(_burgerStand);
			}
			else
			{
				Debug.Log("test2");
			}
		}
	}
}


