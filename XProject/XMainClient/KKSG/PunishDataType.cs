using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200079F RID: 1951
	[ProtoContract(Name = "PunishDataType")]
	public enum PunishDataType
	{
		// Token: 0x040024B9 RID: 9401
		[ProtoEnum(Name = "PUNISH_DATA_UPATE", Value = 1)]
		PUNISH_DATA_UPATE = 1,
		// Token: 0x040024BA RID: 9402
		[ProtoEnum(Name = "PUNISH_DATA_DELETE", Value = 2)]
		PUNISH_DATA_DELETE
	}
}
