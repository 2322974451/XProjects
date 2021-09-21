using System;

namespace XMainClient
{
	// Token: 0x02000F47 RID: 3911
	internal class XJumpEventArgs : XActionArgs
	{
		// Token: 0x0600CFE5 RID: 53221 RVA: 0x003039E3 File Offset: 0x00301BE3
		public XJumpEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Jump;
		}

		// Token: 0x0600CFE6 RID: 53222 RVA: 0x003039F4 File Offset: 0x00301BF4
		public override void Recycle()
		{
			this.Gravity = 0f;
			this.Hvelocity = 0f;
			this.Vvelocity = 0f;
			base.Recycle();
			XEventPool<XJumpEventArgs>.Recycle(this);
		}

		// Token: 0x1700367E RID: 13950
		// (get) Token: 0x0600CFE7 RID: 53223 RVA: 0x00303A29 File Offset: 0x00301C29
		// (set) Token: 0x0600CFE8 RID: 53224 RVA: 0x00303A31 File Offset: 0x00301C31
		public float Gravity { get; set; }

		// Token: 0x1700367F RID: 13951
		// (get) Token: 0x0600CFE9 RID: 53225 RVA: 0x00303A3A File Offset: 0x00301C3A
		// (set) Token: 0x0600CFEA RID: 53226 RVA: 0x00303A42 File Offset: 0x00301C42
		public float Hvelocity { get; set; }

		// Token: 0x17003680 RID: 13952
		// (get) Token: 0x0600CFEB RID: 53227 RVA: 0x00303A4B File Offset: 0x00301C4B
		// (set) Token: 0x0600CFEC RID: 53228 RVA: 0x00303A53 File Offset: 0x00301C53
		public float Vvelocity { get; set; }
	}
}
