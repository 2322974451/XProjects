using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EmblemSlotType")]
	public enum EmblemSlotType
	{

		[ProtoEnum(Name = "EmblemSlotType_None", Value = 0)]
		EmblemSlotType_None,

		[ProtoEnum(Name = "EmblemSlotType_Attri", Value = 1)]
		EmblemSlotType_Attri,

		[ProtoEnum(Name = "EmblemSlotType_Skill", Value = 2)]
		EmblemSlotType_Skill,

		[ProtoEnum(Name = "EmblemSlotType_ExtraSkill", Value = 3)]
		EmblemSlotType_ExtraSkill
	}
}
