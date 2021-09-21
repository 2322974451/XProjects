using System;

namespace XMainClient
{
	// Token: 0x02000FA8 RID: 4008
	internal class XOnUnMountedEventArgs : XEventArgs
	{
		// Token: 0x0600D0F6 RID: 53494 RVA: 0x00305498 File Offset: 0x00303698
		public XOnUnMountedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnUnMounted;
		}

		// Token: 0x0600D0F7 RID: 53495 RVA: 0x003054AD File Offset: 0x003036AD
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XOnUnMountedEventArgs>.Recycle(this);
		}
	}
}
