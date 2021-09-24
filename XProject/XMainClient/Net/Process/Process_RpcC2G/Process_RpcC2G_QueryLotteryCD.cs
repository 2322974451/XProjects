using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryLotteryCD
	{

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

		public static void OnTimeout(QueryLotteryCDArg oArg)
		{
		}
	}
}
