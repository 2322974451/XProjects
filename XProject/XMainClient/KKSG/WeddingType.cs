using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingType")]
	public enum WeddingType
	{

		[ProtoEnum(Name = "WeddingType_Normal", Value = 1)]
		WeddingType_Normal = 1,

		[ProtoEnum(Name = "WeddingType_Luxury", Value = 2)]
		WeddingType_Luxury
	}
}
