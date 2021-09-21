using System;

namespace XMainClient
{
	// Token: 0x02000FAC RID: 4012
	internal class XSkillExternalBuffArgs : XSkillExternalArgs
	{
		// Token: 0x0600D0FE RID: 53502 RVA: 0x0030555C File Offset: 0x0030375C
		public XSkillExternalBuffArgs()
		{
			this.xBuffDesc.Reset();
			this.xTarget = null;
		}

		// Token: 0x0600D0FF RID: 53503 RVA: 0x00305585 File Offset: 0x00303785
		public override void Recycle()
		{
			this.xBuffDesc.Reset();
			this.xTarget = null;
			base.Recycle();
			XEventPool<XSkillExternalBuffArgs>.Recycle(this);
		}

		// Token: 0x04005E93 RID: 24211
		public BuffDesc xBuffDesc = default(BuffDesc);

		// Token: 0x04005E94 RID: 24212
		public XEntity xTarget;
	}
}
