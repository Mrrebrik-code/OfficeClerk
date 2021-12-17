using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Popup", menuName = "SO/Popup")]
public class Popup : ScriptableObject
{
	[SerializeField] private string _messageText;
	[SerializeField] private TypePopup _type;
	[SerializeField] private TypeCategoryPopup _typeCategory;

	public string Message{ get{ return _messageText; } }
	public TypePopup Type { get { return _type; } }
	public TypeCategoryPopup TypeCategory { get { return _typeCategory; } }
}
