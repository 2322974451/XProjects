using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F5E RID: 3934
	internal class XChargeEventArgs : XActionArgs
	{
		// Token: 0x0600D023 RID: 53283 RVA: 0x0030408A File Offset: 0x0030228A
		public XChargeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Charge;
			this.Data = null;
			this.TimeGone = 0f;
		}

		// Token: 0x0600D024 RID: 53284 RVA: 0x003040C0 File Offset: 0x003022C0
		public override void Recycle()
		{
			this.Data = null;
			this.AimedTarget = null;
			this.Height = 0f;
			this.TimeSpan = 0f;
			this.TimeScale = 1f;
			this.TimeGone = 0f;
			base.Recycle();
			XEventPool<XChargeEventArgs>.Recycle(this);
		}

		// Token: 0x17003686 RID: 13958
		// (get) Token: 0x0600D025 RID: 53285 RVA: 0x00304119 File Offset: 0x00302319
		// (set) Token: 0x0600D026 RID: 53286 RVA: 0x00304121 File Offset: 0x00302321
		public XChargeData Data { get; set; }

		// Token: 0x17003687 RID: 13959
		// (get) Token: 0x0600D027 RID: 53287 RVA: 0x0030412A File Offset: 0x0030232A
		// (set) Token: 0x0600D028 RID: 53288 RVA: 0x00304132 File Offset: 0x00302332
		public float Height { get; set; }

		// Token: 0x17003688 RID: 13960
		// (get) Token: 0x0600D029 RID: 53289 RVA: 0x0030413B File Offset: 0x0030233B
		// (set) Token: 0x0600D02A RID: 53290 RVA: 0x00304143 File Offset: 0x00302343
		public float TimeSpan { get; set; }

		// Token: 0x04005E16 RID: 24086
		public XEntity AimedTarget = null;

		// Token: 0x04005E19 RID: 24089
		public float TimeScale = 1f;

		// Token: 0x04005E1A RID: 24090
		public float TimeGone;
	}
}
