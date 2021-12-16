using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Menu 
{
	public class PanelTable : MonoBehaviour
	{
		[SerializeField] private string _name;

		public string Name { get { return _name; } }
	}
}


