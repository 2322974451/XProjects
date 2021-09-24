using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "XSkillSlot")]
	public enum XSkillSlot
	{

		[ProtoEnum(Name = "Normal_Attack", Value = 0)]
		Normal_Attack,

		[ProtoEnum(Name = "Dash_Attack", Value = 1)]
		Dash_Attack,

		[ProtoEnum(Name = "Skill_1_Attack", Value = 2)]
		Skill_1_Attack,

		[ProtoEnum(Name = "Skill_2_Attack", Value = 3)]
		Skill_2_Attack,

		[ProtoEnum(Name = "Skill_3_Attack", Value = 4)]
		Skill_3_Attack,

		[ProtoEnum(Name = "Skill_4_Attack", Value = 5)]
		Skill_4_Attack,

		[ProtoEnum(Name = "Skill_5_Attack", Value = 6)]
		Skill_5_Attack,

		[ProtoEnum(Name = "Skill_1_Buff", Value = 7)]
		Skill_1_Buff,

		[ProtoEnum(Name = "Skill_2_Buff", Value = 8)]
		Skill_2_Buff,

		[ProtoEnum(Name = "Ultra_Attack", Value = 9)]
		Ultra_Attack,

		[ProtoEnum(Name = "Awake_Attack", Value = 10)]
		Awake_Attack,

		[ProtoEnum(Name = "NULL_Key", Value = 11)]
		NULL_Key,

		[ProtoEnum(Name = "Attack_Max", Value = 12)]
		Attack_Max
	}
}
