using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200074C RID: 1868
	[ProtoContract(Name = "TableDef")]
	public enum TableDef
	{
		// Token: 0x0400225A RID: 8794
		[ProtoEnum(Name = "AccountTable", Value = 1)]
		AccountTable = 1,
		// Token: 0x0400225B RID: 8795
		[ProtoEnum(Name = "RoleTable", Value = 2)]
		RoleTable
	}
}
