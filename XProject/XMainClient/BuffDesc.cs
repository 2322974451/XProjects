using System;

namespace XMainClient
{
	// Token: 0x02000E9E RID: 3742
	internal struct BuffDesc
	{
		// Token: 0x0600C794 RID: 51092 RVA: 0x002C91ED File Offset: 0x002C73ED
		public void Reset()
		{
			this.BuffID = 0;
			this.BuffLevel = 0;
			this.CasterID = 0UL;
			this.DelayTime = 0f;
			this.EffectTime = BuffDesc.DEFAULT_TIME;
			this.SkillID = 0U;
		}

		// Token: 0x040057D2 RID: 22482
		public int BuffID;

		// Token: 0x040057D3 RID: 22483
		public int BuffLevel;

		// Token: 0x040057D4 RID: 22484
		public ulong CasterID;

		// Token: 0x040057D5 RID: 22485
		public float DelayTime;

		// Token: 0x040057D6 RID: 22486
		public float EffectTime;

		// Token: 0x040057D7 RID: 22487
		public uint SkillID;

		// Token: 0x040057D8 RID: 22488
		public static float DEFAULT_TIME = -1f;
	}
}
