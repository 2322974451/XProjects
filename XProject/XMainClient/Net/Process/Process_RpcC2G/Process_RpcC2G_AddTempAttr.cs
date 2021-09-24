using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_AddTempAttr
	{

		public static void OnReply(AddTempAttrArg oArg, AddTempAttrRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oArg.type == 0U;
				if (flag2)
				{
					XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
					specificDocument.OnGetEncourage(oRes);
				}
				else
				{
					XGuildDragonDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
					specificDocument2.OnGetEncourage(oRes);
				}
			}
		}

		public static void OnTimeout(AddTempAttrArg oArg)
		{
		}
	}
}
