using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000778 RID: 1912
	[ProtoContract(Name = "PlatType")]
	public enum PlatType
	{
		// Token: 0x040023CD RID: 9165
		[ProtoEnum(Name = "PLAT_IOS", Value = 0)]
		PLAT_IOS,
		// Token: 0x040023CE RID: 9166
		[ProtoEnum(Name = "PLAT_ANDROID", Value = 1)]
		PLAT_ANDROID
	}
}
