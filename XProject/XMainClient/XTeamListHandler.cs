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

	internal class XTeamListHandler : DlgHandlerBase
	{

		public XTeamListHandler()
		{
			this._autoRefreshCb = new XTimerMgr.ElapsedEventHandler(this._AutoRefresh);
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
		}

		public override void OnUnload()
		{
			this.doc.TeamListView = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			DlgHandlerBase.EnsureUnload<XTeamPasswordHandler>(ref this.m_PasswordHandler);
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._UpdateMatchingTime();
		}

		public void OnCurrentDungeonChanged()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			this._RefreshButtonName();
		}

		public void Matching()
		{
			this.m_MatchingTween.PlayTween(true, -1f);
		}

		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.doc.ReqTeamList(true);
				this._TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(5f, this._autoRefreshCb, null);
			}
		}

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

		private bool _OnRecruitClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_GroupRecruit, 0UL);
			return true;
		}

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

		public override void StackRefresh()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			this._RefreshButtonName();
		}

		private bool _OnRefreshBtnClick(IXUIButton go)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			return true;
		}

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

		private bool _OnJoinBtnClick(IXUIButton go)
		{
			this.mCurTeamBriefIndex = (int)go.ID;
			this._RealShowJoinTeamView();
			return true;
		}

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

		private bool _OnAllTeamBtnClick(IXUIButton go)
		{
			DlgBase<XTeamListView, XTeamListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			return true;
		}

		private bool _OnCreateBtnClick(IXUIButton go)
		{
			this._RealShowCreateTeamView();
			return true;
		}

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

		public IXUIButton m_BtnRefresh;

		public GameObject m_NoTeam;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public GameObject m_recruitEmpty;

		public IXUIButton m_BtnCreate;

		public IXUIButton m_BtnMatchTeam;

		public IXUIButton m_BtnRecruit;

		public IXUILabel m_MatchTeamLabel;

		public IXUILabel m_MatchingTeamLabel;

		public IXUIButton m_BtnAllList;

		public IXUITweenTool m_MatchingTween;

		private Transform m_BottomButtonsFrame;

		private Transform m_BottomButtonsNormalPos;

		private Transform m_BottomButtonsNoMatchPos;

		private XTeamDocument doc;

		private XCaptainPVPDocument capDoc;

		private XHeroBattleDocument heroDoc;

		private bool _bFirstOpen = false;

		private uint _TimerID = 0U;

		private int m_SelectedTeamID = 0;

		private int mCurTeamBriefIndex;

		private int m_MatchingTime;

		private int m_FastMatchTime;

		private XTeamPasswordHandler m_PasswordHandler;

		private List<IXUICheckBox> m_SelectedCategoriesGo = new List<IXUICheckBox>();

		private XTimerMgr.ElapsedEventHandler _autoRefreshCb = null;

		private static readonly int MEMBER_INDEX_MASK = 4;
	}
}
