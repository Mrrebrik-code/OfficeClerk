using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PushHandler : SingletonMono<PushHandler>
{
	[SerializeField] private NotificationAchievement _notificationPrefab;
	[SerializeField] private NotificationPosition _positionPrefab;
	[SerializeField] private NotificationPosition _positionStart;

	[SerializeField] private Transform _content;

	private List<NotificationAchievement> _notification = new List<NotificationAchievement>();
	[SerializeField] private float _spacing;
	private List<NotificationPosition> _positions = new List<NotificationPosition>();

	public override void Awake()
	{
		base.Awake();
		for (int i = 0; i < 5; i++)
		{
			if (i == 0)
			{
				var point = Instantiate(_positionPrefab, _content);
				point.SetPosition(_positionStart.GetPosition());
				_positions.Add(point);
			}
			else
			{
				var point = Instantiate(_positionPrefab, _content);
				var position = new Vector2(_positions[i - 1].GetPosition().x, _positions[i - 1].GetPosition().y - _spacing);
				point.GetComponent<RectTransform>().anchoredPosition = position;
				_positions.Add(point);
			}

		}
		_positions.Reverse();
	}
	public void AddNotification(Achievement.Achievement achievement)
	{
		StartCoroutine(Delay(achievement));
	}
	private IEnumerator Delay(Achievement.Achievement achievement)
	{
		foreach (var position in _positions)
		{
			if(position.IsBusy == false)
			{
				position.IsBusy = true;
				var notificaion = Instantiate(_notificationPrefab, _content.transform);
				notificaion.Init(achievement, 2f, () =>
				{
					position.IsBusy = false;
				});

				var startPosition = new Vector2(_positionStart.GetPosition().x - 1000, _positionStart.GetPosition().y);
				notificaion.GetComponent<RectTransform>().anchoredPosition = startPosition;

				notificaion.GetComponent<RectTransform>().anchoredPosition = _positionStart.GetPosition();
				yield return new WaitForSeconds(1f);
				notificaion.GetComponent<RectTransform>().anchoredPosition = position.GetPosition();
				yield break;
			}
		}
	}
}
