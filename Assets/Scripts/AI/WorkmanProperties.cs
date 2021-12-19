using System;

namespace AI
{
	[Serializable]
	public class WorkmanProperties
	{
		public Action OnChange;
		public bool IsReady { get; private set; }

		private float _tValue;
		private float _hValue;
		private float _dValue;
		public float ThirstValue
		{
			get { return _tValue; }
			set
			{
				_tValue += value;
				if (_tValue <= 0) _tValue = 0;
				else if (_tValue > 100) _tValue = 100;

				ReadyWorkman();
				OnChange?.Invoke();
			}
		}
		public float HungryValue
		{
			get { return _hValue; }
			set
			{
				_hValue += value;
				if (_hValue <= 0) _hValue = 0;
				else if (_hValue > 100) _hValue = 100;

				ReadyWorkman();
				OnChange?.Invoke();
			}
		}
		public float DreamValue
		{
			get { return _dValue; }
			set
			{
				_dValue += value;
				if (_dValue <= 0) _dValue = 0;
				else if (_dValue > 100) _dValue = 100;

				ReadyWorkman();
				OnChange?.Invoke();
			}
		}
		private void ReadyWorkman()
		{
			if (_tValue > 0 && _hValue > 0 && _dValue > 0) IsReady = true;
			else IsReady = false;
		}
		public WorkmanProperties(float tValue, float hValue, float dValue)
		{
			ThirstValue = tValue;
			HungryValue = hValue;
			DreamValue = dValue;
			IsReady = true;
		}

	}
}
