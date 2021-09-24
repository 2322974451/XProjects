using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XCharacterCommonMenuView : DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/CharacterCommonMenu";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XCharacterCommonMenuDocument>(XCharacterCommonMenuDocument.uuID);
			this._inviteGuildCD = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("InviteGuildPrivateCD"));
			this._canInviteGuild = true;
			this._pastTime = 0f;
		}

		protected override void OnUnload()
		{
			base.uiBehaviour.playerView = null;
			base.OnUnload();
		}

		public void SetupMenuFilter(int filterValue)
		{
			this.charactorCommonMenuFilter = filterValue;
		}

		public override void RegisterEvent()
		{
			base.Init();
			base.uiBehaviour.btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.btnSendFlower.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendFlower));
			base.uiBehaviour.btnExchange.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExchangeBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.btnSendFlower.gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_FlowerRank));
			this.SetPlayerInfo();
			this.FillBtn();
		}

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

		public void RefreshBtns()
		{
			this.FillBtn();
		}

		public void SetBlock()
		{
			this._bBlock = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(this._roleID);
		}

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

		private void UpdateOnlineState(Transform trans, uint lastlogin)
		{
			GameObject gameObject = trans.Find("Online").gameObject;
			gameObject.SetActive(lastlogin == 0U);
			IXUILabel ixuilabel = trans.Find("Offline").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Empty);
		}

		private bool OnClose(IXUIButton sprClose)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnSendFlower(IXUIButton go)
		{
			DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowBoard(this._roleID, this._roleName);
			return true;
		}

		private bool OnExchangeBtnClick(IXUIButton btn)
		{
			RpcC2G_GuildCampPartyReqExchange rpcC2G_GuildCampPartyReqExchange = new RpcC2G_GuildCampPartyReqExchange();
			rpcC2G_GuildCampPartyReqExchange.oArg.role_id = btn.ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GuildCampPartyReqExchange);
			return true;
		}

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

		private bool OnClickView(IXUIButton btn)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(this._roleID, this._roleName, this._setid, this._powerPoint, this._profession);
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowDetailInfo(btn);
		}

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

		private bool OnTransform()
		{
			XTransformDocument specificDocument = XDocuments.GetSpecificDocument<XTransformDocument>(XTransformDocument.uuID);
			specificDocument.TryTransformOther(this._roleName, this._roleID);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private void AddBlockSucc()
		{
			XFriendsView singleton = DlgBase<XFriendsView, XFriendsBehaviour>.singleton;
			singleton.OnAddBlockSucc = (Action)Delegate.Remove(singleton.OnAddBlockSucc, new Action(this.AddBlockSucc));
			this.SetVisibleWithAnimation(false, null);
		}

		private void RemoveFriendSucc()
		{
			XFriendsView singleton = DlgBase<XFriendsView, XFriendsBehaviour>.singleton;
			singleton.OnRemoveFriendSucc = (Action)Delegate.Remove(singleton.OnRemoveFriendSucc, new Action(this.RemoveFriendSucc));
			this.SetVisibleWithAnimation(false, null);
		}

		private ulong _roleShortID;

		private ulong _roleID;

		private string _roleName;

		private uint _titleID;

		private uint _roleLevel;

		private uint _roleVipLevel;

		private uint _powerPoint;

		private uint _profession;

		private string _guildName;

		private bool _isMyFriend;

		private bool _bBlock;

		private uint _dataLastLogin;

		private ulong _guildID;

		private XUnitAppearanceTeam _team = default(XUnitAppearanceTeam);

		private int charactorCommonMenuFilter = 0;

		private bool _inGuildSelf;

		private int _inviteGuildCD;

		private float _pastTime;

		private bool _canInviteGuild;

		private bool _isHadPairPet;

		private List<uint> _setid = new List<uint>();

		private XCharacterCommonMenuDocument m_doc;
	}
}
