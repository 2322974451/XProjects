using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007AC RID: 1964
	[ProtoContract(Name = "PkResultType")]
	public enum PkResultType
	{
		// Token: 0x04002510 RID: 9488
		[ProtoEnum(Name = "PkResult_Win", Value = 1)]
		PkResult_Win = 1,
		// Token: 0x04002511 RID: 9489
		[ProtoEnum(Name = "PkResult_Lose", Value = 2)]
		PkResult_Lose,
		// Token: 0x04002512 RID: 9490
		[ProtoEnum(Name = "PkResult_Draw", Value = 3)]
		PkResult_Draw
	}
}
