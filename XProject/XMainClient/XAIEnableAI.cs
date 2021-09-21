using System;

namespace XMainClient
{
	// Token: 0x02000F9B RID: 3995
	internal class XAIEnableAI : XEventArgs
	{
		// Token: 0x0600D0DC RID: 53468 RVA: 0x0030522C File Offset: 0x0030342C
		public XAIEnableAI()
		{
			this._eDefine = XEventDefine.XEvent_EnableAI;
			this.Enable = true;
			this.Puppet = true;
		}

		// Token: 0x0600D0DD RID: 53469 RVA: 0x0030524F File Offset: 0x0030344F
		public override void Recycle()
		{
			base.Recycle();
			this.Enable = true;
			this.Puppet = true;
			XEventPool<XAIEnableAI>.Recycle(this);
		}

		// Token: 0x04005E83 RID: 24195
		public bool Enable;

		// Token: 0x04005E84 RID: 24196
		public bool Puppet;
	}
}
