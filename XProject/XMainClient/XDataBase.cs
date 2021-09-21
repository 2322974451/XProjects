using System;

namespace XMainClient
{
	// Token: 0x020008BB RID: 2235
	public abstract class XDataBase
	{
		// Token: 0x06008725 RID: 34597 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Recycle()
		{
		}

		// Token: 0x06008726 RID: 34598 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Init()
		{
		}

		// Token: 0x04002A9B RID: 10907
		public bool bRecycled = true;
	}
}
