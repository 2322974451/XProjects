using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010EC RID: 4332
	internal class Process_RpcC2G_GetDesignationReq
	{
		// Token: 0x0600D86A RID: 55402 RVA: 0x003297E4 File Offset: 0x003279E4
		public static void OnReply(GetDesignationReq oArg, GetDesignationRes oRes)
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
				specificDocument.MaxAbilityDesNum = oRes.maxPPT;
				specificDocument.SetDesignationInfo(1U, oRes.coverDesignationID, oRes.name);
				specificDocument.SetDesignationInfo(2U, oRes.abilityDesignationID, oRes.name);
				specificDocument.SetTabRedPoint(oRes.dataList);
			}
		}

		// Token: 0x0600D86B RID: 55403 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDesignationReq oArg)
		{
		}
	}
}
