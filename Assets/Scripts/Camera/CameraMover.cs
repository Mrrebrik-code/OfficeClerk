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
/*		if (Input.GetKey(KeyCode.W))
		{
			_transform.localPosition += new Vector3(0, 0, -0.5f) * 5 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			_transform.localPosition += new Vector3(0, 0, 0.5f) * 5 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			_transform.localPosition += new Vector3(0.5f, 0, 0) * 5 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			_transform.localPosition += new Vector3(-0.5f, 0, 0) * 5 * Time.deltaTime;
		}*/
		_transform.localPosition = new Vector3(-_xPos * _speed, _yPositionCamera, -_zPos * _speed);
	}
}
