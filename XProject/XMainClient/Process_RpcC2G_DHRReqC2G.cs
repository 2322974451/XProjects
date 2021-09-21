using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001546 RID: 5446
	internal class Process_RpcC2G_DHRReqC2G
	{
		// Token: 0x0600EA30 RID: 59952 RVA: 0x00343D78 File Offset: 0x00341F78
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

		// Token: 0x0600EA31 RID: 59953 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DHRArg oArg)
		{
		}
	}
}
