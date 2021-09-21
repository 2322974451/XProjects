using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000807 RID: 2055
	[ProtoContract(Name = "SaveHistIbGiftEnum")]
	public enum SaveHistIbGiftEnum
	{
		// Token: 0x0400272D RID: 10029
		[ProtoEnum(Name = "SaveIbGift_All", Value = 1)]
		SaveIbGift_All = 1,
		// Token: 0x0400272E RID: 10030
		[ProtoEnum(Name = "SaveIbGift_Self", Value = 2)]
		SaveIbGift_Self,
		// Token: 0x0400272F RID: 10031
		[ProtoEnum(Name = "SaveIbGift_Target", Value = 3)]
		SaveIbGift_Target
	}
}
