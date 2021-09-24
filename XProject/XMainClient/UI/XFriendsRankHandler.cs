using System;
using System.Collections.Generic;
using KKSG;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XFriendsRankHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_ScrollView = (base.PanelObject.transform.Find("FriendsList").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.Find("FriendsList/Friendname").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_MyRank = base.PanelObject.transform.Find("Myname/Tpl");
			this.m_MyRank.gameObject.SetActive(false);
			this.m_NoFriend = base.PanelObject.transform.Find("NoFriend");
			this.m_PkHelpBtn = (base.PanelObject.transform.Find("T3/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_PkHelpLabel = (base.PanelObject.transform.Find("T3/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_PkHelpLabel.gameObject.SetActive(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._RankWrapListUpdated));
			this.m_PkHelpBtn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnHelpBtnPress));
		}

		private void OnHelpBtnPress(IXUIButton btn, bool state)
		{
			bool flag = this.m_PkHelpLabel.gameObject.activeInHierarchy != state;
			if (flag)
			{
				this.m_PkHelpLabel.gameObject.SetActive(state);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_WrapContent.InitContent();
			this.RefreshRankList();
			this.m_PkHelpLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("FRIEND_PK")));
			this.m_PkHelpBtn.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends_Pk));
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.rankItemDict.Clear();
			this.ClearPreTabTextures();
		}

		public void ClearPreTabTextures()
		{
			foreach (KeyValuePair<Transform, IXUITexture> keyValuePair in this._WrapTextureList)
			{
				IXUITexture value = keyValuePair.Value;
				value.ID = 0UL;
				value.SetRuntimeTex(null, true);
			}
			this._WrapTextureList.Clear();
		}

		public void RefreshRankList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.rankItemDict.Clear();
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				bool flag2 = specificDocument.PlatFriendsRankList != null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("FriendsRank RefreshRankList doc.PlatFriendsRankList != null", null, null, null, null, null, XDebugColor.XDebug_None);
					this.m_WrapContent.SetContentCount(specificDocument.PlatFriendsRankList.Count, false);
				}
				bool flag3 = specificDocument.SelfPlatRankInfo != null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddLog("FriendsRank RefreshRankList doc.SelfPlatRankInfo != null", null, null, null, null, null, XDebugColor.XDebug_None);
					this.SetMyRankInfo(specificDocument.SelfPlatRankInfo);
				}
				this.m_MyRank.gameObject.SetActive(specificDocument.SelfPlatRankInfo != null);
				this.m_NoFriend.gameObject.SetActive(specificDocument.PlatFriendsRankList == null || specificDocument.PlatFriendsRankList.Count == 0);
				this.m_ScrollView.ResetPosition();
			}
		}

		private string SimplifyString(string s)
		{
			s = this.RemoveEmoji(s);
			int num = 8;
			bool flag = s.Length > num;
			string result;
			if (flag)
			{
				int num2 = s.Length - num;
				string text = s.Substring(0, num / 2);
				text = XSingleton<XCommon>.singleton.StringCombine(text, "...", s.Substring(num / 2 + num2));
				result = text;
			}
			else
			{
				result = s;
			}
			return result;
		}

		private string RemoveEmoji(string s)
		{
			char[] array = s.ToCharArray();
			List<char> list = new List<char>();
			int i = 0;
			while (i < array.Length - 1)
			{
				char c = array[i];
				int num = (int)c;
				bool flag = num == 55356;
				if (flag)
				{
					char c2 = array[i + 1];
					i += 2;
				}
				else
				{
					bool flag2 = num == 55357;
					if (flag2)
					{
						char c2 = array[i + 1];
						i += 2;
					}
					else
					{
						list.Add(array[i]);
						i++;
					}
				}
			}
			bool flag3 = i == array.Length - 1;
			if (flag3)
			{
				list.Add(array[i]);
			}
			return new string(list.ToArray());
		}

		private void SetBaseRankInfo(Transform item, PlatFriendRankInfo2Client rankInfo, int index)
		{
			bool flag = rankInfo == null;
			if (!flag)
			{
				this.SetRank(item.gameObject, rankInfo.rank - 1U);
				IXUILabel ixuilabel = item.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this.SimplifyString(rankInfo.platfriendBaseInfo.nickname));
				IXUILabel ixuilabel2 = item.Find("Level").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(string.Format("Lv.{0}", rankInfo.level));
				IXUILabel ixuilabel3 = item.Find("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(rankInfo.maxAbility.ToString());
				IXUILabel ixuilabel4 = item.Find("vip").GetComponent("XUILabel") as IXUILabel;
				ixuilabel4.SetText(rankInfo.vipLevel.ToString());
				ixuilabel4.SetVisible(false);
				IXUISprite ixuisprite = item.Find("headboard").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(rankInfo.profession));
				IXUISprite spr = item.FindChild("headboard/AvatarFrame").GetComponent("XUISprite") as IXUISprite;
				XSingleton<UiUtility>.singleton.ParseHeadIcon((rankInfo.pre == null) ? new List<uint>() : rankInfo.pre.setid, spr);
				IXUITexture ixuitexture = item.Find("platHead").GetComponent("XUITexture") as IXUITexture;
				string bigpic = rankInfo.platfriendBaseInfo.bigpic;
				XSingleton<XUICacheImage>.singleton.Load((bigpic != "") ? bigpic : string.Empty, ixuitexture, DlgBase<XFriendsView, XFriendsBehaviour>.singleton.uiBehaviour);
				IXUISprite ixuisprite2 = item.Find("onling").GetComponent("XUISprite") as IXUISprite;
				string sprite = rankInfo.isOnline ? "l_online_01" : "l_online_02";
				ixuisprite2.SetSprite(sprite);
				this._WrapTextureList[item] = ixuitexture;
			}
		}

		private void SetMyRankInfo(PlatFriendRankInfo2Client rankInfo)
		{
			this.SetBaseRankInfo(this.m_MyRank, rankInfo, 99999);
			GameObject gameObject = this.m_MyRank.FindChild("OutOfRange").gameObject;
			gameObject.SetActive(rankInfo.rank == XFlowerRankDocument.INVALID_RANK);
			GameObject gameObject2 = this.m_MyRank.FindChild("platHead/QQVIP").gameObject;
			GameObject gameObject3 = this.m_MyRank.FindChild("platHead/QQSVIP").gameObject;
			XPlatformAbilityDocument specificDocument = XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
			bool flag = specificDocument.QQVipInfo == null;
			if (flag)
			{
				gameObject2.SetActive(false);
				gameObject3.SetActive(false);
			}
			else
			{
				gameObject3.SetActive(specificDocument.QQVipInfo.is_svip);
				gameObject2.SetActive(!specificDocument.QQVipInfo.is_svip && specificDocument.QQVipInfo.is_vip);
			}
			IXUISprite ixuisprite = this.m_MyRank.Find("wxLaunch").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickWXGameCenterLaunchIcon));
			ixuisprite.SetVisible(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_WX && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			IXUISprite ixuisprite2 = this.m_MyRank.Find("qqLaunch").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickQQGameCenterLaunchIcon));
			ixuisprite2.SetVisible(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_QQ && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
		}

		private void _RankWrapListUpdated(Transform item, int index)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			bool flag = index >= specificDocument.PlatFriendsRankList.Count;
			if (!flag)
			{
				PlatFriendRankInfo2Client platFriendRankInfo2Client = specificDocument.PlatFriendsRankList[index];
				bool flag2 = platFriendRankInfo2Client == null;
				if (!flag2)
				{
					this.rankItemDict[item] = platFriendRankInfo2Client.platfriendBaseInfo.openid;
					this.SetBaseRankInfo(item, platFriendRankInfo2Client, index);
					IXUIButton ixuibutton = item.Find("BtnSend").GetComponent("XUIButton") as IXUIButton;
					IXUILabel ixuilabel = item.Find("BtnSend/t").GetComponent("XUILabel") as IXUILabel;
					ixuibutton.ID = (ulong)((long)index);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendBtnClicked));
					ixuibutton.SetEnable(!platFriendRankInfo2Client.hasGiveGift, false);
					ixuilabel.SetEnabled(!platFriendRankInfo2Client.hasGiveGift);
					ixuibutton.SetVisible(platFriendRankInfo2Client.platfriendBaseInfo.openid != XSingleton<XLoginDocument>.singleton.OpenID);
					IXUIButton ixuibutton2 = item.Find("BtnPk").GetComponent("XUIButton") as IXUIButton;
					ixuibutton2.ID = (ulong)((long)index);
					ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendPkBtnClicked));
					bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends_Pk);
					if (flag3)
					{
						ixuibutton2.SetVisible(platFriendRankInfo2Client.platfriendBaseInfo.openid != XSingleton<XLoginDocument>.singleton.OpenID);
					}
					else
					{
						ixuibutton2.SetVisible(false);
					}
					GameObject gameObject = item.FindChild("platHead/QQVIP").gameObject;
					GameObject gameObject2 = item.FindChild("platHead/QQSVIP").gameObject;
					QQVipType qqvipType;
					bool flag4 = specificDocument.FriendsVipInfo.TryGetValue(platFriendRankInfo2Client.platfriendBaseInfo.openid, out qqvipType);
					if (flag4)
					{
						gameObject2.SetActive(qqvipType == QQVipType.SVip);
						gameObject.SetActive(qqvipType == QQVipType.Vip);
					}
					else
					{
						gameObject2.SetActive(false);
						gameObject.SetActive(false);
					}
					IXUISprite ixuisprite = item.Find("wxLaunch").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetVisible(platFriendRankInfo2Client.startType == 3);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickWXGameCenterLaunchIcon));
					IXUISprite ixuisprite2 = item.Find("qqLaunch").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.SetVisible(platFriendRankInfo2Client.startType == 2);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickQQGameCenterLaunchIcon));
				}
			}
		}

		private void OnClickWXGameCenterLaunchIcon(IXUISprite btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FriendRankWXGameCenterTip"), "fece00");
		}

		private void OnClickQQGameCenterLaunchIcon(IXUISprite btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FriendRankQQGameCenterTip"), "fece00");
		}

		private void SetRank(GameObject go, uint rankIndex)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
			bool flag = rankIndex == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetVisible(false);
				ixuisprite.SetVisible(false);
			}
			else
			{
				string[] array = new string[]
				{
					"N1",
					"N2",
					"N3"
				};
				bool flag2 = rankIndex < 3U;
				if (flag2)
				{
					ixuisprite.SetSprite(array[(int)rankIndex]);
					ixuisprite.SetVisible(true);
					ixuilabel.SetVisible(false);
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel.SetText("No." + (rankIndex + 1U));
					ixuilabel.SetVisible(true);
				}
			}
		}

		private bool OnSendBtnClicked(IXUIButton btn)
		{
			int num = (int)btn.ID;
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			bool flag = num >= specificDocument.PlatFriendsRankList.Count;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				PlatFriendRankInfo2Client platFriendRankInfo2Client = specificDocument.PlatFriendsRankList[num];
				bool flag2 = platFriendRankInfo2Client == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					specificDocument.SendGift2PlatFriend(platFriendRankInfo2Client.platfriendBaseInfo.openid);
					result = true;
				}
			}
			return result;
		}

		private bool OnSendPkBtnClicked(IXUIButton btn)
		{
			int num = (int)btn.ID;
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			bool flag = num >= specificDocument.PlatFriendsRankList.Count;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				PlatFriendRankInfo2Client platFriendRankInfo2Client = specificDocument.PlatFriendsRankList[num];
				bool flag2 = platFriendRankInfo2Client == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					specificDocument.SendPk2PlatFriend(platFriendRankInfo2Client.platfriendBaseInfo.openid);
					result = true;
				}
			}
			return result;
		}

		private void ShareToQQFriend(string openID)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["act"] = 1;
			dictionary["openId"] = openID;
			dictionary["title"] = XSingleton<XGlobalConfig>.singleton.GetValue("PlatFriendShareTitle");
			dictionary["summary"] = XSingleton<XGlobalConfig>.singleton.GetValue("PlatFriendShareSummary");
			dictionary["targetUrl"] = XSingleton<XGlobalConfig>.singleton.GetValue("PlatFriendShareTargetUrlQQ");
			dictionary["imageUrl"] = XSingleton<XGlobalConfig>.singleton.GetValue("PlatFriendShareImageUrlQQ");
			dictionary["previewText"] = XSingleton<XGlobalConfig>.singleton.GetValue("PlatFriendSharePreviewTextQQ");
			dictionary["gameTag"] = "MSG_HEART_SEND";
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("ShareToQQFriend paramStr = " + text, null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_qq", text);
		}

		private void ShareToWXFriend(string openID)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["openId"] = openID;
			dictionary["title"] = XSingleton<XGlobalConfig>.singleton.GetValue("PlatFriendShareTitle");
			dictionary["description"] = XSingleton<XGlobalConfig>.singleton.GetValue("PlatFriendShareSummary");
			dictionary["thumbMediaId"] = "";
			dictionary["mediaTagName"] = "MSG_HEART_SEND";
			dictionary["messageExt"] = "ShareWithWeixin";
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("ShareToWXFriend paramStr = " + text, null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_wx", text);
		}

		public void OnRefreshSendGiftState(PlatFriendRankInfo2Client info)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				foreach (KeyValuePair<Transform, string> keyValuePair in this.rankItemDict)
				{
					bool flag2 = keyValuePair.Value == info.platfriendBaseInfo.openid;
					if (flag2)
					{
						IXUIButton ixuibutton = keyValuePair.Key.Find("BtnSend").GetComponent("XUIButton") as IXUIButton;
						ixuibutton.SetEnable(!info.hasGiveGift, false);
						break;
					}
				}
			}
		}

		public void NoticeFriend(string openID)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_noticeFriendOpenID = openID;
				string @string = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_TIP");
				string string2 = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_OK");
				string string3 = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_CANCEL");
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.CheckNoticeFriend), null);
			}
		}

		private bool CheckNoticeFriend(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XAuthorizationChannel channel = XSingleton<XLoginDocument>.singleton.Channel;
			string @string = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_TIP");
			bool flag = channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag)
			{
				@string = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_TIP_QQ");
			}
			else
			{
				bool flag2 = channel == XAuthorizationChannel.XAuthorization_WeChat;
				if (flag2)
				{
					@string = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_TIP_WX");
				}
			}
			string string2 = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_OK2");
			string string3 = XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_CANCEL2");
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnEnsureNoticeFriend), null);
			return true;
		}

		private bool OnEnsureNoticeFriend(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag)
			{
				this.ShareToQQFriend(this.m_noticeFriendOpenID);
			}
			else
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
				if (flag2)
				{
					this.ShareToWXFriend(this.m_noticeFriendOpenID);
				}
			}
			return true;
		}

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public Transform m_MyRank;

		public Transform m_NoFriend;

		public IXUIButton m_PkHelpBtn;

		public IXUILabel m_PkHelpLabel;

		private Dictionary<Transform, string> rankItemDict = new Dictionary<Transform, string>();

		public Dictionary<Transform, IXUITexture> _WrapTextureList = new Dictionary<Transform, IXUITexture>();

		private string m_noticeFriendOpenID;
	}
}
