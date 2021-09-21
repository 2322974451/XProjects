using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010FC RID: 4348
	internal class Process_RpcC2G_GetAchieveRewardReq
	{
		// Token: 0x0600D8AE RID: 55470 RVA: 0x00329E78 File Offset: 0x00328078
		public static void OnReply(GetAchieveRewardReq oArg, GetAchieveRewardRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
				specificDocument.OnClaimedAchieve(oArg.achieveID);
			}
		}

		// Token: 0x0600D8AF RID: 55471 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetAchieveRewardReq oArg)
		{
		}
	}
}
