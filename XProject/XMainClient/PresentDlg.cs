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

	internal class PresentDlg : DlgBase<PresentDlg, PresentBehaviour>
	{

		private XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/PresentDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnPay.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPayClick));
			base.uiBehaviour.m_btnCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelClick));
		}

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

		public void Show(ulong roleid)
		{
			this.mRoleid = roleid;
			this.SetVisible(true, true);
		}

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

		private bool OnCancelClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

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

		private bool OnCancalClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

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

		private ulong mRoleid = 0UL;

		private string mOpenid = string.Empty;

		private string mRoleName = string.Empty;
	}
}
