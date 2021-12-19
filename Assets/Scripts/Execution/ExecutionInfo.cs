using UnityEngine;

namespace Execution
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
