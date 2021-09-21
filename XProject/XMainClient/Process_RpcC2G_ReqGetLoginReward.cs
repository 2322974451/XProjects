using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200110B RID: 4363
	internal class Process_RpcC2G_ReqGetLoginReward
	{
		// Token: 0x0600D8EC RID: 55532 RVA: 0x0032A3F0 File Offset: 0x003285F0
		public static void OnReply(LoginRewardGetReq oArg, LoginRewardGetRet oRes)
		{
			bool flag = oRes.ret == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSevenLoginDocument specificDocument = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
				specificDocument.ReceiveLoginReward(oArg, oRes);
			}
		}

		// Token: 0x0600D8ED RID: 55533 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LoginRewardGetReq oArg)
		{
		}
	}
}
