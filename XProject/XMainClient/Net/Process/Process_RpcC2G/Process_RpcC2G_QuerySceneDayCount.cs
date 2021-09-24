using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QuerySceneDayCount
	{

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

		public static void OnTimeout(QuerySceneDayCountArg oArg)
		{
		}
	}
}
