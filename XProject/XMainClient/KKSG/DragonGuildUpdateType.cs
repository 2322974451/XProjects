using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildUpdateType")]
	public enum DragonGuildUpdateType
	{

		[ProtoEnum(Name = "DUType_AddMember", Value = 1)]
		DUType_AddMember = 1,

		[ProtoEnum(Name = "DUType_LeaveMember", Value = 2)]
		DUType_LeaveMember,

		[ProtoEnum(Name = "DUType_Dissmiss", Value = 3)]
		DUType_Dissmiss,

		[ProtoEnum(Name = "DUType_ShopRefresh", Value = 4)]
		DUType_ShopRefresh,

		[ProtoEnum(Name = "DUType_Level", Value = 5)]
		DUType_Level
	}
}
