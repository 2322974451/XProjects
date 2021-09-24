using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DEProgressState")]
	public enum DEProgressState
	{

		[ProtoEnum(Name = "DEPS_FINISH", Value = 1)]
		DEPS_FINISH = 1,

		[ProtoEnum(Name = "DEPS_FIGHT", Value = 2)]
		DEPS_FIGHT,

		[ProtoEnum(Name = "DEPS_NOTOPEN", Value = 3)]
		DEPS_NOTOPEN
	}
}
