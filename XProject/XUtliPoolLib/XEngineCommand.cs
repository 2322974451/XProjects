using System;

namespace XUtliPoolLib
{

	public class XEngineCommand : IQueueObject
	{

		public IQueueObject next { get; set; }

		public bool IsValid()
		{
			return this.gameObject != null && this.gameObject.objID == this.objID;
		}

		public void Execute()
		{
			bool flag = this.handler != null;
			if (flag)
			{
				this.handler(this.gameObject, this);
			}
		}

		public void Reset()
		{
			this.objID = -1;
			this.commandID = -1;
			this.gameObject = null;
			this.handler = null;
			this.canExecute = null;
			this.data = null;
			this.id = -1;
			this.debugHandler = null;
		}

		public bool CanExecute()
		{
			bool flag = this.gameObject != null && this.gameObject.IsLoaded;
			bool result;
			if (flag)
			{
				bool flag2 = this.canExecute != null;
				result = (!flag2 || this.canExecute(this.gameObject, this));
			}
			else
			{
				result = false;
			}
			return result;
		}

		public static int GetCommandID()
		{
			int result = XEngineCommand.globalCommandID++;
			bool flag = XEngineCommand.globalCommandID > 1000000;
			if (flag)
			{
				XEngineCommand.globalCommandID = 0;
			}
			return result;
		}

		public XGameObject gameObject = null;

		public ExecuteCommandHandler handler = null;

		public CanExecuteHandler canExecute = null;

		public XObjAsyncData data = null;

		public int objID = -1;

		public int commandID = -1;

		public static int globalCommandID = 0;

		public DebugHandler debugHandler = null;

		public int id = -1;

		public static int debugid = 0;

		public static bool debug = false;
	}
}
