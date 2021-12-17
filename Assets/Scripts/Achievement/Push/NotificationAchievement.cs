using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Utils;
using Achievement;
using System;

public class NotificationAchievement : MonoBehaviour
{
	private Action _onDestroy;
	[SerializeField] private CanvasGroup _canvasGroup;
	[SerializeField] private TMP_Text _nameAchievementText;
	[SerializeField] private TMP_Text _rewardAchievementText;
	[SerializeField] private float _time;

	public void Init(Achievement.Achievement achievement, float time, Action callback)
	{
		_nameAchievementText.text = achievement.Name;
		_rewardAchievementText.text = achievement.RewardInfo;
		_onDestroy += callback;
		StartCoroutine(Delay(time));
	}

	private IEnumerator Delay(float time)
	{
		yield return new WaitForSeconds(_time * 2f + time);
		_canvasGroup.DOFade(0, _time);
		yield return new WaitForSeconds(_time);
		_onDestroy?.Invoke();
		DestroyImmediate(gameObject);
	}
}
