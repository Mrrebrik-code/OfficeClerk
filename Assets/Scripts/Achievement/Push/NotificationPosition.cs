using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationPosition : MonoBehaviour
{
	[SerializeField] private RectTransform _rectTransform;
	public bool IsBusy = false;
	public Vector2 GetPosition()
	{
		return _rectTransform.anchoredPosition;
	}

	public void SetPosition(Vector2 position)
	{
		_rectTransform.anchoredPosition = position;
	}
}
