using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GMFFailReason")]
	public enum GMFFailReason
	{

		[ProtoEnum(Name = "GMF_FAIL_NONE", Value = 0)]
		GMF_FAIL_NONE,

		[ProtoEnum(Name = "GMF_FAIL_DIE", Value = 1)]
		GMF_FAIL_DIE,

		[ProtoEnum(Name = "GMF_FAIL_TIMEOVER", Value = 2)]
		GMF_FAIL_TIMEOVER,

		[ProtoEnum(Name = "GMF_FAIL_QUIT", Value = 3)]
		GMF_FAIL_QUIT,

		[ProtoEnum(Name = "GMF_FAIL_REFRESE", Value = 4)]
		GMF_FAIL_REFRESE
	}
}
