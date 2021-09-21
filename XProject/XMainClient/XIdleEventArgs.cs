using System;

namespace XMainClient
{
	// Token: 0x02000F45 RID: 3909
	internal class XIdleEventArgs : XActionArgs
	{
		// Token: 0x0600CFE1 RID: 53217 RVA: 0x00303941 File Offset: 0x00301B41
		public XIdleEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Idle;
		}

		// Token: 0x0600CFE2 RID: 53218 RVA: 0x00303952 File Offset: 0x00301B52
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XIdleEventArgs>.Recycle(this);
		}
	}
}
