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

	internal class XPlatformAbilityDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPlatformAbilityDocument.uuID;
			}
		}

		public static XPlatformAbilityDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
			}
		}

		public QQVipInfoClient QQVipInfo
		{
			get
			{
				return this.m_qqVipInfo;
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PlatformAbilityDocument");

		private QQVipInfoClient m_qqVipInfo = null;

		public bool QQVipRedPoint = false;
	}
}
