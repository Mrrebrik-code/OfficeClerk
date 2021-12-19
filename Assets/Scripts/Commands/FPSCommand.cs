using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;

[Command]
public class FPSCommand : ICommand
{
	private bool _isActive = false;
	public string Name { get => "FPS"; set { } }
	public string Description { get => "Frame per second to game"; set { } }

	public void Execute()
	{
		_isActive = !_isActive;
		FPS.FPSDisplay.Instance.Activate(_isActive);
	}
}
