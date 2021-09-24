using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayGiftIbStatus")]
	public enum PayGiftIbStatus
	{

		[ProtoEnum(Name = "PayGiftIbStatus_CreateBill", Value = 1)]
		PayGiftIbStatus_CreateBill = 1,

		[ProtoEnum(Name = "PayGiftIbStatus_Fail", Value = 2)]
		PayGiftIbStatus_Fail,

		[ProtoEnum(Name = "PayGiftIbStatus_Success", Value = 3)]
		PayGiftIbStatus_Success,

		[ProtoEnum(Name = "PayGiftIbStatus_SuccessNotAddItem", Value = 4)]
		PayGiftIbStatus_SuccessNotAddItem
	}
}
