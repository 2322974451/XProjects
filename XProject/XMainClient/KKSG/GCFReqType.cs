using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFReqType")]
	public enum GCFReqType
	{

		[ProtoEnum(Name = "GCF_JOIN_READY_SCENE", Value = 1)]
		GCF_JOIN_READY_SCENE = 1,

		[ProtoEnum(Name = "GCF_FIGHT_REPORT", Value = 2)]
		GCF_FIGHT_REPORT,

		[ProtoEnum(Name = "GCF_FIGHT_RESULT", Value = 3)]
		GCF_FIGHT_RESULT,

		[ProtoEnum(Name = "GCF_JOIN_FIGHT_SCENE", Value = 4)]
		GCF_JOIN_FIGHT_SCENE
	}
}
