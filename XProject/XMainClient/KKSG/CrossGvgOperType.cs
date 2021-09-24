using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgOperType")]
	public enum CrossGvgOperType
	{

		[ProtoEnum(Name = "CGOT_EnterPointRace", Value = 1)]
		CGOT_EnterPointRace = 1,

		[ProtoEnum(Name = "CGOT_EnterKnockout", Value = 2)]
		CGOT_EnterKnockout,

		[ProtoEnum(Name = "CGOT_SupportGuild", Value = 3)]
		CGOT_SupportGuild,

		[ProtoEnum(Name = "CGOT_LeaveUI", Value = 4)]
		CGOT_LeaveUI
	}
}
