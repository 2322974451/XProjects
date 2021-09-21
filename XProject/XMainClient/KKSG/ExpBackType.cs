using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000771 RID: 1905
	[ProtoContract(Name = "ExpBackType")]
	public enum ExpBackType
	{
		// Token: 0x040023AA RID: 9130
		[ProtoEnum(Name = "EXPBACK_ABYSSS", Value = 1)]
		EXPBACK_ABYSSS = 1,
		// Token: 0x040023AB RID: 9131
		[ProtoEnum(Name = "EXPBACK_NEST", Value = 2)]
		EXPBACK_NEST,
		// Token: 0x040023AC RID: 9132
		[ProtoEnum(Name = "EXPBACK_CAMPTASK", Value = 3)]
		EXPBACK_CAMPTASK
	}
}
