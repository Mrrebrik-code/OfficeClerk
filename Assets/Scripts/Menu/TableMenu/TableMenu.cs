using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Menu
{
	public class TableMenu : SingletonMono<TableMenu>
	{
		[SerializeField] private GameObject _contentToPannels;
		[SerializeField] private GameObject _contentToButtons;

		[SerializeField] private ButtonTable _buttonPrefab;
		private ButtonTable _currentButton;
		private PanelTable _currentPanel;

		[SerializeField] private List<PanelTable> _panelsMenu = new List<PanelTable>();


		private Dictionary<PanelTable, ButtonTable> _menus = new Dictionary<PanelTable, ButtonTable>();

		public override void Awake()
		{
			base.Awake();
			Init();
		}

		private void Init()
		{
			foreach (var menu in _panelsMenu)
			{
				var button = Instantiate(_buttonPrefab, _contentToButtons.transform);
				button.Init(menu);

				_menus.Add(menu, button);
			}
		}
		public void Open(PanelTable menu)
		{

			if (_currentButton != null && _currentPanel != null)
			{
				if (_currentPanel = menu)
				{
					_currentButton.SelectedSwitch();
					_currentButton = null;

					_currentPanel.gameObject.SetActive(false);
					_currentPanel = null;
					return;
				}
				_currentButton.SelectedSwitch();
				_currentPanel.gameObject.SetActive(false);
			}

			var button = _menus[menu];
			button.SelectedSwitch();
			menu.gameObject.SetActive(true);
			_currentPanel = menu;
			_currentButton = button;
		}
	}
}
