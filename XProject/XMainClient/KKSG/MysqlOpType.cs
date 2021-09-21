using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F6 RID: 2038
	[ProtoContract(Name = "MysqlOpType")]
	public enum MysqlOpType
	{
		// Token: 0x040026D7 RID: 9943
		[ProtoEnum(Name = "MYSQL_OP_ADD", Value = 1)]
		MYSQL_OP_ADD = 1,
		// Token: 0x040026D8 RID: 9944
		[ProtoEnum(Name = "MYSQL_OP_UPDATE", Value = 2)]
		MYSQL_OP_UPDATE,
		// Token: 0x040026D9 RID: 9945
		[ProtoEnum(Name = "MYSQL_OP_DELETE", Value = 3)]
		MYSQL_OP_DELETE
	}
}
