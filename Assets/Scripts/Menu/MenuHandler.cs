using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
	public class MenuHandler : MonoBehaviour
	{
		public void Play()
		{
			SceneManager.LoadScene("_Game");
		}
	}
}
