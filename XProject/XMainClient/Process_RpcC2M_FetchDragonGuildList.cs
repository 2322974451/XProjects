using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001639 RID: 5689
	internal class Process_RpcC2M_FetchDragonGuildList
	{
		// Token: 0x0600EE25 RID: 60965 RVA: 0x00349580 File Offset: 0x00347780
		public static void OnReply(FetchDragonGuildListArg oArg, FetchDragonGuildRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oArg.reason == 2;
					if (flag3)
					{
						XRankDocument specificDocument = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
						specificDocument.OnGetDragonGuildList(oArg, oRes);
					}
					else
					{
						XDragonGuildListDocument.Doc.OnGetDragonGuildList(oArg, oRes);
					}
				}
			}
		}

		// Token: 0x0600EE26 RID: 60966 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchDragonGuildListArg oArg)
		{
		}
	}
}
