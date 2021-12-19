using TMPro;
using UnityEngine;

namespace Bank
{
	public class UICookiesHolder : MonoBehaviour, IValueHolder
	{
		[SerializeField] private TMP_Text _cookiesCountText;

		public void UpdateText()
		{
			_cookiesCountText.text = BankManager.Instance.Cookies.Count.ToString();
		}
	}
}
