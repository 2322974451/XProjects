using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RandomGiftView : DlgBase<RandomGiftView, RandomGiftBehaviour>
	{

		private int shareId
		{
			get
			{
				return int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("ShareGiftTableID"));
			}
		}

		public override string fileName
		{
			get
			{
				return "Common/RandomGift";
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

		protected override void Init()
		{
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Share.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareClick));
			base.uiBehaviour.m_WXFriend.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareWXFriendClick));
			base.uiBehaviour.m_WXTimeline.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareWXTimelineClick));
			base.uiBehaviour.m_QQFriend.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareQQFriendClick));
			base.uiBehaviour.m_QQZone.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareQQZoneClick));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		protected override void OnHide()
		{
			this._boxId = null;
			this._actId = null;
			this._url = null;
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

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

		public bool OnShareWXFriendClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.WXFriend, ShareTagType.GiftBag_Tag);
			return true;
		}

		public bool OnShareWXTimelineClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.WXTimeline, ShareTagType.GiftBag_Tag);
			return true;
		}

		public bool OnShareQQFriendClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.QQFriend, ShareTagType.Invite_Tag);
			return true;
		}

		public bool OnShareQQZoneClick(IXUIButton btn)
		{
			this.ShareGift(RandomGiftView.ShareType.QQZone, ShareTagType.Invite_Tag);
			return true;
		}

		public void ReadyShareGift(GetPlatformShareChestArg oArg, GetPlatformShareChestRes oRes)
		{
			this.SetGift(oRes.act_id.ToString(), oRes.boxid, oRes.url);
		}

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

		private string _boxId = null;

		private string _actId = null;

		private string _url = null;

		private enum ShareType
		{

			WXFriend,

			WXTimeline,

			QQFriend,

			QQZone
		}
	}
}
