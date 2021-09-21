using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E8 RID: 2024
	[ProtoContract(Name = "LeagueBattleType")]
	public enum LeagueBattleType
	{
		// Token: 0x0400266B RID: 9835
		[ProtoEnum(Name = "LeagueBattleType_RacePoint", Value = 1)]
		LeagueBattleType_RacePoint = 1,
		// Token: 0x0400266C RID: 9836
		[ProtoEnum(Name = "LeagueBattleType_Eliminate", Value = 2)]
		LeagueBattleType_Eliminate,
		// Token: 0x0400266D RID: 9837
		[ProtoEnum(Name = "LeagueBattleType_CrossRacePoint", Value = 3)]
		LeagueBattleType_CrossRacePoint,
		// Token: 0x0400266E RID: 9838
		[ProtoEnum(Name = "LeagueBattleType_CrossEliminate", Value = 4)]
		LeagueBattleType_CrossEliminate
	}
}
