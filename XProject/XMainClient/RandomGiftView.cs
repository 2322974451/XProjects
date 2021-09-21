using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C94 RID: 3220
	internal class RandomGiftView : DlgBase<RandomGiftView, RandomGiftBehaviour>
	{
		// Token: 0x1700322C RID: 12844
		// (get) Token: 0x0600B5DE RID: 46558 RVA: 0x0024019C File Offset: 0x0023E39C
		private int shareId
		{
			get
			{
				return int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("ShareGiftTableID"));
			}
		}

		// Token: 0x1700322D RID: 12845
		// (get) Token: 0x0600B5DF RID: 46559 RVA: 0x002401C4 File Offset: 0x0023E3C4
		public override string fileName
		{
			get
			{
				return "Common/RandomGift";
			}
		}

		// Token: 0x1700322E RID: 12846
		// (get) Token: 0x0600B5E0 RID: 46560 RVA: 0x002401DC File Offset: 0x0023E3DC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700322F RID: 12847
		// (get) Token: 0x0600B5E1 RID: 46561 RVA: 0x002401F0 File Offset: 0x0023E3F0
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003230 RID: 12848
		// (get) Token: 0x0600B5E2 RID: 46562 RVA: 0x00240204 File Offset: 0x0023E404
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B5E3 RID: 46563 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Init()
		{
		}

		// Token: 0x0600B5E4 RID: 46564 RVA: 0x00240218 File Offset: 0x0023E418
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Share.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareClick));
			base.uiBehaviour.m_WXFriend.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareWXFriendClick));
			base.uiBehaviour.m_WXTimeline.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareWXTimelineClick));
			base.uiBehaviour.m_QQFriend.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareQQFriendClick));
			base.uiBehaviour.m_QQZone.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareQQZoneClick));
		}

		// Token: 0x0600B5E5 RID: 46565 RVA: 0x002402D4 File Offset: 0x0023E4D4
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B5E6 RID: 46566 RVA: 0x002402F0 File Offset: 0x0023E4F0
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_WX.gameObject.SetActive(false);
			base.uiBehaviour.m_QQ.gameObject.SetActive(false);
			base.uiBehaviour.m_BoxWX.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour.m_BoxQQ.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
			if (flag)
			{
				base.uiBehaviour.m_Title.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("RANDOM_GIFT_TITLE_WX")));
				base.uiBehaviour.m_Description.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("RANDOM_GIFT_DESCRIPTION_WX")));
			}
			else
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
				if (flag2)
				{
					base.uiBehaviour.m_Title.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("RANDOM_GIFT_TITLE_QQ")));
					base.uiBehaviour.m_Description.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("RANDOM_GIFT_DESCRIPTION_QQ")));
				}
			}
		}

		// Token: 0x0600B5E7 RID: 46567 RVA: 0x00240449 File Offset: 0x0023E649
		protected override void OnHide()
		{
			this._boxId = null;
			this._actId = null;
			this._url = null;
			base.OnHide();
		}

		// Token: 0x0600B5E8 RID: 46568 RVA: 0x00240468 File Offset: 0x0023E668
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B5E9 RID: 46569 RVA: 0x00240474 File Offset: 0x0023E674
		public void TryOpenUI()
		{
			bool flag = (this._boxId == null || this._actId == null) && this._url == null;
			if (!flag)
			{
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Random_Gift);
				if (!flag2)
				{
					this.SetVisibleWithAnimation(true, null);
				}
			}
		}

		// Token: 0x0600B5EA RID: 46570 RVA: 0x002404C4 File Offset: 0x0023E6C4
		public bool OnShareClick(IXUIButton btn)
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
			if (flag)
			{
				base.uiBehaviour.m_WX.gameObject.SetActive(!base.uiBehaviour.m_WX.gameObject.activeSelf);
			}
			else
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
				if (flag2)
				{
					base.uiBehaviour.m_QQ.gameObject.SetActive(!base.uiBehaviour.m_QQ.gameObject.activeSelf);
				}
				else
				{
					base.uiBehaviour.m_WX.gameObject.SetActive(!base.uiBehaviour.m_WX.gameObject.activeSelf);
					XSingleton<XDebug>.singleton.AddLog("OnShareClick", null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
			return true;
		}

		// Token: 0x0600B5EB RID: 46571 RVA: 0x002405A8 File Offset: 0x0023E7A8
		public bool OnShareWXFriendClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.WXFriend, ShareTagType.GiftBag_Tag);
			return true;
		}

		// Token: 0x0600B5EC RID: 46572 RVA: 0x002405C4 File Offset: 0x0023E7C4
		public bool OnShareWXTimelineClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.WXTimeline, ShareTagType.GiftBag_Tag);
			return true;
		}

		// Token: 0x0600B5ED RID: 46573 RVA: 0x002405E0 File Offset: 0x0023E7E0
		public bool OnShareQQFriendClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.QQFriend, ShareTagType.Invite_Tag);
			return true;
		}

		// Token: 0x0600B5EE RID: 46574 RVA: 0x002405FC File Offset: 0x0023E7FC
		public bool OnShareQQZoneClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.QQZone, ShareTagType.Invite_Tag);
			return true;
		}

		// Token: 0x0600B5EF RID: 46575 RVA: 0x00240618 File Offset: 0x0023E818
		public void ReadyShareGift(GetPlatformShareChestArg oArg, GetPlatformShareChestRes oRes)
		{
			this.SetGift(oRes.act_id.ToString(), oRes.boxid, oRes.url);
		}

		// Token: 0x0600B5F0 RID: 46576 RVA: 0x00240648 File Offset: 0x0023E848
		public void SetGift(string actId, string boxId, string url)
		{
			this._actId = actId;
			this._boxId = boxId;
			this._url = url;
			XSingleton<XDebug>.singleton.AddLog(string.Concat(new string[]
			{
				"RandomGift _boxId:",
				this._boxId,
				" _actId:",
				this._actId,
				"_url:",
				this._url
			}), null, null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x0600B5F1 RID: 46577 RVA: 0x002406BC File Offset: 0x0023E8BC
		private void ShareGift(RandomGiftView.ShareType type, ShareTagType tagType)
		{
			bool issession = type == RandomGiftView.ShareType.WXFriend || type == RandomGiftView.ShareType.QQFriend;
			XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
			{
				"shareId:",
				this.shareId,
				" isSession:",
				issession.ToString(),
				" _actId:",
				this._actId,
				" _boxId:",
				this._boxId,
				" tagType:",
				tagType
			}), null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XScreenShotMgr>.singleton.DoShareWithLink(this.shareId, issession, tagType, this._url, new object[]
			{
				this._actId,
				this._boxId
			});
			this.OnCloseClicked(null);
		}

		// Token: 0x04004748 RID: 18248
		private string _boxId = null;

		// Token: 0x04004749 RID: 18249
		private string _actId = null;

		// Token: 0x0400474A RID: 18250
		private string _url = null;

		// Token: 0x020019AE RID: 6574
		private enum ShareType
		{
			// Token: 0x04007F86 RID: 32646
			WXFriend,
			// Token: 0x04007F87 RID: 32647
			WXTimeline,
			// Token: 0x04007F88 RID: 32648
			QQFriend,
			// Token: 0x04007F89 RID: 32649
			QQZone
		}
	}
}
