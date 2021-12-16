using Menu;
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
