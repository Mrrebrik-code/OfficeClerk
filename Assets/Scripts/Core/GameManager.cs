using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private List<WorkmanAI> _workmans = new List<WorkmanAI>();

	public void AddWorkman(WorkmanAI workman)
	{
		_workmans.Add(workman);
		Debug.Log("Добавлен новый работник в штаб!");
	}
}
