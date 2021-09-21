using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000777 RID: 1911
	[ProtoContract(Name = "LevelSealButtonType")]
	public enum LevelSealButtonType
	{
		// Token: 0x040023C9 RID: 9161
		[ProtoEnum(Name = "BUTTON_STATUS_NONE", Value = 0)]
		BUTTON_STATUS_NONE,
		// Token: 0x040023CA RID: 9162
		[ProtoEnum(Name = "BUTTON_STATUS_LOCKED", Value = 1)]
		BUTTON_STATUS_LOCKED,
		// Token: 0x040023CB RID: 9163
		[ProtoEnum(Name = "BUTTON_STATUS_UNLOCKED", Value = 2)]
		BUTTON_STATUS_UNLOCKED
	}
}
