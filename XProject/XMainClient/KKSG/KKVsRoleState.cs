using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F2 RID: 2034
	[ProtoContract(Name = "KKVsRoleState")]
	public enum KKVsRoleState
	{
		// Token: 0x040026BD RID: 9917
		[ProtoEnum(Name = "KK_VS_ROLE_UNLOAD", Value = 1)]
		KK_VS_ROLE_UNLOAD = 1,
		// Token: 0x040026BE RID: 9918
		[ProtoEnum(Name = "KK_VS_ROLE_NORMAL", Value = 2)]
		KK_VS_ROLE_NORMAL,
		// Token: 0x040026BF RID: 9919
		[ProtoEnum(Name = "KK_VS_ROLE_DIE", Value = 3)]
		KK_VS_ROLE_DIE,
		// Token: 0x040026C0 RID: 9920
		[ProtoEnum(Name = "KK_VS_ROLE_QUIT", Value = 4)]
		KK_VS_ROLE_QUIT
	}
}
