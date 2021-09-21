using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200131E RID: 4894
	internal class Process_RpcC2G_GetSpActivityReward
	{
		// Token: 0x0600E166 RID: 57702 RVA: 0x003377E0 File Offset: 0x003359E0
		public static void OnReply(GetSpActivityRewardArg oArg, GetSpActivityRewardRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				int num = XFastEnumIntEqualityComparer<ActivityType>.ToInt(ActivityType.BigPrize);
				bool flag2 = oArg.actid == 1U;
				if (flag2)
				{
					XCarnivalDocument specificDocument = XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
					specificDocument.RespClaim(oArg.taskid);
				}
				else
				{
					bool flag3 = oArg.actid == (uint)num;
					if (flag3)
					{
						XAncientDocument specificDocument2 = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
						specificDocument2.ResClaim();
					}
					else
					{
						bool flag4 = oArg.actid == WeekEndNestDocument.Doc.m_actId;
						if (flag4)
						{
							WeekEndNestDocument.Doc.OnGetReward(oRes);
						}
						else
						{
							bool flag5 = oArg.actid == 5U;
							if (flag5)
							{
								XBackFlowDocument.Doc.OnGetReward(oArg, oRes);
							}
						}
					}
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
			}
		}

		// Token: 0x0600E167 RID: 57703 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetSpActivityRewardArg oArg)
		{
		}
	}
}
