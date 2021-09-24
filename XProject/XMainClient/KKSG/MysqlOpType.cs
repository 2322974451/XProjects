using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MysqlOpType")]
	public enum MysqlOpType
	{

		[ProtoEnum(Name = "MYSQL_OP_ADD", Value = 1)]
		MYSQL_OP_ADD = 1,

		[ProtoEnum(Name = "MYSQL_OP_UPDATE", Value = 2)]
		MYSQL_OP_UPDATE,

		[ProtoEnum(Name = "MYSQL_OP_DELETE", Value = 3)]
		MYSQL_OP_DELETE
	}
}
