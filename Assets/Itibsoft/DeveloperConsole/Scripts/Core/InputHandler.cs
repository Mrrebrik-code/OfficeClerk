using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	//TODO: Сделать под каждую кнопку свои события
	public event Action<KeyCode> KeyDownEvent;
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Return))
			KeyDownTrigger(KeyCode.Return);
		
		if (Input.GetKeyDown(KeyCode.BackQuote))
			KeyDownTrigger(KeyCode.BackQuote);
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
			KeyDownTrigger(KeyCode.UpArrow);
		
		if (Input.GetKeyDown(KeyCode.DownArrow))
			KeyDownTrigger(KeyCode.DownArrow);
	}

	private void KeyDownTrigger(KeyCode keyCode)
	{
		if (KeyDownEvent != null)
			KeyDownEvent(keyCode);
	}
}
