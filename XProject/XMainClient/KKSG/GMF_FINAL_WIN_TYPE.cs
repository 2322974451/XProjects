using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GMF_FINAL_WIN_TYPE")]
	public enum GMF_FINAL_WIN_TYPE
	{

		[ProtoEnum(Name = "GMF_FWY_NORMAL", Value = 1)]
		GMF_FWY_NORMAL = 1,

		[ProtoEnum(Name = "GMF_FWY_OPNONE", Value = 2)]
		GMF_FWY_OPNONE,

		[ProtoEnum(Name = "GMF_FWY_RANK", Value = 3)]
		GMF_FWY_RANK
	}
}
