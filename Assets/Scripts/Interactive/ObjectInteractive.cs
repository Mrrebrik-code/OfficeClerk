using Interactive;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive
{
	[RequireComponent(typeof(Outline))]
	public class ObjectInteractive : MonoBehaviour
	{
		private float _distanceInteractive = 3f;
		private Outline _outline;
		private IThings _thing;

		private void Start()
		{
			_outline = GetComponent<Outline>();
			_outline.enabled = false;
			_thing = GetComponent<IThings>();
		}

		public void OnMouseEnter()
		{
			_outline.enabled = true;
			PlayerController.Instance.IsHitMove = false;
		}

		public void OnMouseExit()
		{
			_outline.enabled = false;
			PlayerController.Instance.IsHitMove = true;
		}

		public void OnMouseDown()
		{
			float distance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
			if (distance < _distanceInteractive)
			{
				Debug.Log("Вы нажали на объект: " + gameObject.name);
				_thing.Execute();
			}
			else
			{
				Debug.Log("Вы находитесь слишком далеко от объекта!");
			}

		}
	}
}
