using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007DF RID: 2015
	[ProtoContract(Name = "UnitSpecialState")]
	public enum UnitSpecialState
	{
		// Token: 0x0400263F RID: 9791
		[ProtoEnum(Name = "Unit_Puppet", Value = 1)]
		Unit_Puppet = 1,
		// Token: 0x04002640 RID: 9792
		[ProtoEnum(Name = "Unit_Invisible", Value = 2)]
		Unit_Invisible
	}
}
