using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001161 RID: 4449
	internal class Process_RpcC2G_CommendWatchBattle
	{
		// Token: 0x0600DA54 RID: 55892 RVA: 0x0032D148 File Offset: 0x0032B348
		public static void OnReply(CommendWatchBattleArg oArg, CommendWatchBattleRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Spectate_Commend_Succeed"), "fece00");
					XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
					specificDocument.CommendClickSuccess();
				}
			}
		}

		// Token: 0x0600DA55 RID: 55893 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CommendWatchBattleArg oArg)
		{
		}
	}
}
