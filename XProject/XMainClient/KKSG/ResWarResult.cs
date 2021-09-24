using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarResult")]
	public enum ResWarResult
	{

		[ProtoEnum(Name = "RESWAR_SUCESS", Value = 1)]
		RESWAR_SUCESS = 1,

		[ProtoEnum(Name = "RESWAR_FAIL", Value = 2)]
		RESWAR_FAIL,

		[ProtoEnum(Name = "RESWAR_FLAT", Value = 3)]
		RESWAR_FLAT
	}
}
