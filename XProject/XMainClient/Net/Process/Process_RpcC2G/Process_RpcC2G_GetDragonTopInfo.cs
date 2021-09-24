using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetDragonTopInfo
	{

		public static void OnReply(GetDragonTopInfoArg oArg, GetDragonTopInfoRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XDragonNestDocument specificDocument = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
				bool flag2 = oRes.errorCode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					specificDocument.SetDragonNestInfo(oRes.dragonInfo);
				}
			}
		}

		public static void OnTimeout(GetDragonTopInfoArg oArg)
		{
		}
	}
}
