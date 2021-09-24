using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PersonalCarrerReqType")]
	public enum PersonalCarrerReqType
	{

		[ProtoEnum(Name = "PCRT_HOME_PAGE", Value = 1)]
		PCRT_HOME_PAGE = 1,

		[ProtoEnum(Name = "PCRT_PVP_PKINFO", Value = 2)]
		PCRT_PVP_PKINFO,

		[ProtoEnum(Name = "PCRT_TROPHY", Value = 3)]
		PCRT_TROPHY
	}
}
