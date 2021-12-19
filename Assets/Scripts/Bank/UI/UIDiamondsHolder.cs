using TMPro;
using UnityEngine;

namespace Bank
{
	public class UIDiamondsHolder : MonoBehaviour, IValueHolder
	{
		[SerializeField] private TMP_Text _diamondsCountText;

		public void UpdateText()
		{
			_diamondsCountText.text = BankManager.Instance.Diamonds.Count.ToString();
		}
	}
}
