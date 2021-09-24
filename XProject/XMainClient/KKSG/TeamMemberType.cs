using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamMemberType")]
	public enum TeamMemberType
	{

		[ProtoEnum(Name = "TMT_NORMAL", Value = 1)]
		TMT_NORMAL = 1,

		[ProtoEnum(Name = "TMT_HELPER", Value = 2)]
		TMT_HELPER,

		[ProtoEnum(Name = "TMT_USETICKET", Value = 3)]
		TMT_USETICKET
	}
}
