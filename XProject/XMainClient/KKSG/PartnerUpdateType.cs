using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PartnerUpdateType")]
	public enum PartnerUpdateType
	{

		[ProtoEnum(Name = "PUType_Normal", Value = 1)]
		PUType_Normal = 1,

		[ProtoEnum(Name = "PUType_Leave", Value = 2)]
		PUType_Leave,

		[ProtoEnum(Name = "PUType_Dissolve", Value = 3)]
		PUType_Dissolve,

		[ProtoEnum(Name = "PUType_Shop", Value = 4)]
		PUType_Shop
	}
}
