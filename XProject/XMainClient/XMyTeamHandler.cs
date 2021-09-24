using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMyTeamHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_BtnStart = (base.PanelObject.transform.FindChild("BtnStart").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnBroadcast = (base.PanelObject.transform.FindChild("BtnBroadcast").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnMatchMembers = (base.PanelObject.transform.FindChild("BtnMatchMembers").GetComponent("XUIButton") as IXUIButton);
			this.m_StartHighlight = this.m_BtnStart.gameObject.transform.FindChild("Highlight").gameObject;
			this.m_BtnSetting = (base.PanelObject.transform.Find("BtnTeamSetting").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnLeave = (base.PanelObject.transform.Find("BtnLeave").GetComponent("XUISprite") as IXUISprite);
			this.m_PosLeave = this.m_BtnLeave.gameObject.transform.localPosition;
			this.m_PosStart = this.m_BtnStart.gameObject.transform.localPosition;
			Transform transform = base.PanelObject.transform.FindChild("Panel/MemberTpl4");
			this.m_MemberPoolSmall.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.FindChild("Panel/MemberTpl6");
			this.m_MemberPoolLarge.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_MatchMembersIdleLabel = (this.m_BtnMatchMembers.gameObject.transform.FindChild("IdleLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_MatchMembersMatchingLabel = (this.m_BtnMatchMembers.gameObject.transform.FindChild("MatchingLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_StartLabel = (this.m_BtnStart.gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnAddCount = (base.PanelObject.transform.Find("BtnAddCount").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnHelper = (base.PanelObject.transform.Find("BtnHelper").GetComponent("XUISprite") as IXUISprite);
			this.m_HelperSelected = (base.PanelObject.transform.Find("BtnHelper/Selected").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnTicket = (base.PanelObject.transform.Find("BtnTicket").GetComponent("XUISprite") as IXUISprite);
			this.m_TicketSelected = (base.PanelObject.transform.Find("BtnTicket/Selected").GetComponent("XUISprite") as IXUISprite);
			this.m_PPTRequirementTotal = base.PanelObject.transform.Find("BattlePoint").gameObject;
			this.m_PPTRequirement = (this.m_PPTRequirementTotal.gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel);
			this.m_GoldGroup = base.PanelObject.transform.Find("RewardHunt").gameObject;
			this.m_GoldGroupDescri = this.m_GoldGroup.transform.Find("Description").gameObject;
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.doc.MyTeamView = this;
			this.expDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this.capDoc = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
			this.heroDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this.preDoc = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			this.dragonDoc = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
			DlgHandlerBase.EnsureCreate<XTeamBonusHandler>(ref this.m_BonusHandler, base.PanelObject.transform.Find("GuildBonusFrame").gameObject, null, true);
			DlgHandlerBase.EnsureCreate<XTeamPartnerBonusHandler>(ref this.m_FriendBonusHandler, base.PanelObject.transform.Find("FriendBonusFrame").gameObject, this, true);
			DlgHandlerBase.EnsureCreate<XTeamPasswordHandler>(ref this.m_PasswordHandler, base.PanelObject.transform.Find("PasswordFrame").gameObject, this, false);
			DlgHandlerBase.EnsureCreate<XTeamSettingHandler>(ref this.m_SettingHandler, base.PanelObject.transform, false, this);
			this.m_FriendBonusHandler.bConsiderTeam = true;
			base.Alloc3DAvatarPool("XMyTeamHandler", 1);
			this.m_DicFriendDegree.Clear();
			this.m_MilitaryIconTypes.Clear();
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("TeamMilitaryIconTypes");
			this.m_MilitaryIconTypes.UnionWith(intList);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnStart.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnStartBtnClick));
			this.m_BtnBroadcast.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnBroadcastBtnClick));
			this.m_BtnMatchMembers.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnMatchMembersBtnClick));
			this.m_BtnLeave.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberLeaveClick));
			this.m_BtnAddCount.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnAddCountClicked));
			this.m_BtnHelper.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnHelperClicked));
			this.m_BtnSetting.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSettingBtnClicked));
			this.m_BtnTicket.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnTicketClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("XMyTeamHandler", 4);
			this.RefreshPage();
			this.ShowChat(true);
			this.m_bDirty = false;
		}

		protected override void OnHide()
		{
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			base.Return3DAvatarPool();
			this._ClearAvatarStates();
			this._ClearChatTimer();
			this._ClearPreEffect();
			this._ResetUIDummyCallback();
			this.ShowChat(false);
			base.OnHide();
		}

		private void ShowChat(bool show)
		{
			ShowSettingArgs showSettingArgs = new ShowSettingArgs();
			if (show)
			{
				showSettingArgs.position = 1;
				showSettingArgs.needforceshow = true;
				showSettingArgs.forceshow = true;
				showSettingArgs.needdepth = true;
				showSettingArgs.depth = 4;
			}
			else
			{
				showSettingArgs.position = 0;
				showSettingArgs.needforceshow = true;
				showSettingArgs.forceshow = false;
				showSettingArgs.needdepth = true;
				showSettingArgs.depth = 0;
				showSettingArgs.anim = false;
			}
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatMiniUI(showSettingArgs);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("XMyTeamHandler", 4);
			this.RefreshPage();
			this.ShowChat(true);
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetForceShow(true);
		}

		public override void LeaveStackTop()
		{
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetForceShow(false);
			this.ShowChat(false);
			this._ResetUIDummyCallback();
			base.LeaveStackTop();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XTeamBonusHandler>(ref this.m_BonusHandler);
			DlgHandlerBase.EnsureUnload<XTeamPartnerBonusHandler>(ref this.m_FriendBonusHandler);
			DlgHandlerBase.EnsureUnload<XTeamSettingHandler>(ref this.m_SettingHandler);
			DlgHandlerBase.EnsureUnload<XTeamPasswordHandler>(ref this.m_PasswordHandler);
			this._ClearChatTimer();
			this._ClearPreEffect();
			this.doc.MyTeamView = null;
			this.m_DicFriendDegree.Clear();
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetForceShow(false);
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool bDirty = this.m_bDirty;
			if (bDirty)
			{
				this.RefreshPage();
				this.m_bDirty = false;
			}
		}

		private void _ClearChatTimer()
		{
			foreach (uint token in this.m_ChatTimerToken.Values)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
			}
			this.m_ChatTimerToken.Clear();
		}

		private void _CloseChatTimer(ulong uid)
		{
			uint token = 0U;
			bool flag = this.m_ChatTimerToken.TryGetValue(uid, out token);
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
				this.m_ChatTimerToken.Remove(uid);
			}
		}

		private void _ClearAvatarStates()
		{
			for (int i = 0; i < XMyTeamHandler.SMALL_TEAM_CAPACITY; i++)
			{
				bool flag = this.m_Avatars[i] == null;
				if (!flag)
				{
					this.m_Avatars[i] = null;
				}
			}
		}

		private void _RefreshAvatarStates()
		{
		}

		private void CheckTicketStates(bool userTicket = false)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID((int)this.doc.currentDungeonID);
			bool flag = expeditionDataByID != null;
			if (flag)
			{
				uint num = expeditionDataByID.UseTicket[0];
				uint num2 = expeditionDataByID.UseTicket[1];
				bool flag2 = num > 0U;
				if (flag2)
				{
					XLevelSealDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					uint sealType = specificDocument2.SealType;
					bool flag3 = num2 <= sealType;
					if (flag3)
					{
						this.m_BtnTicket.SetAlpha(1f);
						this.m_TicketSelected.SetAlpha(userTicket ? 1f : 0f);
						return;
					}
				}
			}
			this.m_BtnTicket.SetAlpha(0f);
			this.m_TicketSelected.SetAlpha(0f);
		}

		public void RefreshPage()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool bInTeam = this.doc.bInTeam;
				if (bInTeam)
				{
					int count = this.doc.MyTeam.members.Count;
					int playerNumber = this.doc.currentExpInfo.PlayerNumber;
					bool bIsLeader = this.doc.bIsLeader;
					this.m_BtnStart.SetVisible(bIsLeader);
					this.m_BtnMatchMembers.SetVisible(bIsLeader);
					this.m_BtnBroadcast.SetVisible(bIsLeader);
					this.m_BtnSetting.SetVisible(bIsLeader && this.doc.currentExpInfo.CostType.Count != 0);
					this.m_BtnLeave.gameObject.transform.localPosition = (bIsLeader ? this.m_PosLeave : this.m_PosStart);
					this.m_BtnHelper.SetAlpha((this.doc.currentExpInfo.CanHelp == 0 || bIsLeader) ? 0f : 1f);
					this.m_HelperSelected.SetAlpha(this.doc.bIsHelper ? 1f : 0f);
					this.m_PPTRequirementTotal.SetActive(this.doc.MyTeam.teamBrief.teamPPT > 0U);
					this.m_PPTRequirement.SetText(this.doc.MyTeam.teamBrief.GetStrTeamPPT(double.MaxValue));
					this.doc.MyTeam.teamBrief.goldGroup.SetUI(this.m_GoldGroup, true);
					this.m_GoldGroupDescri.SetActive(!bIsLeader);
					this.RefreshButtonStates();
					this.CheckTicketStates(this.doc.bIsTecket);
					bool flag2 = !this.m_bDirty;
					if (flag2)
					{
						XSingleton<X3DAvatarMgr>.singleton.ClearDummy(this.m_dummPool);
						this._ClearAvatarStates();
					}
					bool flag3 = this.doc.currentExpInfo != null && !this.doc.currentExpInfo.ShowPPT;
					bool flag4 = !flag3;
					if (flag4)
					{
						this.m_BonusHandler.SetVisible(true);
						this.m_FriendBonusHandler.SetVisible(true);
						this.m_BonusHandler.Refresh();
						this.m_FriendBonusHandler.RefreshData();
					}
					else
					{
						this.m_BonusHandler.SetVisible(false);
						this.m_FriendBonusHandler.SetVisible(false);
					}
					this.m_PasswordHandler.RefreshState();
					bool flag5 = this.doc.currentExpInfo == null || this.doc.currentExpInfo.PlayerNumber <= XMyTeamHandler.SMALL_TEAM_CAPACITY;
					this.m_MemberPoolSmall.FakeReturnAll();
					this.m_MemberPoolLarge.FakeReturnAll();
					int num = Math.Max(playerNumber, flag5 ? XMyTeamHandler.SMALL_TEAM_CAPACITY : XMyTeamHandler.LARGE_TEAM_CAPACITY);
					this.m_MemberCount = num;
					Vector3 vector = flag5 ? this.m_MemberPoolSmall.TplPos : this.m_MemberPoolLarge.TplPos;
					this._ClearUIDummy();
					this._ClearPreEffect();
					for (int i = 0; i < num; i++)
					{
						bool flag6 = flag5;
						GameObject gameObject;
						if (flag6)
						{
							gameObject = this.m_MemberPoolSmall.FetchGameObject(false);
							gameObject.transform.localPosition = new Vector3(vector.x + (float)(i * this.m_MemberPoolSmall.TplWidth), vector.y, vector.z);
						}
						else
						{
							gameObject = this.m_MemberPoolLarge.FetchGameObject(false);
							gameObject.transform.localPosition = new Vector3(vector.x + (float)(i % 4 * this.m_MemberPoolLarge.TplWidth), vector.y - (float)(i / 4 * this.m_MemberPoolLarge.TplHeight), vector.z);
						}
						bool flag7 = i < count;
						if (flag7)
						{
							this._SetMember(gameObject, this.doc.MyTeam.members[i], true, i, flag5);
						}
						else
						{
							bool flag8 = i < playerNumber;
							if (flag8)
							{
								this._SetMember(gameObject, null, true, i, flag5);
							}
							else
							{
								this._SetMember(gameObject, null, false, i, flag5);
							}
						}
					}
					this.m_MemberPoolSmall.ActualReturnAll(false);
					this.m_MemberPoolLarge.ActualReturnAll(false);
				}
				else
				{
					DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
				}
			}
		}

		private void _TryCreateFriendDegreeHandler(GameObject go)
		{
			XTeamFriendDegreeHandler value;
			bool flag = this.m_DicFriendDegree.TryGetValue(go, out value);
			if (!flag)
			{
				DlgHandlerBase.EnsureCreate<XTeamFriendDegreeHandler>(ref value, go.transform.FindChild("Info/FriendDegreeFrame").gameObject, null, true);
				this.m_DicFriendDegree.Add(go, value);
			}
		}

		public void HideChatUI(object obj)
		{
			IXUISprite ixuisprite = obj as IXUISprite;
			ixuisprite.SetVisible(false);
			ixuisprite.ID = 0UL;
		}

		private void _ClearUIDummy()
		{
			for (int i = 0; i < this.m_UIDummys.Length; i++)
			{
				bool flag = this.m_UIDummys[i] != null;
				if (flag)
				{
					this.m_UIDummys[i].RefreshRenderQueue = null;
					this.m_UIDummys[i] = null;
				}
			}
		}

		private void _ClearPreEffect()
		{
			bool flag = this.m_preEffects != null;
			if (flag)
			{
				int i = 0;
				int count = this.m_preEffects.Count;
				while (i < count)
				{
					bool flag2 = this.m_preEffects[i] != null;
					if (flag2)
					{
						XSingleton<XFxMgr>.singleton.DestroyFx(this.m_preEffects[i], true);
					}
					i++;
				}
				this.m_preEffects.Clear();
			}
		}

		private void _ResetUIDummyCallback()
		{
			for (int i = 0; i < this.m_UIDummys.Length; i++)
			{
				bool flag = this.m_UIDummys[i] != null;
				if (!flag)
				{
					break;
				}
				this.m_UIDummys[i].RefreshRenderQueue = null;
			}
		}

		private void _SetMember(GameObject go, XTeamMember data, bool bActive, int index, bool bSmallMember)
		{
			GameObject gameObject = go.transform.FindChild("Info").gameObject;
			GameObject gameObject2 = go.transform.FindChild("OpMenu").gameObject;
			IXUILabel ixuilabel = go.transform.FindChild("Lock").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject3 = go.transform.Find("BgSmall").gameObject;
			IXUIButton ixuibutton = go.transform.FindChild("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			Transform transform = go.transform.Find("Loading");
			IXUISprite ixuisprite = go.transform.Find("Bg_GoldGroup").GetComponent("XUISprite") as IXUISprite;
			gameObject.SetActive(data != null && bActive);
			gameObject2.SetActive(data != null && bActive);
			gameObject3.SetActive(bActive);
			ixuibutton.SetVisible(data == null && bActive);
			bool flag = ixuibutton.IsVisible();
			if (flag)
			{
				GameObject gameObject4 = ixuibutton.gameObject.transform.Find("LetsMakeFriends").gameObject;
				bool flag2 = this.doc.currentDungeonType == TeamLevelType.TeamLevelWedding || this.doc.currentDungeonType == TeamLevelType.TeamLevelWeddingLicense;
				if (flag2)
				{
					gameObject4.SetActive(false);
				}
				else
				{
					gameObject4.SetActive(this.doc.MyTeam.members.Count == index);
				}
			}
			bool flag3 = transform != null;
			if (flag3)
			{
				transform.gameObject.SetActive(data != null && bActive);
			}
			if (bActive)
			{
				ixuilabel.SetVisible(false);
			}
			else
			{
				ixuilabel.SetVisible(true);
				ixuilabel.SetText(XStringDefineProxy.GetString("TEAM_MAX_MEMBER_COUNT", new object[]
				{
					this.doc.currentExpInfo.PlayerNumber
				}));
			}
			IXUISprite ixuisprite2 = go.transform.FindChild("chatvoice").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite3 = go.transform.FindChild("chattext").GetComponent("XUISprite") as IXUISprite;
			bool flag4 = bActive || data == null || !this.m_ChatTimerToken.ContainsKey(data.uid);
			if (flag4)
			{
				ixuisprite2.SetVisible(false);
				ixuisprite3.SetVisible(false);
			}
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnInviteBtnClick));
			IXUISprite ixuisprite4 = go.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite5 = go.transform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite5.ID = (ulong)((long)index);
			ixuisprite5.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClicked));
			bool flag5 = data == null;
			if (flag5)
			{
				ixuisprite.SetSprite("", "", false);
			}
			else
			{
				bool flag6 = data.uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = ixuilabel2.gameObject.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject5 = gameObject.transform.FindChild("Leader").gameObject;
				Transform transform2 = gameObject.transform.FindChild("Snapshot");
				transform2.gameObject.SetActive(true);
				IXUISprite ixuisprite6 = gameObject.transform.FindChild("ProfIcon").GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject6 = gameObject.transform.Find("Helper").gameObject;
				IXUISprite ixuisprite7 = gameObject.transform.Find("Rewardless").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite8 = gameObject.transform.Find("MilitaryRank").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite9 = gameObject.transform.Find("DragonMedal").GetComponent("XUISprite") as IXUISprite;
				ixuisprite9.gameObject.SetActive(false);
				Transform transform3 = gameObject.transform.Find("CrossServer");
				GameObject gameObject7 = gameObject.transform.Find("Mysterious").gameObject;
				IXUISprite ixuisprite10 = gameObject.transform.Find("Regression").GetComponent("XUISprite") as IXUISprite;
				ixuisprite10.SetVisible(data.regression);
				ixuilabelSymbol.InputText = XSingleton<XCommon>.singleton.StringCombine(data.name, XWelfareDocument.GetMemberPrivilegeIconString(data.paymemberid), XRechargeDocument.GetVIPIconString(data.vip));
				bool flag7 = flag6;
				if (flag7)
				{
					ixuilabel2.SetColor(new Color(0.9137255f, 0.81960785f, 0.60784316f));
				}
				else
				{
					ixuilabel2.SetColor(new Color(0.57254905f, 0.7137255f, 0.9490196f));
				}
				ixuilabel3.SetText(flag6 ? XSingleton<XAttributeMgr>.singleton.XPlayerData.Level.ToString() : data.level.ToString());
				gameObject5.SetActive(data.bIsLeader);
				GameObject gameObject8 = gameObject.transform.Find("BattlePointBG").gameObject;
				bool flag8 = this.doc.currentExpInfo != null && !this.doc.currentExpInfo.ShowPPT;
				if (flag8)
				{
					gameObject8.SetActive(false);
				}
				else
				{
					gameObject8.SetActive(true);
					IXUILabel ixuilabel4 = gameObject8.transform.Find("Power").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite11 = gameObject8.transform.Find("SisterTA").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel5 = ixuisprite11.transform.Find("Info").GetComponent("XUILabel") as IXUILabel;
					bool flag9 = ixuilabel5 != null;
					if (flag9)
					{
						ixuilabel5.SetVisible(false);
					}
					uint num = 0U;
					bool flag10 = flag6;
					bool flag11;
					if (flag10)
					{
						num = (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
						flag11 = this.doc.TryGetPveProfessionPPT(this.doc.IsTarja, XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID, ref num);
					}
					else
					{
						num = data.ppt;
						flag11 = this.doc.TryGetPveProfessionPPT(data.IsTarja, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(data.profession), ref num);
					}
					ixuisprite11.SetVisible(flag11);
					ixuilabel4.SetText(flag11 ? string.Format("[c][f1d309]{0}[-][/c]", num) : num.ToString());
					ixuisprite11.ID = 0UL;
					ixuisprite11.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnShowTarjaTipHandle));
				}
				int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(data.profession);
				ixuisprite6.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profID);
				this._SetRelation(gameObject, data, flag6);
				gameObject6.SetActive(data.bIsHelper);
				ixuisprite7.SetVisible(!data.bIsHelper && this.dragonDoc.GetDragonNestRewardlessLevel(this.doc.currentDungeonID) <= data.level);
				ixuisprite7.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnRewardlessPressed));
				ixuisprite7.transform.Find("Popup").gameObject.SetActive(false);
				this._SetLeftCount(gameObject, data, flag6);
				if (bSmallMember)
				{
					bool active = this._SetMemberAvatar(transform2, data, index);
					transform.gameObject.SetActive(active);
				}
				else
				{
					IXUISprite ixuisprite12 = transform2.GetComponent("XUISprite") as IXUISprite;
					ixuisprite12.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(profID));
				}
				bool flag12 = ixuisprite3.ID != data.uid;
				if (flag12)
				{
					this._CloseChatTimer(ixuisprite3.ID);
					ixuisprite3.SetVisible(false);
					ixuisprite3.ID = 0UL;
				}
				bool flag13 = ixuisprite2.ID != data.uid;
				if (flag13)
				{
					this._CloseChatTimer(ixuisprite2.ID);
					ixuisprite2.SetVisible(false);
					ixuisprite2.ID = 0UL;
				}
				IXUISprite ixuisprite13 = gameObject2.transform.FindChild("Kick").GetComponent("XUISprite") as IXUISprite;
				ixuisprite13.ID = (ulong)((long)index);
				ixuisprite13.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberLeaveClick));
				IXUISprite ixuisprite14 = gameObject2.transform.FindChild("LeaderCommission").GetComponent("XUISprite") as IXUISprite;
				ixuisprite14.ID = (ulong)((long)index);
				ixuisprite14.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnChangeLeaderClick));
				bool flag14 = flag6 && this.doc.bInTeam;
				if (flag14)
				{
					this.m_BtnLeave.ID = (ulong)((long)index);
					ixuisprite13.SetVisible(false);
				}
				else
				{
					ixuisprite13.SetVisible(this.doc.bIsLeader);
				}
				ixuisprite14.SetVisible(this.doc.bIsLeader && !data.bIsLeader);
				string text = string.Empty;
				bool flag15 = this.doc.bInTeam && data.bIsLeader && this.doc.MyTeam.teamBrief.goldGroup.type > GoldGroupType.GGT_NONE;
				if (flag15)
				{
					bool flag16 = this.doc.MyTeam.teamBrief.goldGroup.type == GoldGroupType.GGT_DIAMOND;
					if (flag16)
					{
						text = XSingleton<XGlobalConfig>.singleton.GetValue("TeamFrame_gct_1");
					}
					else
					{
						bool flag17 = this.doc.MyTeam.teamBrief.goldGroup.type == GoldGroupType.GGT_TICKET;
						if (flag17)
						{
							text = XSingleton<XGlobalConfig>.singleton.GetValue("TeamFrame_gct_2");
						}
					}
				}
				else
				{
					bool flag18 = flag6;
					if (flag18)
					{
						text = this.preDoc.GetPreContent(PrerogativeType.PreTeamBorder);
					}
					else
					{
						bool flag19 = data.outlook != null && data.outlook.pre != null;
						if (flag19)
						{
							text = XPrerogativeDocument.ConvertTypeToPreContent(PrerogativeType.PreTeamBorder, data.outlook.pre.setid);
						}
						else
						{
							text = XPrerogativeDocument.ConvertTypeToPreContent(PrerogativeType.PreTeamBorder, 0U);
						}
					}
				}
				bool flag20 = false;
				bool flag21 = !string.IsNullOrEmpty(text);
				if (flag21)
				{
					string[] array = text.Split(XGlobalConfig.SequenceSeparator);
					bool flag22 = array.Length >= 2;
					if (flag22)
					{
						flag20 = true;
						ixuisprite.SetSprite(array[1], array[0], false);
					}
				}
				bool flag23 = !flag20;
				if (flag23)
				{
					ixuisprite.SetSprite("", "", false);
				}
				List<uint> ids = null;
				bool flag24 = !flag6 && data.outlook.pre == null;
				if (flag24)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("data.outlook.pre is null", null, null, null, null, null);
				}
				bool flag25 = !flag6 && data.outlook.pre != null;
				if (flag25)
				{
					uint score = data.outlook.pre.score;
					ids = data.outlook.pre.setid;
				}
				string text2 = flag6 ? this.preDoc.GetPreContent(PrerogativeType.PreTeamBackground) : XPrerogativeDocument.ConvertTypeToPreContent(PrerogativeType.PreTeamBackground, ids);
				string text3 = string.Empty;
				bool flag26 = !string.IsNullOrEmpty(text2);
				if (flag26)
				{
					string[] array2 = text2.Split(XGlobalConfig.ListSeparator);
					text3 = ((!bSmallMember && array2.Length > 1) ? array2[1] : array2[0]);
				}
				bool flag27 = !string.IsNullOrEmpty(text3);
				if (flag27)
				{
					XFx item = XSingleton<XFxMgr>.singleton.CreateUIFx(text3, ixuisprite.transform, false);
					this.m_preEffects.Add(item);
				}
				bool flag28 = this.m_MilitaryIconTypes.Contains(XFastEnumIntEqualityComparer<TeamLevelType>.ToInt(this.doc.currentDungeonType));
				if (flag28)
				{
					string militaryIcon = XMilitaryRankDocument.GetMilitaryIcon((data.outlook != null && data.outlook.military != null) ? data.outlook.military.military_rank : 0U);
					bool flag29 = string.IsNullOrEmpty(militaryIcon);
					if (flag29)
					{
						ixuisprite8.SetVisible(false);
					}
					else
					{
						ixuisprite8.SetVisible(true);
						ixuisprite8.SetSprite(militaryIcon);
					}
				}
				else
				{
					ixuisprite8.SetVisible(false);
				}
				bool flag30 = transform3 != null && this.doc.MyTeam != null && this.doc.MyTeam.myData != null;
				if (flag30)
				{
					bool flag31 = flag6;
					if (flag31)
					{
						transform3.gameObject.SetActive(false);
					}
					else
					{
						transform3.gameObject.SetActive(this.doc.MyTeam.myData.ServerID != data.ServerID);
					}
				}
				bool flag32 = gameObject7 != null;
				if (flag32)
				{
					bool flag33 = this.doc.MyTeam.teamBrief.rift != null && data.bIsLeader;
					if (flag33)
					{
						gameObject7.SetActive(true);
						this.doc.MyTeam.teamBrief.rift.SetUI(gameObject7);
					}
					else
					{
						gameObject7.SetActive(false);
					}
				}
			}
		}

		private void _SetRelation(GameObject infoGo, XTeamMember data, bool bIsPlayer)
		{
			if (bIsPlayer)
			{
				XTeamView.SetTeamRelationUI(infoGo.transform.Find("Relation"), null, false, XTeamRelation.Relation.TR_NONE);
			}
			else
			{
				data.Relation.UpdateRelation(data.uid, data.guildID, data.dragonGuildID);
				XTeamView.SetTeamRelationUI(infoGo.transform.Find("Relation"), data.Relation, false, XTeamRelation.Relation.TR_NONE);
			}
			IXUILabel ixuilabel = infoGo.transform.Find("FriendValue").GetComponent("XUILabel") as IXUILabel;
			if (bIsPlayer)
			{
				ixuilabel.SetVisible(false);
			}
			else
			{
				ixuilabel.SetVisible(true);
				XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(data.uid);
				bool flag = friendDataById != null;
				if (flag)
				{
					ixuilabel.SetText(friendDataById.degreeAll.ToString());
				}
				else
				{
					ixuilabel.SetText("0");
				}
			}
		}

		private void _SetLeftCount(GameObject infoGo, XTeamMember data, bool bIsPlayer)
		{
			IXUILabel ixuilabel = infoGo.transform.FindChild("LeftCount").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = infoGo.transform.Find("NoCount").gameObject;
			bool flag = data.leftCount < 0;
			if (flag)
			{
				ixuilabel.SetVisible(true);
				ixuilabel.SetText(XStringDefineProxy.GetString("TEAM_TARGET_NOT_OPEN"));
				gameObject.SetActive(false);
			}
			else
			{
				bool flag2 = data.leftCount == 0 && this.doc.currentDungeonType != TeamLevelType.TeamLevelCaptainPVP && this.doc.currentDungeonType != TeamLevelType.TeamLevelMoba && this.doc.currentDungeonType != TeamLevelType.TeamLevelHeroBattle && this.doc.currentDungeonType != TeamLevelType.TeamLevelDragonNest && this.doc.currentDungeonType != TeamLevelType.TeamLevelTeamLeague && !data.bIsHelper && !data.bIsTicket;
				if (flag2)
				{
					ixuilabel.SetVisible(false);
					gameObject.SetActive(this.doc.currentExpInfo.CostCountType != 0);
				}
				else
				{
					bool flag3 = this.doc.currentDungeonType == TeamLevelType.TeamLevelGoddessTrial || this.doc.currentDungeonType == TeamLevelType.TeamLevelEndlessAbyss;
					if (flag3)
					{
						ixuilabel.SetVisible(true);
						ixuilabel.SetText(string.Format("{0}/{1}", bIsPlayer ? this.doc.GetMyDayCount() : data.leftCount, this.doc.GetCurrentDayMaxCount()));
						gameObject.SetActive(false);
					}
					else
					{
						ixuilabel.SetVisible(false);
						gameObject.SetActive(false);
					}
				}
			}
		}

		private bool OnShowTarjaTipHandle(IXUISprite sprite, bool pressed)
		{
			IXUILabel ixuilabel = sprite.transform.Find("Info").GetComponent("XUILabel") as IXUILabel;
			bool flag = ixuilabel == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = sprite.ID == 1UL;
				if (flag2)
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TEAM_TARJA_DESC_TEAM")));
				}
				else
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TEAM_TARJA_DESC")));
				}
				ixuilabel.SetVisible(pressed);
				result = false;
			}
			return result;
		}

		private string _GetSceneDescription(SceneTable.RowData rowData)
		{
			SceneType type = (SceneType)rowData.type;
			if (type <= SceneType.SCENE_GUILD_HALL)
			{
				switch (type)
				{
				case SceneType.SCENE_HALL:
				case SceneType.SCENE_ARENA:
					break;
				case SceneType.SCENE_BATTLE:
					return XStringDefineProxy.GetString("MASTER_DUNGEON");
				case SceneType.SCENE_NEST:
				case (SceneType)4:
					goto IL_84;
				default:
					if (type != SceneType.SCENE_GUILD_HALL)
					{
						goto IL_84;
					}
					break;
				}
				return rowData.Comment;
			}
			if (type == SceneType.SCENE_ABYSSS)
			{
				return XStringDefineProxy.GetString("ABYSS_DUNGEON");
			}
			if (type == SceneType.SCENE_GODDESS)
			{
				return XStringDefineProxy.GetString("GODDESS_DUNGEON");
			}
			if (type == SceneType.SCENE_ENDLESSABYSS)
			{
				return XStringDefineProxy.GetString("EndlessAbyss");
			}
			IL_84:
			return rowData.Comment;
		}

		private void _OnDummyLoaded(XEquipComponent equipComp)
		{
			this.m_bDirty = true;
		}

		private bool _SetMemberAvatar(Transform snapShot, XTeamMember data, int index)
		{
			bool result = false;
			XDummy xdummy = null;
			IUIDummy iuidummy = snapShot.GetComponent("UIDummy") as IUIDummy;
			this.m_UIDummys[index] = iuidummy;
			bool flag = data.uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, iuidummy);
				XSingleton<X3DAvatarMgr>.singleton.ResetMainAnimation();
			}
			else
			{
				xdummy = XSingleton<X3DAvatarMgr>.singleton.FindCreateCommonRoleDummy(this.m_dummPool, data.uid, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(data.profession), data.outlook, iuidummy, index);
				bool flag2 = xdummy != null;
				if (flag2)
				{
					bool delayLoad = XSingleton<XResourceLoaderMgr>.singleton.DelayLoad;
					if (delayLoad)
					{
						xdummy.Equipment.SetLoadFinishedCallback(new LoadFinishedCallback(this._OnDummyLoaded));
					}
				}
				this.m_Avatars[index] = xdummy;
			}
			bool flag3 = xdummy != null;
			if (flag3)
			{
				result = xdummy.Equipment.IsLoadingPart();
			}
			return result;
		}

		public void RefreshButtonStates()
		{
			this.m_BtnAddCount.SetVisible(this.expDoc.GetBuyLimit(this.doc.currentDungeonType) > 0);
			bool bInTeam = this.doc.bInTeam;
			if (bInTeam)
			{
				this.m_BtnStart.SetGrey(this.doc.MyTeam.members.Count >= this.doc.currentExpInfo.PlayerLeastNumber);
				this.m_BtnStart.SetGrey(this.doc.currentDungeonType != TeamLevelType.TeamLevelPartner);
				bool flag = this.doc.currentDungeonType == TeamLevelType.TeamLevelWeddingLicense;
				if (flag)
				{
					this.m_BtnStart.SetGrey(false);
				}
				this.m_StartHighlight.SetActive(false);
				bool bIsLeader = this.doc.bIsLeader;
				bool flag2 = bIsLeader;
				if (flag2)
				{
					bool flag3 = this.doc.currentDungeonType == TeamLevelType.TeamLevelCaptainPVP || this.doc.currentDungeonType == TeamLevelType.TeamLevelHeroBattle || this.doc.currentDungeonType == TeamLevelType.TeamLevelMoba || this.doc.currentDungeonType == TeamLevelType.TeamLevelMultiPK || this.doc.currentDungeonType == TeamLevelType.TeamLevelWeekendParty || this.doc.currentDungeonType == TeamLevelType.TeamLevelCustomPKTwo;
					if (flag3)
					{
						this.m_BtnStart.SetVisible(false);
						this.m_BtnMatchMembers.SetVisible(true);
					}
					else
					{
						this.m_BtnStart.SetVisible(true);
						this.m_BtnMatchMembers.SetVisible(false);
					}
				}
				else
				{
					this.m_BtnStart.SetVisible(false);
					this.m_BtnMatchMembers.SetVisible(false);
				}
				IXUILabel ixuilabel = this.m_BtnStart.gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
				XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
				bool flag4 = this.doc.currentDungeonType == TeamLevelType.TeamLevelTeamLeague;
				if (flag4)
				{
					this.m_BtnStart.SetVisible(bIsLeader && specificDocument.TeamLeagueID == 0UL);
					this.m_BtnMatchMembers.SetVisible(bIsLeader && specificDocument.TeamLeagueID > 0UL);
					ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("CREATE_TEAM_LEAGUE"));
				}
				else
				{
					ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("START_FIGHT"));
				}
				this.m_MatchMembersIdleLabel.SetVisible(!this.doc.bMatching);
				this.m_MatchMembersMatchingLabel.SetVisible(this.doc.bMatching);
				bool flag5 = this.m_BtnBroadcast.IsVisible();
				if (flag5)
				{
					this.m_BtnBroadcast.SetEnable(true, false);
				}
			}
		}

		private bool _OnStartBtnClick(IXUIButton go)
		{
			bool flag = !this.doc.bIsLeader;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.doc.currentDungeonType == TeamLevelType.TeamLevelPartner || this.doc.currentDungeonType == TeamLevelType.TeamLevelWeddingLicense;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = this.doc.MyTeam.members.Count < this.doc.currentExpInfo.PlayerLeastNumber && go == this.m_BtnStart;
					if (flag3)
					{
						bool flag4 = this.doc.currentDungeonType == TeamLevelType.TeamLevelGuildMine;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("TEAM_LACK_OF_MEMBERS_CONFIRM", new object[]
							{
								this.doc.currentExpInfo.PlayerLeastNumber.ToString()
							}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._OnStartConfirmBtnClick));
							return true;
						}
					}
					bool flag5 = this.doc.currentDungeonType == TeamLevelType.TeamLevelGuildMine;
					if (flag5)
					{
						XGuildMineEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
						specificDocument.ReqEnterMine();
					}
					else
					{
						bool flag6 = this.doc.currentDungeonType == TeamLevelType.TeamLevelTeamLeague;
						if (flag6)
						{
							DlgBase<XTeamLeagueCreateView, XTeamLeagueCreateBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						}
						else
						{
							this.doc.ReqTeamOp(TeamOperate.TEAM_START_BATTLE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
						}
					}
					result = true;
				}
			}
			return result;
		}

		private bool _OnStartConfirmBtnClick(IXUIButton btn)
		{
			this._OnStartBtnClick(btn);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool _OnBroadcastBtnClick(IXUIButton go)
		{
			bool flag = this.doc.MyTeam == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !string.IsNullOrEmpty(this.doc.password);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CantBroadCastCausePassword"), "fece00");
					result = true;
				}
				else
				{
					XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
					TeamLevelType currentDungeonType = this.doc.currentDungeonType;
					NoticeType noticeType;
					if (currentDungeonType != TeamLevelType.TeamLevelExpdition && currentDungeonType != TeamLevelType.TeamLevelNest)
					{
						if (currentDungeonType != TeamLevelType.TeamLevelGuildCamp)
						{
							noticeType = NoticeType.NT_INVITE_NORMALTEAM;
						}
						else
						{
							noticeType = NoticeType.NT_INVITE_GUILDTEAM;
						}
					}
					else
					{
						noticeType = NoticeType.NT_INVITE_NORMALTEAM;
					}
					bool flag3 = noticeType != NoticeType.NT_INVITE_GUILDTEAM || this._CanSendGuildInvite(true);
					if (flag3)
					{
						specificDocument.SendTeamInvitation(noticeType, (uint)this.doc.MyTeam.teamBrief.teamID, this.doc.MyTeam.teamBrief.dungeonID, this.doc.currentDungeonName);
					}
					XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					bool bInGuild = specificDocument2.bInGuild;
					if (bInGuild)
					{
						bool flag4 = this._CanSendGuildInvite(false);
						if (flag4)
						{
							specificDocument.SendTeamInvitation(NoticeType.NT_INVITE_GUILDTEAM, (uint)this.doc.MyTeam.teamBrief.teamID, this.doc.MyTeam.teamBrief.dungeonID, this.doc.currentDungeonName);
						}
					}
					result = true;
				}
			}
			return result;
		}

		private bool _CanSendGuildInvite(bool bShowTips)
		{
			float time = Time.time;
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GuildBroadcastCD");
			bool flag = time - this.guildInviteTime >= (float)@int;
			bool result;
			if (flag)
			{
				this.guildInviteTime = time;
				result = true;
			}
			else
			{
				if (bShowTips)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BROADCAST_TIMELIMIT", new object[]
					{
						((int)((float)@int - time + this.guildInviteTime + 1f)).ToString()
					}), "fece00");
				}
				result = false;
			}
			return result;
		}

		private bool _OnMatchMembersBtnClick(IXUIButton go)
		{
			TeamLevelType currentDungeonType = this.doc.currentDungeonType;
			if (currentDungeonType != TeamLevelType.TeamLevelCaptainPVP)
			{
				switch (currentDungeonType)
				{
				case TeamLevelType.TeamLevelHeroBattle:
				case TeamLevelType.TeamLevelMultiPK:
				case TeamLevelType.TeamLevelWeekendParty:
				case TeamLevelType.TeamLevelMoba:
				case TeamLevelType.TeamLevelCustomPKTwo:
					break;
				case TeamLevelType.TeamLevelTeamLeague:
				{
					XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
					specificDocument.ReqMatchGame(!this.doc.bMatching);
					return true;
				}
				case TeamLevelType.TeamLevelFestival:
				case TeamLevelType.TeamLevelTask:
				case TeamLevelType.TeamLevelSkyCraft:
					return true;
				default:
					return true;
				}
			}
			KMatchType type = XTeamDocument.TeamType2MatchType(this.doc.currentDungeonType);
			KMatchOp op = (!this.doc.bMatching) ? KMatchOp.KMATCH_OP_START : KMatchOp.KMATCH_OP_STOP;
			this.doc.ReqMatchStateChange(type, op, true);
			return true;
		}

		private bool _OnOpenListBtnClick(IXUIButton go)
		{
			DlgBase<XTeamListView, XTeamListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private void _OnSettingBtnClicked(IXUISprite go)
		{
			this.m_SettingHandler.SetVisible(true);
		}

		private bool _OnChatBtnClick(IXUIButton go)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.ShowChannel(ChatChannelType.Team);
			return true;
		}

		private bool _OnInviteBtnClick(IXUIButton go)
		{
			bool flag = this.doc.currentDungeonType == TeamLevelType.TeamLevelWedding;
			if (flag)
			{
				RoleOutLookBrief teamLoverRole = XWeddingDocument.Doc.GetTeamLoverRole();
				bool flag2 = teamLoverRole != null;
				if (flag2)
				{
					this.doc.ReqTeamOp(TeamOperate.TEAM_INVITE, teamLoverRole.roleid, null, TeamMemberType.TMT_NORMAL, null);
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeddingLoverInviteTip", new object[]
					{
						teamLoverRole.name
					}), "fece00");
				}
			}
			else
			{
				DlgBase<XTeamInviteView, XTeamInviteBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
			return true;
		}

		private void _OnMemberLeaveClick(IXUISprite go)
		{
			int num = (int)go.ID;
			bool flag = !this.doc.bInTeam || num >= this.doc.MyTeam.members.Count;
			if (!flag)
			{
				this.m_SelectedMemberID = this.doc.MyTeam.members[num].uid;
				bool flag2 = this.m_SelectedMemberID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					this.doc.ReqTeamOp(TeamOperate.TEAM_LEAVE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("TEAM_FIREMEMBER_CONFIRM", new object[]
					{
						this.doc.MyTeam.members[num].name
					}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._DoFireFromTeam));
				}
			}
		}

		private bool _DoFireFromTeam(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.doc.ReqTeamOp(TeamOperate.TEAM_KICK, this.m_SelectedMemberID, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		private void _OnChangeLeaderClick(IXUISprite go)
		{
			int num = (int)go.ID;
			bool flag = !this.doc.bInTeam || num >= this.doc.MyTeam.members.Count;
			if (!flag)
			{
				this.m_SelectedMemberID = this.doc.MyTeam.members[num].uid;
				bool flag2 = this.m_SelectedMemberID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("TEAM_CHANGELEADER_CONFIRM", new object[]
					{
						this.doc.MyTeam.members[num].name
					}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._DoChangeLeader));
				}
			}
		}

		private bool _DoChangeLeader(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.doc.ReqTeamOp(TeamOperate.TEAM_TRAHS_LEADER, this.m_SelectedMemberID, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		private void _OnMemberClicked(IXUISprite go)
		{
			bool flag = !this.doc.bInTeam;
			if (!flag)
			{
				int num = (int)go.ID;
				bool flag2 = num < this.doc.MyTeam.members.Count;
				if (flag2)
				{
					XTeamMember xteamMember = this.doc.MyTeam.members[num];
					bool flag3 = xteamMember.uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (!flag3)
					{
						bool flag4 = !xteamMember.bIsRobot;
						if (flag4)
						{
							XCharacterCommonMenuDocument.ReqCharacterMenuInfo(xteamMember.uid, false);
						}
					}
				}
			}
		}

		private bool _OnAddCountClicked(IXUIButton btn)
		{
			DlgBase<XBuyCountView, XBuyCountBehaviour>.singleton.ActiveShow(this.doc.currentDungeonType);
			return true;
		}

		private void _OnHelperClicked(IXUISprite sp)
		{
			this.doc.ReqTeamOp(TeamOperate.TEAM_MEMBER_TYPE, 0UL, null, this.doc.bIsHelper ? TeamMemberType.TMT_NORMAL : TeamMemberType.TMT_HELPER, null);
		}

		private void _OnTicketClicked(IXUISprite sp)
		{
			this.doc.ReqTeamOp(TeamOperate.TEAM_MEMBER_TYPE, 0UL, null, this.doc.bIsTecket ? TeamMemberType.TMT_NORMAL : TeamMemberType.TMT_USETICKET, null);
		}

		private bool _OnRewardlessPressed(IXUISprite sp, bool isPress)
		{
			Transform transform = sp.transform.Find("Popup");
			transform.gameObject.SetActive(isPress);
			return true;
		}

		public static readonly int SMALL_TEAM_CAPACITY = 4;

		public static readonly int LARGE_TEAM_CAPACITY = 8;

		public GameObject m_StartHighlight;

		public IXUIButton m_BtnStart;

		public IXUIButton m_BtnBroadcast;

		public IXUIButton m_BtnMatchMembers;

		public IXUISprite m_BtnSetting;

		public IXUISprite m_BtnLeave;

		private Vector3 m_PosLeave;

		private Vector3 m_PosStart;

		public IXUILabel m_MatchMembersIdleLabel;

		public IXUILabel m_MatchMembersMatchingLabel;

		public IXUILabel m_StartLabel;

		public XUIPool m_MemberPoolSmall = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_MemberPoolLarge = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_BtnAddCount;

		private IXUISprite m_BtnHelper;

		private IXUISprite m_HelperSelected;

		private IXUISprite m_BtnTicket;

		private IXUISprite m_TicketSelected;

		private IXUILabel m_PPTRequirement;

		private GameObject m_PPTRequirementTotal;

		private GameObject m_GoldGroup;

		private GameObject m_GoldGroupDescri;

		private XTeamDocument doc;

		private XExpeditionDocument expDoc;

		private XCaptainPVPDocument capDoc;

		private XHeroBattleDocument heroDoc;

		private XPrerogativeDocument preDoc;

		private XDragonNestDocument dragonDoc;

		private XTeamBonusHandler m_BonusHandler = null;

		private XTeamPartnerBonusHandler m_FriendBonusHandler = null;

		private XTeamSettingHandler m_SettingHandler = null;

		private XTeamPasswordHandler m_PasswordHandler = null;

		private XDummy[] m_Avatars = new XDummy[XMyTeamHandler.SMALL_TEAM_CAPACITY];

		private IUIDummy[] m_UIDummys = new IUIDummy[XMyTeamHandler.SMALL_TEAM_CAPACITY];

		private int m_MemberCount = 0;

		private Dictionary<GameObject, XTeamFriendDegreeHandler> m_DicFriendDegree = new Dictionary<GameObject, XTeamFriendDegreeHandler>();

		private Dictionary<ulong, uint> m_ChatTimerToken = new Dictionary<ulong, uint>();

		private List<XFx> m_preEffects = new List<XFx>();

		private bool m_bDirty;

		private HashSet<int> m_MilitaryIconTypes = new HashSet<int>();

		private float guildInviteTime = 0f;

		private ulong m_SelectedMemberID;
	}
}
