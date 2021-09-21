using System;

namespace XMainClient
{
	// Token: 0x02000F57 RID: 3927
	internal class XAIRestartEventArgs : XEventArgs
	{
		// Token: 0x0600D015 RID: 53269 RVA: 0x00303E1E File Offset: 0x0030201E
		public XAIRestartEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIRestart;
		}

		// Token: 0x0600D016 RID: 53270 RVA: 0x00303E30 File Offset: 0x00302030
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XAIRestartEventArgs>.Recycle(this);
		}
	}
}
