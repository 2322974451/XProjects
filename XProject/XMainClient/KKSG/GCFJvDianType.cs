using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFJvDianType")]
	public enum GCFJvDianType
	{

		[ProtoEnum(Name = "GCF_JUDIAN_UP", Value = 1)]
		GCF_JUDIAN_UP = 1,

		[ProtoEnum(Name = "GCF_JUDIAN_MID", Value = 2)]
		GCF_JUDIAN_MID,

		[ProtoEnum(Name = "GCF_JUDIAN_DOWN", Value = 3)]
		GCF_JUDIAN_DOWN
	}
}
