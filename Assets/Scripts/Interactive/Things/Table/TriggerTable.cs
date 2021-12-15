using Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive.Things
{
	public class TriggerTable : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			PausedMenuHandler.Instance.OpenTableMenu();
			gameObject.SetActive(false);
		}
	}
}
