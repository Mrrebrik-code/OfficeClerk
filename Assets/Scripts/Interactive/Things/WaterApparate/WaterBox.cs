using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBox : MonoBehaviour, IThings
{
	public Action OnWaterBoxOut;
	public float Value = 100;
	private bool _isFull = true;
	[SerializeField] private bool _isSetToBox = false;
	[SerializeField] private WaterInfo _info;
	public TypeObject Type { get; set; }
	private void Awake()
	{
		Type = TypeObject.WaterBox;
		_info.SetValue(Value);
		if (_isSetToBox == false)
		{
			_info.gameObject.SetActive(false);
		}
	}

	public void Init(float value)
	{
		_isSetToBox = true;
		Value = value;
		if(Value > 0)
		{
			_isFull = true;
		}
		_info.SetValue(Value);
		_info.gameObject.SetActive(true);
	}
	public void Execute()
	{
		if (_isSetToBox)
		{
			if (Value <= 0)
			{
				_isFull = false;
			}
			if (_isFull)
			{
				Debug.Log("Попил воды!");
				Value -= 20;
				_info.SetValue(Value);
			}
			else
			{
				OnWaterBoxOut?.Invoke();
				Debug.Log("Вода закончилась!");
			}
		}
		else
		{
			PlayerController.Instance.WaterBox.SetActive(true);
			Debug.Log("Выподобрали бочку с водой!");
			Inventory.Instance.AddThing(this);
			Destroy(gameObject);
		}
		
	}
}
