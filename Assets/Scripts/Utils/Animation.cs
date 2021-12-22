using System;
using UnityEngine;
using UnityEngine.UI;

public static class Animation
{
	public static void Fade(this Image image, float target, float time, Action callback)
	{
		AnimationUpdater.Instance.Fade(image, image.color.a, target, time, callback);
	}

	public static void Fade(this CanvasGroup canvasGroup, float target, float time, Action callback)
	{
		AnimationUpdater.Instance.Fade(canvasGroup, canvasGroup.alpha, target, time, callback);
	}

	public static void Move(this RectTransform recTransform, Vector2 target, float time, Action callback)
	{
		AnimationUpdater.Instance.Move(recTransform, recTransform.anchoredPosition, target, time, callback);
	}
}
