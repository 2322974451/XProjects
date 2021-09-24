using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KKVsRoleState")]
	public enum KKVsRoleState
	{

		[ProtoEnum(Name = "KK_VS_ROLE_UNLOAD", Value = 1)]
		KK_VS_ROLE_UNLOAD = 1,

		[ProtoEnum(Name = "KK_VS_ROLE_NORMAL", Value = 2)]
		KK_VS_ROLE_NORMAL,

		[ProtoEnum(Name = "KK_VS_ROLE_DIE", Value = 3)]
		KK_VS_ROLE_DIE,

		[ProtoEnum(Name = "KK_VS_ROLE_QUIT", Value = 4)]
		KK_VS_ROLE_QUIT
	}
}
