using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200115D RID: 4445
	internal class Process_RpcC2G_EnterWatchBattle
	{
		// Token: 0x0600DA42 RID: 55874 RVA: 0x0032CED4 File Offset: 0x0032B0D4
		public static void OnReply(EnterWatchBattleArg oArg, EnterWatchBattleRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					bool flag3 = oRes.error == ErrorCode.ERR_WATCH_LIVEISFULL || oRes.error == ErrorCode.ERR_WATCH_LIVEISOVER;
					if (flag3)
					{
						specificDocument.EnterLiveError(oRes.error == ErrorCode.ERR_WATCH_LIVEISOVER);
					}
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					specificDocument.IsLoadingSpectateScene = false;
				}
				else
				{
					XSpectateSceneDocument specificDocument2 = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
					specificDocument2.IsBlueTeamDict.Clear();
				}
			}
		}

		// Token: 0x0600DA43 RID: 55875 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnterWatchBattleArg oArg)
		{
		}
	}
}
