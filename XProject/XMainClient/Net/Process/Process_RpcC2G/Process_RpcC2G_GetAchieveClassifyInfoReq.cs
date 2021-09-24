using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetAchieveClassifyInfoReq
	{

		public static void OnReply(GetAchieveClassifyInfoReq oArg, GetAchieveClassifyInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
				specificDocument.OnResAchieveType(oRes);
			}
		}

		public static void OnTimeout(GetAchieveClassifyInfoReq oArg)
		{
		}
	}
}
