using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HallIconState")]
	public enum HallIconState
	{

		[ProtoEnum(Name = "HICONS_BEGIN", Value = 1)]
		HICONS_BEGIN = 1,

		[ProtoEnum(Name = "HICONS_END", Value = 2)]
		HICONS_END
	}
}
