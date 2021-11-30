using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ObjectInteractive : MonoBehaviour
{
	private Outline _outline;
	private IThings _thing;

	private void Start()
	{
		_outline = GetComponent<Outline>();
		_outline.enabled = false;
		_thing = GetComponent<IThings>();
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
		_thing.Execute();
	}
}
