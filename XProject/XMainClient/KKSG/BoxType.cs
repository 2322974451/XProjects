using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000762 RID: 1890
	[ProtoContract(Name = "BoxType")]
	public enum BoxType
	{
		// Token: 0x04002348 RID: 9032
		[ProtoEnum(Name = "BOX_TYPE_NONE", Value = 0)]
		BOX_TYPE_NONE,
		// Token: 0x04002349 RID: 9033
		[ProtoEnum(Name = "BOX_TYPE_GOLD", Value = 3)]
		BOX_TYPE_GOLD = 3,
		// Token: 0x0400234A RID: 9034
		[ProtoEnum(Name = "BOX_TYPE_SILVER", Value = 2)]
		BOX_TYPE_SILVER = 2,
		// Token: 0x0400234B RID: 9035
		[ProtoEnum(Name = "BOX_TYPE_COPPER", Value = 1)]
		BOX_TYPE_COPPER = 1,
		// Token: 0x0400234C RID: 9036
		[ProtoEnum(Name = "BOX_TYPE_DIAMOND", Value = 4)]
		BOX_TYPE_DIAMOND = 4
	}
}
