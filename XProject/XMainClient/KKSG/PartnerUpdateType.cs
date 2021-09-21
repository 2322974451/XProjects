using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D5 RID: 2005
	[ProtoContract(Name = "PartnerUpdateType")]
	public enum PartnerUpdateType
	{
		// Token: 0x0400260B RID: 9739
		[ProtoEnum(Name = "PUType_Normal", Value = 1)]
		PUType_Normal = 1,
		// Token: 0x0400260C RID: 9740
		[ProtoEnum(Name = "PUType_Leave", Value = 2)]
		PUType_Leave,
		// Token: 0x0400260D RID: 9741
		[ProtoEnum(Name = "PUType_Dissolve", Value = 3)]
		PUType_Dissolve,
		// Token: 0x0400260E RID: 9742
		[ProtoEnum(Name = "PUType_Shop", Value = 4)]
		PUType_Shop
	}
}
