using System;

namespace XMainClient
{
	// Token: 0x02000D26 RID: 3366
	internal interface ILogData : IComparable<ILogData>
	{
		// Token: 0x0600BB29 RID: 47913
		string GetContent();

		// Token: 0x0600BB2A RID: 47914
		string GetTime();
	}
}
