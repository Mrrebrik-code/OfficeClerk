using UnityEngine;

public class CameraMover : MonoBehaviour
{
	private Transform _transform;
	private float _xPosition, _zPosition;
	private float _yPositionCamera = 7f;
	[SerializeField] private float _minX;
	[SerializeField] private float _maxX;
	[SerializeField] private float _minZ;
	[SerializeField] private float _maxZ;
	private void Start()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		_yPositionCamera -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * Configurator.Instance.Data.SpeedScrollCamera;
		_xPosition += Input.GetAxis("Horizontal");
		_zPosition += Input.GetAxis("Vertical");

		_yPositionCamera = Mathf.Clamp(_yPositionCamera, Configurator.Instance.Data.MinPositionCamera, Configurator.Instance.Data.MaxPositionCamera);
		_xPosition = Mathf.Clamp(_xPosition , _minX, _maxX);
		_zPosition = Mathf.Clamp(_zPosition , _minZ, _maxZ);
		_transform.localPosition = new Vector3(-_xPosition * Configurator.Instance.Data.SpeedMoveCamera , _yPositionCamera, -_zPosition * Configurator.Instance.Data.SpeedMoveCamera);
	}
}
