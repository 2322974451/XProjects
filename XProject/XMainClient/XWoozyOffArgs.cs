using System;

namespace XMainClient
{
	// Token: 0x02000F9D RID: 3997
	internal class XWoozyOffArgs : XEventArgs
	{
		// Token: 0x0600D0E0 RID: 53472 RVA: 0x0030529B File Offset: 0x0030349B
		public XWoozyOffArgs()
		{
			this._eDefine = XEventDefine.XEvent_WoozyOff;
		}

		// Token: 0x0600D0E1 RID: 53473 RVA: 0x003052B0 File Offset: 0x003034B0
		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XWoozyOffArgs>.Recycle(this);
		}

		// Token: 0x04005E86 RID: 24198
		public XEntity Self;
	}
}
