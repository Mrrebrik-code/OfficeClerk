using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive.Things
{
	public class Table : MonoBehaviour, IThings
	{
		[SerializeField] private Transform _pointMove;

		public TypeObject Type { get; set; }

		private void Awake()
		{
			Type = TypeObject.Table;
		}
		public void Execute()
		{
			_pointMove.gameObject.SetActive(true);
			PlayerController.Instance.Move(_pointMove.position);
		}
	}
}
