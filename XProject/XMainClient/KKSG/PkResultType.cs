using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkResultType")]
	public enum PkResultType
	{

		[ProtoEnum(Name = "PkResult_Win", Value = 1)]
		PkResult_Win = 1,

		[ProtoEnum(Name = "PkResult_Lose", Value = 2)]
		PkResult_Lose,

		[ProtoEnum(Name = "PkResult_Draw", Value = 3)]
		PkResult_Draw
	}
}
