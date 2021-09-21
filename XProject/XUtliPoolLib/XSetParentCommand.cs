using System;

namespace XUtliPoolLib
{
	// Token: 0x020001E2 RID: 482
	public class XSetParentCommand
	{
		// Token: 0x06000AFC RID: 2812 RVA: 0x0003A96C File Offset: 0x00038B6C
		public static void DebugString(XGameObject gameObject, XEngineCommand command, string str, int id)
		{
			bool flag = command.data != null;
			if (flag)
			{
				XGameObject xgameObject = command.data.data as XGameObject;
				bool flag2 = xgameObject != null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddWarningLog2("[EngineCommand] SetParentCmd {0} ID:{1} parent:{2} current:{3}", new object[]
					{
						str,
						id,
						xgameObject.Name,
						gameObject.Name
					});
				}
			}
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0003A9DC File Offset: 0x00038BDC
		public static bool CanExecute(XGameObject gameObject, XEngineCommand command)
		{
			bool flag = command.data != null;
			if (flag)
			{
				XGameObject xgameObject = command.data.data as XGameObject;
				bool flag2 = xgameObject != null;
				if (flag2)
				{
					return xgameObject.IsLoaded;
				}
			}
			return true;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0003AA24 File Offset: 0x00038C24
		public static void Execute(XGameObject gameObject, XEngineCommand command)
		{
			XGameObject parent = (command.data == null) ? null : (command.data.data as XGameObject);
			gameObject.SyncSetParent(parent);
		}

		// Token: 0x04000580 RID: 1408
		public static ExecuteCommandHandler handler = new ExecuteCommandHandler(XSetParentCommand.Execute);

		// Token: 0x04000581 RID: 1409
		public static CanExecuteHandler canExecute = new CanExecuteHandler(XSetParentCommand.CanExecute);

		// Token: 0x04000582 RID: 1410
		public static DebugHandler debugHandler = new DebugHandler(XSetParentCommand.DebugString);
	}
}
