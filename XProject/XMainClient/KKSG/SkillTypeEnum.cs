using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillTypeEnum")]
	public enum SkillTypeEnum
	{

		[ProtoEnum(Name = "Skill_None", Value = 0)]
		Skill_None,

		[ProtoEnum(Name = "Skill_Normal", Value = 1)]
		Skill_Normal,

		[ProtoEnum(Name = "Skill_Big", Value = 2)]
		Skill_Big,

		[ProtoEnum(Name = "Skill_UnUsed", Value = 3)]
		Skill_UnUsed,

		[ProtoEnum(Name = "Skill_SceneBuff", Value = 4)]
		Skill_SceneBuff,

		[ProtoEnum(Name = "Skill_Help", Value = 5)]
		Skill_Help,

		[ProtoEnum(Name = "Skill_Buff", Value = 6)]
		Skill_Buff,

		[ProtoEnum(Name = "Skill_Awake", Value = 7)]
		Skill_Awake
	}
}
