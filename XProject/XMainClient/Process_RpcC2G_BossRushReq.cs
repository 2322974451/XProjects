using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001163 RID: 4451
	internal class Process_RpcC2G_BossRushReq
	{
		// Token: 0x0600DA5D RID: 55901 RVA: 0x0032D25C File Offset: 0x0032B45C
		public static void OnReply(BossRushArg oArg, BossRushRes oRes)
		{
			bool flag = oRes.ret == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XBossBushDocument specificDocument = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
				bool flag2 = oRes.ret == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					bool flag3 = oArg.type == BossRushReqStatus.BOSSRUSH_REQ_BASEDATA || oArg.type == BossRushReqStatus.BOSSRUSH_REQ_REFRESH;
					if (flag3)
					{
						specificDocument.Resp(oArg.type, oRes.data);
					}
					else
					{
						bool flag4 = oArg.type == BossRushReqStatus.BOSSRUSH_REQ_APPEARANCE || oArg.type == BossRushReqStatus.BOSSRUSH_REQ_CONTINUE;
						if (flag4)
						{
							specificDocument.unitAppearance = oRes.bossApp;
							DlgBase<BossRushDlg, BossRushBehavior>.singleton.GoBattle();
						}
						else
						{
							bool flag5 = oArg.type == BossRushReqStatus.BOSSRUSH_REQ_LEFTCOUNT;
							if (flag5)
							{
								specificDocument.leftChanllageCnt = oRes.leftcount;
								XActivityDocument.Doc.OnGetDayCount();
							}
							else
							{
								XSingleton<XDebug>.singleton.AddLog("rcv server msg!", null, null, null, null, null, XDebugColor.XDebug_None);
							}
						}
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("bossrush err=>", oRes.ret.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				}
			}
		}

		// Token: 0x0600DA5E RID: 55902 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BossRushArg oArg)
		{
		}
	}
}
