using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Achievement
{
    public class AchievementManager : SingletonMono<AchievementManager>
    {
		[SerializeField] private AchievementHolder _achievementHolderPrefab;
		[SerializeField] private Transform _contentAchievement;

		private List<AchievementHolder> _products = new List<AchievementHolder>();

		public override void Awake()
		{
			base.Awake();
			Init();
		}

		private List<Achievement> LoadAchievement()
		{
			return Resources.LoadAll<Achievement>("Achievements").ToList();
		}

		private void Init()
		{
			List<Achievement> achievements = LoadAchievement();
			if (achievements == null) return;

			foreach (var achievement in achievements)
			{
				AchievementHolder productHolderTemp = Instantiate(_achievementHolderPrefab, _contentAchievement);
				productHolderTemp.SetAchievement(achievement);
				productHolderTemp.UpdateTargetAchievement(0);
				_products.Add(productHolderTemp);
			}
		}
	}
}

