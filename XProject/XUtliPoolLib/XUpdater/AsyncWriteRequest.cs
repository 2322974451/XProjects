using System;

namespace XUpdater
{
	// Token: 0x02000010 RID: 16
	internal sealed class AsyncWriteRequest
	{
		// Token: 0x0400002C RID: 44
		public bool IsDone = false;

		// Token: 0x0400002D RID: 45
		public bool HasError = false;

		// Token: 0x0400002E RID: 46
		public string Location = null;

		// Token: 0x0400002F RID: 47
		public string Name = null;

		// Token: 0x04000030 RID: 48
		public uint Size = 0U;
	}
}
