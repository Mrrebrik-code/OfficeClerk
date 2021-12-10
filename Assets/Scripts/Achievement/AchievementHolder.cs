using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Achievement
{
	public class AchievementHolder : MonoBehaviour
	{
		private Achievement _achievement;

		[SerializeField] private TMP_Text _descriptionText;
		[SerializeField] private TMP_Text _rewardText;
		[SerializeField] private TMP_Text _targetText;

		[SerializeField] private GameObject _buttonReward;
		[SerializeField] private GameObject _buttonTarget;

		private int _countTargetSuccefful = 0;
		public void SetAchievement(Achievement achievement)
		{
			_achievement = achievement;
			_descriptionText.text = achievement.Description;
			_rewardText.text = achievement.Reward.ToString() + "печенек";

			_buttonReward.SetActive(false);
			_buttonTarget.SetActive(true);
		}

		public void UpdateTargetAchievement(int value)
		{
			_countTargetSuccefful += value;
			_targetText.text = $"{_countTargetSuccefful}/{_achievement.Target}";

			if (_countTargetSuccefful >= _achievement.Target)
			{
				_buttonReward.SetActive(true);
				_buttonTarget.SetActive(false);
			}

			
		}
	}
}

