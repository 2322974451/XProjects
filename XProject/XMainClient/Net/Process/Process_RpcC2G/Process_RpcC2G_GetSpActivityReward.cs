using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetSpActivityReward
	{

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

		public static void OnTimeout(GetSpActivityRewardArg oArg)
		{
		}
	}
}
