using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
	public class ButtonTable : MonoBehaviour
	{
		[SerializeField] private Button _button;
		[SerializeField] private Image _image;
		[SerializeField] private TMP_Text _nameButton;
		[SerializeField] private HandTutorial _handTutorial;
		private bool _isSelected;
		private PanelTable _panel;
		public void Init(PanelTable panel)
		{
			_panel = panel;
			_nameButton.text = panel.Name;
			_button.onClick.AddListener(OpenPenel);
			if(panel.Name == "Магазин")
			{
				_handTutorial.Type = TypeHandTutorial.ButtonShop;
				TutorialManager.Instance.AddHand(_handTutorial);
			}
			
		}
		public void SelectedSwitch()
		{
			_isSelected = !_isSelected;
			if (_isSelected)
			{
				_image.color = Color.green;
			}
			else
			{
				_image.color = Color.white;
			}
		}
		private void OpenPenel()
		{
			Debug.Log("Test");
			TableMenu.Instance.Open(_panel);
		}

	}
}
