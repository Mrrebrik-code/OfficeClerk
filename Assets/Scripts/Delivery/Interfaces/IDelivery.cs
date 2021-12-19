using Interactive;
using System;
using UnityEngine;

namespace Shop.Delivery
{
	public interface IDelivery
	{
		float TimeDelivery { get; }
		TypeObject Thing { get; }
		Vector3 Destination{ get; }
		bool IsDelivered { get; }
		void ToOrderDelivery(Vector3 destination, Action callback);
	}
}
