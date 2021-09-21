using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000824 RID: 2084
	[ProtoContract(Name = "DragonGuildUpdateType")]
	public enum DragonGuildUpdateType
	{
		// Token: 0x040027BF RID: 10175
		[ProtoEnum(Name = "DUType_AddMember", Value = 1)]
		DUType_AddMember = 1,
		// Token: 0x040027C0 RID: 10176
		[ProtoEnum(Name = "DUType_LeaveMember", Value = 2)]
		DUType_LeaveMember,
		// Token: 0x040027C1 RID: 10177
		[ProtoEnum(Name = "DUType_Dissmiss", Value = 3)]
		DUType_Dissmiss,
		// Token: 0x040027C2 RID: 10178
		[ProtoEnum(Name = "DUType_ShopRefresh", Value = 4)]
		DUType_ShopRefresh,
		// Token: 0x040027C3 RID: 10179
		[ProtoEnum(Name = "DUType_Level", Value = 5)]
		DUType_Level
	}
}
