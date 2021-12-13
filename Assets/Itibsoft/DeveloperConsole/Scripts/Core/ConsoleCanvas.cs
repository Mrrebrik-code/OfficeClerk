using UnityEngine;
using UnityEngine.UI;


namespace Itibsoft.ConsoleDeveloper.Core
{
	public class ConsoleCanvas : MonoBehaviour
	{
		private Camera _camera;
		private Canvas _canvas;
		private CanvasScaler _canvasScaler;

		private void Awake() => Init();

		private void Init()
		{
			_camera = Camera.main;
			_canvas = GetComponent<Canvas>();
			_canvasScaler = GetComponent<CanvasScaler>();

			_canvas.renderMode = RenderMode.ScreenSpaceCamera;
			_canvas.worldCamera = _camera;

			_canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			_canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
			_canvasScaler.matchWidthOrHeight = 0.5f;
		}
	}
}
