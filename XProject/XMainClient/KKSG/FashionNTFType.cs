using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200075C RID: 1884
	[ProtoContract(Name = "FashionNTFType")]
	public enum FashionNTFType
	{
		// Token: 0x0400230B RID: 8971
		[ProtoEnum(Name = "ADD_FASHION", Value = 1)]
		ADD_FASHION = 1,
		// Token: 0x0400230C RID: 8972
		[ProtoEnum(Name = "UPGRADE_FASHION", Value = 2)]
		UPGRADE_FASHION,
		// Token: 0x0400230D RID: 8973
		[ProtoEnum(Name = "WEAR_FASHION", Value = 3)]
		WEAR_FASHION,
		// Token: 0x0400230E RID: 8974
		[ProtoEnum(Name = "DELBODY_FASHION", Value = 4)]
		DELBODY_FASHION,
		// Token: 0x0400230F RID: 8975
		[ProtoEnum(Name = "DELBAG_FASHION", Value = 5)]
		DELBAG_FASHION
	}
}
