using System;

namespace XUtliPoolLib
{
	// Token: 0x020001E7 RID: 487
	public class XObjAsyncData : IQueueObject
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000B38 RID: 2872 RVA: 0x0003AF57 File Offset: 0x00039157
		// (set) Token: 0x06000B39 RID: 2873 RVA: 0x0003AF5F File Offset: 0x0003915F
		public IQueueObject next { get; set; }

		// Token: 0x06000B3A RID: 2874 RVA: 0x0003AF68 File Offset: 0x00039168
		public void Reset()
		{
			this.data = null;
			this.commandCb = null;
			bool flag = this.resetCb != null;
			if (flag)
			{
				this.resetCb();
				this.resetCb = null;
			}
		}

		// Token: 0x04000587 RID: 1415
		public object data = null;

		// Token: 0x04000588 RID: 1416
		public CommandCallback commandCb = null;

		// Token: 0x04000589 RID: 1417
		public ResetCallback resetCb = null;
	}
}
