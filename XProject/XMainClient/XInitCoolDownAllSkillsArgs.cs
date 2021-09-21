using System;

namespace XMainClient
{
	// Token: 0x02000FA2 RID: 4002
	internal class XInitCoolDownAllSkillsArgs : XEventArgs
	{
		// Token: 0x0600D0EA RID: 53482 RVA: 0x0030537C File Offset: 0x0030357C
		public XInitCoolDownAllSkillsArgs()
		{
			this._eDefine = XEventDefine.XEvent_InitCoolDownAllSkills;
		}

		// Token: 0x0600D0EB RID: 53483 RVA: 0x00305391 File Offset: 0x00303591
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XInitCoolDownAllSkillsArgs>.Recycle(this);
		}
	}
}
