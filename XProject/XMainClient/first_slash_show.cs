using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B7E RID: 2942
	internal class first_slash_show
	{
		// Token: 0x0600A955 RID: 43349 RVA: 0x001E20D4 File Offset: 0x001E02D4
		public static bool Do(List<XActor> actors)
		{
			bool flag = actors != null && actors.Count == XGame.RoleCount && !first_slash_show._replaced;
			if (flag)
			{
				for (int i = 0; i < XGame.RoleCount; i++)
				{
					XActor xactor = actors[i];
					bool replaced = xactor.Replaced;
					if (replaced)
					{
						uint key = (uint)(i + 1);
						XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(key);
						XOutlookData xoutlookData = new XOutlookData();
						xoutlookData.SetDefaultFashion(byID.FashionTemplate);
						XDummy dummy = XSingleton<XEntityMgr>.singleton.CreateDummy(byID.PresentID, (uint)byID.FashionTemplate, xoutlookData, false, false, true);
						xactor.ReplaceActor(dummy);
						xactor.Replaced = false;
					}
					bool flag2 = xactor.Dummy != null && xactor.Dummy.Equipment != null;
					if (flag2)
					{
						xactor.Dummy.Equipment.EnableRealTimeShadow(XQualitySetting._CastShadow);
					}
				}
				first_slash_show._replaced = true;
			}
			bool flag3 = actors == null;
			if (flag3)
			{
				first_slash_show._replaced = false;
			}
			return true;
		}

		// Token: 0x04003E9C RID: 16028
		private static bool _replaced = false;
	}
}
