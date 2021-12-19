using System;

namespace Bank
{
	public class Diamonds: IValue
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
		public Diamonds(int count)
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
				BankManager.Instance.History.EnqueueTransaction(new Transaction(count, TypeTransaction.Diamnonds));
				return true;
			}
			return false;
		}

		public void Withdraw(int count, Action<bool> callback)
		{
			if (Count >= count)
			{
				Count = -count;
				
				BankManager.Instance.History.EnqueueTransaction(new Transaction(count, TypeTransaction.Diamnonds));
				callback?.Invoke(true);
			}
			callback?.Invoke(false);
		}
	}
}

