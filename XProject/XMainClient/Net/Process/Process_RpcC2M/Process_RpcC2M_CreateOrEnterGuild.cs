using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_CreateOrEnterGuild
	{

		public static void OnReply(CreateOrJoinGuild oArg, CreateOrJoinGuildRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					XGuildListDocument specificDocument = XDocuments.GetSpecificDocument<XGuildListDocument>(XGuildListDocument.uuID);
					bool iscreate = oArg.iscreate;
					if (iscreate)
					{
						specificDocument.OnCreateGuild(oArg, oRes);
					}
					else
					{
						specificDocument.OnApplyGuild(oArg, oRes);
					}
				}
			}
		}

		public static void OnTimeout(CreateOrJoinGuild oArg)
		{
		}
	}
}
