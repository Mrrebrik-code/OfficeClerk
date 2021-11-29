using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTable : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		PausedMenuHandler.Instance.OpenSettings();
		gameObject.SetActive(false);
	}
}
