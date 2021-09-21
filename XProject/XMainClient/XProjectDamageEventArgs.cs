using System;

namespace XMainClient
{
	// Token: 0x02000FA6 RID: 4006
	internal class XProjectDamageEventArgs : XEventArgs
	{
		// Token: 0x0600D0F2 RID: 53490 RVA: 0x00305437 File Offset: 0x00303637
		public XProjectDamageEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ProjectDamage;
		}

		// Token: 0x0600D0F3 RID: 53491 RVA: 0x0030544C File Offset: 0x0030364C
		public override void Recycle()
		{
			base.Recycle();
			this.Damage = null;
			this.Hurt = null;
			this.Receiver = null;
			XEventPool<XProjectDamageEventArgs>.Recycle(this);
		}

		// Token: 0x04005E8D RID: 24205
		public ProjectDamageResult Damage;

		// Token: 0x04005E8E RID: 24206
		public HurtInfo Hurt;

		// Token: 0x04005E8F RID: 24207
		public XEntity Receiver;
	}
}
