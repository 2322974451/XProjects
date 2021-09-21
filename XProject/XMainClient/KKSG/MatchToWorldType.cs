using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F0 RID: 2032
	[ProtoContract(Name = "MatchToWorldType")]
	public enum MatchToWorldType
	{
		// Token: 0x04002699 RID: 9881
		[ProtoEnum(Name = "MTWT_ADD", Value = 1)]
		MTWT_ADD = 1,
		// Token: 0x0400269A RID: 9882
		[ProtoEnum(Name = "MTWT_DEL", Value = 2)]
		MTWT_DEL,
		// Token: 0x0400269B RID: 9883
		[ProtoEnum(Name = "MTWT_MATCH_INWORLD", Value = 3)]
		MTWT_MATCH_INWORLD
	}
}
