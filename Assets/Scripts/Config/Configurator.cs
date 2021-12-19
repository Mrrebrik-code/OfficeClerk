using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Configurator : SingletonMono<Configurator>
{
	public Configuration Data{ get; private set; }

	public override void Awake()
	{
		IsDontDestroyOnLoad = true;
		base.Awake();
		Data = Resources.LoadAll<Configuration>("Config")[0];
	}
}
