using AI;
using System;
using UnityEngine;

namespace Interactive.Things 
{
	public class Burger : MonoBehaviour, IThings
	{
		public Action<Burger, WorkmanAI> OnEateBurger;
		public bool IsDone { get; set; }
		public TypeObject Type { get; set; }

		private void Awake()
		{
			Type = TypeObject.Burger;
		}
		public void Execute()
		{
			OnEateBurger?.Invoke(this, null);
		}
	}
}


