using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayCardType")]
	public enum PayCardType
	{

		[ProtoEnum(Name = "WEEK_CARD", Value = 1)]
		WEEK_CARD = 1,

		[ProtoEnum(Name = "MONTH_CARD", Value = 2)]
		MONTH_CARD
	}
}
