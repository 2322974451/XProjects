using System;

namespace XMainClient
{
	// Token: 0x02000F8C RID: 3980
	internal class XDragonGuildInfoChange : XEventArgs
	{
		// Token: 0x0600D0B6 RID: 53430 RVA: 0x00304F26 File Offset: 0x00303126
		public XDragonGuildInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_DragonGuildInfoChange;
		}

		// Token: 0x0600D0B7 RID: 53431 RVA: 0x00304F3B File Offset: 0x0030313B
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XDragonGuildInfoChange>.Recycle(this);
		}
	}
}
