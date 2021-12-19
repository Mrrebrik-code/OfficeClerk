using AI;
using UnityEngine;

namespace Interactive.Things
{
	public class TriggerBurgerStand : MonoBehaviour
	{
		[SerializeField] private BurgerStand _burgerStand;
		private void OnTriggerEnter(Collider other)
		{
			HungryState workman = other.GetComponentInChildren<HungryState>();

			if (workman != null)
			{
				workman.SetBurgerStandUsing(_burgerStand);
			}
		}
	}
}


