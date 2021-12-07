using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interactive.Things
{
	public class WaterApparate : MonoBehaviour, IThings
	{
		[SerializeField] private WaterBox _waterBox;
		public WaterBox WaterBox { get { return _waterBox; } }

		private bool _isWaterBox = false;

		public TypeObject Type { get; set; }
		private void Awake()
		{
			_waterBox.OnWaterBoxOut += OnWaterBoxOutHandler;
			Type = TypeObject.WaterApparature;
		}

		private void OnWaterBoxOutHandler()
		{
			_waterBox.gameObject.SetActive(false);
			_isWaterBox = false;
		}

		public void Execute()
		{
			if (_isWaterBox == false)
			{
				var waterBox = Inventory.Instance.PutThing(TypeObject.WaterBox);

				if (waterBox != null)
				{
					PlayerController.Instance.WaterBox.SetActive(false);
					SetWaterBox((WaterBox)waterBox);
				}
				else
				{
					Debug.Log("У вас нет бочки с водой!");
				}
			}
			else
			{
				Debug.Log("Бочка с водой уже установлена!");
			}
		}

		public void SetWaterBox(WaterBox waterBox)
		{
			_waterBox.gameObject.SetActive(true);
			_waterBox.Init(waterBox.Value);
			_isWaterBox = true;
		}
	}
}
