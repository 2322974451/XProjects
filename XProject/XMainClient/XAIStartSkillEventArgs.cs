using System;

namespace XMainClient
{
	// Token: 0x02000F58 RID: 3928
	internal class XAIStartSkillEventArgs : XEventArgs
	{
		// Token: 0x0600D017 RID: 53271 RVA: 0x00303E41 File Offset: 0x00302041
		public XAIStartSkillEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIStartSkill;
		}

		// Token: 0x0600D018 RID: 53272 RVA: 0x00303E61 File Offset: 0x00302061
		public override void Recycle()
		{
			this.SkillId = 0U;
			this.IsCaster = false;
			base.Recycle();
			XEventPool<XAIStartSkillEventArgs>.Recycle(this);
		}

		// Token: 0x04005E02 RID: 24066
		public uint SkillId = 0U;

		// Token: 0x04005E03 RID: 24067
		public bool IsCaster = false;
	}
}
