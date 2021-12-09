using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive.Things
{
	public class TriggerBed : MonoBehaviour
	{
		[SerializeField] private Bed _bed;
		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("test");
			DreamState workman = other.GetComponentInChildren<DreamState>();

			if (workman != null)
			{
				Debug.Log("test3");
				workman.SetBedUsing(_bed);
			}
			else
			{
				Debug.Log("test2");
			}
		}
	}
}

