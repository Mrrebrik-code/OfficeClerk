using Interactive;
using System.Collections;
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
		}

		public void SetDeliveryTarget(TypeObject thing, int count)
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
