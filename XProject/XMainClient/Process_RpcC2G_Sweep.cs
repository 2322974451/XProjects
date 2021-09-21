using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200104E RID: 4174
	internal class Process_RpcC2G_Sweep
	{
		// Token: 0x0600D5EE RID: 54766 RVA: 0x00325234 File Offset: 0x00323434
		public static void OnReply(SweepArg oArg, SweepRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oArg.sceneID != 0U && oArg.sceneID != 2010U;
				if (flag2)
				{
					XSweepDocument specificDocument = XDocuments.GetSpecificDocument<XSweepDocument>(XSweepDocument.uuID);
					specificDocument.GetReward(oRes);
					DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.OnGotSweepRes();
				}
				else
				{
					ErrorCode result = oRes.result;
					if (result != ErrorCode.ERR_SUCCESS)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						bool flag3 = DlgBase<BossRushDlg, BossRushBehavior>.singleton.IsVisible();
						if (flag3)
						{
							XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_BossRush, 0UL);
						}
						bool flag4 = DlgBase<TheExpView, TheExpBehaviour>.singleton.IsVisible();
						if (flag4)
						{
							XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
							specificDocument2.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
							DlgBase<TheExpView, TheExpBehaviour>.singleton.RefreshLeftCount();
						}
						bool flag5 = DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.IsVisible();
						if (flag5)
						{
							XDragonNestDocument specificDocument3 = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
							specificDocument3.SendReqDragonNestInfo();
						}
					}
				}
			}
		}

		// Token: 0x0600D5EF RID: 54767 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SweepArg oArg)
		{
		}
	}
}
