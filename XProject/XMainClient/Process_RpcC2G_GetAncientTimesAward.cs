using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A16 RID: 2582
	internal class Process_RpcC2G_GetAncientTimesAward
	{
		// Token: 0x06009E15 RID: 40469 RVA: 0x0019DE94 File Offset: 0x0019C094
		public static void OnReply(AncientTimesArg oArg, AncientTimesRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
			}
			bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag2)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag3 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag3)
				{
					XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
					specificDocument.ResPoint(oRes.reward);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
				}
			}
		}

		// Token: 0x06009E16 RID: 40470 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AncientTimesArg oArg)
		{
		}
	}
}
