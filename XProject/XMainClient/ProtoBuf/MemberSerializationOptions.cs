using System;

namespace ProtoBuf
{
	// Token: 0x02000853 RID: 2131
	[Flags]
	public enum MemberSerializationOptions
	{
		// Token: 0x04002893 RID: 10387
		None = 0,
		// Token: 0x04002894 RID: 10388
		Packed = 1,
		// Token: 0x04002895 RID: 10389
		Required = 2,
		// Token: 0x04002896 RID: 10390
		AsReference = 4,
		// Token: 0x04002897 RID: 10391
		DynamicType = 8,
		// Token: 0x04002898 RID: 10392
		OverwriteList = 16,
		// Token: 0x04002899 RID: 10393
		AsReferenceHasValue = 32
	}
}
