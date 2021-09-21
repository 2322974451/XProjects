using System;

namespace XUtliPoolLib
{
	// Token: 0x020001E1 RID: 481
	public class XEngineCommand : IQueueObject
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x0003A7CA File Offset: 0x000389CA
		// (set) Token: 0x06000AF4 RID: 2804 RVA: 0x0003A7D2 File Offset: 0x000389D2
		public IQueueObject next { get; set; }

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0003A7DC File Offset: 0x000389DC
		public bool IsValid()
		{
			return this.gameObject != null && this.gameObject.objID == this.objID;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0003A80C File Offset: 0x00038A0C
		public void Execute()
		{
			bool flag = this.handler != null;
			if (flag)
			{
				this.handler(this.gameObject, this);
			}
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0003A83C File Offset: 0x00038A3C
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

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0003A878 File Offset: 0x00038A78
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

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0003A8D0 File Offset: 0x00038AD0
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

		// Token: 0x04000574 RID: 1396
		public XGameObject gameObject = null;

		// Token: 0x04000575 RID: 1397
		public ExecuteCommandHandler handler = null;

		// Token: 0x04000576 RID: 1398
		public CanExecuteHandler canExecute = null;

		// Token: 0x04000577 RID: 1399
		public XObjAsyncData data = null;

		// Token: 0x04000578 RID: 1400
		public int objID = -1;

		// Token: 0x04000579 RID: 1401
		public int commandID = -1;

		// Token: 0x0400057A RID: 1402
		public static int globalCommandID = 0;

		// Token: 0x0400057B RID: 1403
		public DebugHandler debugHandler = null;

		// Token: 0x0400057C RID: 1404
		public int id = -1;

		// Token: 0x0400057D RID: 1405
		public static int debugid = 0;

		// Token: 0x0400057E RID: 1406
		public static bool debug = false;
	}
}
