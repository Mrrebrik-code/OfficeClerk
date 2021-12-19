using UnityEngine;
using UnityEngine.UI;

public class ButtonPurchase : MonoBehaviour
{
	[SerializeField] private TypePurchaseMenu _type;

	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(Open);
	}

	private void Open()
	{
		PurchaseManager.Instance.Open(_type);
	}
}
