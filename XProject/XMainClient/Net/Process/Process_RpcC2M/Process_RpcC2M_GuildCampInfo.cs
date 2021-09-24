using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GuildCampInfo
	{

		public static void OnReply(GuildCampInfoArg oArg, GuildCampInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.error == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XGuildSmallMonsterDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
						XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						int leftEnterCount = 2;
						bool flag4 = specificDocument2.currentDayCount.ContainsKey(TeamLevelType.TeamLevelGuildCamp);
						if (flag4)
						{
							leftEnterCount = specificDocument2.currentDayCount[TeamLevelType.TeamLevelGuildCamp];
						}
						bool flag5 = specificDocument2 != null;
						if (flag5)
						{
							specificDocument.SetGuildSmallMonsterInfo(leftEnterCount, oRes.curCampID, oRes.nextCampID, oRes.rankInfos);
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
				}
			}
		}

		public static void OnTimeout(GuildCampInfoArg oArg)
		{
		}
	}
}
