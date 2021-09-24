using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FortStatus")]
	public enum FortStatus
	{

		[ProtoEnum(Name = "FORTSTATUS_MAX", Value = 1)]
		FORTSTATUS_MAX = 1
	}
}
