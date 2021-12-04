using System;

namespace AI
{
	public interface IWorkmanState
	{
		Action CallBack { get; set; }
		WorkmanAI AI { get; }
		void UpdateState();
		void Execute(WorkmanAI ai);

	}
}
