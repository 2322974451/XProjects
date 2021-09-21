using System;

namespace XMainClient
{
	// Token: 0x02000FA5 RID: 4005
	internal class XOnRevivedArgs : XEventArgs
	{
		// Token: 0x0600D0F0 RID: 53488 RVA: 0x00305406 File Offset: 0x00303606
		public XOnRevivedArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnRevived;
			this.entity = null;
		}

		// Token: 0x0600D0F1 RID: 53489 RVA: 0x0030541F File Offset: 0x0030361F
		public override void Recycle()
		{
			base.Recycle();
			this.entity = null;
			XEventPool<XOnRevivedArgs>.Recycle(this);
		}

		// Token: 0x04005E8C RID: 24204
		public XEntity entity;
	}
}
