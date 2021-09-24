using System;

namespace XUtliPoolLib
{

	public class XCallCommand
	{

		public static void DebugString(XGameObject gameObject, XEngineCommand command, string str, int id)
		{
			bool flag = command.data != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddWarningLog2("[EngineCommand] CallCmd {0} ID:{1} data:{2} location:{3} objID:{4}", new object[]
				{
					str,
					id,
					command.data.data,
					gameObject.m_Location,
					gameObject.objID
				});
			}
		}

		public static void Execute(XGameObject gameObject, XEngineCommand command)
		{
			bool flag = command.data != null && command.data.commandCb != null;
			if (flag)
			{
				command.data.commandCb(gameObject, command.data.data, command.commandID);
			}
		}

		public static ExecuteCommandHandler handler = new ExecuteCommandHandler(XCallCommand.Execute);

		public static DebugHandler debugHandler = new DebugHandler(XCallCommand.DebugString);
	}
}
