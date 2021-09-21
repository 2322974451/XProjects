using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200113A RID: 4410
	internal class Process_RpcC2G_PvpNowAllData
	{
		// Token: 0x0600D9B0 RID: 55728 RVA: 0x0032B758 File Offset: 0x00329958
		public static void OnReply(roArg oArg, PvpNowGameData oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				bool bNoShowLog = oArg.bNoShowLog;
				if (bNoShowLog)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
			}
			else
			{
				XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
				specificDocument.SetReqBattleCaptainPVPRefreshInfo(oArg, oRes);
			}
		}

		// Token: 0x0600D9B1 RID: 55729 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(roArg oArg)
		{
		}
	}
}
