using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class second_slash_show
	{

		public static bool Do(List<XActor> actors)
		{
			bool flag = actors != null && actors.Count == XGame.RoleCount && !second_slash_show._replaced;
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
				bool flag3 = second_slash_show._done == null;
				if (flag3)
				{
					second_slash_show._done = new XTimerMgr.ElapsedEventHandler(second_slash_show.Done);
				}
				XSingleton<XTimerMgr>.singleton.SetGlobalTimer(0.1f, second_slash_show._done, actors);
				int j = 0;
				while (j < XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Count)
				{
					bool flag4 = XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo[j] != null;
					if (flag4)
					{
						RoleBriefInfo roleBriefInfo = XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo[j];
						int num = (int)roleBriefInfo.type % (int)(RoleType)10 - (int)RoleType.Role_Warrior;
						bool flag5 = num >= actors.Count;
						if (!flag5)
						{
							actors[num].ReplaceActor(second_slash_show.SetupRole(roleBriefInfo));
							actors[num].Replaced = true;
							XSelectcharStage.ShowBillboard(actors[num].Dummy);
						}
					}
					else
					{
						uint num2 = (uint)(j + 1);
						bool flag6 = num2 == 1U;
						if (flag6)
						{
							uint @int = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("AvengerEntityStaticID");
							bool flag7 = @int > 0U;
							if (flag7)
							{
								XEntityStatistics.RowData byID2 = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(@int);
								bool flag8 = byID2 != null;
								if (flag8)
								{
									XOutlookData xoutlookData2 = new XOutlookData();
									xoutlookData2.SetDefaultFashion(byID2.FashionTemplate);
									XDummy xdummy = XSingleton<XEntityMgr>.singleton.CreateDummy(byID2.PresentID, (uint)byID2.FashionTemplate, xoutlookData2, false, false, true);
									bool flag9 = xdummy != null && xdummy.Equipment != null;
									if (flag9)
									{
										xdummy.Equipment.EnableRealTimeShadow(XQualitySetting._CastShadow);
									}
									actors[j].ReplaceActor(xdummy);
									actors[j].Replaced = true;
								}
							}
						}
					}
					IL_296:
					j++;
					continue;
					goto IL_296;
				}
				second_slash_show._replaced = true;
			}
			bool flag10 = actors == null;
			if (flag10)
			{
				second_slash_show._replaced = false;
			}
			return true;
		}

		protected static XDummy SetupRole(RoleBriefInfo brief)
		{
			uint presentID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID((uint)((int)brief.type % (int)(RoleType)10)).PresentID;
			uint type = (uint)brief.type;
			XOutlookData xoutlookData = new XOutlookData();
			xoutlookData.SetData(brief.outlook, type);
			XDummy xdummy = XSingleton<XEntityMgr>.singleton.CreateDummy(presentID, type, xoutlookData, true, false, true);
			bool flag = xdummy != null && xdummy.Equipment != null;
			if (flag)
			{
				xdummy.Equipment.EnableRealTimeShadow(XQualitySetting._CastShadow);
			}
			return xdummy;
		}

		public static void Done(object o)
		{
		}

		private static bool _replaced = false;

		private static XTimerMgr.ElapsedEventHandler _done = null;
	}
}
