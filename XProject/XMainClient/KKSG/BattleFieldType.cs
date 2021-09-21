using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000820 RID: 2080
	[ProtoContract(Name = "BattleFieldType")]
	public enum BattleFieldType
	{
		// Token: 0x040027AD RID: 10157
		[ProtoEnum(Name = "BATTLE_FIELD_READY_ENTER", Value = 1)]
		BATTLE_FIELD_READY_ENTER = 1,
		// Token: 0x040027AE RID: 10158
		[ProtoEnum(Name = "BATTLE_FIELD_READY_LEAVE", Value = 2)]
		BATTLE_FIELD_READY_LEAVE
	}
}
