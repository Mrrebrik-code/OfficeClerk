using Interactive;
using Interactive.Things;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Factories
{
	public class FactoryWaterBox : SingletonMono<FactoryWaterBox>, IFactory<List<WaterBox>>
	{
		[SerializeField] private List<WaterBox> _waterBoxes = new List<WaterBox>();
		public List<IThings> Things { get; private set; } = new List<IThings>();

		public List<WaterBox> Create(int count)
		{
			List<WaterBox> tempListWaterBoxes = new List<WaterBox>();
			if(Things.Count != _waterBoxes.Count)
			{
				foreach (var waterBox in _waterBoxes)
				{
					if (!Things.Contains(waterBox))
					{
						tempListWaterBoxes.Add(waterBox);
						
					}
				}
			}
			else
			{
				return null;
			}
			if(tempListWaterBoxes.Count >= count)
			{
				var waterBoxes = new List<WaterBox>();
				for (int i = 0; i < count; i++)
				{
					var waterBox = tempListWaterBoxes[i];
					waterBoxes.Add(waterBox);
					waterBox.gameObject.SetActive(true);
					_waterBoxes.Remove(waterBox);
				}
				return waterBoxes;
			}
			else
			{
				return null;
			}
		}

		public List<WaterBox> HasGetWaterBoxToFactory(int count)
		{
			if (Things.Count >= count)
			{
				List<WaterBox> waterBoxes = new List<WaterBox>();
				for (int i = 0; i < count; i++)
				{
					var tempThing = Things[i];
					waterBoxes.Add((WaterBox)tempThing);
				}
				foreach (var waterBox in waterBoxes)
				{
					Things.Remove(waterBox);
				}
				return waterBoxes;
			}
			return null;
		}
	}
}
