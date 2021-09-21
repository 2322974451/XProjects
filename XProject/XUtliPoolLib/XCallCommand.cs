using System;

namespace XUtliPoolLib
{
	// Token: 0x020001E3 RID: 483
	public class XCallCommand
	{
		// Token: 0x06000B01 RID: 2817 RVA: 0x0003AA8C File Offset: 0x00038C8C
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

		// Token: 0x06000B02 RID: 2818 RVA: 0x0003AAF4 File Offset: 0x00038CF4
		public static void Execute(XGameObject gameObject, XEngineCommand command)
		{
			bool flag = command.data != null && command.data.commandCb != null;
			if (flag)
			{
				command.data.commandCb(gameObject, command.data.data, command.commandID);
			}
		}

		// Token: 0x04000583 RID: 1411
		public static ExecuteCommandHandler handler = new ExecuteCommandHandler(XCallCommand.Execute);

		// Token: 0x04000584 RID: 1412
		public static DebugHandler debugHandler = new DebugHandler(XCallCommand.DebugString);
	}
}
