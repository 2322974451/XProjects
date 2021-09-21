using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200080E RID: 2062
	[ProtoContract(Name = "CustomBattleTag")]
	public enum CustomBattleTag
	{
		// Token: 0x0400274C RID: 10060
		[ProtoEnum(Name = "CustomBattle_Tag_Friend", Value = 1)]
		CustomBattle_Tag_Friend = 1,
		// Token: 0x0400274D RID: 10061
		[ProtoEnum(Name = "CustomBattle_Tag_Guild", Value = 2)]
		CustomBattle_Tag_Guild,
		// Token: 0x0400274E RID: 10062
		[ProtoEnum(Name = "CustomBattle_Tag_Cross", Value = 3)]
		CustomBattle_Tag_Cross,
		// Token: 0x0400274F RID: 10063
		[ProtoEnum(Name = "CustomBattle_Tag_GM", Value = 4)]
		CustomBattle_Tag_GM
	}
}
