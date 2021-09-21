using System;

namespace XMainClient
{
	// Token: 0x02000F60 RID: 3936
	internal class XHitEventArgs : XEventArgs
	{
		// Token: 0x0600D02F RID: 53295 RVA: 0x003041CF File Offset: 0x003023CF
		public XHitEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Hit;
		}

		// Token: 0x0600D030 RID: 53296 RVA: 0x003041E0 File Offset: 0x003023E0
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XHitEventArgs>.Recycle(this);
		}
	}
}
