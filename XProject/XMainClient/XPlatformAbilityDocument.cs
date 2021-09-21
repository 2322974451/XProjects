using System;
using System.Collections.Generic;
using KKSG;
using MiniJSON;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000960 RID: 2400
	internal class XPlatformAbilityDocument : XDocComponent
	{
		// Token: 0x17002C4D RID: 11341
		// (get) Token: 0x060090AD RID: 37037 RVA: 0x00149ED8 File Offset: 0x001480D8
		public override uint ID
		{
			get
			{
				return XPlatformAbilityDocument.uuID;
			}
		}

		// Token: 0x17002C4E RID: 11342
		// (get) Token: 0x060090AE RID: 37038 RVA: 0x00149EF0 File Offset: 0x001480F0
		public static XPlatformAbilityDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
			}
		}

		// Token: 0x17002C4F RID: 11343
		// (get) Token: 0x060090AF RID: 37039 RVA: 0x00149F0C File Offset: 0x0014810C
		public QQVipInfoClient QQVipInfo
		{
			get
			{
				return this.m_qqVipInfo;
			}
		}

		// Token: 0x060090B0 RID: 37040 RVA: 0x00149F24 File Offset: 0x00148124
		public void ClickRedPointNtf()
		{
			bool flag = !this.QQVipRedPoint;
			if (!flag)
			{
				PtcC2G_CloseHintNtf ptcC2G_CloseHintNtf = new PtcC2G_CloseHintNtf();
				ptcC2G_CloseHintNtf.Data.systemid = (uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_QQVIP);
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_CloseHintNtf);
			}
		}

		// Token: 0x060090B1 RID: 37041 RVA: 0x00149F6C File Offset: 0x0014816C
		public void QueryQQVipInfo()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP);
			if (flag)
			{
				RpcC2G_QueryQQVipInfo rpcC2G_QueryQQVipInfo = new RpcC2G_QueryQQVipInfo();
				rpcC2G_QueryQQVipInfo.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QueryQQVipInfo);
			}
		}

		// Token: 0x060090B2 RID: 37042 RVA: 0x00149FC8 File Offset: 0x001481C8
		public void OnQueryQQVipInfo(QueryQQVipInfoArg oArg, QueryQQVipInfoRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					bool flag3 = oRes.info == null;
					if (!flag3)
					{
						this.m_qqVipInfo = oRes.info;
						XSingleton<XDebug>.singleton.AddLog(string.Concat(new string[]
						{
							"[QQVipInfo] isVip:",
							this.m_qqVipInfo.is_svip.ToString(),
							", isSVip:",
							this.m_qqVipInfo.is_svip.ToString(),
							",is_bigger_one_month:",
							this.m_qqVipInfo.is_bigger_one_month.ToString()
						}), null, null, null, null, null, XDebugColor.XDebug_None);
						bool flag4 = DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible() && DlgBase<XOptionsView, XOptionsBehaviour>.singleton.CurrentTab == OptionsTab.InfoTab;
						if (flag4)
						{
							DlgBase<XOptionsView, XOptionsBehaviour>.singleton.ShowQQVipInfo();
						}
						bool flag5 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
						if (flag5)
						{
							DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshQQVipInfo();
						}
						bool flag6 = DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
						if (flag6)
						{
							DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.RefreshQQVip();
						}
					}
				}
			}
		}

		// Token: 0x060090B3 RID: 37043 RVA: 0x0014A104 File Offset: 0x00148304
		public void OpenQQVipRechargeH5()
		{
			string text = string.Format("{0}?sRoleId={1}&sPartition={2}&sPfkey={3}", new object[]
			{
				XSingleton<XGlobalConfig>.singleton.GetValue("QQVipRechargeUrl"),
				XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID,
				XSingleton<XClientNetwork>.singleton.ServerID,
				"pfkey"
			});
			XSingleton<XDebug>.singleton.AddLog("[OpenQQVipRechargeH5] url = " + text, null, null, null, null, null, XDebugColor.XDebug_None);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["url"] = text;
			dictionary["screendir"] = "LANDSCAPE";
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize(dictionary));
		}

		// Token: 0x060090B4 RID: 37044 RVA: 0x0014A1C4 File Offset: 0x001483C4
		public void OnQQVipPayCallback(string msg)
		{
			XSingleton<XDebug>.singleton.AddLog("Pay [OnQQVipPayCallback] msg:" + msg, null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = msg == "Success";
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("QQVIP_RECHARGE_SUC"), "fece00");
				this.QueryQQVipInfo();
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("QQVIP_RECHARGE_FAIL"), "fece00");
			}
		}

		// Token: 0x060090B5 RID: 37045 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002FE6 RID: 12262
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PlatformAbilityDocument");

		// Token: 0x04002FE7 RID: 12263
		private QQVipInfoClient m_qqVipInfo = null;

		// Token: 0x04002FE8 RID: 12264
		public bool QQVipRedPoint = false;
	}
}
