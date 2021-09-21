using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200080B RID: 2059
	[ProtoContract(Name = "EmblemSlotType")]
	public enum EmblemSlotType
	{
		// Token: 0x0400273F RID: 10047
		[ProtoEnum(Name = "EmblemSlotType_None", Value = 0)]
		EmblemSlotType_None,
		// Token: 0x04002740 RID: 10048
		[ProtoEnum(Name = "EmblemSlotType_Attri", Value = 1)]
		EmblemSlotType_Attri,
		// Token: 0x04002741 RID: 10049
		[ProtoEnum(Name = "EmblemSlotType_Skill", Value = 2)]
		EmblemSlotType_Skill,
		// Token: 0x04002742 RID: 10050
		[ProtoEnum(Name = "EmblemSlotType_ExtraSkill", Value = 3)]
		EmblemSlotType_ExtraSkill
	}
}
