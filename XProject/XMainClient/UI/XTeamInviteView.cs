using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamInviteView : DlgBase<XTeamInviteView, XTeamInviteBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/TeamInviteDlg";
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
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._InviteDoc = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			this._InviteDoc.InviteHandler = this;
		}

		protected override void OnHide()
		{
			this.ClearPreTabTextures();
			this.hasPlatFriends = false;
			base.OnHide();
		}

		protected override void OnUnload()
		{
			this._InviteDoc.InviteHandler = null;
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_ToggleFriend.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnToggleChanged));
			base.uiBehaviour.m_ToggleGuild.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnToggleChanged));
			base.uiBehaviour.m_ToggleRecommand.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnToggleChanged));
			base.uiBehaviour.m_TogglePlatFriend.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnToggleChanged));
			base.uiBehaviour.m_BtnAddFriendMiddle.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnAddFriendClicked));
			base.uiBehaviour.m_BtnAddFriendBottom.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnAddFriendClicked));
			base.uiBehaviour.m_BtnJoinGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinGuildClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentItemInit));
			base.uiBehaviour.m_ClosedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._TryRefresh();
		}

		public override void StackRefresh()
		{
			this._TryRefresh();
		}

		private void _TryRefresh()
		{
			this._InviteDoc.ReqInviteList();
			bool flag = this.m_SelectedTab != -1;
			if (flag)
			{
				this.Refresh();
			}
		}

		public void LocalServerRefresh()
		{
			bool flag = this.m_SelectedTab != 3;
			if (flag)
			{
				this.Refresh();
			}
		}

		public void Refresh()
		{
			bool flag = this._TeamDoc.currentExpInfo.isCrossServerInvite && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends_Pk);
			if (flag)
			{
				base.uiBehaviour.m_TogglePlatFriend.gameObject.SetActive(true);
			}
			else
			{
				base.uiBehaviour.m_TogglePlatFriend.gameObject.SetActive(false);
				bool flag2 = this.m_SelectedTab == 3;
				if (flag2)
				{
					this.m_SelectedTab = 0;
				}
			}
			bool flag3 = this.m_SelectedTab == 3 && !this.hasPlatFriends;
			if (flag3)
			{
				XSingleton<XDebug>.singleton.AddLog("[InvitePlatFriend]ReqPlatFriendsRank", null, null, null, null, null, XDebugColor.XDebug_None);
				XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
				specificDocument.ReqPlatFriendsRank();
				this.hasPlatFriends = true;
			}
			else
			{
				int num = 0;
				bool flag4 = this.m_SelectedTab != -1;
				if (flag4)
				{
					num = this._InviteDoc.InviteLists[this.m_SelectedTab].Count;
				}
				XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
				{
					"m_SelectedTab:",
					this.m_SelectedTab,
					"\ndataCount:",
					num
				}), null, null, null, null, null);
				base.uiBehaviour.m_WrapContent.SetContentCount(num, false);
				base.uiBehaviour.m_ScrollView.ResetPosition();
				base.uiBehaviour.m_EmptyList.SetActive(num == 0);
				base.uiBehaviour.m_BtnAddFriendMiddle.SetVisible(this.m_SelectedTab == 1 && num <= 1);
				base.uiBehaviour.m_BtnAddFriendBottom.SetVisible(this.m_SelectedTab == 1 && num > 1 && num <= 2);
				base.uiBehaviour.m_BtnJoinGuild.SetVisible(this.m_SelectedTab == 2 && !this._GuildDoc.bInGuild);
			}
		}

		private void _WrapContentItemInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnInviteClick));
		}

		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.m_SelectedTab < 0;
			if (!flag)
			{
				bool flag2 = index >= this._InviteDoc.InviteLists[this.m_SelectedTab].Count;
				if (!flag2)
				{
					XTeamInviteListData xteamInviteListData = this._InviteDoc.InviteLists[this.m_SelectedTab][index];
					bool flag3 = xteamInviteListData == null;
					if (!flag3)
					{
						IXUILabelSymbol ixuilabelSymbol = t.FindChild("Info/Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
						IXUILabel ixuilabel = t.FindChild("Info/Level").GetComponent("XUILabel") as IXUILabel;
						IXUISprite ixuisprite = t.FindChild("Info/AvatarBG/Avatar").GetComponent("XUISprite") as IXUISprite;
						IXUISprite ixuisprite2 = t.FindChild("Info/Profession").GetComponent("XUISprite") as IXUISprite;
						IXUILabel ixuilabel2 = t.FindChild("Info/AvatarBG/BattlePointBG/Power").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel3 = t.FindChild("Info/GuildName").GetComponent("XUILabel") as IXUILabel;
						IXUIButton ixuibutton = t.FindChild("BtnInvite").GetComponent("XUIButton") as IXUIButton;
						GameObject gameObject = t.Find("Invited").gameObject;
						IXUILabel ixuilabel4 = t.Find("State").GetComponent("XUILabel") as IXUILabel;
						Transform t2 = t.Find("Info/AvatarBG/Relation");
						Transform transform = t.Find("Info/AvatarBG/Plat/wxLaunch");
						Transform transform2 = t.Find("Info/AvatarBG/Plat/qqLaunch");
						Transform transform3 = t.Find("Info/AvatarBG/Status/Online");
						Transform transform4 = t.Find("Info/AvatarBG/Status/Offline");
						ixuilabelSymbol.InputText = XSingleton<XCommon>.singleton.StringCombine(xteamInviteListData.name, XRechargeDocument.GetVIPIconString(xteamInviteListData.vip));
						ixuilabel.SetText("Lv." + xteamInviteListData.level.ToString());
						ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)xteamInviteListData.profession);
						ixuisprite2.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)xteamInviteListData.profession);
						ixuilabel2.SetText(xteamInviteListData.ppt.ToString());
						bool flag4 = string.IsNullOrEmpty(xteamInviteListData.guildname);
						if (flag4)
						{
							ixuilabel3.SetVisible(false);
						}
						else
						{
							ixuilabel3.SetText(xteamInviteListData.guildname);
							ixuilabel3.SetVisible(true);
						}
						XTeamRelation.Relation targetRelation = XTeamRelation.Relation.TR_NONE;
						bool flag5 = this.m_SelectedTab == 1;
						if (flag5)
						{
							targetRelation = (XTeamRelation.Relation)5;
						}
						else
						{
							bool flag6 = this.m_SelectedTab == 2;
							if (flag6)
							{
								targetRelation = XTeamRelation.Relation.TR_GUILD;
							}
						}
						XTeamView.SetTeamRelationUI(t2, xteamInviteListData.relation, true, targetRelation);
						ixuibutton.ID = (ulong)((long)index);
						ixuibutton.SetVisible(!xteamInviteListData.bSent);
						gameObject.SetActive(xteamInviteListData.bSent);
						bool flag7 = this.m_SelectedTab == 0;
						if (flag7)
						{
							ixuilabel4.SetText(string.Empty);
						}
						else
						{
							ixuilabel4.SetText(XStringDefineProxy.GetString(xteamInviteListData.state.ToString()));
						}
						bool flag8 = this.m_SelectedTab == 3;
						if (flag8)
						{
							transform2.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
							transform.gameObject.SetActive(true);
							transform3.gameObject.SetActive(false);
							transform4.gameObject.SetActive(true);
						}
						else
						{
							transform2.gameObject.SetActive(false);
							transform.gameObject.SetActive(false);
							transform3.gameObject.SetActive(false);
							transform4.gameObject.SetActive(false);
						}
						IXUITexture ixuitexture = t.Find("Info/AvatarBG/platHead").GetComponent("XUITexture") as IXUITexture;
						bool flag9 = this.m_SelectedTab == 3;
						if (flag9)
						{
							transform2.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
							transform.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
							transform3.gameObject.SetActive(xteamInviteListData.isOnline);
							transform4.gameObject.SetActive(!xteamInviteListData.isOnline);
							ixuitexture.gameObject.SetActive(true);
							ixuitexture.ID = (ulong)((long)index);
							string bigpic = xteamInviteListData.bigpic;
							XSingleton<XUICacheImage>.singleton.Load((bigpic != "") ? bigpic : string.Empty, ixuitexture, DlgBase<XTeamInviteView, XTeamInviteBehaviour>.singleton.uiBehaviour);
							this._WrapTextureList.Add(ixuitexture);
						}
						else
						{
							transform2.gameObject.SetActive(false);
							transform.gameObject.SetActive(false);
							transform3.gameObject.SetActive(false);
							transform4.gameObject.SetActive(false);
							ixuitexture.gameObject.SetActive(false);
						}
					}
				}
			}
		}

		public void ClearPreTabTextures()
		{
			for (int i = 0; i < this._WrapTextureList.Count; i++)
			{
				this._WrapTextureList[i].SetTexturePath("");
			}
			this._WrapTextureList.Clear();
		}

		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			this.SetVisible(false, true);
		}

		private bool _OnToggleChanged(IXUICheckBox go)
		{
			bool flag = !go.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_SelectedTab = (int)go.ID;
				this.Refresh();
				result = true;
			}
			return result;
		}

		private bool _OnInviteClick(IXUIButton go)
		{
			bool flag = this.m_SelectedTab < 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XTeamInviteListData xteamInviteListData = this._InviteDoc.InviteLists[this.m_SelectedTab][(int)go.ID];
				bool flag2 = xteamInviteListData == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = xteamInviteListData.sameGuild == 0;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_INVITE_NOT_SAMEGUILD"), "fece00");
						result = true;
					}
					else
					{
						bool flag4 = this.m_SelectedTab == 3;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddLog("[InvitePlatFriend]_OnInviteClick", null, null, null, null, null, XDebugColor.XDebug_None);
							this._TeamDoc.ReqTeamOp(TeamOperate.TEAM_INVITE, 0UL, null, TeamMemberType.TMT_NORMAL, xteamInviteListData.openid);
						}
						else
						{
							this._TeamDoc.ReqTeamOp(TeamOperate.TEAM_INVITE, xteamInviteListData.uid, null, TeamMemberType.TMT_NORMAL, null);
						}
						xteamInviteListData.bSent = true;
						base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
						result = true;
					}
				}
			}
			return result;
		}

		private bool _OnAddFriendClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			return true;
		}

		private bool _OnJoinGuildClicked(IXUIButton btn)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_LOG_CANNOT_JOIN"), "fece00");
				result = true;
			}
			else
			{
				this.SetVisibleWithAnimation(false, null);
				DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private int m_SelectedTab = -1;

		private XTeamDocument _TeamDoc;

		private XTeamInviteDocument _InviteDoc;

		private XGuildDocument _GuildDoc;

		public List<IXUITexture> _WrapTextureList = new List<IXUITexture>();

		private bool hasPlatFriends = false;
	}
}
