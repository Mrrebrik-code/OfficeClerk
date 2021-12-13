using InputDevice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
	private Transform _transform;
	private float _xRot;
	private float _xPos, _zPos;
	private float _yPositionCamera = 7f;
	[SerializeField] private float _speed;
	[SerializeField] private bool _isMobile;
	private void Start()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		if (_isMobile)
		{
			_yPositionCamera -= TouchField.Instance.TouchDist.y  * Time.deltaTime ;

			_xPos += Joystick.Instance.Horizontal();
			_zPos += Joystick.Instance.Vertical();
		}
		else
		{
			_yPositionCamera -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 220f;

			_xPos += Input.GetAxis("Horizontal");
			_zPos += Input.GetAxis("Vertical");
		}
		_yPositionCamera = Mathf.Clamp(_yPositionCamera, 4f, 10f);


		

		_transform.localPosition = new Vector3(-_xPos * _speed, _yPositionCamera, -_zPos * _speed);
	}
}
