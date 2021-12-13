using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	[Command]
	public class LogFullCommand : ICommand
	{
		public string Name { get => "Log.Full"; set { } }
		public string Description 
		{
			get
			{
				return $"Logger full contoller[ {Tools.GetColoredRichText("OFF", GetTypeColorForIsFullLogReverse())} / {Tools.GetColoredRichText("ON", GetTypeColorForIsFullLog())} ]";
			} 
			set { } 
		}

		public void Execute()
		{
			Logger.Instance.IsFullLog = !Logger.Instance.IsFullLog;
			Logger.Instance.AddLog($"Logger IsFullLog = {Tools.GetColoredRichText(Logger.Instance.IsFullLog.ToString(), GetTypeColorForIsFullLog())}", this);
			
		}

		private TypeColor GetTypeColorForIsFullLog()
		{
			return Logger.Instance.IsFullLog ? TypeColor.Green : TypeColor.Red;
		}
		
		private TypeColor GetTypeColorForIsFullLogReverse()
		{
			return Logger.Instance.IsFullLog ? TypeColor.Red : TypeColor.Green;
		}
	}
}
