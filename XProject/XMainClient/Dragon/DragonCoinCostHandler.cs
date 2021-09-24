using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class DragonCoinCostHandler : ICostHandler
	{

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

		private List<uint> m_Costs = new List<uint>();
	}
}
