using System;

namespace ProtoBuf
{
	// Token: 0x0200085A RID: 2138
	public enum WireType
	{
		// Token: 0x040028CA RID: 10442
		None = -1,
		// Token: 0x040028CB RID: 10443
		Variant,
		// Token: 0x040028CC RID: 10444
		Fixed64,
		// Token: 0x040028CD RID: 10445
		String,
		// Token: 0x040028CE RID: 10446
		StartGroup,
		// Token: 0x040028CF RID: 10447
		EndGroup,
		// Token: 0x040028D0 RID: 10448
		Fixed32,
		// Token: 0x040028D1 RID: 10449
		SignedVariant = 8
	}
}
