using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200102C RID: 4140
	internal class Process_RpcC2G_QuerySceneDayCount
	{
		// Token: 0x0600D55C RID: 54620 RVA: 0x00323E64 File Offset: 0x00322064
		public static void OnReply(QuerySceneDayCountArg oArg, QuerySceneDayCountRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				switch (oArg.type)
				{
				case 1U:
				{
					XLevelDocument xlevelDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
					xlevelDocument.UpdateSceneDayTime(oRes);
					XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					specificDocument.OnGetSceneDayCount(oRes);
					break;
				}
				}
			}
		}

		// Token: 0x0600D55D RID: 54621 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QuerySceneDayCountArg oArg)
		{
		}
	}
}
