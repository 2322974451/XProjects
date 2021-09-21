using System;

namespace XMainClient
{
	// Token: 0x02000F44 RID: 3908
	internal abstract class XSkillExternalArgs : XEventArgs
	{
		// Token: 0x0600CFDF RID: 53215 RVA: 0x00303901 File Offset: 0x00301B01
		public XSkillExternalArgs()
		{
			this._eDefine = XEventDefine.XEvent_SkillExternal;
		}

		// Token: 0x0600CFE0 RID: 53216 RVA: 0x00303925 File Offset: 0x00301B25
		public override void Recycle()
		{
			this.callback = null;
			this.delay = 0f;
			base.Recycle();
		}

		// Token: 0x04005DDF RID: 24031
		public SkillExternalCallback callback = null;

		// Token: 0x04005DE0 RID: 24032
		public float delay = 0f;
	}
}
