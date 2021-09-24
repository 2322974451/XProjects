using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FashionNTFType")]
	public enum FashionNTFType
	{

		[ProtoEnum(Name = "ADD_FASHION", Value = 1)]
		ADD_FASHION = 1,

		[ProtoEnum(Name = "UPGRADE_FASHION", Value = 2)]
		UPGRADE_FASHION,

		[ProtoEnum(Name = "WEAR_FASHION", Value = 3)]
		WEAR_FASHION,

		[ProtoEnum(Name = "DELBODY_FASHION", Value = 4)]
		DELBODY_FASHION,

		[ProtoEnum(Name = "DELBAG_FASHION", Value = 5)]
		DELBAG_FASHION
	}
}
