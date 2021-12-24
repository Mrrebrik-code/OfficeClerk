using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTutorial : MonoBehaviour
{
	public bool IsDone = false;
	public TypeHandTutorial Type;
	private void Start()
	{
		
	}
	public void Hide()
	{
		Destroy(gameObject);
	}

	public void Complet()
	{
		if(TutorialManager.Instance.CurrentTutorial == Tutorials.Shop)
		{
			IsDone = true;
			Hide();
		}
	}
}
