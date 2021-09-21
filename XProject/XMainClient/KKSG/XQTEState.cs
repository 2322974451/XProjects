using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000764 RID: 1892
	[ProtoContract(Name = "XQTEState")]
	public enum XQTEState
	{
		// Token: 0x04002354 RID: 9044
		[ProtoEnum(Name = "QTE_None", Value = 0)]
		QTE_None,
		// Token: 0x04002355 RID: 9045
		[ProtoEnum(Name = "QTE_HitBackPresent", Value = 1)]
		QTE_HitBackPresent,
		// Token: 0x04002356 RID: 9046
		[ProtoEnum(Name = "QTE_HitBackStraight", Value = 2)]
		QTE_HitBackStraight,
		// Token: 0x04002357 RID: 9047
		[ProtoEnum(Name = "QTE_HitBackGetUp", Value = 3)]
		QTE_HitBackGetUp,
		// Token: 0x04002358 RID: 9048
		[ProtoEnum(Name = "QTE_HitFlyPresent", Value = 4)]
		QTE_HitFlyPresent,
		// Token: 0x04002359 RID: 9049
		[ProtoEnum(Name = "QTE_HitFlyLand", Value = 5)]
		QTE_HitFlyLand,
		// Token: 0x0400235A RID: 9050
		[ProtoEnum(Name = "QTE_HitFlyBounce", Value = 6)]
		QTE_HitFlyBounce,
		// Token: 0x0400235B RID: 9051
		[ProtoEnum(Name = "QTE_HitFlyStraight", Value = 7)]
		QTE_HitFlyStraight,
		// Token: 0x0400235C RID: 9052
		[ProtoEnum(Name = "QTE_HitFlyGetUp", Value = 8)]
		QTE_HitFlyGetUp,
		// Token: 0x0400235D RID: 9053
		[ProtoEnum(Name = "QTE_HitRollPresent", Value = 9)]
		QTE_HitRollPresent,
		// Token: 0x0400235E RID: 9054
		[ProtoEnum(Name = "QTE_HitRollStraight", Value = 10)]
		QTE_HitRollStraight,
		// Token: 0x0400235F RID: 9055
		[ProtoEnum(Name = "QTE_HitRollGetUp", Value = 11)]
		QTE_HitRollGetUp,
		// Token: 0x04002360 RID: 9056
		[ProtoEnum(Name = "QTE_HitFreeze", Value = 12)]
		QTE_HitFreeze
	}
}
