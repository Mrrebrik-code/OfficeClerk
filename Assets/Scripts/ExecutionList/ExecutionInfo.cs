using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExecutionList
{
	public class ExecutionInfo
	{
		public float Time { get; private set; }
		public Sprite Icon { get; private set; }

		public ExecutionInfo(float time, Sprite icon)
		{
			Time = time;
			Icon = icon;
		}
	}
}
