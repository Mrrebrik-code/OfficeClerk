using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

		private int _countTargetSuccefful = 0;
		public void SetAchievement(Achievement achievement)
		{
			Achievement = achievement;
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

		public void TakeReward()
		{
			//Прописать систему состояний кнопки цель-получить-получен
			_buttonReward.SetActive(false);
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

