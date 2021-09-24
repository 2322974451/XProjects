using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFZhanLingType")]
	public enum GCFZhanLingType
	{

		[ProtoEnum(Name = "GCFZL_BEGIN", Value = 1)]
		GCFZL_BEGIN = 1,

		[ProtoEnum(Name = "GCFZL_BREAK", Value = 2)]
		GCFZL_BREAK,

		[ProtoEnum(Name = "GCFZL_END", Value = 3)]
		GCFZL_END
	}
}
