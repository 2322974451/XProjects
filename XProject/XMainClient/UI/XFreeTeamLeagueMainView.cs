using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200173E RID: 5950
	internal class XFreeTeamLeagueMainView : DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>
	{
		// Token: 0x170037DC RID: 14300
		// (get) Token: 0x0600F5EA RID: 62954 RVA: 0x0037A7EC File Offset: 0x003789EC
		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueMain";
			}
		}

		// Token: 0x170037DD RID: 14301
		// (get) Token: 0x0600F5EB RID: 62955 RVA: 0x0037A804 File Offset: 0x00378A04
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037DE RID: 14302
		// (get) Token: 0x0600F5EC RID: 62956 RVA: 0x0037A818 File Offset: 0x00378A18
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037DF RID: 14303
		// (get) Token: 0x0600F5ED RID: 62957 RVA: 0x0037A82C File Offset: 0x00378A2C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037E0 RID: 14304
		// (get) Token: 0x0600F5EE RID: 62958 RVA: 0x0037A840 File Offset: 0x00378A40
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037E1 RID: 14305
		// (get) Token: 0x0600F5EF RID: 62959 RVA: 0x0037A854 File Offset: 0x00378A54
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037E2 RID: 14306
		// (get) Token: 0x0600F5F0 RID: 62960 RVA: 0x0037A868 File Offset: 0x00378A68
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F5F1 RID: 62961 RVA: 0x0037A87B File Offset: 0x00378A7B
		protected override void Init()
		{
			this.InitProperties();
			this.InitTopRewards();
		}

		// Token: 0x0600F5F2 RID: 62962 RVA: 0x0037A88C File Offset: 0x00378A8C
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F5F3 RID: 62963 RVA: 0x0037A896 File Offset: 0x00378A96
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F5F4 RID: 62964 RVA: 0x0037A8A0 File Offset: 0x00378AA0
		public override void StackRefresh()
		{
			base.StackRefresh();
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueBattleInfo();
		}

		// Token: 0x0600F5F5 RID: 62965 RVA: 0x0037A8B5 File Offset: 0x00378AB5
		protected override void OnShow()
		{
			base.OnShow();
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueBattleInfo();
			this.InitRankRewards();
			base.uiBehaviour.RankListRoot.gameObject.SetActive(false);
		}

		// Token: 0x0600F5F6 RID: 62966 RVA: 0x0037A8E8 File Offset: 0x00378AE8
		protected override void OnHide()
		{
			this.ClearState();
			base.OnHide();
		}

		// Token: 0x0600F5F7 RID: 62967 RVA: 0x0037A8F9 File Offset: 0x00378AF9
		public void RefreshUI()
		{
			this.UpdateActivityRules();
			this.UpdateTeamDetailInfo();
			this.UpdateRoleAvartars();
			this.UpdateActivityRewards();
			this.UpdateFinalResultFlag();
			this.RefreshMyRank();
		}

		// Token: 0x0600F5F8 RID: 62968 RVA: 0x0037A928 File Offset: 0x00378B28
		public void ClearState()
		{
			base.uiBehaviour.rankWrapContent.SetContentCount(0, false);
			base.uiBehaviour.MemberUIPool.ReturnAll(false);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			base.Return3DAvatarPool();
			this.ClearAvatarStates();
		}

		// Token: 0x0600F5F9 RID: 62969 RVA: 0x0037A978 File Offset: 0x00378B78
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

		// Token: 0x0600F5FA RID: 62970 RVA: 0x0037AABC File Offset: 0x00378CBC
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

		// Token: 0x0600F5FB RID: 62971 RVA: 0x0037AB80 File Offset: 0x00378D80
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

		// Token: 0x0600F5FC RID: 62972 RVA: 0x0037AC60 File Offset: 0x00378E60
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool activeSelf = base.uiBehaviour.RankListRoot.gameObject.activeSelf;
			if (activeSelf)
			{
				this.SetRewardLeftTime();
			}
		}

		// Token: 0x0600F5FD RID: 62973 RVA: 0x0037AC98 File Offset: 0x00378E98
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

		// Token: 0x0600F5FE RID: 62974 RVA: 0x0037AD3C File Offset: 0x00378F3C
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

		// Token: 0x0600F5FF RID: 62975 RVA: 0x0037AECC File Offset: 0x003790CC
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

		// Token: 0x0600F600 RID: 62976 RVA: 0x0037B130 File Offset: 0x00379330
		private bool OnFinalResultBtnClicked(IXUIButton button)
		{
			DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F601 RID: 62977 RVA: 0x0037B150 File Offset: 0x00379350
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

		// Token: 0x0600F602 RID: 62978 RVA: 0x0037B1A4 File Offset: 0x003793A4
		private bool OnRankBtnClicked(IXUIButton button)
		{
			DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>.singleton.SetVisibleWithAnimation(true, null);
			XRankDocument specificDocument = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
			specificDocument.ReqRankList(XRankType.LeagueTeamRank);
			return true;
		}

		// Token: 0x0600F603 RID: 62979 RVA: 0x0037B1D8 File Offset: 0x003793D8
		private bool OnRankRewardsBtnClicked(IXUIButton button)
		{
			base.uiBehaviour.RankListRoot.gameObject.SetActive(true);
			this.RefreshMyRank();
			return true;
		}

		// Token: 0x0600F604 RID: 62980 RVA: 0x0037B209 File Offset: 0x00379409
		private void OnCloseRankList(IXUISprite uiSprite)
		{
			base.uiBehaviour.RankListRoot.gameObject.SetActive(false);
		}

		// Token: 0x0600F605 RID: 62981 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void UpdateActivityRewards()
		{
		}

		// Token: 0x0600F606 RID: 62982 RVA: 0x0037B224 File Offset: 0x00379424
		private void UpdateFinalResultFlag()
		{
			IXUILabel ixuilabel = base.uiBehaviour.FinalResultBtn.gameObject.transform.Find("Type").GetComponent("XUILabel") as IXUILabel;
			string text = (XFreeTeamVersusLeagueDocument.Doc.EliStateType == LeagueEliType.LeagueEliType_Cross) ? XSingleton<XStringTable>.singleton.GetString("LeagueCrossSeverFight") : XSingleton<XStringTable>.singleton.GetString("LeagueEliminationResult");
			ixuilabel.SetText(text);
			base.uiBehaviour.FinalResultBtn.gameObject.SetActive(XFreeTeamVersusLeagueDocument.Doc.EliStateType != LeagueEliType.LeagueEliType_None);
		}

		// Token: 0x0600F607 RID: 62983 RVA: 0x0037B2C0 File Offset: 0x003794C0
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

		// Token: 0x0600F608 RID: 62984 RVA: 0x0037B2FC File Offset: 0x003794FC
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

		// Token: 0x0600F609 RID: 62985 RVA: 0x0037B464 File Offset: 0x00379664
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

		// Token: 0x0600F60A RID: 62986 RVA: 0x0037B4B8 File Offset: 0x003796B8
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

		// Token: 0x0600F60B RID: 62987 RVA: 0x0037B52C File Offset: 0x0037972C
		private bool OnEnsureQuitTeamLeague(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			specificDocument.ReqLeaveTeamLeague();
			return true;
		}

		// Token: 0x0600F60C RID: 62988 RVA: 0x0037B560 File Offset: 0x00379760
		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F60D RID: 62989 RVA: 0x0037B57C File Offset: 0x0037977C
		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_TeamLeague);
			return true;
		}

		// Token: 0x0600F60E RID: 62990 RVA: 0x0037B5A0 File Offset: 0x003797A0
		private bool OnShopBtnClicked(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		// Token: 0x0600F60F RID: 62991 RVA: 0x0037B5C8 File Offset: 0x003797C8
		private void InitRankRewards()
		{
			base.uiBehaviour.RankListRoot.gameObject.SetActive(true);
			LeagueRankReward leagueRankRewardTable = XFreeTeamVersusLeagueDocument.LeagueRankRewardTable;
			base.uiBehaviour.rankWrapContent.SetContentCount(leagueRankRewardTable.Table.Length, false);
			base.uiBehaviour.rankScrollView.ResetPosition();
		}

		// Token: 0x0600F610 RID: 62992 RVA: 0x0037B61E File Offset: 0x0037981E
		private void UpdateActivityRules()
		{
			base.uiBehaviour.ActivityRulesLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XFreeTeamVersusLeagueDocument.Doc.GetOpenInstructionString()));
		}

		// Token: 0x0600F611 RID: 62993 RVA: 0x0037B648 File Offset: 0x00379848
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

		// Token: 0x04006AB4 RID: 27316
		private XDummy[] _Avatars;
	}
}
