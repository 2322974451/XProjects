﻿using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetRiftGuildRank
	{

		public static void OnReply(GetRiftGuildRankArg oArg, GetRiftGuildRankRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.error > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
					else
					{
						XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
						specificDocument.ResGuildRank(oRes);
					}
				}
			}
		}

		public static void OnTimeout(GetRiftGuildRankArg oArg)
		{
		}
	}
}
