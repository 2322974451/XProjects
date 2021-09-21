using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000836 RID: 2102
	[ProtoContract(Name = "CrossGvgBattleType")]
	public enum CrossGvgBattleType
	{
		// Token: 0x04002826 RID: 10278
		[ProtoEnum(Name = "CGBT_PointRace", Value = 1)]
		CGBT_PointRace = 1,
		// Token: 0x04002827 RID: 10279
		[ProtoEnum(Name = "CGBT_Knockout", Value = 2)]
		CGBT_Knockout
	}
}
