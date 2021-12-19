using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class PopupHandler : SingletonMono<PopupHandler>
{
	[SerializeField] private PopupHolder _popupPrefab;
	[SerializeField] private GameObject _content;
	private Dictionary<TypePopup, Popup> _popups = new Dictionary<TypePopup, Popup>();
	private Dictionary<TypePopup, Popup> _popupsAchievemnts = new Dictionary<TypePopup, Popup>();
	private PopupHolder _currentPopup;
	public override void Awake()
	{
		base.Awake();
		Init();
	}
	private List<Popup> LoadPopupsData()
	{
		return Resources.LoadAll<Popup>("Popups").ToList();
	}
	private void Init()
	{
		var popups = LoadPopupsData();
		if (popups == null) return;

		foreach (var popup in popups)
		{
			_popups.Add(popup.Type, popup);
		}
	}

	public void ShowPopup(TypePopup popup)
	{
		if(_currentPopup == null && _popups.ContainsKey(popup))
		{
			_currentPopup = Instantiate(_popupPrefab, _content.transform);
			_currentPopup.Init(_popups[popup], OnPopupHandlerDestory);
		}
	}
	public void ShowPopup(Popup popup)
	{
		if (_currentPopup == null)
		{
			_currentPopup = Instantiate(_popupPrefab, _content.transform);
			_currentPopup.Init(popup, OnPopupHandlerDestory);
		}
	}

	private void OnPopupHandlerDestory()
	{
		_currentPopup = null;
	}
}
