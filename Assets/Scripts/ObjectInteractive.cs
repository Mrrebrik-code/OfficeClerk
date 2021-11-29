using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ObjectInteractive : MonoBehaviour
{
	private Outline _outline;
	[SerializeField] private Transform _pointMove;

	private void Start()
	{
		_outline = GetComponent<Outline>();
		_outline.enabled = false;
	}

	public void OnMouseEnter()
	{
		_outline.enabled = true;
		PlayerController.Instance.IsHitMove = false;
	}

	public void OnMouseExit()
	{
		_outline.enabled = false;
		PlayerController.Instance.IsHitMove = true;
	}

	public void OnMouseDown()
	{
		_pointMove.gameObject.SetActive(true);
		PlayerController.Instance.Move(_pointMove.position);
	}
}
