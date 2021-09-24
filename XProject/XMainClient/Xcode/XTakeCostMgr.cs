using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTakeCostMgr : XSingleton<XTakeCostMgr>
	{

		private static ICostHandler MakeCostHandler()
		{
			return new DragonCoinCostHandler();
		}

		public CostInfo QueryCost(string CostName, int Times)
		{
			CostInfo costInfo;
			costInfo.type = (ItemEnum)0;
			costInfo.count = 0U;
			ICostHandler handler = this.GetHandler(CostName);
			bool flag = handler == null;
			CostInfo result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Can't find CostName: {0} in globalconfig.txt", CostName), null, null, null, null, null);
				result = costInfo;
			}
			else
			{
				result = handler.GetCost(Times);
			}
			return result;
		}

		public ICostHandler GetHandler(string CostName)
		{
			ICostHandler costHandler = null;
			bool flag = !this.m_CostCache.TryGetValue(CostName, out costHandler);
			if (flag)
			{
				string value = XSingleton<XGlobalConfig>.singleton.GetValue(CostName);
				bool flag2 = value != "";
				if (flag2)
				{
					costHandler = XTakeCostMgr.MakeCostHandler();
					bool flag3 = !costHandler.ParseCostConfigString(value);
					if (flag3)
					{
						costHandler = null;
					}
					this.m_CostCache.Add(CostName, costHandler);
				}
			}
			return costHandler;
		}

		private Dictionary<string, ICostHandler> m_CostCache = new Dictionary<string, ICostHandler>();
	}
}
