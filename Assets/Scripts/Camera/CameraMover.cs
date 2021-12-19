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
			_yPositionCamera -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * Configurator.Instance.Data.SpeedScrollCamera;

			_xPos += Input.GetAxis("Horizontal");
			_zPos += Input.GetAxis("Vertical");
		}
		_yPositionCamera = Mathf.Clamp(_yPositionCamera, Configurator.Instance.Data.MinPositionCamera, Configurator.Instance.Data.MaxPositionCamera);


		

		_transform.localPosition = new Vector3(-_xPos * Configurator.Instance.Data.SpeedMoveCamera, _yPositionCamera, -_zPos * Configurator.Instance.Data.SpeedMoveCamera);
	}
}
