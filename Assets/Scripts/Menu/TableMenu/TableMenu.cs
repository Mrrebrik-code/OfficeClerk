using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class TableMenu : SingletonMono<TableMenu>
{
	[SerializeField] private GameObject _contentToPannels;
	[SerializeField] private GameObject _contentToButtons;

	[SerializeField] private ButtonTable _buttonPrefab;
	private ButtonTable _currentButton;
	private GameObject _currentPanel;

	private Dictionary<PanelTable, object[]> _panels = new Dictionary<PanelTable, object[]>();

	public override void Awake()
	{
		base.Awake();
		Init();
	}
	private List<PanelTable> LoadPanelTable()
	{
		return Resources.LoadAll<PanelTable>("PanelTables").ToList();
	}

	private void Init()
	{
		List<PanelTable> panelTables = LoadPanelTable();
		if (panelTables == null) return;

		foreach (var panel in panelTables)
		{
			GameObject panelTemp = Instantiate(panel.Panel, _contentToPannels.transform);
			ButtonTable buttonTemp = Instantiate(_buttonPrefab, _contentToButtons.transform);
			buttonTemp.Init(panel);

			_panels.Add(panel, new object[2]{ panelTemp, buttonTemp });

			if(panel.Name == "Магазин")
			{
				var contents = panel.Panel.GetComponent<Shop.Shop>().GetContentsOfTransform();
				Shop.ShopHandler.Instance.Init(contents[0], contents[1]);
			}
		}
	}
	public void Open(PanelTable panel)
	{
		if(_currentButton != null && _currentPanel != null)
		{
			_currentButton.SelectedSwitch();
			_currentPanel.gameObject.SetActive(false);
		}
		


		var panelTemp = (GameObject)_panels[panel][0];
		panelTemp.SetActive(true);
		_currentPanel = panelTemp;
		var buttonTemp = (ButtonTable)_panels[panel][1];
		_currentButton = buttonTemp;
		buttonTemp.SelectedSwitch();
	}
}
