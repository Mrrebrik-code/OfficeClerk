using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
	public static Inventory Instance;
	private List<IThings> _things = new List<IThings>();

	private void Awake()
	{
		Instance = this;
	}
	public void AddThing(IThings thing)
	{
		_things.Add(thing);
	}

	public IThings PutThing(TypeObject type)
	{
		foreach (var thingTemp in _things)
		{
			if(thingTemp.Type == type)
			{
				_things.Remove(thingTemp);
				return thingTemp;
			}
		}
		return null;
	}
}
