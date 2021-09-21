using System;

namespace XMainClient
{
	// Token: 0x02000F97 RID: 3991
	internal class XEnmityEventArgs : XEventArgs
	{
		// Token: 0x1700369F RID: 13983
		// (get) Token: 0x0600D0CC RID: 53452 RVA: 0x003050F8 File Offset: 0x003032F8
		// (set) Token: 0x0600D0CD RID: 53453 RVA: 0x00305110 File Offset: 0x00303310
		public XObject Starter
		{
			get
			{
				return this._starter;
			}
			set
			{
				this._starter = value;
			}
		}

		// Token: 0x0600D0CE RID: 53454 RVA: 0x0030511A File Offset: 0x0030331A
		public XEnmityEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Enmity;
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
		}

		// Token: 0x0600D0CF RID: 53455 RVA: 0x0030513E File Offset: 0x0030333E
		public override void Recycle()
		{
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.DeltaValue = 0.0;
			this._starter = null;
			base.Recycle();
			XEventPool<XEnmityEventArgs>.Recycle(this);
		}

		// Token: 0x170036A0 RID: 13984
		// (get) Token: 0x0600D0D0 RID: 53456 RVA: 0x0030516E File Offset: 0x0030336E
		// (set) Token: 0x0600D0D1 RID: 53457 RVA: 0x00305176 File Offset: 0x00303376
		public XAttributeDefine AttrKey { get; set; }

		// Token: 0x170036A1 RID: 13985
		// (get) Token: 0x0600D0D2 RID: 53458 RVA: 0x0030517F File Offset: 0x0030337F
		// (set) Token: 0x0600D0D3 RID: 53459 RVA: 0x00305187 File Offset: 0x00303387
		public double DeltaValue { get; set; }

		// Token: 0x170036A2 RID: 13986
		// (get) Token: 0x0600D0D4 RID: 53460 RVA: 0x00305190 File Offset: 0x00303390
		// (set) Token: 0x0600D0D5 RID: 53461 RVA: 0x00305198 File Offset: 0x00303398
		public uint SkillId { get; set; }

		// Token: 0x04005E7C RID: 24188
		protected XObject _starter = null;
	}
}
