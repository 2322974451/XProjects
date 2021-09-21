using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200080D RID: 2061
	[ProtoContract(Name = "BagType")]
	public enum BagType
	{
		// Token: 0x04002747 RID: 10055
		[ProtoEnum(Name = "EquipBag", Value = 1)]
		EquipBag = 1,
		// Token: 0x04002748 RID: 10056
		[ProtoEnum(Name = "EmblemBag", Value = 2)]
		EmblemBag,
		// Token: 0x04002749 RID: 10057
		[ProtoEnum(Name = "ArtifactBag", Value = 3)]
		ArtifactBag,
		// Token: 0x0400274A RID: 10058
		[ProtoEnum(Name = "ItemBag", Value = 4)]
		ItemBag
	}
}
