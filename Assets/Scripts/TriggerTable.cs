using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTable : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Table open!");
		gameObject.SetActive(false);
	}
}
