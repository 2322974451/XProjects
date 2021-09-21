using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DA5 RID: 3493
	internal class DragonCoinCostHandler : ICostHandler
	{
		// Token: 0x0600BDA8 RID: 48552 RVA: 0x00276DD4 File Offset: 0x00274FD4
		public CostInfo GetCost(int i)
		{
			CostInfo result;
			result.type = ItemEnum.DRAGON_COIN;
			bool flag = this.m_Costs.Count == 0;
			if (flag)
			{
				result.count = 0U;
			}
			else
			{
				bool flag2 = i >= 0 && i < this.m_Costs.Count;
				if (flag2)
				{
					result.count = this.m_Costs[i];
				}
				else
				{
					result.count = this.m_Costs[this.m_Costs.Count - 1];
				}
			}
			return result;
		}

		// Token: 0x0600BDA9 RID: 48553 RVA: 0x00276E60 File Offset: 0x00275060
		public bool ParseCostConfigString(string str)
		{
			string[] array = str.Split(XGlobalConfig.ListSeparator);
			uint num = 0U;
			while ((ulong)num < (ulong)((long)array.Length))
			{
				this.m_Costs.Add(uint.Parse(array[(int)num]));
				num += 1U;
			}
			return true;
		}

		// Token: 0x04004D46 RID: 19782
		private List<uint> m_Costs = new List<uint>();
	}
}
