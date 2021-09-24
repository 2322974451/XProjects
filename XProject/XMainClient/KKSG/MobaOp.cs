using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaOp")]
	public enum MobaOp
	{

		[ProtoEnum(Name = "MobaOp_LevelSkill", Value = 1)]
		MobaOp_LevelSkill = 1,

		[ProtoEnum(Name = "MobaOp_Upgrade", Value = 2)]
		MobaOp_Upgrade
	}
}
