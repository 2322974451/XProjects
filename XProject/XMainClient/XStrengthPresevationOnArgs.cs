using System;

namespace XMainClient
{
	// Token: 0x02000F9E RID: 3998
	internal class XStrengthPresevationOnArgs : XEventArgs
	{
		// Token: 0x0600D0E2 RID: 53474 RVA: 0x003052C8 File Offset: 0x003034C8
		public XStrengthPresevationOnArgs()
		{
			this._eDefine = XEventDefine.XEvent_StrengthPresevedOn;
		}

		// Token: 0x0600D0E3 RID: 53475 RVA: 0x003052DD File Offset: 0x003034DD
		public override void Recycle()
		{
			this.Host = null;
			base.Recycle();
			XEventPool<XStrengthPresevationOnArgs>.Recycle(this);
		}

		// Token: 0x04005E87 RID: 24199
		public XEntity Host;
	}
}
