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

		private List<AchievementHolder> _achievements = new List<AchievementHolder>();
		private List<AchievementHolder> _doneAchievements = new List<AchievementHolder>();

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
				_achievements.Add(productHolderTemp);
			}
		}

		private List<AchievementHolder> HasAchievementsOfType(TypeAchievement type)
		{
			List<AchievementHolder> achievementList = new List<AchievementHolder>();
			foreach (var achievement in _achievements)
			{
				if(achievement.Achievement.Type == type)
				{
					achievementList.Add(achievement);
				}
			}

			return (achievementList.Count > 0) ? achievementList : null;
		}

		public void DoneAchievementTarget(TypeAchievement type, int countSuccessful = 1)
		{
			var achievements = HasAchievementsOfType(type);
			if (achievements == null) return;

			achievements.ForEach(achievement =>
			{
				achievement.UpdateTargetAchievement(countSuccessful);
			});
		}

		public void CompletAchievement(AchievementHolder achievement)
		{
			_achievements.Remove(achievement);
			_doneAchievements.Add(achievement);
		}
	}
}

