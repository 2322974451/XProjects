using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000795 RID: 1941
	[ProtoContract(Name = "RoleState")]
	public enum RoleState
	{
		// Token: 0x0400247C RID: 9340
		[ProtoEnum(Name = "Logoff", Value = 0)]
		Logoff,
		// Token: 0x0400247D RID: 9341
		[ProtoEnum(Name = "LoadScene", Value = 1)]
		LoadScene,
		// Token: 0x0400247E RID: 9342
		[ProtoEnum(Name = "InHall", Value = 2)]
		InHall,
		// Token: 0x0400247F RID: 9343
		[ProtoEnum(Name = "InBattle", Value = 3)]
		InBattle
	}
}
