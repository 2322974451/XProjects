using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BagType")]
	public enum BagType
	{

		[ProtoEnum(Name = "EquipBag", Value = 1)]
		EquipBag = 1,

		[ProtoEnum(Name = "EmblemBag", Value = 2)]
		EmblemBag,

		[ProtoEnum(Name = "ArtifactBag", Value = 3)]
		ArtifactBag,

		[ProtoEnum(Name = "ItemBag", Value = 4)]
		ItemBag
	}
}
