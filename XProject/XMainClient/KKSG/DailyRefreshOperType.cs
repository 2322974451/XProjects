using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyRefreshOperType")]
	public enum DailyRefreshOperType
	{

		[ProtoEnum(Name = "DROT_Refresh", Value = 1)]
		DROT_Refresh = 1,

		[ProtoEnum(Name = "DROT_Refuse", Value = 2)]
		DROT_Refuse,

		[ProtoEnum(Name = "DROT_BuyCount", Value = 3)]
		DROT_BuyCount,

		[ProtoEnum(Name = "DROT_AskHelp", Value = 4)]
		DROT_AskHelp
	}
}
