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
	// Token: 0x02000E63 RID: 3683
	internal class XTeamListHandler : DlgHandlerBase
	{
		// Token: 0x0600C537 RID: 50487 RVA: 0x002B605C File Offset: 0x002B425C
		public XTeamListHandler()
		{
			this._autoRefreshCb = new XTimerMgr.ElapsedEventHandler(this._AutoRefresh);
		}

		// Token: 0x0600C538 RID: 50488 RVA: 0x002B60AC File Offset: 0x002B42AC
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.FindChild("Bg");
			this.m_BottomButtonsFrame = transform.Find("BottomButtonsFrame");
			this.m_BottomButtonsNormalPos = transform.Find("BottomButtonsNormalPos");
			this.m_BottomButtonsNoMatchPos = transform.Find("BottomButtonsNoMatchPos");
			this.m_BtnRefresh = (transform.FindChild("BtnRefresh").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRecruit = (transform.Find("BtnRecruit").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnCreate = (this.m_BottomButtonsFrame.FindChild("BtnCreate").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnMatchTeam = (this.m_BottomButtonsFrame.FindChild("BtnMatch").GetComponent("XUIButton") as IXUIButton);
			this.m_MatchTeamLabel = (this.m_BtnMatchTeam.gameObject.transform.FindChild("IdleLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_MatchingTeamLabel = (this.m_BtnMatchTeam.gameObject.transform.FindChild("MatchingLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnAllList = (transform.Find("BtnTeamRoom").GetComponent("XUIButton") as IXUIButton);
			this.m_MatchingTween = (transform.Find("MatchingFrame").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_recruitEmpty = transform.Find("RecruitEmpty").gameObject;
			transform = base.PanelObject.transform.FindChild("Bg/AllTeamsFrame");
			this.m_NoTeam = transform.FindChild("NoTeams").gameObject;
			this.m_ScrollView = (transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (transform.FindChild("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.doc.TeamListView = this;
			this.doc.InitTeamListSelection();
			this.capDoc = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
			this.heroDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			DlgHandlerBase.EnsureCreate<XTeamPasswordHandler>(ref this.m_PasswordHandler, this.m_BottomButtonsFrame.Find("PasswordFrame").gameObject, this, true);
		}

		// Token: 0x0600C539 RID: 50489 RVA: 0x002B6320 File Offset: 0x002B4520
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnRefresh.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRefreshBtnClick));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.m_BtnMatchTeam.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnMatchTeamBtnClick));
			this.m_BtnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCreateBtnClick));
			this.m_BtnAllList.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnAllTeamBtnClick));
			this.m_BtnRecruit.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRecruitClick));
		}

		// Token: 0x0600C53A RID: 50490 RVA: 0x002B63C8 File Offset: 0x002B45C8
		protected override void OnShow()
		{
			base.OnShow();
			this.m_MatchingTween.gameObject.SetActive(false);
			this._bFirstOpen = true;
			this.m_SelectedTeamID = -1;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			this.RefreshPage();
			this._RefreshButtonName();
		}

		// Token: 0x0600C53B RID: 50491 RVA: 0x002B6424 File Offset: 0x002B4624
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
		}

		// Token: 0x0600C53C RID: 50492 RVA: 0x002B6446 File Offset: 0x002B4646
		public override void OnUnload()
		{
			this.doc.TeamListView = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			DlgHandlerBase.EnsureUnload<XTeamPasswordHandler>(ref this.m_PasswordHandler);
			base.OnUnload();
		}

		// Token: 0x0600C53D RID: 50493 RVA: 0x002B6480 File Offset: 0x002B4680
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._UpdateMatchingTime();
		}

		// Token: 0x0600C53E RID: 50494 RVA: 0x002B6491 File Offset: 0x002B4691
		public void OnCurrentDungeonChanged()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			this._RefreshButtonName();
		}

		// Token: 0x0600C53F RID: 50495 RVA: 0x002B64B4 File Offset: 0x002B46B4
		public void Matching()
		{
			this.m_MatchingTween.PlayTween(true, -1f);
		}

		// Token: 0x0600C540 RID: 50496 RVA: 0x002B64CC File Offset: 0x002B46CC
		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.doc.ReqTeamList(true);
				this._TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(5f, this._autoRefreshCb, null);
			}
		}

		// Token: 0x0600C541 RID: 50497 RVA: 0x002B6510 File Offset: 0x002B4710
		public void RefreshPage()
		{
			List<XTeamBriefData> teamList = this.doc.TeamList;
			this.m_WrapContent.SetContentCount(teamList.Count, false);
			bool bFirstOpen = this._bFirstOpen;
			if (bFirstOpen)
			{
				this.m_ScrollView.ResetPosition();
				this._bFirstOpen = false;
			}
			bool flag = GroupChatDocument.GetStageID(this.doc.currentDungeonID) > 0U;
			this.m_BtnRecruit.SetVisible(flag);
			bool flag2 = teamList.Count > 0;
			this.m_NoTeam.SetActive(!flag2 && !flag);
			this.m_recruitEmpty.SetActive(!flag2 && flag);
			this._UpdateButtonState();
		}

		// Token: 0x0600C542 RID: 50498 RVA: 0x002B65B8 File Offset: 0x002B47B8
		private void WrapContentItemUpdated(Transform t, int index)
		{
			List<XTeamBriefData> teamList = this.doc.TeamList;
			bool flag = index >= teamList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range: ", index.ToString(), null, null, null, null);
			}
			else
			{
				XTeamBriefData xteamBriefData = teamList[index];
				IXUILabel ixuilabel = t.FindChild("TeamName").GetComponent("XUILabel") as IXUILabel;
				IXUIButton ixuibutton = t.FindChild("BtnJoin").GetComponent("XUIButton") as IXUIButton;
				GameObject gameObject = t.FindChild("IsFull").gameObject;
				GameObject gameObject2 = t.FindChild("IsFighting").gameObject;
				GameObject gameObject3 = t.Find("Members/Leader").gameObject;
				GameObject gameObject4 = t.Find("Lock").gameObject;
				IXUILabel ixuilabel2 = t.Find("BattlePoint/Num").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.Find("SisterTA").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = 0UL;
				ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnPressTarjaInfo));
				IXUILabel ixuilabel3 = ixuisprite.transform.Find("Info").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = ixuilabel3 != null;
				if (flag2)
				{
					ixuilabel3.SetVisible(false);
				}
				IXUISprite ixuisprite2 = t.Find("SisterTATeam").GetComponent("XUISprite") as IXUISprite;
				ixuilabel3 = (ixuisprite2.transform.Find("Info").GetComponent("XUILabel") as IXUILabel);
				IXUISprite ixuisprite3 = t.Find("Regression").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.SetVisible(xteamBriefData.regression);
				bool flag3 = ixuilabel3 != null;
				if (flag3)
				{
					ixuilabel3.SetVisible(false);
				}
				ixuisprite2.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnPressTarjaInfo));
				ixuisprite2.ID = 1UL;
				bool flag4 = xteamBriefData.rift == null;
				if (flag4)
				{
					ixuilabel.SetText(xteamBriefData.teamName);
				}
				else
				{
					ixuilabel.SetText(xteamBriefData.rift.GetSceneName(xteamBriefData.teamName));
				}
				gameObject.SetActive(xteamBriefData.state == XTeamState.TS_FULL);
				gameObject2.SetActive(xteamBriefData.state == XTeamState.TS_FIGHTING);
				ixuibutton.SetVisible(xteamBriefData.state == XTeamState.TS_NOT_FULL || xteamBriefData.state == XTeamState.TS_VOTING);
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinBtnClick));
				gameObject3.SetActive(false);
				gameObject4.SetActive(xteamBriefData.hasPwd);
				ixuilabel2.SetText(xteamBriefData.GetStrTeamPPT(0.0));
				xteamBriefData.goldGroup.SetUI(t.Find("RewardHunt").gameObject, true);
				int i;
				for (i = 0; i < xteamBriefData.members.Count; i++)
				{
					Transform transform = t.Find("Members/Member" + i.ToString());
					this._SetTeamMemberUI(transform, xteamBriefData.members[i], xteamBriefData, i, index);
					bool flag5 = xteamBriefData.members[i].position == XTeamPosition.TP_LEADER;
					if (flag5)
					{
						gameObject3.SetActive(true);
						gameObject3.transform.localPosition = transform.localPosition;
					}
				}
				while (i < xteamBriefData.totalMemberCount)
				{
					this._SetTeamMemberUI(t.Find("Members/Member" + i.ToString()), null, xteamBriefData, i, index);
					i++;
				}
				while (i < XMyTeamHandler.LARGE_TEAM_CAPACITY)
				{
					this._SetTeamMemberUI(t.Find("Members/Member" + i.ToString()), null, null, i, index);
					i++;
				}
				ixuisprite2.SetVisible(xteamBriefData.isTarja);
				ixuisprite.SetVisible(this.doc.ShowTarja());
			}
		}

		// Token: 0x0600C543 RID: 50499 RVA: 0x002B69B8 File Offset: 0x002B4BB8
		private void _SetTeamMemberUI(Transform t, XTeamMemberBriefData memberData, XTeamBriefData teamData, int memberIndex, int teamIndex)
		{
			bool flag = t == null;
			if (!flag)
			{
				bool flag2 = teamData == null;
				if (flag2)
				{
					t.gameObject.SetActive(false);
				}
				else
				{
					t.gameObject.SetActive(true);
					IXUISprite ixuisprite = t.Find("Prof").GetComponent("XUISprite") as IXUISprite;
					Transform t2 = t.Find("Relation");
					bool flag3 = memberData != null;
					if (flag3)
					{
						ixuisprite.SetVisible(true);
						ixuisprite.ID = (ulong)((long)(teamIndex << XTeamListHandler.MEMBER_INDEX_MASK | memberIndex));
						ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(XFastEnumIntEqualityComparer<RoleType>.ToInt(memberData.profession)));
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClicked));
						XTeamView.SetTeamRelationUI(t2, memberData.relation, true, XTeamRelation.Relation.TR_NONE);
					}
					else
					{
						ixuisprite.SetVisible(false);
						XTeamView.SetTeamRelationUI(t2, null, true, XTeamRelation.Relation.TR_NONE);
					}
				}
			}
		}

		// Token: 0x0600C544 RID: 50500 RVA: 0x002B6AA8 File Offset: 0x002B4CA8
		private bool _OnPressTarjaInfo(IXUISprite sprite, bool pressed)
		{
			IXUILabel ixuilabel = sprite.transform.Find("Info").GetComponent("XUILabel") as IXUILabel;
			bool flag = ixuilabel != null;
			if (flag)
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
			}
			return false;
		}

		// Token: 0x0600C545 RID: 50501 RVA: 0x002B6B34 File Offset: 0x002B4D34
		private bool _OnRecruitClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_GroupRecruit, 0UL);
			return true;
		}

		// Token: 0x0600C546 RID: 50502 RVA: 0x002B6B5C File Offset: 0x002B4D5C
		private void _OnMemberClicked(IXUISprite iSp)
		{
			int num = (int)(iSp.ID & (ulong)((long)((1 << XTeamListHandler.MEMBER_INDEX_MASK) - 1)));
			int num2 = (int)(iSp.ID >> XTeamListHandler.MEMBER_INDEX_MASK);
			List<XTeamBriefData> teamList = this.doc.TeamList;
			bool flag = num2 >= teamList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("teamIndex out of range: ", num2.ToString(), null, null, null, null);
			}
			else
			{
				XTeamBriefData xteamBriefData = teamList[num2];
				bool flag2 = num >= xteamBriefData.members.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("memberIndex out of range: ", num.ToString(), null, null, null, null);
				}
				else
				{
					XTeamMemberBriefData xteamMemberBriefData = xteamBriefData.members[num];
					bool flag3 = !xteamMemberBriefData.robot;
					if (flag3)
					{
						XCharacterCommonMenuDocument.ReqCharacterMenuInfo(xteamMemberBriefData.uid, false);
					}
				}
			}
		}

		// Token: 0x0600C547 RID: 50503 RVA: 0x002B6C38 File Offset: 0x002B4E38
		private void _UpdateButtonState()
		{
			bool flag = this.doc.IsSoloMatching(this.doc.currentDungeonType);
			this.m_MatchingTeamLabel.SetVisible(flag);
			this.m_MatchTeamLabel.SetVisible(!flag);
			bool flag2 = !flag;
			if (flag2)
			{
				this.m_MatchingTween.gameObject.SetActive(false);
			}
			else
			{
				bool bAutoMatching = this.doc.bAutoMatching;
				if (bAutoMatching)
				{
					this.Matching();
					this.doc.bAutoMatching = false;
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this.m_MatchingTime = -1;
			}
			this._UpdateMatchingTime();
		}

		// Token: 0x0600C548 RID: 50504 RVA: 0x002B6491 File Offset: 0x002B4691
		public override void StackRefresh()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			this._RefreshButtonName();
		}

		// Token: 0x0600C549 RID: 50505 RVA: 0x002B6CD4 File Offset: 0x002B4ED4
		private bool _OnRefreshBtnClick(IXUIButton go)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			return true;
		}

		// Token: 0x0600C54A RID: 50506 RVA: 0x002B6D00 File Offset: 0x002B4F00
		private void _OnTeamClick(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			List<XTeamBriefData> teamList = this.doc.TeamList;
			bool flag = num >= teamList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range: ", num.ToString(), null, null, null, null);
			}
			else
			{
				XTeamBriefData xteamBriefData = teamList[num];
				this.m_SelectedTeamID = xteamBriefData.teamID;
				this.m_WrapContent.RefreshAllVisibleContents();
				this._UpdateButtonState();
			}
		}

		// Token: 0x0600C54B RID: 50507 RVA: 0x002B6D78 File Offset: 0x002B4F78
		private bool _OnJoinBtnClick(IXUIButton go)
		{
			this.mCurTeamBriefIndex = (int)go.ID;
			this._RealShowJoinTeamView();
			return true;
		}

		// Token: 0x0600C54C RID: 50508 RVA: 0x002B6DA4 File Offset: 0x002B4FA4
		private bool _OnMatchTeamBtnClick(IXUIButton go)
		{
			TeamLevelType currentDungeonType = this.doc.currentDungeonType;
			if (currentDungeonType != TeamLevelType.TeamLevelCaptainPVP && currentDungeonType != TeamLevelType.TeamLevelHeroBattle && currentDungeonType - TeamLevelType.TeamLevelMultiPK > 3)
			{
				this.doc.ToggleMatching();
			}
			else
			{
				KMatchType kmatchType = XTeamDocument.TeamType2MatchType(this.doc.currentDungeonType);
				KMatchOp op = (this.doc.SoloMatchType != kmatchType) ? KMatchOp.KMATCH_OP_START : KMatchOp.KMATCH_OP_STOP;
				this.doc.ReqMatchStateChange(kmatchType, op, false);
			}
			return true;
		}

		// Token: 0x0600C54D RID: 50509 RVA: 0x002B6E1C File Offset: 0x002B501C
		private bool _OnAllTeamBtnClick(IXUIButton go)
		{
			DlgBase<XTeamListView, XTeamListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			return true;
		}

		// Token: 0x0600C54E RID: 50510 RVA: 0x002B6E50 File Offset: 0x002B5050
		private bool _OnCreateBtnClick(IXUIButton go)
		{
			this._RealShowCreateTeamView();
			return true;
		}

		// Token: 0x0600C54F RID: 50511 RVA: 0x002B6E6C File Offset: 0x002B506C
		private void _RefreshButtonName()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID((int)this.doc.currentDungeonID);
			bool flag = expeditionDataByID == null || expeditionDataByID.fastmatch == 0;
			if (flag)
			{
				this.m_MatchTeamLabel.SetText(XStringDefineProxy.GetString("TEAM_MATCH_BTN_NORMAL"));
			}
			else
			{
				this.m_MatchTeamLabel.SetText(XStringDefineProxy.GetString("TEAM_MATCH_BTN_QUICK"));
			}
			bool flag2 = expeditionDataByID != null;
			if (flag2)
			{
				bool flag3 = expeditionDataByID.FMARobotTime == 0;
				if (flag3)
				{
					this.m_MatchingTeamLabel.SetText(XStringDefineProxy.GetString("MATCHING"));
				}
				this.m_FastMatchTime = expeditionDataByID.FMARobotTime;
			}
			else
			{
				this.m_FastMatchTime = 0;
			}
		}

		// Token: 0x0600C550 RID: 50512 RVA: 0x002B6F24 File Offset: 0x002B5124
		private void _UpdateMatchingTime()
		{
			bool flag = this.m_FastMatchTime == 0;
			if (!flag)
			{
				bool flag2 = this.m_MatchingTime != this.doc.MatchingTime && this.doc.MatchingTime >= 0;
				if (flag2)
				{
					this.m_MatchingTime = this.doc.MatchingTime;
					this.m_MatchingTeamLabel.SetText(string.Format("{0}...\n{1}", XStringDefineProxy.GetString("MATCHING"), XStringDefineProxy.GetString("LEFT_MATCH_TIME", new object[]
					{
						this.m_MatchingTime,
						this.m_FastMatchTime
					})));
				}
			}
		}

		// Token: 0x0600C551 RID: 50513 RVA: 0x002B6FD0 File Offset: 0x002B51D0
		private void _RealShowCreateTeamView()
		{
			bool flag = this.doc.MyTeam != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAM_ALREADY_INTEAM, "fece00");
			}
			else
			{
				this.doc.password = this.m_PasswordHandler.GetPassword();
				this.doc.ReqTeamOp(TeamOperate.TEAM_CREATE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				specificDocument.SetValue(XOptionsDefine.OD_TEAM_PASSWORD, this.m_PasswordHandler.GetInputPassword());
			}
		}

		// Token: 0x0600C552 RID: 50514 RVA: 0x002B7054 File Offset: 0x002B5254
		private void _RealShowJoinTeamView()
		{
			bool bInTeam = this.doc.bInTeam;
			if (bInTeam)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAM_ALREADY_INTEAM, "fece00");
			}
			else
			{
				XTeamBriefData teamBriefByIndex = this.doc.GetTeamBriefByIndex(this.mCurTeamBriefIndex);
				bool flag = teamBriefByIndex == null;
				if (!flag)
				{
					XTeamView.TryJoinTeam(teamBriefByIndex.teamID, teamBriefByIndex.hasPwd);
				}
			}
		}

		// Token: 0x04005632 RID: 22066
		public IXUIButton m_BtnRefresh;

		// Token: 0x04005633 RID: 22067
		public GameObject m_NoTeam;

		// Token: 0x04005634 RID: 22068
		public IXUIScrollView m_ScrollView;

		// Token: 0x04005635 RID: 22069
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04005636 RID: 22070
		public GameObject m_recruitEmpty;

		// Token: 0x04005637 RID: 22071
		public IXUIButton m_BtnCreate;

		// Token: 0x04005638 RID: 22072
		public IXUIButton m_BtnMatchTeam;

		// Token: 0x04005639 RID: 22073
		public IXUIButton m_BtnRecruit;

		// Token: 0x0400563A RID: 22074
		public IXUILabel m_MatchTeamLabel;

		// Token: 0x0400563B RID: 22075
		public IXUILabel m_MatchingTeamLabel;

		// Token: 0x0400563C RID: 22076
		public IXUIButton m_BtnAllList;

		// Token: 0x0400563D RID: 22077
		public IXUITweenTool m_MatchingTween;

		// Token: 0x0400563E RID: 22078
		private Transform m_BottomButtonsFrame;

		// Token: 0x0400563F RID: 22079
		private Transform m_BottomButtonsNormalPos;

		// Token: 0x04005640 RID: 22080
		private Transform m_BottomButtonsNoMatchPos;

		// Token: 0x04005641 RID: 22081
		private XTeamDocument doc;

		// Token: 0x04005642 RID: 22082
		private XCaptainPVPDocument capDoc;

		// Token: 0x04005643 RID: 22083
		private XHeroBattleDocument heroDoc;

		// Token: 0x04005644 RID: 22084
		private bool _bFirstOpen = false;

		// Token: 0x04005645 RID: 22085
		private uint _TimerID = 0U;

		// Token: 0x04005646 RID: 22086
		private int m_SelectedTeamID = 0;

		// Token: 0x04005647 RID: 22087
		private int mCurTeamBriefIndex;

		// Token: 0x04005648 RID: 22088
		private int m_MatchingTime;

		// Token: 0x04005649 RID: 22089
		private int m_FastMatchTime;

		// Token: 0x0400564A RID: 22090
		private XTeamPasswordHandler m_PasswordHandler;

		// Token: 0x0400564B RID: 22091
		private List<IXUICheckBox> m_SelectedCategoriesGo = new List<IXUICheckBox>();

		// Token: 0x0400564C RID: 22092
		private XTimerMgr.ElapsedEventHandler _autoRefreshCb = null;

		// Token: 0x0400564D RID: 22093
		private static readonly int MEMBER_INDEX_MASK = 4;
	}
}
