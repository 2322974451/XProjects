using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D2 RID: 2002
	[ProtoContract(Name = "EMentorRelationPosition")]
	public enum EMentorRelationPosition
	{
		// Token: 0x040025FA RID: 9722
		[ProtoEnum(Name = "EMentorPosMaster", Value = 1)]
		EMentorPosMaster = 1,
		// Token: 0x040025FB RID: 9723
		[ProtoEnum(Name = "EMentorPosStudent", Value = 2)]
		EMentorPosStudent,
		// Token: 0x040025FC RID: 9724
		[ProtoEnum(Name = "EMentorPosMax", Value = 3)]
		EMentorPosMax
	}
}
