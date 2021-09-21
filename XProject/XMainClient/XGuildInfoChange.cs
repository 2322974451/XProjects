using System;

namespace XMainClient
{
	// Token: 0x02000F8B RID: 3979
	internal class XGuildInfoChange : XEventArgs
	{
		// Token: 0x0600D0B4 RID: 53428 RVA: 0x00304F03 File Offset: 0x00303103
		public XGuildInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_GuildInfoChange;
		}

		// Token: 0x0600D0B5 RID: 53429 RVA: 0x00304F15 File Offset: 0x00303115
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XGuildInfoChange>.Recycle(this);
		}
	}
}
