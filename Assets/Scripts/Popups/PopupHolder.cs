using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupHolder : MonoBehaviour
{
	public Action CallBack;
	[SerializeField] private Button _buttonClose;
	[SerializeField] private TMP_Text _nameCategoryText;
	[SerializeField] private TMP_Text _contentPopupText;
	private Popup _popup;

	public void Init(Popup popup, Action callback)
	{
		_popup = popup;
		_buttonClose.onClick.AddListener(Close);
		_nameCategoryText.text = _popup.TypeCategory.ToString();
		_contentPopupText.text = _popup.Message;
		CallBack += callback;
	}

	private void Close()
	{
		DestroyImmediate(gameObject);
		CallBack?.Invoke();
	}
}
