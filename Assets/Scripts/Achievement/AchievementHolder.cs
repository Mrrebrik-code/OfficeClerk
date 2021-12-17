using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Bank;

namespace Achievement
{
	public class AchievementHolder : MonoBehaviour
	{
		public Achievement Achievement { get; private set; }

		[SerializeField] private TMP_Text _descriptionText;
		[SerializeField] private TMP_Text _rewardText;
		[SerializeField] private TMP_Text _targetText;

		[SerializeField] private GameObject _buttonReward;
		[SerializeField] private GameObject _buttonTarget;
		[SerializeField] private GameObject _buttonComplet;

		private Popup _popupDescrition;

		private int _countTargetSuccefful = 0;
		public void SetAchievement(Achievement achievement)
		{
			Achievement = achievement;
			_popupDescrition = new Popup(achievement.Description, TypeCategoryPopup.Info, TypePopup.Achievement);

			_descriptionText.text = achievement.Description;
			_rewardText.text = achievement.Reward.ToString() + " печенек";

			_buttonReward.SetActive(false);
			_buttonTarget.SetActive(true);
		}

		public void UpdateTargetAchievement(int value)
		{
			_countTargetSuccefful += value;
			_targetText.text = $"{_countTargetSuccefful}/{Achievement.Target}";

			if (_countTargetSuccefful >= Achievement.Target)
			{
				Complet();
			}
		}

		public void ShowDescriptionPopup()
		{
			PopupHandler.Instance.ShowPopup(_popupDescrition);
		}

		public void TakeReward()
		{
			BankManager.Instance.Cookies.Put(Achievement.Reward);
			_buttonReward.SetActive(false);
			_buttonComplet.SetActive(true);
		}

		public void Complet()
		{
			Achievement.IsDone = true;
			AchievementManager.Instance.CompletAchievement(this);

			_buttonReward.SetActive(true);
			_buttonTarget.SetActive(false);
		}
	}
}

