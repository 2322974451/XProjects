using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200106F RID: 4207
	internal class Process_RpcC2I_QueryGateIP
	{
		// Token: 0x0600D674 RID: 54900 RVA: 0x0032618C File Offset: 0x0032438C
		public static void OnReply(QueryGateArg oArg, QueryGateRes oRes)
		{
			bool flag = XSingleton<XClientNetwork>.singleton.OnAuthorized(oArg, oRes);
			if (flag)
			{
				XSingleton<XLoginDocument>.singleton.SetAnnouncement(oRes.notice);
				XSingleton<XLoginDocument>.singleton.OnAuthorized(oRes.userphone);
				XSingleton<XLoginDocument>.singleton.SetGateIPTable(oRes.servers, oRes.gateconfig, oRes.allservers);
				XSingleton<XLoginDocument>.singleton.SetFriendServerList(oRes.platFriendServers);
				XSingleton<XLoginDocument>.singleton.SetLoginZoneID(oRes.loginzoneid);
				XSingleton<XLoginDocument>.singleton.SetFreeflow(oRes.freeflow, oRes.cctype);
			}
			else
			{
				XSingleton<XLoginDocument>.singleton.OnAuthorizedFailed();
				bool flag2 = oRes.error == ErrorCode.ERR_PLAT_BANACC;
				if (flag2)
				{
					string format = oRes.baninfo.reason + "\n" + XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString(oRes.error.ToString()));
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(format, XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)oRes.baninfo.endtime, XStringDefineProxy.GetString("IDIP_TIPS_TIME"), true)), XStringDefineProxy.GetString("COMMON_OK"), null, 300);
				}
			}
		}

		// Token: 0x0600D675 RID: 54901 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryGateArg oArg)
		{
		}
	}
}
