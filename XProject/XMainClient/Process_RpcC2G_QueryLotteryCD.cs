using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001028 RID: 4136
	internal class Process_RpcC2G_QueryLotteryCD
	{
		// Token: 0x0600D54A RID: 54602 RVA: 0x00323B58 File Offset: 0x00321D58
		public static void OnReply(QueryLotteryCDArg oArg, QueryLotteryCDRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				specificDocument.OnQueryLotteryCD(oRes.goldbuycooldown, oRes.cooldown, oRes.goldbuycount, oRes.coinbaodi);
			}
		}

		// Token: 0x0600D54B RID: 54603 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryLotteryCDArg oArg)
		{
		}
	}
}
