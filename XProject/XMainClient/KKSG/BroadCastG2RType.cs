using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BroadCastG2RType")]
	public enum BroadCastG2RType
	{

		[ProtoEnum(Name = "BroadCastG2RType_MS", Value = 1)]
		BroadCastG2RType_MS = 1,

		[ProtoEnum(Name = "BroadCastG2RType_NS", Value = 2)]
		BroadCastG2RType_NS,

		[ProtoEnum(Name = "BroadCastG2RType_DB", Value = 3)]
		BroadCastG2RType_DB
	}
}
