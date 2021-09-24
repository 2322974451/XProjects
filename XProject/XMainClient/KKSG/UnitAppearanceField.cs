using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UnitAppearanceField")]
	public enum UnitAppearanceField
	{

		[ProtoEnum(Name = "UNIT_BASIC", Value = 15)]
		UNIT_BASIC = 15,

		[ProtoEnum(Name = "UNIT_ATTR", Value = 32)]
		UNIT_ATTR = 32,

		[ProtoEnum(Name = "UNIT_FASHION", Value = 64)]
		UNIT_FASHION = 64,

		[ProtoEnum(Name = "UNIT_EQUIP", Value = 128)]
		UNIT_EQUIP = 128,

		[ProtoEnum(Name = "UNIT_SKILL", Value = 256)]
		UNIT_SKILL = 256,

		[ProtoEnum(Name = "UNIT_EMBLEM", Value = 512)]
		UNIT_EMBLEM = 512,

		[ProtoEnum(Name = "UNIT_VIPLEVEL", Value = 1024)]
		UNIT_VIPLEVEL = 1024,

		[ProtoEnum(Name = "UNIT_TIMELOGIN", Value = 2048)]
		UNIT_TIMELOGIN = 2048,

		[ProtoEnum(Name = "UNIT_GUILD", Value = 16384)]
		UNIT_GUILD = 16384,

		[ProtoEnum(Name = "UNIT_TITLE", Value = 524288)]
		UNIT_TITLE = 524288,

		[ProtoEnum(Name = "UNIT_SPRITELEADER", Value = 8388608)]
		UNIT_SPRITELEADER = 8388608,

		[ProtoEnum(Name = "UNIT_SPRITE", Value = 16777216)]
		UNIT_SPRITE = 16777216,

		[ProtoEnum(Name = "UNIT_PETS", Value = 33554432)]
		UNIT_PETS = 33554432,

		[ProtoEnum(Name = "UNIT_ARTIFACT", Value = 32768)]
		UNIT_ARTIFACT = 32768,

		[ProtoEnum(Name = "UNIT_PRE", Value = 65536)]
		UNIT_PRE = 65536
	}
}
