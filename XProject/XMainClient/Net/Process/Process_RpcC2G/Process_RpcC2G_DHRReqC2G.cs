using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_DHRReqC2G
	{

		public static void OnReply(DHRArg oArg, DHRRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XDragonRewardDocument specificDocument = XDocuments.GetSpecificDocument<XDragonRewardDocument>(XDragonRewardDocument.uuID);
						bool flag4 = specificDocument != null;
						if (flag4)
						{
							specificDocument.OnResAchieve(oRes.rewstate, oRes.helpcount, oRes.wanthelp);
						}
					}
				}
			}
		}

		public static void OnTimeout(DHRArg oArg)
		{
		}
	}
}
