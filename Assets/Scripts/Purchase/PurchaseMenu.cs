using TMPro;
using UnityEngine;

public class PurchaseMenu : MonoBehaviour
{
	[SerializeField] private GameObject _diamondMenu;
	[SerializeField] private GameObject _cookiesMenu;

	[SerializeField] private TMP_Text _namePanelText;

	public void OpenDiamondsPurchase()
	{
		_namePanelText.text = "Алмазы";
		_cookiesMenu.SetActive(false);
		_diamondMenu.SetActive(true);
	}

	public void OpenCookiesPurchase()
	{
		_namePanelText.text = "Печеньки";
		_cookiesMenu.SetActive(true);
		_diamondMenu.SetActive(false);
	}
}
