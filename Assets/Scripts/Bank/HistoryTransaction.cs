using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Bank
{
	public class HistoryTransaction
	{
		private List<Transaction> _transactions = new List<Transaction>();
		public void EnqueueTransaction(Transaction transaction)
		{
			_transactions.Add(transaction);
		}

		public Transaction PeekTransaction()
		{
			return _transactions[_transactions.Count];
		}

		public Transaction DequeueTransaction()
		{
			var temp = _transactions[_transactions.Count - 1];
			_transactions.Remove(temp);

			return temp;
		}

		public void UndoTransaction()
		{
			if(_transactions.Count > 0)
			{
				var transaction = DequeueTransaction();
				switch(transaction.Type)
				{
					case TypeTransaction.Cookies:
						BankManager.Instance.Cookies.Put(transaction.Price);
						Debug.LogError("Вернули: " + transaction.Price);
						break;
					case TypeTransaction.Diamnonds:
						BankManager.Instance.Diamonds.Put(transaction.Price);
						break;
				}
			}
		}
	}
}
