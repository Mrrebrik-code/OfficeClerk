using AI;
using UnityEngine;

public class TableWorkman : MonoBehaviour
{
	[SerializeField] private Transform _pont;
	private WorkmanAI _worknam;
	public bool IsFree = true;
	public bool IsBuy = false;

	public Transform GetPoint()
	{
		return _pont;
	}

	public void SetWorkman(WorkmanAI ai)
	{
		_worknam = ai;
		IsFree = false;
	}
}
