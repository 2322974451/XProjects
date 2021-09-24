using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BoxType")]
	public enum BoxType
	{

		[ProtoEnum(Name = "BOX_TYPE_NONE", Value = 0)]
		BOX_TYPE_NONE,

		[ProtoEnum(Name = "BOX_TYPE_GOLD", Value = 3)]
		BOX_TYPE_GOLD = 3,

		[ProtoEnum(Name = "BOX_TYPE_SILVER", Value = 2)]
		BOX_TYPE_SILVER = 2,

		[ProtoEnum(Name = "BOX_TYPE_COPPER", Value = 1)]
		BOX_TYPE_COPPER = 1,

		[ProtoEnum(Name = "BOX_TYPE_DIAMOND", Value = 4)]
		BOX_TYPE_DIAMOND = 4
	}
}
