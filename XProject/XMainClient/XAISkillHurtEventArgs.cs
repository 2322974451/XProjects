using System;

namespace XMainClient
{
	// Token: 0x02000F5A RID: 3930
	internal class XAISkillHurtEventArgs : XEventArgs
	{
		// Token: 0x0600D01B RID: 53275 RVA: 0x00303EBF File Offset: 0x003020BF
		public XAISkillHurtEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AISkillHurt;
		}

		// Token: 0x0600D01C RID: 53276 RVA: 0x00303EDF File Offset: 0x003020DF
		public override void Recycle()
		{
			this.SkillId = 0U;
			base.Recycle();
			XEventPool<XAISkillHurtEventArgs>.Recycle(this);
		}

		// Token: 0x04005E06 RID: 24070
		public uint SkillId = 0U;

		// Token: 0x04005E07 RID: 24071
		public bool IsCaster = false;
	}
}
