using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007BE RID: 1982
	[ProtoContract(Name = "ResWarResult")]
	public enum ResWarResult
	{
		// Token: 0x04002580 RID: 9600
		[ProtoEnum(Name = "RESWAR_SUCESS", Value = 1)]
		RESWAR_SUCESS = 1,
		// Token: 0x04002581 RID: 9601
		[ProtoEnum(Name = "RESWAR_FAIL", Value = 2)]
		RESWAR_FAIL,
		// Token: 0x04002582 RID: 9602
		[ProtoEnum(Name = "RESWAR_FLAT", Value = 3)]
		RESWAR_FLAT
	}
}
