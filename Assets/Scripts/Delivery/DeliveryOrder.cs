using Interactive;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Shop.Delivery
{
	public class DeliveryOrder : IDelivery
	{
		public float TimeDelivery { get; private set; } = 10f;
		public TypeObject Thing { get; private set; }
		public Vector3 Destination { get; private set; }
		public bool IsDelivered { get; private set; } = false;

		public DeliveryOrder(TypeObject thing, int count, float time)
		{
			Thing = thing;
			TimeDelivery = time;

			//Сделать делигацию заказа курьеру, который этим предметом занимается.
			//Если допустим курьер занимается доставкой воды, то он не может принять заказ доставки пиццы.
		}

		public void ToOrderDelivery(Vector3 destination, Action callback)
		{
			Destination = destination;
			DeliveryTiming(callback);
		}

		private async void DeliveryTiming(Action callback)
		{
			await Task.Run(() =>
			{
				TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(TimeDelivery));
				Thread.Sleep(time);
				IsDelivered = true;
				callback?.Invoke();
			});
		}
	}
}
