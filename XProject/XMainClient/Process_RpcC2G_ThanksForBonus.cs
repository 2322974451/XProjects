using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001117 RID: 4375
	internal class Process_RpcC2G_ThanksForBonus
	{
		// Token: 0x0600D920 RID: 55584 RVA: 0x0032A868 File Offset: 0x00328A68
		public static void OnReply(ThanksForBonusArg oArg, ThanksForBonusRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XQuickReplyDocument specificDocument = XDocuments.GetSpecificDocument<XQuickReplyDocument>(XQuickReplyDocument.uuID);
				specificDocument.OnThankForBonus(oArg, oRes);
			}
		}

		// Token: 0x0600D921 RID: 55585 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ThanksForBonusArg oArg)
		{
		}
	}
}
