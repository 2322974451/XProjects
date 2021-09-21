using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200182A RID: 6186
	internal class XCharacterCommonMenuView : DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>
	{
		// Token: 0x17003927 RID: 14631
		// (get) Token: 0x060100F0 RID: 65776 RVA: 0x003D45D8 File Offset: 0x003D27D8
		public override string fileName
		{
			get
			{
				return "GameSystem/CharacterCommonMenu";
			}
		}

		// Token: 0x17003928 RID: 14632
		// (get) Token: 0x060100F1 RID: 65777 RVA: 0x003D45F0 File Offset: 0x003D27F0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003929 RID: 14633
		// (get) Token: 0x060100F2 RID: 65778 RVA: 0x003D4604 File Offset: 0x003D2804
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700392A RID: 14634
		// (get) Token: 0x060100F3 RID: 65779 RVA: 0x003D4618 File Offset: 0x003D2818
		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060100F4 RID: 65780 RVA: 0x003D462C File Offset: 0x003D282C
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XCharacterCommonMenuDocument>(XCharacterCommonMenuDocument.uuID);
			this._inviteGuildCD = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("InviteGuildPrivateCD"));
			this._canInviteGuild = true;
			this._pastTime = 0f;
		}

		// Token: 0x060100F5 RID: 65781 RVA: 0x003D467D File Offset: 0x003D287D
		protected override void OnUnload()
		{
			base.uiBehaviour.playerView = null;
			base.OnUnload();
		}

		// Token: 0x060100F6 RID: 65782 RVA: 0x003D4693 File Offset: 0x003D2893
		public void SetupMenuFilter(int filterValue)
		{
			this.charactorCommonMenuFilter = filterValue;
		}

		// Token: 0x060100F7 RID: 65783 RVA: 0x003D46A0 File Offset: 0x003D28A0
		public override void RegisterEvent()
		{
			base.Init();
			base.uiBehaviour.btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.btnSendFlower.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendFlower));
			base.uiBehaviour.btnExchange.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExchangeBtnClick));
		}

		// Token: 0x060100F8 RID: 65784 RVA: 0x003D470C File Offset: 0x003D290C
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.btnSendFlower.gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_FlowerRank));
			this.SetPlayerInfo();
			this.FillBtn();
		}

		// Token: 0x060100F9 RID: 65785 RVA: 0x003D4748 File Offset: 0x003D2948
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !this._canInviteGuild;
			if (flag)
			{
				this._pastTime += Time.deltaTime;
			}
			bool flag2 = this._pastTime >= (float)this._inviteGuildCD;
			if (flag2)
			{
				this._canInviteGuild = true;
				this._pastTime = 0f;
			}
		}

		// Token: 0x060100FA RID: 65786 RVA: 0x003D47A8 File Offset: 0x003D29A8
		public void ShowMenu(UnitAppearance unitInfo)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				bool flag2 = unitInfo == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("[CharacterCommonMenu] unitInfo is null", null, null, null, null, null, XDebugColor.XDebug_None);
				}
				else
				{
					this._roleID = unitInfo.uID;
					this._roleName = unitInfo.unitName;
					this._titleID = ((unitInfo.outlook != null && unitInfo.outlook.title != null) ? unitInfo.outlook.title.titleID : 0U);
					this._roleLevel = unitInfo.level;
					this._powerPoint = unitInfo.PowerPoint;
					this._profession = unitInfo.unitType;
					this._roleVipLevel = unitInfo.viplevel;
					this._dataLastLogin = unitInfo.lastlogin;
					this._guildName = ((unitInfo.outlook != null && unitInfo.outlook.guild != null) ? unitInfo.outlook.guild.name : "");
					this._guildID = ((unitInfo.outlook != null && unitInfo.outlook.guild != null) ? unitInfo.outlook.guild.id : 0UL);
					this._roleShortID = (ulong)unitInfo.nickid;
					this._setid = ((unitInfo.outlook != null && unitInfo.outlook.pre != null) ? unitInfo.outlook.pre.setid : new List<uint>());
					this._isMyFriend = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(this._roleID);
					this._bBlock = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(this._roleID);
					this._team.SetData(unitInfo.team);
					this._isHadPairPet = false;
					XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this._roleID);
					bool flag3 = entity != null && entity.Attributes.Outlook.state.type == OutLookStateType.OutLook_RidePet;
					if (flag3)
					{
						uint petType = XPetDocument.GetPetType(entity.Attributes.Outlook.state.param);
						this._isHadPairPet = (petType == 1U);
					}
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					this._inGuildSelf = specificDocument.bInGuild;
					this.SetVisibleWithAnimation(true, null);
				}
			}
		}

		// Token: 0x060100FB RID: 65787 RVA: 0x003D49D1 File Offset: 0x003D2BD1
		public void RefreshBtns()
		{
			this.FillBtn();
		}

		// Token: 0x060100FC RID: 65788 RVA: 0x003D49DB File Offset: 0x003D2BDB
		public void SetBlock()
		{
			this._bBlock = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(this._roleID);
		}

		// Token: 0x060100FD RID: 65789 RVA: 0x003D49F4 File Offset: 0x003D2BF4
		private void SetPlayerInfo()
		{
			base.uiBehaviour.playerView.uidLab.SetText(string.Format("UID:{0}", this._roleShortID));
			base.uiBehaviour.playerView.lbName.InputText = XSingleton<XCommon>.singleton.StringCombine(XTitleDocument.GetTitleWithFormat(this._titleID, this._roleName), XRechargeDocument.GetVIPIconString(this._roleVipLevel));
			base.uiBehaviour.playerView.lbPPT.SetText(this._powerPoint.ToString());
			base.uiBehaviour.playerView.sprHead.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)this._profession));
			base.uiBehaviour.playerView.SetGuildName(this._guildName);
			base.uiBehaviour.playerView.lbLevel.SetText(this._roleLevel.ToString());
			XSingleton<UiUtility>.singleton.ParseHeadIcon(this._setid, base.uiBehaviour.m_sprFrame);
			this.UpdateOnlineState(base.uiBehaviour.playerView.lbName.gameObject.transform.parent, this._dataLastLogin);
			int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_FlowerRank));
			base.uiBehaviour.btnSendFlower.gameObject.SetActive((ulong)this._roleLevel >= (ulong)((long)sysOpenLevel));
			base.uiBehaviour.btnExchange.ID = this._roleID;
			XGuildCollectDocument specificDocument = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
			base.uiBehaviour.btnExchange.SetVisible(XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_HALL && specificDocument.ActivityState);
		}

		// Token: 0x060100FE RID: 65790 RVA: 0x003D4BB0 File Offset: 0x003D2DB0
		private void FillBtn()
		{
			base.uiBehaviour.m_btntemPool.ReturnAll(true);
			bool flag = XCharacterCommonMenuDocument.CharacterCommonInfoTable == null;
			if (!flag)
			{
				int num = 0;
				List<int> list = null;
				bool flag2 = this.charactorCommonMenuFilter > 0;
				if (flag2)
				{
					string key = XSingleton<XCommon>.singleton.StringCombine("CharacterCommonMenuFilter", this.charactorCommonMenuFilter.ToString());
					list = XSingleton<XGlobalConfig>.singleton.GetIntList(key);
				}
				bool flag3 = list != null && list.Count > 0;
				for (int i = 0; i < XCharacterCommonMenuDocument.CharacterCommonInfoTable.Table.Length; i++)
				{
					CharacterCommonInfo.RowData rowData = XCharacterCommonMenuDocument.CharacterCommonInfoTable.Table[i];
					bool flag4 = rowData == null;
					if (!flag4)
					{
						bool flag5 = flag3 && list.Contains((int)rowData.Type);
						if (!flag5)
						{
							bool flag6 = !this.IsShow(rowData.Type);
							if (!flag6)
							{
								GameObject gameObject = base.uiBehaviour.m_btntemPool.FetchGameObject(false);
								gameObject.transform.parent = this.m_uiBehaviour.m_parentTra;
								gameObject.transform.localScale = Vector3.one;
								gameObject.transform.localPosition = new Vector3((float)(base.uiBehaviour.m_btntemPool.TplWidth * (num % 2)), (float)(-(float)base.uiBehaviour.m_btntemPool.TplHeight * (num / 2)), 0f);
								IXUIButton ixuibutton = gameObject.GetComponent("XUIButton") as IXUIButton;
								ixuibutton.ID = (ulong)rowData.Type;
								ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickBtn));
								IXUILabel ixuilabel = gameObject.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
								ixuilabel.SetText(rowData.ShowText);
								num++;
							}
						}
					}
				}
				bool flag7 = num < 9;
				if (flag7)
				{
					int num2 = (num % 2 == 0) ? (num / 2) : (num / 2 + 1);
					base.uiBehaviour.m_bgSpr.spriteHeight = base.uiBehaviour.TotalHeight - (5 - num2) * base.uiBehaviour.m_btntemPool.TplHeight;
					base.uiBehaviour.m_bgTra.localPosition = new Vector3(0f, (float)(-(float)(5 - num2) * base.uiBehaviour.m_btntemPool.TplHeight / 2), 0f);
				}
				else
				{
					base.uiBehaviour.m_bgSpr.spriteHeight = base.uiBehaviour.TotalHeight;
					base.uiBehaviour.m_bgTra.localPosition = Vector3.zero;
				}
				this.charactorCommonMenuFilter = 0;
			}
		}

		// Token: 0x060100FF RID: 65791 RVA: 0x003D4E64 File Offset: 0x003D3064
		public bool IsShow(uint type)
		{
			switch (type)
			{
			case 2U:
				return this._isMyFriend;
			case 3U:
				return !this._isMyFriend;
			case 5U:
				return this._team.bHasTeam;
			case 6U:
				return !this._team.bHasTeam;
			case 7U:
				return this._inGuildSelf;
			case 8U:
				return !this._inGuildSelf;
			case 9U:
				return !this._bBlock;
			case 10U:
				return this._bBlock;
			case 12U:
				return XMentorshipDocument.Doc.ClickedRoleMentorshipStatus == MentorApplyStatus.MentorApplyMaster;
			case 13U:
				return XMentorshipDocument.Doc.ClickedRoleMentorshipStatus == MentorApplyStatus.MentorApplyStudent;
			case 14U:
				return XCharacterCommonMenuDocument.IsHasRole && this._isHadPairPet;
			case 15U:
			{
				XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
				return XCharacterCommonMenuDocument.IsHasRole && !this._isHadPairPet && specificDocument.IsDrivingPairPet;
			}
			}
			return true;
		}

		// Token: 0x06010100 RID: 65792 RVA: 0x003D4F84 File Offset: 0x003D3184
		private void UpdateOnlineState(Transform trans, uint lastlogin)
		{
			GameObject gameObject = trans.Find("Online").gameObject;
			gameObject.SetActive(lastlogin == 0U);
			IXUILabel ixuilabel = trans.Find("Offline").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Empty);
		}

		// Token: 0x06010101 RID: 65793 RVA: 0x003D4FD8 File Offset: 0x003D31D8
		private bool OnClose(IXUIButton sprClose)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010102 RID: 65794 RVA: 0x003D4FF4 File Offset: 0x003D31F4
		private bool OnSendFlower(IXUIButton go)
		{
			DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowBoard(this._roleID, this._roleName);
			return true;
		}

		// Token: 0x06010103 RID: 65795 RVA: 0x003D5020 File Offset: 0x003D3220
		private bool OnExchangeBtnClick(IXUIButton btn)
		{
			RpcC2G_GuildCampPartyReqExchange rpcC2G_GuildCampPartyReqExchange = new RpcC2G_GuildCampPartyReqExchange();
			rpcC2G_GuildCampPartyReqExchange.oArg.role_id = btn.ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GuildCampPartyReqExchange);
			return true;
		}

		// Token: 0x06010104 RID: 65796 RVA: 0x003D5058 File Offset: 0x003D3258
		private bool OnClickBtn(IXUIButton button)
		{
			ulong id = button.ID;
			ulong num = id;
			ulong num2 = num - 1UL;
			if (num2 <= 15UL)
			{
				switch ((uint)num2)
				{
				case 0U:
					this.OnClickView(button);
					break;
				case 1U:
				case 2U:
					this.OnDeleteFriendClicked();
					break;
				case 3U:
					this.OnChatClicked();
					break;
				case 4U:
				case 5U:
					this.OnClickTeamChat();
					break;
				case 6U:
				case 7U:
					this.OnGuildClicked();
					break;
				case 8U:
				case 9U:
					this.OnClickBlackList(button);
					break;
				case 10U:
					this.OnPKBtnClicked();
					break;
				case 11U:
				case 12U:
					this.OnBSBtnClicked();
					break;
				case 13U:
				case 14U:
					this.OnInvite();
					break;
				case 15U:
					this.OnTransform();
					break;
				}
			}
			return true;
		}

		// Token: 0x06010105 RID: 65797 RVA: 0x003D5128 File Offset: 0x003D3328
		private bool OnClickView(IXUIButton btn)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(this._roleID, this._roleName, this._setid, this._powerPoint, this._profession);
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowDetailInfo(btn);
		}

		// Token: 0x06010106 RID: 65798 RVA: 0x003D517C File Offset: 0x003D337C
		private bool OnDeleteFriendClicked()
		{
			bool flag = XPartnerDocument.Doc.IsMyPartner(this._roleID);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NeedCanclePartner"), "fece00");
				result = true;
			}
			else
			{
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends);
				if (flag2)
				{
					int sysid = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Friends);
					int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(sysid);
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
					{
						sysOpenLevel
					}) + XSingleton<XGameSysMgr>.singleton.GetSysName(sysid), "fece00");
					result = true;
				}
				else
				{
					bool isMyFriend = this._isMyFriend;
					if (isMyFriend)
					{
						XFriendsView singleton = DlgBase<XFriendsView, XFriendsBehaviour>.singleton;
						singleton.OnRemoveFriendSucc = (Action)Delegate.Combine(singleton.OnRemoveFriendSucc, new Action(this.RemoveFriendSucc));
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveFriend(this._roleID);
					}
					else
					{
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(this._roleID);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06010107 RID: 65799 RVA: 0x003D5288 File Offset: 0x003D3488
		private bool OnChatClicked()
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends);
			bool result;
			if (flag)
			{
				int sysid = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Friends);
				int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(sysid);
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
				{
					sysOpenLevel
				}) + XSingleton<XGameSysMgr>.singleton.GetSysName(sysid), "fece00");
				result = true;
			}
			else
			{
				DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>.singleton.SetVisible(false, true);
				this.SetVisibleWithAnimation(false, null);
				bool bBlock = this._bBlock;
				if (bBlock)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_BLOCK_HINT_TEXT"), "fece00");
				}
				else
				{
					DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(this._roleID, this._roleName, this._setid, this._powerPoint, this._profession);
					DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.PrivateChat(null);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06010108 RID: 65800 RVA: 0x003D5378 File Offset: 0x003D3578
		private bool OnClickTeamChat()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_FAMILYGARDEN;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CurSceneCanNotCtrl"), "fece00");
				result = true;
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Team);
				if (flag2)
				{
					int sysid = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Team);
					int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(sysid);
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
					{
						sysOpenLevel
					}) + XSingleton<XGameSysMgr>.singleton.GetSysName(sysid), "fece00");
					result = true;
				}
				else
				{
					XCharacterCommonMenuDocument specificDocument2 = XDocuments.GetSpecificDocument<XCharacterCommonMenuDocument>(XCharacterCommonMenuDocument.uuID);
					bool flag3 = !this._team.bHasTeam;
					if (flag3)
					{
						specificDocument2.TryInviteTeam(this._roleID);
					}
					else
					{
						specificDocument2.TryJoinTeam(this._team);
					}
					DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>.singleton.SetVisible(false, true);
					this.SetVisibleWithAnimation(false, null);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06010109 RID: 65801 RVA: 0x003D548C File Offset: 0x003D368C
		private bool OnGuildClicked()
		{
			bool inGuildSelf = this._inGuildSelf;
			if (inGuildSelf)
			{
				bool canInviteGuild = this._canInviteGuild;
				if (canInviteGuild)
				{
					bool bBlock = this._bBlock;
					if (bBlock)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RRIENDS_INVITE_GUILD_ERROR2"), "fece00");
					}
					else
					{
						XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
						bool flag = specificDocument.BasicData.uid == this._guildID;
						if (flag)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_SAME_IN"), "fece00");
							return true;
						}
						DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId = this._roleID;
						ChatInfo chatInfo = new ChatInfo();
						chatInfo.mTime = DateTime.Now;
						chatInfo.isSelfSender = true;
						chatInfo.mReceiverName = this._roleName;
						chatInfo.mReceiverId = this._roleID;
						chatInfo.mReciverPowerPoint = this._powerPoint;
						chatInfo.mRecieverProfession = this._profession;
						chatInfo.mReceiverVip = this._roleVipLevel;
						XChatDocument specificDocument2 = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
						specificDocument2.AddChatinfo2FriendList(chatInfo);
						XInvitationDocument specificDocument3 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
						specificDocument3.SendGuildInvitationPrivate();
						this._canInviteGuild = false;
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RRIENDS_INVITE_GUILD_ERROR"), "fece00");
				}
			}
			else
			{
				bool flag2 = this._guildID == 0UL;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_JOIN_GUILD"), "fece00");
				}
				else
				{
					XGuildViewDocument specificDocument4 = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
					specificDocument4.View(this._guildID);
					DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>.singleton.SetVisible(false, true);
					this.SetVisibleWithAnimation(false, null);
				}
			}
			return true;
		}

		// Token: 0x0601010A RID: 65802 RVA: 0x003D5654 File Offset: 0x003D3854
		private bool OnClickBlackList(IXUIButton btn)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends);
			bool result;
			if (flag)
			{
				int sysid = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Friends);
				int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(sysid);
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
				{
					sysOpenLevel
				}) + XSingleton<XGameSysMgr>.singleton.GetSysName(sysid), "fece00");
				result = true;
			}
			else
			{
				this.OnHide();
				bool bBlock = this._bBlock;
				if (bBlock)
				{
					ulong id = btn.ID;
					btn.ID = this._roleID;
					bool flag2 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnRemoveBlockFriend(btn);
					btn.ID = id;
					result = flag2;
				}
				else
				{
					XFriendsView singleton = DlgBase<XFriendsView, XFriendsBehaviour>.singleton;
					singleton.OnAddBlockSucc = (Action)Delegate.Combine(singleton.OnAddBlockSucc, new Action(this.AddBlockSucc));
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddBlockFriend(this._roleID);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0601010B RID: 65803 RVA: 0x003D574C File Offset: 0x003D394C
		private bool OnPKBtnClicked()
		{
			int sysid = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_PK);
			int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(sysid);
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PK);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
				{
					sysOpenLevel
				}) + XSingleton<XGameSysMgr>.singleton.GetSysName(sysid), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = (ulong)this._roleLevel < (ulong)((long)sysOpenLevel);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PLAYER_SYS_NOT_OPEN"), "fece00");
					result = false;
				}
				else
				{
					XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
					specificDocument.SendPKInvitation(this._roleID);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0601010C RID: 65804 RVA: 0x003D5810 File Offset: 0x003D3A10
		private bool OnBSBtnClicked()
		{
			XMentorshipDocument.Doc.ClickedMainSceneRoleID = this._roleID;
			bool flag = XMentorshipDocument.Doc.ClickedRoleMentorshipStatus == MentorApplyStatus.MentorApplyMaster;
			if (flag)
			{
				XMentorshipDocument.Doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_ApplyMaster, XMentorshipDocument.Doc.ClickedMainSceneRoleID, 0);
			}
			else
			{
				bool flag2 = XMentorshipDocument.Doc.ClickedRoleMentorshipStatus == MentorApplyStatus.MentorApplyStudent;
				if (flag2)
				{
					XMentorshipDocument.Doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_ApplyStudent, XMentorshipDocument.Doc.ClickedMainSceneRoleID, 0);
				}
			}
			return true;
		}

		// Token: 0x0601010D RID: 65805 RVA: 0x003D5888 File Offset: 0x003D3A88
		private bool OnInvite()
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			bool isHadPairPet = this._isHadPairPet;
			if (isHadPairPet)
			{
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Horse);
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_PETSYS_NOT_OPEN"), "fece00");
					return false;
				}
				specificDocument.ReqPetPetOperationOther(PetOtherOp.DoPetPairRide, this._roleID);
			}
			else
			{
				bool isDrivingPairPet = specificDocument.IsDrivingPairPet;
				if (isDrivingPairPet)
				{
					specificDocument.ReqPetPetOperationOther(PetOtherOp.InvitePetPairRide, this._roleID);
				}
			}
			return true;
		}

		// Token: 0x0601010E RID: 65806 RVA: 0x003D5910 File Offset: 0x003D3B10
		private bool OnTransform()
		{
			XTransformDocument specificDocument = XDocuments.GetSpecificDocument<XTransformDocument>(XTransformDocument.uuID);
			specificDocument.TryTransformOther(this._roleName, this._roleID);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0601010F RID: 65807 RVA: 0x003D594A File Offset: 0x003D3B4A
		private void AddBlockSucc()
		{
			XFriendsView singleton = DlgBase<XFriendsView, XFriendsBehaviour>.singleton;
			singleton.OnAddBlockSucc = (Action)Delegate.Remove(singleton.OnAddBlockSucc, new Action(this.AddBlockSucc));
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x06010110 RID: 65808 RVA: 0x003D597C File Offset: 0x003D3B7C
		private void RemoveFriendSucc()
		{
			XFriendsView singleton = DlgBase<XFriendsView, XFriendsBehaviour>.singleton;
			singleton.OnRemoveFriendSucc = (Action)Delegate.Remove(singleton.OnRemoveFriendSucc, new Action(this.RemoveFriendSucc));
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x0400727D RID: 29309
		private ulong _roleShortID;

		// Token: 0x0400727E RID: 29310
		private ulong _roleID;

		// Token: 0x0400727F RID: 29311
		private string _roleName;

		// Token: 0x04007280 RID: 29312
		private uint _titleID;

		// Token: 0x04007281 RID: 29313
		private uint _roleLevel;

		// Token: 0x04007282 RID: 29314
		private uint _roleVipLevel;

		// Token: 0x04007283 RID: 29315
		private uint _powerPoint;

		// Token: 0x04007284 RID: 29316
		private uint _profession;

		// Token: 0x04007285 RID: 29317
		private string _guildName;

		// Token: 0x04007286 RID: 29318
		private bool _isMyFriend;

		// Token: 0x04007287 RID: 29319
		private bool _bBlock;

		// Token: 0x04007288 RID: 29320
		private uint _dataLastLogin;

		// Token: 0x04007289 RID: 29321
		private ulong _guildID;

		// Token: 0x0400728A RID: 29322
		private XUnitAppearanceTeam _team = default(XUnitAppearanceTeam);

		// Token: 0x0400728B RID: 29323
		private int charactorCommonMenuFilter = 0;

		// Token: 0x0400728C RID: 29324
		private bool _inGuildSelf;

		// Token: 0x0400728D RID: 29325
		private int _inviteGuildCD;

		// Token: 0x0400728E RID: 29326
		private float _pastTime;

		// Token: 0x0400728F RID: 29327
		private bool _canInviteGuild;

		// Token: 0x04007290 RID: 29328
		private bool _isHadPairPet;

		// Token: 0x04007291 RID: 29329
		private List<uint> _setid = new List<uint>();

		// Token: 0x04007292 RID: 29330
		private XCharacterCommonMenuDocument m_doc;
	}
}
