using System;

namespace XMainClient
{
	// Token: 0x02000F48 RID: 3912
	internal class XFallEventArgs : XActionArgs
	{
		// Token: 0x0600CFED RID: 53229 RVA: 0x00303A5C File Offset: 0x00301C5C
		public XFallEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Fall;
		}

		// Token: 0x0600CFEE RID: 53230 RVA: 0x00303A6D File Offset: 0x00301C6D
		public override void Recycle()
		{
			this.HVelocity = 0f;
			this.Gravity = 0f;
			base.Recycle();
			XEventPool<XFallEventArgs>.Recycle(this);
		}

		// Token: 0x17003681 RID: 13953
		// (get) Token: 0x0600CFEF RID: 53231 RVA: 0x00303A96 File Offset: 0x00301C96
		// (set) Token: 0x0600CFF0 RID: 53232 RVA: 0x00303A9E File Offset: 0x00301C9E
		public float HVelocity { get; set; }

		// Token: 0x17003682 RID: 13954
		// (get) Token: 0x0600CFF1 RID: 53233 RVA: 0x00303AA7 File Offset: 0x00301CA7
		// (set) Token: 0x0600CFF2 RID: 53234 RVA: 0x00303AAF File Offset: 0x00301CAF
		public float Gravity { get; set; }
	}
}
