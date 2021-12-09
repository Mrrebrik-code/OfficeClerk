using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
	private Transform _transform;
	private float _xRot;
	private float _xPos, _zPos;
	private float _yPositionCamera = 5f;
	[SerializeField] private float _speed;
	private void Start()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		_yPositionCamera -= TouchField.Instance.TouchDist.y * Time.deltaTime;
		_yPositionCamera = Mathf.Clamp(_yPositionCamera, 4f, 10f);

		_xPos += Joystick.Instance.Horizontal();
		_zPos += Joystick.Instance.Vertical();

		_transform.localPosition = new Vector3(-_xPos * _speed, _yPositionCamera, -_zPos * _speed);
	}
}
