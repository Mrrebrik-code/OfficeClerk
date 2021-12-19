using UnityEngine;

[CreateAssetMenu(fileName = "Purchase", menuName = "SO/Purchase")]
public class PurchaseProduct : ScriptableObject
{
	[SerializeField] private int _price;
	[SerializeField] private int _count;
	[SerializeField] private Sprite _icon;
	[SerializeField] private TypePurchase _type;

	public int Price { get { return _price; } }
	public int Count { get{ return _count; } }
	public Sprite Icon{ get{ return _icon; } }
	public TypePurchase Type { get{ return _type; } }
}
