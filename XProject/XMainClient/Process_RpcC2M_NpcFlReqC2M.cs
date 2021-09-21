using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001610 RID: 5648
	internal class Process_RpcC2M_NpcFlReqC2M
	{
		// Token: 0x0600ED76 RID: 60790 RVA: 0x003485AC File Offset: 0x003467AC
		public static void OnReply(NpcFlArg oArg, NpcFlRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XNPCFavorDocument specificDocument = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
					bool flag3 = specificDocument != null;
					if (flag3)
					{
						specificDocument.OnReqSrvNpcInfo(oArg, oRes);
					}
				}
			}
		}

		// Token: 0x0600ED77 RID: 60791 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(NpcFlArg oArg)
		{
		}
	}
}
