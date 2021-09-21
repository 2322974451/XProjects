using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000810 RID: 2064
	[ProtoContract(Name = "ForgeOpType")]
	public enum ForgeOpType
	{
		// Token: 0x04002754 RID: 10068
		[ProtoEnum(Name = "Forge_Equip", Value = 1)]
		Forge_Equip = 1,
		// Token: 0x04002755 RID: 10069
		[ProtoEnum(Name = "Forge_Replace", Value = 2)]
		Forge_Replace,
		// Token: 0x04002756 RID: 10070
		[ProtoEnum(Name = "Forge_Retain", Value = 3)]
		Forge_Retain
	}
}
