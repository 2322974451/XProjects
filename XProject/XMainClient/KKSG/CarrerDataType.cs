using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007EF RID: 2031
	[ProtoContract(Name = "CarrerDataType")]
	public enum CarrerDataType
	{
		// Token: 0x04002694 RID: 9876
		[ProtoEnum(Name = "CARRER_DATA_LEVEL", Value = 1)]
		CARRER_DATA_LEVEL = 1,
		// Token: 0x04002695 RID: 9877
		[ProtoEnum(Name = "CARRER_DATA_NEST", Value = 2)]
		CARRER_DATA_NEST,
		// Token: 0x04002696 RID: 9878
		[ProtoEnum(Name = "CARRER_DATA_DRAGON", Value = 3)]
		CARRER_DATA_DRAGON,
		// Token: 0x04002697 RID: 9879
		[ProtoEnum(Name = "CARRER_DATA_CREATEROLE", Value = 4)]
		CARRER_DATA_CREATEROLE
	}
}
