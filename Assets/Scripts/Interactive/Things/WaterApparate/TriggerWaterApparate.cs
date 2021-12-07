using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactive.Things
{
    public class TriggerWaterApparate : MonoBehaviour
    {
		[SerializeField] private WaterApparate _waterApparate;
		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("test");
			ThirstState workman = other.GetComponentInChildren<ThirstState>();

			if(workman != null)
			{
				Debug.Log("test3");
				workman.SetWatterApparateUsing(_waterApparate);
			}
			else
			{
				Debug.Log("test2");
			}
		}
	}
}


