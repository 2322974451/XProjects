using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TableDef")]
	public enum TableDef
	{

		[ProtoEnum(Name = "AccountTable", Value = 1)]
		AccountTable = 1,

		[ProtoEnum(Name = "RoleTable", Value = 2)]
		RoleTable
	}
}
