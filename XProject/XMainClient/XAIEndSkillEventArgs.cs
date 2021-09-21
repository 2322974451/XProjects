using System;

namespace XMainClient
{
	// Token: 0x02000F59 RID: 3929
	internal class XAIEndSkillEventArgs : XEventArgs
	{
		// Token: 0x0600D019 RID: 53273 RVA: 0x00303E80 File Offset: 0x00302080
		public XAIEndSkillEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIEndSkill;
		}

		// Token: 0x0600D01A RID: 53274 RVA: 0x00303EA0 File Offset: 0x003020A0
		public override void Recycle()
		{
			this.SkillId = 0U;
			this.IsCaster = false;
			base.Recycle();
			XEventPool<XAIEndSkillEventArgs>.Recycle(this);
		}

		// Token: 0x04005E04 RID: 24068
		public uint SkillId = 0U;

		// Token: 0x04005E05 RID: 24069
		public bool IsCaster = false;
	}
}
