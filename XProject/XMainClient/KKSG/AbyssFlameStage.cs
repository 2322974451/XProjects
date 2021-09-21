using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000770 RID: 1904
	[ProtoContract(Name = "AbyssFlameStage")]
	public enum AbyssFlameStage
	{
		// Token: 0x040023A6 RID: 9126
		[ProtoEnum(Name = "ABYSS_NONE_FLAME", Value = 1)]
		ABYSS_NONE_FLAME = 1,
		// Token: 0x040023A7 RID: 9127
		[ProtoEnum(Name = "ABYSS_ON_FLAME", Value = 2)]
		ABYSS_ON_FLAME,
		// Token: 0x040023A8 RID: 9128
		[ProtoEnum(Name = "ABYSS_WIN_FLAME", Value = 3)]
		ABYSS_WIN_FLAME
	}
}
