using System;

namespace XMainClient
{
	// Token: 0x02000F93 RID: 3987
	internal class XSkillQTEEventArgs : XEventArgs
	{
		// Token: 0x0600D0C4 RID: 53444 RVA: 0x00305042 File Offset: 0x00303242
		public XSkillQTEEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_QTE;
		}

		// Token: 0x0600D0C5 RID: 53445 RVA: 0x00305062 File Offset: 0x00303262
		public override void Recycle()
		{
			base.Recycle();
			this.State = 0U;
			this.On = false;
			XEventPool<XSkillQTEEventArgs>.Recycle(this);
		}

		// Token: 0x04005E79 RID: 24185
		public uint State = 0U;

		// Token: 0x04005E7A RID: 24186
		public bool On = false;
	}
}
