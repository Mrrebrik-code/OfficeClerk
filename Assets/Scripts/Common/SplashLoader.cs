using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SplashLoader : MonoBehaviour
{
	[SerializeField] private GameObject _logo;
	[SerializeField] private GameObject _info;
	[SerializeField] private Image _fader;

	private void Awake()
	{
		StartCoroutine(Loader());
	}

	private IEnumerator Loader()
	{
		yield return new WaitForSeconds(1f);
		_logo.SetActive(true);
		_fader.DOFade(0, 1f);
		yield return new WaitForSeconds(2f);
		_fader.DOFade(1, 1f);
		yield return new WaitForSeconds(2f);
		_logo.SetActive(false);
		_fader.DOFade(0, 1f);
		yield return new WaitForSeconds(2f);
		_fader.DOFade(1, 1f);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("_Menu");
	}
}
