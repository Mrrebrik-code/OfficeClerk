using System;
using UnityEngine;

namespace Bank
{
	public class Cookies : IValue
	{
		private int _count;
		public int Count
		{
			get { return _count; }
			set
			{
				_count += value;
				if (_count <= 0) _count = 0;

				BankManager.Instance.OnUpdateValueUI?.Invoke();
			}
		}
		public Cookies(int count)
		{
			_count = count;
		}
		public bool Put(int count)
		{
			Count = count;
			return true;
		}
		public void Put(int count, Action<bool> callback)
		{
			Count = count;
			callback?.Invoke(true);
		}

		public bool Withdraw(int count)
		{
			if (Count >= count)
			{
				Count = -count;
				BankManager.Instance.History.EnqueueTransaction(new Transaction(count, TypeTransaction.Cookies));
				return true;
			}
			return false;
		}

		public void Withdraw(int count, Action<bool> callback)
		{
			if (Count >= count)
			{
				Count = -count;
				Debug.LogError("Потрачено: " + count);
				BankManager.Instance.History.EnqueueTransaction(new Transaction(count, TypeTransaction.Cookies));
				callback?.Invoke(true);
				return;
			}
			callback?.Invoke(false);
		}
	}
}

