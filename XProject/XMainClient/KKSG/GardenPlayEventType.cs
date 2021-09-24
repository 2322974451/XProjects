using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenPlayEventType")]
	public enum GardenPlayEventType
	{

		[ProtoEnum(Name = "PLANT", Value = 1)]
		PLANT = 1,

		[ProtoEnum(Name = "PLANT_STAGE", Value = 2)]
		PLANT_STAGE,

		[ProtoEnum(Name = "PLANT_STATE_CHANGE", Value = 3)]
		PLANT_STATE_CHANGE,

		[ProtoEnum(Name = "BANQUET", Value = 4)]
		BANQUET,

		[ProtoEnum(Name = "BANQUET_STAGE", Value = 5)]
		BANQUET_STAGE,

		[ProtoEnum(Name = "PLANT_DELETE", Value = 6)]
		PLANT_DELETE,

		[ProtoEnum(Name = "PLANT_SPRITE", Value = 7)]
		PLANT_SPRITE,

		[ProtoEnum(Name = "PLANT_MATURE", Value = 8)]
		PLANT_MATURE,

		[ProtoEnum(Name = "FISH_FACE", Value = 9)]
		FISH_FACE,

		[ProtoEnum(Name = "FISH_RESULT", Value = 10)]
		FISH_RESULT,

		[ProtoEnum(Name = "FISH_STOP", Value = 11)]
		FISH_STOP
	}
}
