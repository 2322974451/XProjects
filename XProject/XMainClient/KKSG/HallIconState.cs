using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007AD RID: 1965
	[ProtoContract(Name = "HallIconState")]
	public enum HallIconState
	{
		// Token: 0x04002514 RID: 9492
		[ProtoEnum(Name = "HICONS_BEGIN", Value = 1)]
		HICONS_BEGIN = 1,
		// Token: 0x04002515 RID: 9493
		[ProtoEnum(Name = "HICONS_END", Value = 2)]
		HICONS_END
	}
}
