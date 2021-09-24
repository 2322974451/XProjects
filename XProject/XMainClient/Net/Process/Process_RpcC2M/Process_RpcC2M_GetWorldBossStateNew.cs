using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetWorldBossStateNew
	{

		public static void OnReply(GetWorldBossStateArg oArg, GetWorldBossStateRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oArg.type == 0U;
				if (flag2)
				{
					XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
					specificDocument.OnGetWorldBossLeftState(oRes);
				}
				else
				{
					XGuildDragonDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
					specificDocument2.OnGetWorldBossLeftState(oRes);
				}
			}
		}

		public static void OnTimeout(GetWorldBossStateArg oArg)
		{
		}
	}
}
