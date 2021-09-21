using System;

namespace XMainClient
{
	// Token: 0x02000F9F RID: 3999
	internal class XStrengthPresevationOffArgs : XEventArgs
	{
		// Token: 0x0600D0E4 RID: 53476 RVA: 0x003052F5 File Offset: 0x003034F5
		public XStrengthPresevationOffArgs()
		{
			this._eDefine = XEventDefine.XEvent_StrengthPresevedOff;
		}

		// Token: 0x0600D0E5 RID: 53477 RVA: 0x0030530A File Offset: 0x0030350A
		public override void Recycle()
		{
			this.Host = null;
			base.Recycle();
			XEventPool<XStrengthPresevationOffArgs>.Recycle(this);
		}

		// Token: 0x04005E88 RID: 24200
		public XEntity Host;
	}
}
