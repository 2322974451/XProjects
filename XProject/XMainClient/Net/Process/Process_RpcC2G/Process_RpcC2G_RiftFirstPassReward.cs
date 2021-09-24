﻿using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_RiftFirstPassReward
	{

		public static void OnReply(RiftFirstPassRewardArg oArg, RiftFirstPassRewardRes oRes)
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
						bool flag4 = oArg.opType == RiftFirstPassOpType.Rift_FirstPass_Op_GetReward;
						if (flag4)
						{
							specificDocument.SetFirstPassClaim((int)oArg.floor);
						}
						specificDocument.ResFisrtPassRwd(oArg.opType, oRes);
					}
				}
			}
		}

		public static void OnTimeout(RiftFirstPassRewardArg oArg)
		{
		}
	}
}
