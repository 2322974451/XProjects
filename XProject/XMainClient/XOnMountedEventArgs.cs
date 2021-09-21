using System;

namespace XMainClient
{
	// Token: 0x02000FA7 RID: 4007
	internal class XOnMountedEventArgs : XEventArgs
	{
		// Token: 0x0600D0F4 RID: 53492 RVA: 0x00305472 File Offset: 0x00303672
		public XOnMountedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnMounted;
		}

		// Token: 0x0600D0F5 RID: 53493 RVA: 0x00305487 File Offset: 0x00303687
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XOnMountedEventArgs>.Recycle(this);
		}
	}
}
