using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PartnerOperType")]
	public enum PartnerOperType
	{

		[ProtoEnum(Name = "POT_Normal", Value = 1)]
		POT_Normal = 1,

		[ProtoEnum(Name = "POT_Liveness", Value = 2)]
		POT_Liveness,

		[ProtoEnum(Name = "POT_Leave", Value = 3)]
		POT_Leave,

		[ProtoEnum(Name = "POT_ApplyLeave", Value = 4)]
		POT_ApplyLeave,

		[ProtoEnum(Name = "POT_CancelLeave", Value = 5)]
		POT_CancelLeave,

		[ProtoEnum(Name = "POT_Dissolve", Value = 6)]
		POT_Dissolve
	}
}
