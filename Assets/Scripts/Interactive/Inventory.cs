using Interactive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Interactive
{
	public class Inventory : SingletonMono<Inventory>
	{
		private List<IThings> _things = new List<IThings>();

		public void AddThing(IThings thing)
		{
			_things.Add(thing);
		}

		public override void Awake()
		{
			base.Awake();
		}

		public IThings PutThing(TypeObject type)
		{
			foreach (var thingTemp in _things)
			{
				if (thingTemp.Type == type)
				{
					_things.Remove(thingTemp);
					return thingTemp;
				}
			}
			return null;
		}
	}
}
