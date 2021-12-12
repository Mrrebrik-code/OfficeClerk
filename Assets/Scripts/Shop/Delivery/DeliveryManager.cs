using Interactive;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace Shop.Delivery
{
	public class DeliveryManager : SingletonMono<DeliveryManager>
	{
		[SerializeField] private Courier _courier;
		[SerializeField] private Transform _pointDeliveryWater;

		private void Start()
		{
			IThings test = null;
			SetDeliveryTarget(test, 5);
		}

		public void SetDeliveryTarget(IThings thing, int count)
		{
			var order = new DeliveryOrder(thing, count, 10f);
			StartCoroutine(QueueFreeCourier(order));
		}

		private IEnumerator QueueFreeCourier(DeliveryOrder order)
		{
			while (!_courier.IsFree)
			{
				yield return null;
			}

			var isDelivered = _courier.TrySetDeliveryOrder(order);

			if (isDelivered)
			{
				order.ToOrderDelivery(_pointDeliveryWater.position, () =>
				{
					//Переместить в позицию
					_courier.IsFree = true;
					Debug.LogError("Test 10f");
				});
			}
			
		}
	}
}
