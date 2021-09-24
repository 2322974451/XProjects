using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFsynType")]
	public enum GCFsynType
	{

		[ProtoEnum(Name = "GCF_SYN_KILL", Value = 1)]
		GCF_SYN_KILL = 1,

		[ProtoEnum(Name = "GCF_SYN_LEAVE_BATTLE", Value = 2)]
		GCF_SYN_LEAVE_BATTLE,

		[ProtoEnum(Name = "GCF_SYN_OCCUPY", Value = 3)]
		GCF_SYN_OCCUPY,

		[ProtoEnum(Name = "GCF_SYN_MUL_POINT", Value = 4)]
		GCF_SYN_MUL_POINT,

		[ProtoEnum(Name = "GCF_SYN_FIGHT_END", Value = 5)]
		GCF_SYN_FIGHT_END,

		[ProtoEnum(Name = "GCF_SYN_BACK_TO_READY", Value = 6)]
		GCF_SYN_BACK_TO_READY
	}
}
