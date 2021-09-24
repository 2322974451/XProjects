using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SaveHistIbGiftEnum")]
	public enum SaveHistIbGiftEnum
	{

		[ProtoEnum(Name = "SaveIbGift_All", Value = 1)]
		SaveIbGift_All = 1,

		[ProtoEnum(Name = "SaveIbGift_Self", Value = 2)]
		SaveIbGift_Self,

		[ProtoEnum(Name = "SaveIbGift_Target", Value = 3)]
		SaveIbGift_Target
	}
}
