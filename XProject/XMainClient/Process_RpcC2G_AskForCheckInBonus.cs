using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001115 RID: 4373
	internal class Process_RpcC2G_AskForCheckInBonus
	{
		// Token: 0x0600D917 RID: 55575 RVA: 0x0032A790 File Offset: 0x00328990
		public static void OnReply(AskForCheckInBonusArg oArg, AskForCheckInBonusRes oRes)
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
				specificDocument.OnAskForCheckInBonus(oArg, oRes);
			}
		}

		// Token: 0x0600D918 RID: 55576 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AskForCheckInBonusArg oArg)
		{
		}
	}
}
