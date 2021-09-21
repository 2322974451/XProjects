using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E9 RID: 2025
	[ProtoContract(Name = "SkillTypeEnum")]
	public enum SkillTypeEnum
	{
		// Token: 0x04002670 RID: 9840
		[ProtoEnum(Name = "Skill_None", Value = 0)]
		Skill_None,
		// Token: 0x04002671 RID: 9841
		[ProtoEnum(Name = "Skill_Normal", Value = 1)]
		Skill_Normal,
		// Token: 0x04002672 RID: 9842
		[ProtoEnum(Name = "Skill_Big", Value = 2)]
		Skill_Big,
		// Token: 0x04002673 RID: 9843
		[ProtoEnum(Name = "Skill_UnUsed", Value = 3)]
		Skill_UnUsed,
		// Token: 0x04002674 RID: 9844
		[ProtoEnum(Name = "Skill_SceneBuff", Value = 4)]
		Skill_SceneBuff,
		// Token: 0x04002675 RID: 9845
		[ProtoEnum(Name = "Skill_Help", Value = 5)]
		Skill_Help,
		// Token: 0x04002676 RID: 9846
		[ProtoEnum(Name = "Skill_Buff", Value = 6)]
		Skill_Buff,
		// Token: 0x04002677 RID: 9847
		[ProtoEnum(Name = "Skill_Awake", Value = 7)]
		Skill_Awake
	}
}
