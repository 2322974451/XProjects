using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CarrerDataType")]
	public enum CarrerDataType
	{

		[ProtoEnum(Name = "CARRER_DATA_LEVEL", Value = 1)]
		CARRER_DATA_LEVEL = 1,

		[ProtoEnum(Name = "CARRER_DATA_NEST", Value = 2)]
		CARRER_DATA_NEST,

		[ProtoEnum(Name = "CARRER_DATA_DRAGON", Value = 3)]
		CARRER_DATA_DRAGON,

		[ProtoEnum(Name = "CARRER_DATA_CREATEROLE", Value = 4)]
		CARRER_DATA_CREATEROLE
	}
}
