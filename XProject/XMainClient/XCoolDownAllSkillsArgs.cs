using System;

namespace XMainClient
{
	// Token: 0x02000FA1 RID: 4001
	internal class XCoolDownAllSkillsArgs : XEventArgs
	{
		// Token: 0x0600D0E8 RID: 53480 RVA: 0x00305356 File Offset: 0x00303556
		public XCoolDownAllSkillsArgs()
		{
			this._eDefine = XEventDefine.XEvent_CoolDownAllSkills;
		}

		// Token: 0x0600D0E9 RID: 53481 RVA: 0x0030536B File Offset: 0x0030356B
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XCoolDownAllSkillsArgs>.Recycle(this);
		}
	}
}
