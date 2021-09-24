using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BroadCastType")]
	public enum BroadCastType
	{

		[ProtoEnum(Name = "BroadCastToAll", Value = 1)]
		BroadCastToAll = 1,

		[ProtoEnum(Name = "BroadCastMax", Value = 2)]
		BroadCastMax
	}
}
