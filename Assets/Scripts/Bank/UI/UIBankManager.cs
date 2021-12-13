using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Bank
{
	public class UIBankManager : MonoBehaviour
	{
		[SerializeField] private UICookiesHolder _cookiesHolder;
		[SerializeField] private UIDiamondsHolder _diamondsHolder;
		private List<IValueHolder> _holders = new List<IValueHolder>();
		public void Awake()
		{
			_holders.Add(_cookiesHolder);
			_holders.Add(_diamondsHolder);

			BankManager.Instance.OnUpdateValueUI += OnUpdateHandler;
		}

		private void OnUpdateHandler()
		{
			_holders.ForEach(holder => holder.UpdateText());
		}
	}
}
