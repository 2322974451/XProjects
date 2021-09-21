using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000803 RID: 2051
	[ProtoContract(Name = "CustomBattleScale")]
	public enum CustomBattleScale
	{
		// Token: 0x0400271B RID: 10011
		[ProtoEnum(Name = "CustomBattle_Scale_Friend", Value = 1)]
		CustomBattle_Scale_Friend = 1,
		// Token: 0x0400271C RID: 10012
		[ProtoEnum(Name = "CustomBattle_Scale_Guild", Value = 2)]
		CustomBattle_Scale_Guild,
		// Token: 0x0400271D RID: 10013
		[ProtoEnum(Name = "CustomBattle_Scale_Server", Value = 3)]
		CustomBattle_Scale_Server,
		// Token: 0x0400271E RID: 10014
		[ProtoEnum(Name = "CustomBattle_Scale_All", Value = 4)]
		CustomBattle_Scale_All
	}
}
