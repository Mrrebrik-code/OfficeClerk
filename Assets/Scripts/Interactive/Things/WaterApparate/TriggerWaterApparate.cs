using AI;
using UnityEngine;

namespace Interactive.Things
{
    public class TriggerWaterApparate : MonoBehaviour
    {
		[SerializeField] private WaterApparate _waterApparate;
		private void OnTriggerEnter(Collider other)
		{
			ThirstState workman = other.GetComponentInChildren<ThirstState>();

			if(workman != null)
			{
				workman.SetWatterApparateUsing(_waterApparate);
			}
		}
	}
}


