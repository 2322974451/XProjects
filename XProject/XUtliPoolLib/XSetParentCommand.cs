using System;

namespace XUtliPoolLib
{

	public class XSetParentCommand
	{

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

		public static void Execute(XGameObject gameObject, XEngineCommand command)
		{
			XGameObject parent = (command.data == null) ? null : (command.data.data as XGameObject);
			gameObject.SyncSetParent(parent);
		}

		public static ExecuteCommandHandler handler = new ExecuteCommandHandler(XSetParentCommand.Execute);

		public static CanExecuteHandler canExecute = new CanExecuteHandler(XSetParentCommand.CanExecute);

		public static DebugHandler debugHandler = new DebugHandler(XSetParentCommand.DebugString);
	}
}
