using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001679 RID: 5753
	internal class Process_RpcC2G_GetMyRiftInfo
	{
		// Token: 0x0600EF32 RID: 61234 RVA: 0x0034AE04 File Offset: 0x00349004
		public static void OnReply(GetMyRiftInfoArg oArg, GetMyRiftInfoRes oRes)
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
						specificDocument.ResRiftInfo(oRes);
					}
				}
			}
		}

		// Token: 0x0600EF33 RID: 61235 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMyRiftInfoArg oArg)
		{
		}
	}
}
