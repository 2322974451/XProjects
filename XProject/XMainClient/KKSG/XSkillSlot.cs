using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000784 RID: 1924
	[ProtoContract(Name = "XSkillSlot")]
	public enum XSkillSlot
	{
		// Token: 0x04002403 RID: 9219
		[ProtoEnum(Name = "Normal_Attack", Value = 0)]
		Normal_Attack,
		// Token: 0x04002404 RID: 9220
		[ProtoEnum(Name = "Dash_Attack", Value = 1)]
		Dash_Attack,
		// Token: 0x04002405 RID: 9221
		[ProtoEnum(Name = "Skill_1_Attack", Value = 2)]
		Skill_1_Attack,
		// Token: 0x04002406 RID: 9222
		[ProtoEnum(Name = "Skill_2_Attack", Value = 3)]
		Skill_2_Attack,
		// Token: 0x04002407 RID: 9223
		[ProtoEnum(Name = "Skill_3_Attack", Value = 4)]
		Skill_3_Attack,
		// Token: 0x04002408 RID: 9224
		[ProtoEnum(Name = "Skill_4_Attack", Value = 5)]
		Skill_4_Attack,
		// Token: 0x04002409 RID: 9225
		[ProtoEnum(Name = "Skill_5_Attack", Value = 6)]
		Skill_5_Attack,
		// Token: 0x0400240A RID: 9226
		[ProtoEnum(Name = "Skill_1_Buff", Value = 7)]
		Skill_1_Buff,
		// Token: 0x0400240B RID: 9227
		[ProtoEnum(Name = "Skill_2_Buff", Value = 8)]
		Skill_2_Buff,
		// Token: 0x0400240C RID: 9228
		[ProtoEnum(Name = "Ultra_Attack", Value = 9)]
		Ultra_Attack,
		// Token: 0x0400240D RID: 9229
		[ProtoEnum(Name = "Awake_Attack", Value = 10)]
		Awake_Attack,
		// Token: 0x0400240E RID: 9230
		[ProtoEnum(Name = "NULL_Key", Value = 11)]
		NULL_Key,
		// Token: 0x0400240F RID: 9231
		[ProtoEnum(Name = "Attack_Max", Value = 12)]
		Attack_Max
	}
}
