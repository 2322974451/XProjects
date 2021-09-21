using System;

namespace XMainClient
{
	// Token: 0x02000F71 RID: 3953
	internal class XRealDeadEventArgs : XActionArgs
	{
		// Token: 0x0600D074 RID: 53364 RVA: 0x003047AC File Offset: 0x003029AC
		public XRealDeadEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_RealDead;
			this.Killer = null;
			this.TheDead = null;
		}

		// Token: 0x0600D075 RID: 53365 RVA: 0x003047CC File Offset: 0x003029CC
		public override void Recycle()
		{
			base.Recycle();
			this.Killer = null;
			this.TheDead = null;
			XEventPool<XRealDeadEventArgs>.Recycle(this);
		}

		// Token: 0x04005E43 RID: 24131
		public XEntity Killer;

		// Token: 0x04005E44 RID: 24132
		public XEntity TheDead;
	}
}
