using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013EF RID: 5103
	internal class Process_RpcC2G_GetHeroBattleInfo
	{
		// Token: 0x0600E4C0 RID: 58560 RVA: 0x0033C128 File Offset: 0x0033A328
		public static void OnReply(GetHeroBattleInfoArg oArg, GetHeroBattleInfoRes oRes)
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
					specificDocument.SetHeroBattleInfo(oRes);
				}
			}
		}

		// Token: 0x0600E4C1 RID: 58561 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetHeroBattleInfoArg oArg)
		{
		}
	}
}
