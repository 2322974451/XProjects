using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007CD RID: 1997
	[ProtoContract(Name = "DBOperType")]
	public enum DBOperType
	{
		// Token: 0x040025D7 RID: 9687
		[ProtoEnum(Name = "DBOper_Insert", Value = 1)]
		DBOper_Insert = 1,
		// Token: 0x040025D8 RID: 9688
		[ProtoEnum(Name = "DBOper_Update", Value = 2)]
		DBOper_Update,
		// Token: 0x040025D9 RID: 9689
		[ProtoEnum(Name = "DBOper_Del", Value = 3)]
		DBOper_Del,
		// Token: 0x040025DA RID: 9690
		[ProtoEnum(Name = "DBOper_DelAll", Value = 4)]
		DBOper_DelAll,
		// Token: 0x040025DB RID: 9691
		[ProtoEnum(Name = "DBOper_ReplaceId", Value = 5)]
		DBOper_ReplaceId
	}
}
