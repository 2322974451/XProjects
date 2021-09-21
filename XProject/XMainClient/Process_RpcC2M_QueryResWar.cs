using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001353 RID: 4947
	internal class Process_RpcC2M_QueryResWar
	{
		// Token: 0x0600E23F RID: 57919 RVA: 0x00338BE8 File Offset: 0x00336DE8
		public static void OnReply(QueryResWarArg oArg, QueryResWarRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.error > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
					else
					{
						bool flag4 = oArg.paramSpecified && oArg.param == QueryResWarEnum.RESWAR_FLOWAWARD;
						if (flag4)
						{
							DlgBase<GuildMineRewardView, GuildMineRewardBehaviour>.singleton.SetRewardInfo(oRes);
						}
						else
						{
							XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
							specificDocument.SetAllInfo(oArg, oRes);
						}
					}
				}
			}
		}

		// Token: 0x0600E240 RID: 57920 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryResWarArg oArg)
		{
		}
	}
}
