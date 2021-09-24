using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ChangeGuildCard
	{

		public static void OnReply(ChangeGuildCardArg oArg, ChangeGuildCardRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
				specificDocument.WaitRpc = false;
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					specificDocument.ChangeCard(oArg.card, oRes.card, oRes.result);
				}
				else
				{
					bool flag3 = oRes.errorcode != ErrorCode.ERR_UNKNOWN;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
				}
			}
		}

		public static void OnTimeout(ChangeGuildCardArg oArg)
		{
		}
	}
}
