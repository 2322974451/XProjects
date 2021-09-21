using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200103A RID: 4154
	internal class Process_RpcC2G_Checkin
	{
		// Token: 0x0600D597 RID: 54679 RVA: 0x00324598 File Offset: 0x00322798
		public static void OnReply(CheckinArg oArg, CheckinRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XLoginRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLoginRewardDocument>(XLoginRewardDocument.uuID);
				specificDocument.OnCheckin(oRes);
			}
		}

		// Token: 0x0600D598 RID: 54680 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CheckinArg oArg)
		{
		}
	}
}
