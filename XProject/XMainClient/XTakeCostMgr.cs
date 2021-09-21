using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DA6 RID: 3494
	internal class XTakeCostMgr : XSingleton<XTakeCostMgr>
	{
		// Token: 0x0600BDAB RID: 48555 RVA: 0x00276EC0 File Offset: 0x002750C0
		private static ICostHandler MakeCostHandler()
		{
			return new DragonCoinCostHandler();
		}

		// Token: 0x0600BDAC RID: 48556 RVA: 0x00276ED8 File Offset: 0x002750D8
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

		// Token: 0x0600BDAD RID: 48557 RVA: 0x00276F34 File Offset: 0x00275134
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

		// Token: 0x04004D47 RID: 19783
		private Dictionary<string, ICostHandler> m_CostCache = new Dictionary<string, ICostHandler>();
	}
}
