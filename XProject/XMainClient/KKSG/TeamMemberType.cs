using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007FE RID: 2046
	[ProtoContract(Name = "TeamMemberType")]
	public enum TeamMemberType
	{
		// Token: 0x040026F6 RID: 9974
		[ProtoEnum(Name = "TMT_NORMAL", Value = 1)]
		TMT_NORMAL = 1,
		// Token: 0x040026F7 RID: 9975
		[ProtoEnum(Name = "TMT_HELPER", Value = 2)]
		TMT_HELPER,
		// Token: 0x040026F8 RID: 9976
		[ProtoEnum(Name = "TMT_USETICKET", Value = 3)]
		TMT_USETICKET
	}
}
