using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Panel", menuName = "SO/PanelTable")]
public class PanelTable : ScriptableObject
{
	[SerializeField] private string _name;
	[SerializeField] private GameObject _panel;

	public string Name{ get { return _name; } }
	public GameObject Panel { get { return _panel; } }
}
