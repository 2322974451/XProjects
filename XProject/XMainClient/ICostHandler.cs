using System;

namespace XMainClient
{
	// Token: 0x02000DA4 RID: 3492
	internal interface ICostHandler
	{
		// Token: 0x0600BDA6 RID: 48550
		CostInfo GetCost(int i);

		// Token: 0x0600BDA7 RID: 48551
		bool ParseCostConfigString(string str);
	}
}
