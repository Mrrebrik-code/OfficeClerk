using System;
using UnityEngine;
using UnityEngine.UI;

public class FaderOut : MonoBehaviour
{
	[SerializeField] private Image _image;

	private void Start()
	{
		_image.Fade(0, 2f, ()=>{ });
	}

	public void FaderIn(Action callback)
	{
		_image.Fade(1, 2f, callback);
	}
}
