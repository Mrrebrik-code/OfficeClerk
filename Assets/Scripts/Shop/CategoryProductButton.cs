using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryProductButton : MonoBehaviour
{
	[SerializeField] private TMP_Text _nameButtonText;
	[SerializeField] private Button _button;
	private GameObject _content;
	public void Init(GameObject content)
	{
		_content = content;
		_button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		_content.SetActive(true);
	}
}
