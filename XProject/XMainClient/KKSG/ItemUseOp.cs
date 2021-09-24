using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemUseOp")]
	public enum ItemUseOp
	{

		[ProtoEnum(Name = "BagFind", Value = 0)]
		BagFind,

		[ProtoEnum(Name = "BodyFind", Value = 1)]
		BodyFind,

		[ProtoEnum(Name = "FashionWear", Value = 2)]
		FashionWear,

		[ProtoEnum(Name = "FashionOff", Value = 3)]
		FashionOff,

		[ProtoEnum(Name = "Composite", Value = 4)]
		Composite,

		[ProtoEnum(Name = "FashionSuitWear", Value = 5)]
		FashionSuitWear,

		[ProtoEnum(Name = "FashionSuitOff", Value = 6)]
		FashionSuitOff,

		[ProtoEnum(Name = "ItemBuffAdd", Value = 7)]
		ItemBuffAdd,

		[ProtoEnum(Name = "FashionDisplayWear", Value = 8)]
		FashionDisplayWear,

		[ProtoEnum(Name = "FashionDisplayOff", Value = 9)]
		FashionDisplayOff,

		[ProtoEnum(Name = "FashionSuitDisplayWear", Value = 10)]
		FashionSuitDisplayWear,

		[ProtoEnum(Name = "FashionSuitDisplayOff", Value = 11)]
		FashionSuitDisplayOff,

		[ProtoEnum(Name = "ActivationFashion", Value = 12)]
		ActivationFashion,

		[ProtoEnum(Name = "ActivationHairColor", Value = 13)]
		ActivationHairColor,

		[ProtoEnum(Name = "UseHairColor", Value = 14)]
		UseHairColor
	}
}
