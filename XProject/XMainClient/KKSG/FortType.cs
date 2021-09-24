using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FortType")]
	public enum FortType
	{

		[ProtoEnum(Name = "FORTTYPE_MAX", Value = 1)]
		FORTTYPE_MAX = 1
	}
}
