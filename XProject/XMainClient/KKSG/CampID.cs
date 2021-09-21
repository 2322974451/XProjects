using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200076A RID: 1898
	[ProtoContract(Name = "CampID")]
	public enum CampID
	{
		// Token: 0x04002390 RID: 9104
		[ProtoEnum(Name = "CAMP_DRAGON", Value = 1)]
		CAMP_DRAGON = 1,
		// Token: 0x04002391 RID: 9105
		[ProtoEnum(Name = "CAMP_KNIGHT", Value = 2)]
		CAMP_KNIGHT,
		// Token: 0x04002392 RID: 9106
		[ProtoEnum(Name = "CAMP_ADVENTURER", Value = 3)]
		CAMP_ADVENTURER
	}
}
