using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200144D RID: 5197
	internal class Process_RpcC2G_GetHeroBattleGameRecord
	{
		// Token: 0x0600E63E RID: 58942 RVA: 0x0033E2C8 File Offset: 0x0033C4C8
		public static void OnReply(GetHeroBattleGameRecordArg oArg, GetHeroBattleGameRecordRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					specificDocument.SetBattleRecord(oRes.games);
				}
			}
		}

		// Token: 0x0600E63F RID: 58943 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetHeroBattleGameRecordArg oArg)
		{
		}
	}
}
