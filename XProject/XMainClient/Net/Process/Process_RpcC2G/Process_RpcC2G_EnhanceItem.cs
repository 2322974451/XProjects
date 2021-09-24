using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_EnhanceItem
	{

		public static void OnReply(EnhanceItemArg oArg, EnhanceItemRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
				specificDocument.OnEnhanceBack(oRes);
				bool flag2 = oRes.ErrorCode == ErrorCode.ERR_ENHANCE_SUCCEED;
				if (flag2)
				{
					XSingleton<XTutorialHelper>.singleton.EnhanceItem = true;
				}
			}
		}

		public static void OnTimeout(EnhanceItemArg oArg)
		{
		}
	}
}
