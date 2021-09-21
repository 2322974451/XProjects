using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001868 RID: 6248
	internal class XTeamInviteView : DlgBase<XTeamInviteView, XTeamInviteBehaviour>
	{
		// Token: 0x1700399F RID: 14751
		// (get) Token: 0x06010437 RID: 66615 RVA: 0x003EF084 File Offset: 0x003ED284
		public override string fileName
		{
			get
			{
				return "Team/TeamInviteDlg";
			}
		}

		// Token: 0x170039A0 RID: 14752
		// (get) Token: 0x06010438 RID: 66616 RVA: 0x003EF09C File Offset: 0x003ED29C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039A1 RID: 14753
		// (get) Token: 0x06010439 RID: 66617 RVA: 0x003EF0B0 File Offset: 0x003ED2B0
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039A2 RID: 14754
		// (get) Token: 0x0601043A RID: 66618 RVA: 0x003EF0C4 File Offset: 0x003ED2C4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601043B RID: 66619 RVA: 0x003EF0D7 File Offset: 0x003ED2D7
		protected override void Init()
		{
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._InviteDoc = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			this._InviteDoc.InviteHandler = this;
		}

		// Token: 0x0601043C RID: 66620 RVA: 0x003EF116 File Offset: 0x003ED316
		protected override void OnHide()
		{
			this.ClearPreTabTextures();
			this.hasPlatFriends = false;
			base.OnHide();
		}

		// Token: 0x0601043D RID: 66621 RVA: 0x003EF12E File Offset: 0x003ED32E
		protected override void OnUnload()
		{
			this._InviteDoc.InviteHandler = null;
			base.OnUnload();
		}

		// Token: 0x0601043E RID: 66622 RVA: 0x003EF144 File Offset: 0x003ED344
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

		// Token: 0x0601043F RID: 66623 RVA: 0x003EF27B File Offset: 0x003ED47B
		protected override void OnShow()
		{
			base.OnShow();
			this._TryRefresh();
		}

		// Token: 0x06010440 RID: 66624 RVA: 0x003EF28C File Offset: 0x003ED48C
		public override void StackRefresh()
		{
			this._TryRefresh();
		}

		// Token: 0x06010441 RID: 66625 RVA: 0x003EF298 File Offset: 0x003ED498
		private void _TryRefresh()
		{
			this._InviteDoc.ReqInviteList();
			bool flag = this.m_SelectedTab != -1;
			if (flag)
			{
				this.Refresh();
			}
		}

		// Token: 0x06010442 RID: 66626 RVA: 0x003EF2CC File Offset: 0x003ED4CC
		public void LocalServerRefresh()
		{
			bool flag = this.m_SelectedTab != 3;
			if (flag)
			{
				this.Refresh();
			}
		}

		// Token: 0x06010443 RID: 66627 RVA: 0x003EF2F4 File Offset: 0x003ED4F4
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

		// Token: 0x06010444 RID: 66628 RVA: 0x003EF4E4 File Offset: 0x003ED6E4
		private void _WrapContentItemInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnInviteClick));
		}

		// Token: 0x06010445 RID: 66629 RVA: 0x003EF520 File Offset: 0x003ED720
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

		// Token: 0x06010446 RID: 66630 RVA: 0x003EF9DC File Offset: 0x003EDBDC
		public void ClearPreTabTextures()
		{
			for (int i = 0; i < this._WrapTextureList.Count; i++)
			{
				this._WrapTextureList[i].SetTexturePath("");
			}
			this._WrapTextureList.Clear();
		}

		// Token: 0x06010447 RID: 66631 RVA: 0x003EFA29 File Offset: 0x003EDC29
		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		// Token: 0x06010448 RID: 66632 RVA: 0x003EFA35 File Offset: 0x003EDC35
		private void _OnCloseClicked(IXUISprite iSp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x06010449 RID: 66633 RVA: 0x003EFA44 File Offset: 0x003EDC44
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

		// Token: 0x0601044A RID: 66634 RVA: 0x003EFA7C File Offset: 0x003EDC7C
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

		// Token: 0x0601044B RID: 66635 RVA: 0x003EFB74 File Offset: 0x003EDD74
		private bool _OnAddFriendClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			return true;
		}

		// Token: 0x0601044C RID: 66636 RVA: 0x003EFB9C File Offset: 0x003EDD9C
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

		// Token: 0x040074F2 RID: 29938
		private int m_SelectedTab = -1;

		// Token: 0x040074F3 RID: 29939
		private XTeamDocument _TeamDoc;

		// Token: 0x040074F4 RID: 29940
		private XTeamInviteDocument _InviteDoc;

		// Token: 0x040074F5 RID: 29941
		private XGuildDocument _GuildDoc;

		// Token: 0x040074F6 RID: 29942
		public List<IXUITexture> _WrapTextureList = new List<IXUITexture>();

		// Token: 0x040074F7 RID: 29943
		private bool hasPlatFriends = false;
	}
}
