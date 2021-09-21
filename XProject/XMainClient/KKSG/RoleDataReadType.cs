using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000780 RID: 1920
	[ProtoContract(Name = "RoleDataReadType")]
	public enum RoleDataReadType
	{
		// Token: 0x040023F4 RID: 9204
		[ProtoEnum(Name = "ROLE_DATA_READ_SELECT_ROLE", Value = 1)]
		ROLE_DATA_READ_SELECT_ROLE = 1,
		// Token: 0x040023F5 RID: 9205
		[ProtoEnum(Name = "ROLE_DATA_READ_IDIP", Value = 2)]
		ROLE_DATA_READ_IDIP
	}
}
