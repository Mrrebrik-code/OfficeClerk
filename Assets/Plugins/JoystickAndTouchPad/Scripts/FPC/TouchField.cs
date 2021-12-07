using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static TouchField Instance;
    [HideInInspector] public Vector2 TouchDist;
    public bool isPressed;
    private Vector2 _pointerOld;
    private int _pointerId;
    private bool _pressed;

	private void Awake()
	{
        Instance = this;

    }
	public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        _pointerId = eventData.pointerId;
        _pointerOld = eventData.position;
    }

    private void FixedUpdate()
    {
        if (isPressed)
        {
            if (_pointerId >= 0 && _pointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[_pointerId].position - _pointerOld;
                _pointerOld = Input.touches[_pointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - _pointerOld;
                _pointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
