using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000E9F RID: 3743
	internal class SkillEffect
	{
		// Token: 0x040057D9 RID: 22489
		public DamageElement DamageElementType;

		// Token: 0x040057DA RID: 22490
		public double PhyRatio;

		// Token: 0x040057DB RID: 22491
		public double PhyFixed;

		// Token: 0x040057DC RID: 22492
		public double MagRatio;

		// Token: 0x040057DD RID: 22493
		public double MagFixed;

		// Token: 0x040057DE RID: 22494
		public double PercentDamage;

		// Token: 0x040057DF RID: 22495
		public float DecSuperArmor;

		// Token: 0x040057E0 RID: 22496
		public List<BuffDesc> Buffs;

		// Token: 0x040057E1 RID: 22497
		public uint ExclusiveMask;
	}
}
