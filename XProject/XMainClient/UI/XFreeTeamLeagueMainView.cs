using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XFreeTeamLeagueMainView : DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueMain";
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.InitProperties();
			this.InitTopRewards();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueBattleInfo();
		}

		protected override void OnShow()
		{
			base.OnShow();
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueBattleInfo();
			this.InitRankRewards();
			base.uiBehaviour.RankListRoot.gameObject.SetActive(false);
		}

		protected override void OnHide()
		{
			this.ClearState();
			base.OnHide();
		}

		public void RefreshUI()
		{
			this.UpdateActivityRules();
			this.UpdateTeamDetailInfo();
			this.UpdateRoleAvartars();
			this.UpdateActivityRewards();
			this.UpdateFinalResultFlag();
			this.RefreshMyRank();
		}

		public void ClearState()
		{
			base.uiBehaviour.rankWrapContent.SetContentCount(0, false);
			base.uiBehaviour.MemberUIPool.ReturnAll(false);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			base.Return3DAvatarPool();
			this.ClearAvatarStates();
		}

		public void UpdateTeamDetailInfo()
		{
			XFreeTeamVersusLeagueDocument doc = XFreeTeamVersusLeagueDocument.Doc;
			base.uiBehaviour.CreateTeamBtn.gameObject.SetActive(false);
			base.uiBehaviour.TeamMatchBtn.gameObject.SetActive(doc.TeamLeagueID > 0UL);
			base.uiBehaviour.TeamQuitBtn.gameObject.SetActive(doc.TeamLeagueID > 0UL);
			base.uiBehaviour.TeamInfoRoot.gameObject.SetActive(true);
			bool flag = doc.TeamLeagueID > 0UL;
			if (flag)
			{
				base.uiBehaviour.PartInTimesLabel.SetText(doc.BattledTimes.ToString());
				base.uiBehaviour.TeamNameLabel.SetText(doc.LeagueTeamName);
				base.uiBehaviour.TeamScoreLabel.SetText(doc.BattleScore.ToString());
				base.uiBehaviour.WinPercentageLabel.SetText((int)(doc.BattleWinRate * 100f) + "%");
			}
			else
			{
				base.uiBehaviour.CreateTeamBtn.gameObject.SetActive(true);
				base.uiBehaviour.TeamInfoRoot.gameObject.SetActive(false);
			}
		}

		public void UpdateRoleAvartars()
		{
			base.Return3DAvatarPool();
			base.Alloc3DAvatarPool("TeamLeagueMain");
			bool flag = XFreeTeamVersusLeagueDocument.Doc.TeamLeagueID > 0UL;
			if (flag)
			{
				base.uiBehaviour.MemberUIPool.ReturnAll(false);
				int myTeamMemberCount = XFreeTeamVersusLeagueDocument.Doc.GetMyTeamMemberCount();
				for (int i = 0; i < myTeamMemberCount; i++)
				{
					LeagueTeamDetailInfo myTeamMemberInfoByIndex = XFreeTeamVersusLeagueDocument.Doc.GetMyTeamMemberInfoByIndex(i);
					GameObject gameObject = base.uiBehaviour.MemberUIPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3((float)(base.uiBehaviour.MemberUIPool.TplWidth * i), 0f, 0f);
					this.UpdateTeamMemberInfo(gameObject, myTeamMemberInfoByIndex, i);
				}
			}
		}

		public void RefreshMyRank()
		{
			uint myTeamRank = XFreeTeamVersusLeagueDocument.Doc.MyTeamRank;
			bool flag = myTeamRank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				base.uiBehaviour.MainViewRankLabel.SetText(XSingleton<XStringTable>.singleton.GetString("ARENA_NO_RANK"));
			}
			else
			{
				base.uiBehaviour.MainViewRankLabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), myTeamRank + 1U));
			}
			bool activeSelf = base.uiBehaviour.RankListRoot.gameObject.activeSelf;
			if (activeSelf)
			{
				bool flag2 = myTeamRank == XRankDocument.INVALID_RANK;
				if (flag2)
				{
					base.uiBehaviour.MyRankLabel.SetText(XSingleton<XStringTable>.singleton.GetString("ARENA_NO_RANK"));
				}
				else
				{
					base.uiBehaviour.MyRankLabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), myTeamRank + 1U));
				}
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool activeSelf = base.uiBehaviour.RankListRoot.gameObject.activeSelf;
			if (activeSelf)
			{
				this.SetRewardLeftTime();
			}
		}

		private void SetRewardLeftTime()
		{
			int rewardsLeftTime = XFreeTeamVersusLeagueDocument.Doc.GetRewardsLeftTime();
			bool flag = rewardsLeftTime >= 1;
			if (flag)
			{
				base.uiBehaviour.RewardsLeftTimeLabel.gameObject.SetActive(true);
				bool flag2 = rewardsLeftTime >= 43200;
				if (flag2)
				{
					base.uiBehaviour.RewardsLeftTimeLabel.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString(rewardsLeftTime, 4));
				}
				else
				{
					base.uiBehaviour.RewardsLeftTimeLabel.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString(rewardsLeftTime, 5));
				}
			}
			else
			{
				base.uiBehaviour.RewardsLeftTimeLabel.gameObject.SetActive(false);
			}
		}

		private void InitProperties()
		{
			this._Avatars = new XDummy[4];
			base.uiBehaviour.HonorShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopBtnClicked));
			base.uiBehaviour.RankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankBtnClicked));
			base.uiBehaviour.RankRewardsBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankRewardsBtnClicked));
			base.uiBehaviour.VersusRecordsBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnVersusRecordsBtnClicked));
			base.uiBehaviour.FinalResultBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFinalResultBtnClicked));
			base.uiBehaviour.CreateTeamBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCreateOrMatchClicked));
			base.uiBehaviour.TeamMatchBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCreateOrMatchClicked));
			base.uiBehaviour.TeamQuitBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQuitTeamLeagueClicked));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
			base.uiBehaviour.RankListRoot.gameObject.SetActive(true);
			base.uiBehaviour.rankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateRankRewardsItem));
			base.uiBehaviour.RankListMask.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseRankList));
		}

		private void UpdateRankRewardsItem(Transform itemTransform, int index)
		{
			LeagueRankReward leagueRankRewardTable = XFreeTeamVersusLeagueDocument.LeagueRankRewardTable;
			bool flag = index < leagueRankRewardTable.Table.Length;
			if (flag)
			{
				LeagueRankReward.RowData rowData = leagueRankRewardTable.Table[index];
				IXUISprite ixuisprite = itemTransform.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = itemTransform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = rowData.rank[0] == rowData.rank[1] && rowData.rank[0] <= 3U;
				if (flag2)
				{
					ixuilabel.gameObject.SetActive(false);
					ixuisprite.gameObject.SetActive(true);
					ixuisprite.SetSprite(ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + rowData.rank[0]);
				}
				else
				{
					ixuilabel.gameObject.SetActive(true);
					ixuisprite.gameObject.SetActive(false);
					ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("LeagueTeamNormalRank"), rowData.rank[0], rowData.rank[1]));
				}
				Transform transform = itemTransform.Find("Grid");
				int childCount = transform.childCount;
				int count = rowData.reward.Count;
				int num = Mathf.Min(childCount, count);
				int i;
				for (i = 0; i < num; i++)
				{
					Transform child = transform.GetChild(i);
					child.gameObject.SetActive(true);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(child.gameObject, (int)rowData.reward[i, 0], (int)rowData.reward[i, 1], false);
					IXUISprite ixuisprite2 = child.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)rowData.reward[i, 0];
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				while (i < childCount)
				{
					Transform child2 = transform.GetChild(i);
					child2.gameObject.SetActive(false);
					i++;
				}
			}
		}

		private bool OnFinalResultBtnClicked(IXUIButton button)
		{
			DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool OnVersusRecordsBtnClicked(IXUIButton button)
		{
			bool flag = XFreeTeamVersusLeagueDocument.Doc.TeamLeagueID > 0UL;
			if (flag)
			{
				DlgBase<XTeamLeagueRecordView, XTeamLeagueRecordBehavior>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CreateLeagueTeamFirst"), "fece00");
			}
			return true;
		}

		private bool OnRankBtnClicked(IXUIButton button)
		{
			DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>.singleton.SetVisibleWithAnimation(true, null);
			XRankDocument specificDocument = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
			specificDocument.ReqRankList(XRankType.LeagueTeamRank);
			return true;
		}

		private bool OnRankRewardsBtnClicked(IXUIButton button)
		{
			base.uiBehaviour.RankListRoot.gameObject.SetActive(true);
			this.RefreshMyRank();
			return true;
		}

		private void OnCloseRankList(IXUISprite uiSprite)
		{
			base.uiBehaviour.RankListRoot.gameObject.SetActive(false);
		}

		private void UpdateActivityRewards()
		{
		}

		private void UpdateFinalResultFlag()
		{
			IXUILabel ixuilabel = base.uiBehaviour.FinalResultBtn.gameObject.transform.Find("Type").GetComponent("XUILabel") as IXUILabel;
			string text = (XFreeTeamVersusLeagueDocument.Doc.EliStateType == LeagueEliType.LeagueEliType_Cross) ? XSingleton<XStringTable>.singleton.GetString("LeagueCrossSeverFight") : XSingleton<XStringTable>.singleton.GetString("LeagueEliminationResult");
			ixuilabel.SetText(text);
			base.uiBehaviour.FinalResultBtn.gameObject.SetActive(XFreeTeamVersusLeagueDocument.Doc.EliStateType != LeagueEliType.LeagueEliType_None);
		}

		private void ClearAvatarStates()
		{
			for (int i = 0; i < 4; i++)
			{
				bool flag = this._Avatars[i] == null;
				if (!flag)
				{
					this._Avatars[i] = null;
				}
			}
		}

		private void UpdateTeamMemberInfo(GameObject obj, LeagueTeamDetailInfo info, int index)
		{
			Transform transform = obj.transform.Find("Info");
			IXUILabel ixuilabel = transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(info.roleBrief.name);
			IXUILabel ixuilabel2 = transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(info.roleBrief.level.ToString());
			IXUISprite ixuisprite = transform.Find("ProfIcon").GetComponent("XUISprite") as IXUISprite;
			int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(info.roleBrief.profession);
			ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profID);
			Transform transform2 = transform.Find("Snapshot");
			IUIDummy snapShot = transform2.GetComponent("UIDummy") as IUIDummy;
			bool flag = info.roleBrief.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, snapShot);
				XSingleton<X3DAvatarMgr>.singleton.ResetMainAnimation();
			}
			else
			{
				XDummy xdummy = XSingleton<X3DAvatarMgr>.singleton.FindCreateCommonRoleDummy(this.m_dummPool, info.roleBrief.roleid, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(info.roleBrief.profession), info.roleBrief.outlook, snapShot, index);
				this._Avatars[index] = xdummy;
			}
		}

		private bool OnCreateOrMatchClicked(IXUIButton btn)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument2.GetExpeditionList(TeamLevelType.TeamLevelTeamLeague);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
			return true;
		}

		private bool OnQuitTeamLeagueClicked(IXUIButton btn)
		{
			string @string = XStringDefineProxy.GetString("TEAM_LEAGUE_QUIT_TIP");
			string string2 = XStringDefineProxy.GetString("COMMON_OK");
			string string3 = XStringDefineProxy.GetString("COMMON_CANCEL");
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnEnsureQuitTeamLeague), null);
			return true;
		}

		private bool OnEnsureQuitTeamLeague(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.ReqLeaveTeamLeague();
			return true;
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_TeamLeague);
			return true;
		}

		private bool OnShopBtnClicked(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		private void InitRankRewards()
		{
			base.uiBehaviour.RankListRoot.gameObject.SetActive(true);
			LeagueRankReward leagueRankRewardTable = XFreeTeamVersusLeagueDocument.LeagueRankRewardTable;
			base.uiBehaviour.rankWrapContent.SetContentCount(leagueRankRewardTable.Table.Length, false);
			base.uiBehaviour.rankScrollView.ResetPosition();
		}

		private void UpdateActivityRules()
		{
			base.uiBehaviour.ActivityRulesLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XFreeTeamVersusLeagueDocument.Doc.GetOpenInstructionString()));
		}

		private void InitTopRewards()
		{
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("LeagueTeamRewards", true);
			int i = 0;
			int num = Mathf.Min(base.uiBehaviour.RewardsRoot.childCount, (int)sequenceList.Count);
			while (i < num)
			{
				GameObject gameObject = base.uiBehaviour.RewardsRoot.GetChild(i).gameObject;
				gameObject.SetActive(true);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, sequenceList[i, 0], sequenceList[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)sequenceList[i, 0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				i++;
			}
			while (i < base.uiBehaviour.RewardsRoot.childCount)
			{
				base.uiBehaviour.RewardsRoot.GetChild(i).gameObject.SetActive(false);
				i++;
			}
		}

		private XDummy[] _Avatars;
	}
}
