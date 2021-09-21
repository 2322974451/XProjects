using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000829 RID: 2089
	[ProtoContract(Name = "TaskOper")]
	public enum TaskOper
	{
		// Token: 0x040027E7 RID: 10215
		[ProtoEnum(Name = "TaskOper_Set", Value = 1)]
		TaskOper_Set = 1,
		// Token: 0x040027E8 RID: 10216
		[ProtoEnum(Name = "TaskOper_Add", Value = 2)]
		TaskOper_Add,
		// Token: 0x040027E9 RID: 10217
		[ProtoEnum(Name = "TaskOper_Del", Value = 3)]
		TaskOper_Del
	}
}
