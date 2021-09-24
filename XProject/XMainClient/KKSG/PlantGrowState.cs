using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlantGrowState")]
	public enum PlantGrowState
	{

		[ProtoEnum(Name = "growDrought", Value = 1)]
		growDrought = 1,

		[ProtoEnum(Name = "growPest", Value = 2)]
		growPest,

		[ProtoEnum(Name = "growSluggish", Value = 3)]
		growSluggish,

		[ProtoEnum(Name = "growCD", Value = 4)]
		growCD,

		[ProtoEnum(Name = "growMature", Value = 5)]
		growMature,

		[ProtoEnum(Name = "growCorrect", Value = 6)]
		growCorrect
	}
}
