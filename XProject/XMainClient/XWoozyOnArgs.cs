using System;

namespace XMainClient
{
	// Token: 0x02000F9C RID: 3996
	internal class XWoozyOnArgs : XEventArgs
	{
		// Token: 0x0600D0DE RID: 53470 RVA: 0x0030526E File Offset: 0x0030346E
		public XWoozyOnArgs()
		{
			this._eDefine = XEventDefine.XEvent_WoozyOn;
		}

		// Token: 0x0600D0DF RID: 53471 RVA: 0x00305283 File Offset: 0x00303483
		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XWoozyOnArgs>.Recycle(this);
		}

		// Token: 0x04005E85 RID: 24197
		public XEntity Self;
	}
}
