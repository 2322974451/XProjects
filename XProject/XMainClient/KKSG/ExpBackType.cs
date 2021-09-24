using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ExpBackType")]
	public enum ExpBackType
	{

		[ProtoEnum(Name = "EXPBACK_ABYSSS", Value = 1)]
		EXPBACK_ABYSSS = 1,

		[ProtoEnum(Name = "EXPBACK_NEST", Value = 2)]
		EXPBACK_NEST,

		[ProtoEnum(Name = "EXPBACK_CAMPTASK", Value = 3)]
		EXPBACK_CAMPTASK
	}
}
