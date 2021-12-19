using UnityEngine;

namespace Shop.Delivery
{
	public class Courier : MonoBehaviour
	{
		private DeliveryOrder _orderDelivery = null;
		public bool IsFree { get; set; } = true;

		public bool TrySetDeliveryOrder(DeliveryOrder order)
		{
			if (IsFree)
			{
				IsFree = false; 
				_orderDelivery = order;
				return true;
			}
			return false;
		}

		private void MoveToDestinationOrder()
		{

		}
	}
}
