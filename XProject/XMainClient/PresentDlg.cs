using System;
using System.Collections.Generic;
using MiniJSON;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C03 RID: 3075
	internal class PresentDlg : DlgBase<PresentDlg, PresentBehaviour>
	{
		// Token: 0x170030D3 RID: 12499
		// (get) Token: 0x0600AEC4 RID: 44740 RVA: 0x0020EC2C File Offset: 0x0020CE2C
		private XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		// Token: 0x170030D4 RID: 12500
		// (get) Token: 0x0600AEC5 RID: 44741 RVA: 0x0020EC48 File Offset: 0x0020CE48
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030D5 RID: 12501
		// (get) Token: 0x0600AEC6 RID: 44742 RVA: 0x0020EC5C File Offset: 0x0020CE5C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030D6 RID: 12502
		// (get) Token: 0x0600AEC7 RID: 44743 RVA: 0x0020EC70 File Offset: 0x0020CE70
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030D7 RID: 12503
		// (get) Token: 0x0600AEC8 RID: 44744 RVA: 0x0020EC84 File Offset: 0x0020CE84
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170030D8 RID: 12504
		// (get) Token: 0x0600AEC9 RID: 44745 RVA: 0x0020EC98 File Offset: 0x0020CE98
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030D9 RID: 12505
		// (get) Token: 0x0600AECA RID: 44746 RVA: 0x0020ECAC File Offset: 0x0020CEAC
		public override string fileName
		{
			get
			{
				return "GameSystem/PresentDlg";
			}
		}

		// Token: 0x0600AECB RID: 44747 RVA: 0x0020ECC3 File Offset: 0x0020CEC3
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600AECC RID: 44748 RVA: 0x0020ECD0 File Offset: 0x0020CED0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnPay.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPayClick));
			base.uiBehaviour.m_btnCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelClick));
		}

		// Token: 0x0600AECD RID: 44749 RVA: 0x0020ED20 File Offset: 0x0020CF20
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_icon, this.doc.currItemID, 0, false);
			base.uiBehaviour.m_lblPrice.SetText((this.doc.currCIBShop.row.rmb / 10f).ToString());
			base.uiBehaviour.m_input.selected(false);
			base.uiBehaviour.m_input.SetText("");
			base.uiBehaviour.m_input.SetDefault(XStringDefineProxy.GetString("PresentDefault"));
			XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(this.mRoleid);
			bool flag = friendDataById != null;
			if (flag)
			{
				base.uiBehaviour.m_lblTitle.SetText(string.Format(XStringDefineProxy.GetString("PresentTitle", new object[]
				{
					friendDataById.name
				}), new object[0]));
			}
		}

		// Token: 0x0600AECE RID: 44750 RVA: 0x0020EE26 File Offset: 0x0020D026
		public void Show(ulong roleid)
		{
			this.mRoleid = roleid;
			this.SetVisible(true, true);
		}

		// Token: 0x0600AECF RID: 44751 RVA: 0x0020EE3C File Offset: 0x0020D03C
		private bool OnPayClick(IXUIButton btn)
		{
			string text = base.uiBehaviour.m_input.GetText();
			XSingleton<XDebug>.singleton.AddLog("input=>", text, null, null, null, null, XDebugColor.XDebug_None);
			this.SetVisible(false, true);
			XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			CIBShop currCIBShop = specificDocument.currCIBShop;
			bool flag = currCIBShop != null;
			if (flag)
			{
				XRechargeDocument specificDocument2 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				specificDocument2.SDKBuyGoods(currCIBShop.row.id, 1U, this.mRoleid, text, currCIBShop.row.goodsid, currCIBShop.row.rmb);
			}
			return true;
		}

		// Token: 0x0600AED0 RID: 44752 RVA: 0x0020EEDC File Offset: 0x0020D0DC
		private bool OnCancelClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AED1 RID: 44753 RVA: 0x0020EEF8 File Offset: 0x0020D0F8
		public void OnResPresent(string openid, string name)
		{
			this.mOpenid = openid;
			this.mRoleName = name;
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(string.IsNullOrEmpty(openid));
			string @string = XStringDefineProxy.GetString("PresentSucc");
			string string2 = XStringDefineProxy.GetString("PresentOK");
			string string3 = XStringDefineProxy.GetString("PresentCancel");
			string string4 = XStringDefineProxy.GetString("PresentCertain");
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ShowNoTip(XTempTipDefine.OD_START);
			bool flag = !string.IsNullOrEmpty(openid);
			if (flag)
			{
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnOKClick), new ButtonClickEventHandler(this.OnCancalClick));
			}
			else
			{
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string4, string3);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnCancalClick), new ButtonClickEventHandler(this.OnCancalClick));
			}
		}

		// Token: 0x0600AED2 RID: 44754 RVA: 0x0020EFE4 File Offset: 0x0020D1E4
		private bool OnOKClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XDebug>.singleton.AddLog("Do Share to platform friends", null, null, null, null, null, XDebugColor.XDebug_None);
			string @string = XStringDefineProxy.GetString("PresentShare", new object[]
			{
				this.mRoleName
			});
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag)
			{
				this.ShareToQQFriend(this.mOpenid, @string);
			}
			else
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
				if (flag2)
				{
					this.ShareToWXFriend(this.mOpenid, @string);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PresentMode"), "fece00");
				}
			}
			return true;
		}

		// Token: 0x0600AED3 RID: 44755 RVA: 0x0020F090 File Offset: 0x0020D290
		private bool OnCancalClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AED4 RID: 44756 RVA: 0x0020F0B0 File Offset: 0x0020D2B0
		private void ShareToQQFriend(string openID, string desc)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["act"] = 1;
			dictionary["openId"] = openID;
			dictionary["title"] = XSingleton<XGlobalConfig>.singleton.GetValue("PresFriendShareTitle");
			dictionary["summary"] = desc;
			dictionary["targetUrl"] = XSingleton<XGlobalConfig>.singleton.GetValue("PresFriendShareTargetUrlQQ");
			dictionary["imageUrl"] = XSingleton<XGlobalConfig>.singleton.GetValue("PresFriendShareImageUrlQQ");
			dictionary["previewText"] = XSingleton<XGlobalConfig>.singleton.GetValue("PresFriendSharePreviewTextQQ");
			dictionary["gameTag"] = "MSG_HEART_SEND";
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("ShareToQQFriend paramStr = ", text, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_qq", text);
		}

		// Token: 0x0600AED5 RID: 44757 RVA: 0x0020F1A0 File Offset: 0x0020D3A0
		private void ShareToWXFriend(string openID, string desc)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["openId"] = openID;
			dictionary["title"] = XSingleton<XGlobalConfig>.singleton.GetValue("PresFriendShareTitle");
			dictionary["description"] = desc;
			dictionary["thumbMediaId"] = "";
			dictionary["mediaTagName"] = "MSG_HEART_SEND";
			dictionary["messageExt"] = "ShareWithWeixin";
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("ShareToWXFriend paramStr = ", text, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_wx", text);
		}

		// Token: 0x04004277 RID: 17015
		private ulong mRoleid = 0UL;

		// Token: 0x04004278 RID: 17016
		private string mOpenid = string.Empty;

		// Token: 0x04004279 RID: 17017
		private string mRoleName = string.Empty;
	}
}
