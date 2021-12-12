using Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shop.Delivery
{
	public interface IDelivery
	{
		float TimeDelivery { get; }
		IThings Thing { get; }
		Vector3 Destination{ get; }
		bool IsDelivered { get; }
		void ToOrderDelivery(Vector3 destination, Action callback);
	}
}
