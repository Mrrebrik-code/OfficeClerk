using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Bank
{
	public class BankManager : SingletonMono<BankManager>
	{
		public Action OnUpdateValueUI;
		public Cookies Cookies { get; private set; }
		public Diamonds Diamonds { get; private set; }
		public HistoryTransaction History { get; private set; }
		public override void Awake()
		{
			base.Awake();
			History = new HistoryTransaction();
			Cookies = new Cookies(Configurator.Instance.Data.CountCookiesStart);
			Diamonds = new Diamonds(Configurator.Instance.Data.CountDiamondStart);

			OnUpdateValueUI?.Invoke();
		}
	}
}


