using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F5 RID: 2037
	[ProtoContract(Name = "PayGiftIbStatus")]
	public enum PayGiftIbStatus
	{
		// Token: 0x040026D2 RID: 9938
		[ProtoEnum(Name = "PayGiftIbStatus_CreateBill", Value = 1)]
		PayGiftIbStatus_CreateBill = 1,
		// Token: 0x040026D3 RID: 9939
		[ProtoEnum(Name = "PayGiftIbStatus_Fail", Value = 2)]
		PayGiftIbStatus_Fail,
		// Token: 0x040026D4 RID: 9940
		[ProtoEnum(Name = "PayGiftIbStatus_Success", Value = 3)]
		PayGiftIbStatus_Success,
		// Token: 0x040026D5 RID: 9941
		[ProtoEnum(Name = "PayGiftIbStatus_SuccessNotAddItem", Value = 4)]
		PayGiftIbStatus_SuccessNotAddItem
	}
}
