using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000F92 RID: 3986
	internal class XTaskStatusChangeArgs : XEventArgs
	{
		// Token: 0x0600D0C2 RID: 53442 RVA: 0x0030501C File Offset: 0x0030321C
		public XTaskStatusChangeArgs()
		{
			this._eDefine = XEventDefine.XEvent_TaskStateChange;
		}

		// Token: 0x0600D0C3 RID: 53443 RVA: 0x00305031 File Offset: 0x00303231
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XTaskStatusChangeArgs>.Recycle(this);
		}

		// Token: 0x04005E77 RID: 24183
		public TaskStatus status;

		// Token: 0x04005E78 RID: 24184
		public uint id;
	}
}
