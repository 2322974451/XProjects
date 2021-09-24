using System;
using System.Collections.Generic;
using KKSG;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingView : DlgBase<XQualifyingView, XQualifyingBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/QualifierDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Qualifying);
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
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

		public override bool autoload
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
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (flag)
			{
				this._doc.CurrentSelect = 0;
			}
			base.uiBehaviour.m_NumberTween = XNumberTween.Create(base.uiBehaviour.m_WinOfPoint);
			base.uiBehaviour.m_NumberTween.tweenDuaration = 1.5f;
			this.m_handler = DlgHandlerBase.EnsureCreate<GuildQualifierHandler>(ref this.m_handler, base.uiBehaviour.m_Bg, false, null);
			DlgHandlerBase.EnsureCreate<BattleRecordHandler>(ref this.m_BattleRecord2V2Handler, base.uiBehaviour.m_BattleRecordFrame, null, false);
			this.SetRankTab();
			this.SetupTab();
		}

		public void RefreshGuildQualifier()
		{
			XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
			bool serverActive = specificDocument.ServerActive;
			if (serverActive)
			{
				bool flag = !this.m_handler.IsVisible();
				if (flag)
				{
					this.m_handler.SetVisible(true);
				}
				this.m_handler.RefreshData();
			}
			else
			{
				this.m_handler.SetVisible(false);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_UnOpen2V2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnUnOpenBtnClick));
			base.uiBehaviour.m_ShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClicked));
			base.uiBehaviour.m_RankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankBoardClicked));
			base.uiBehaviour.m_BattleRecordBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChallengeRecordClicked));
			base.uiBehaviour.m_TrainBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTrainClicked));
			base.uiBehaviour.m_PointRewardBtn.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnChestClicked));
			base.uiBehaviour.m_RankRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankRewardClicked));
			base.uiBehaviour.m_Match1V1Btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBeginMatchClicked));
			base.uiBehaviour.m_Match2V2Btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBeginMatchClicked));
			base.uiBehaviour.m_TeamBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTeamBtnClick));
			base.uiBehaviour.m_RankWindow.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankWindowCloseClicked));
			base.uiBehaviour.m_RankRewardWindow.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankRewardWindowCloseClicked));
			base.uiBehaviour.m_PointRewardWindow.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPointRewardWindowCloseClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Qualifying);
			return true;
		}

		private void OnUnOpenBtnClick(IXUISprite iSp)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PK2V2_NOT_IN_CITY"), "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL"), XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XSysDefine.XSys_Qualifying2)), "fece00");
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendQueryPKInfo();
			XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
			specificDocument.SendGuildLadderRankInfo();
			base.uiBehaviour.m_RankWindow.SetVisible(false);
			base.uiBehaviour.m_RankRewardWindow.SetVisible(false);
			base.uiBehaviour.m_PointRewardWindow.SetVisible(false);
			this.SetBeginMatchButton(XStringDefineProxy.GetString("BEGIN_MATCH"));
			this.Refresh(false);
			this.RefreshMatch2v2Btn();
			DlgBase<RandomGiftView, RandomGiftBehaviour>.singleton.TryOpenUI();
			base.uiBehaviour.m_UnOpen2V2.SetVisible(!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Qualifying2) || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall);
		}

		public void Refresh(bool isSwitch)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Current = ", this._doc.CurrentSelect.ToString(), null, null, null, null);
			this.SetupRankRewardFrame();
			this.SetupChallengeFrame(isSwitch);
		}

		private bool OnCloseClicked(IXUIButton button)
		{
			bool isMatching = this._doc.IsMatching;
			if (isMatching)
			{
				this._doc.SendEndMatch();
			}
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SetVisibleWithAnimation(false, null);
			}
			else
			{
				XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
				specificDocument.SendLeaveScene();
			}
			return true;
		}

		private bool OnRankWindowCloseClicked(IXUIButton button)
		{
			base.uiBehaviour.m_RankWindow.SetVisible(false);
			return true;
		}

		private bool OnRankRewardWindowCloseClicked(IXUIButton button)
		{
			base.uiBehaviour.m_RankRewardWindow.SetVisible(false);
			return true;
		}

		private bool OnPointRewardWindowCloseClicked(IXUIButton button)
		{
			base.uiBehaviour.m_PointRewardWindow.SetVisible(false);
			return true;
		}

		private bool OnBeginMatchClicked(IXUIButton button)
		{
			bool flag = this._doc.CurrentSelect == 0;
			bool flag2;
			if (flag)
			{
				flag2 = this._doc.IsMatching;
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				flag2 = (specificDocument.SoloMatchType == KMatchType.KMT_PKTWO);
			}
			bool flag3 = !flag2;
			if (flag3)
			{
				bool flag4 = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnBeginMatchClicked), button);
				if (flag4)
				{
					return true;
				}
				this._doc.SendBeginMatch();
			}
			else
			{
				this._doc.SendEndMatch();
			}
			return true;
		}

		private void SetupTab()
		{
			base.uiBehaviour.m_TabPool.ReturnAll(false);
			GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
			IXUICheckBox ixuicheckBox = gameObject.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ID = 0UL;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			IXUILabel ixuilabel = gameObject.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = gameObject.transform.Find("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<XGameSysMgr>.singleton.GetSystemName(XSysDefine.XSys_Qualifying));
			ixuilabel2.SetText(XSingleton<XGameSysMgr>.singleton.GetSystemName(XSysDefine.XSys_Qualifying));
			ixuicheckBox.bChecked = (this._doc.CurrentSelect == 0);
		}

		private bool OnTabClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this._doc.CurrentSelect != (int)icb.ID;
				if (flag2)
				{
					base.uiBehaviour.m_FxFireworkGo.SetActive(false);
					this._doc.SetCurrentSys((int)icb.ID);
				}
				result = true;
			}
			return result;
		}

		private bool OnTeamBtnClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelMultiPK);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
			return true;
		}

		private bool OnTrainClicked(IXUIButton button)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue("QualifierTrainURL");
			dictionary["screendir"] = "SENSOR";
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize(dictionary));
			return true;
		}

		private bool OnShopClicked(IXUIButton button)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		private bool OnRankRewardClicked(IXUIButton button)
		{
			base.uiBehaviour.m_RankRewardWindow.SetVisible(true);
			this.SetupRankRewardWindow();
			return true;
		}

		private bool OnChallengeRecordClicked(IXUIButton button)
		{
			bool flag = this._doc.CurrentSelect == 0;
			if (flag)
			{
				bool flag2 = this.m_QualifyingRecordsHandler == null;
				if (flag2)
				{
					DlgHandlerBase.EnsureCreate<XQualifyingRecordsHandler>(ref this.m_QualifyingRecordsHandler, base.uiBehaviour.m_Bg, true, this);
				}
				this.m_QualifyingRecordsHandler.WinCount = this._doc.MatchTotalWin;
				this.m_QualifyingRecordsHandler.DrawCount = this._doc.MatchTotalDraw;
				this.m_QualifyingRecordsHandler.LoseCount = this._doc.MatchTotalLose;
				this.m_QualifyingRecordsHandler.ContinueWin = this._doc.ContinueWin;
				this.m_QualifyingRecordsHandler.ContinueLose = this._doc.ContinueLose;
				this.m_QualifyingRecordsHandler.ProfessionWin = this._doc.ProfessionWin;
				this.m_QualifyingRecordsHandler.GameRecords = this._doc.GameRecords;
				this.m_QualifyingRecordsHandler.Refresh();
			}
			else
			{
				this.m_BattleRecord2V2Handler.SetupRecord(this._doc.GameRecords2V2);
			}
			return true;
		}

		private bool OnRankBoardClicked(IXUIButton button)
		{
			bool flag = this._doc.RankList.Count == 0;
			if (flag)
			{
				for (int i = 0; i <= XGame.RoleCount; i++)
				{
					List<QualifyingRankInfo> item = new List<QualifyingRankInfo>();
					this._doc.RankList.Add(item);
				}
			}
			this._doc.SendQueryRankInfo(0U);
			base.uiBehaviour.m_RankWindow.SetVisible(true);
			this.SetupRankWindow(this._doc.RankList[0]);
			base.uiBehaviour.m_RankTypeAll.ForceSetFlag(true);
			List<GameObject> list = ListPool<GameObject>.Get();
			base.uiBehaviour.m_RankTabPool.GetActiveList(list);
			for (int j = 0; j < list.Count; j++)
			{
				IXUICheckBox ixuicheckBox = list[j].transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag2 = ixuicheckBox.ID > 0UL;
				if (flag2)
				{
					ixuicheckBox.SetVisible(this._doc.CurrentSelect == 0);
				}
			}
			return true;
		}

		private void OnChestClicked(IXUITexture sp)
		{
			base.uiBehaviour.m_PointRewardWindow.SetVisible(true);
			this.SetupPointRewardWindow(true);
		}

		private bool OnPointRewardTplClick(IXUIButton button)
		{
			this._doc.SendFetchPointReward((uint)button.ID);
			return true;
		}

		private void OnRankItemClicked(IXUILabel label)
		{
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
		}

		private bool OnRankTabClicked(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._doc.SendQueryRankInfo((uint)checkBox.ID);
				this.SetupRankWindow(this._doc.RankList[(int)checkBox.ID]);
				result = true;
			}
			return result;
		}

		private void SetRankTab()
		{
			base.uiBehaviour.m_RankTabPool.SetupPool(base.uiBehaviour.m_RankWindow.m_TabTpl.transform.parent.gameObject, base.uiBehaviour.m_RankWindow.m_TabTpl, 5U, false);
			base.uiBehaviour.m_RankTabPool.ReturnAll(false);
			GameObject gameObject = base.uiBehaviour.m_RankTabPool.FetchGameObject(false);
			IXUICheckBox ixuicheckBox = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
			base.uiBehaviour.m_RankTypeAll = ixuicheckBox;
			ixuicheckBox.ID = 0UL;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRankTabClicked));
			for (int i = 0; i < XGame.RoleCount; i++)
			{
				string profName = XSingleton<XProfessionSkillMgr>.singleton.GetProfName(i + 1);
				GameObject gameObject2 = base.uiBehaviour.m_RankTabPool.FetchGameObject(false);
				gameObject2.transform.localPosition -= new Vector3(0f, (float)(base.uiBehaviour.m_RankTabPool.TplHeight * (i + 1)), 0f);
				ixuicheckBox = (gameObject2.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				ixuicheckBox.ID = (ulong)((long)i + 1L);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRankTabClicked));
				IXUILabel ixuilabel = gameObject2.transform.FindChild("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(profName);
				IXUILabel ixuilabel2 = gameObject2.transform.FindChild("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(profName);
			}
		}

		public void SetupRankWindow(List<QualifyingRankInfo> list)
		{
			base.uiBehaviour.m_RankWindow.m_RolePool.FakeReturnAll();
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RankWindow.m_RolePool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Bg/Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Bg/Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = gameObject.transform.FindChild("Bg/Point").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Bg/RankImage").GetComponent("XUISprite") as IXUISprite;
				bool flag = list[i].rank > 3U;
				if (flag)
				{
					ixuilabel.SetText(string.Format("No.{0}", list[i].rank));
				}
				else
				{
					ixuilabel.SetText("");
				}
				ixuilabel2.SetText(string.Format("Lv.{0}", list[i].level));
				ixuilabel3.SetText(list[i].name);
				ixuilabel4.SetText(list[i].point.ToString());
				ixuisprite.SetSprite(string.Format("N{0}", list[i].rank));
				ixuilabel3.ID = list[i].uid;
				bool flag2 = list[i].uid == 0UL;
				if (flag2)
				{
					ixuilabel3.RegisterLabelClickEventHandler(null);
				}
				else
				{
					ixuilabel3.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnRankItemClicked));
				}
				gameObject.transform.localPosition = base.uiBehaviour.m_RankWindow.m_RolePool.TplPos - new Vector3(0f, (float)(i * base.uiBehaviour.m_RankWindow.m_RolePool.TplHeight));
			}
			base.uiBehaviour.m_RankWindow.m_RolePool.ActualReturnAll(false);
			base.uiBehaviour.m_RankWindow.m_ScrollView.ResetPosition();
		}

		public void SetupPointRewardWindow(bool resetPos = true)
		{
			base.uiBehaviour.m_PointRewardWindow.m_CurrentPoint.SetText(this._doc.WinOfPoint.ToString());
			Vector3 tplPos = base.uiBehaviour.m_PointRewardWindow.m_RewardPool.TplPos;
			base.uiBehaviour.m_PointRewardWindow.m_RewardPool.FakeReturnAll();
			base.uiBehaviour.m_PointRewardWindow.m_ItemPool.FakeReturnAll();
			List<int> list = new List<int>();
			for (int i = 0; i < this._doc.PointRewardList.Count; i++)
			{
				list.Add(i);
			}
			list.Sort(new Comparison<int>(this._doc.PointRewardCompare));
			for (int j = 0; j < this._doc.PointRewardList.Count; j++)
			{
				GameObject gameObject = base.uiBehaviour.m_PointRewardWindow.m_RewardPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Point/Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this._doc.PointRewardList[list[j]].point.ToString());
				for (int k = 0; k < this._doc.PointRewardList[list[j]].reward.Count; k++)
				{
					GameObject gameObject2 = base.uiBehaviour.m_PointRewardWindow.m_ItemPool.FetchGameObject(false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)this._doc.PointRewardList[list[j]].reward[k, 0], (int)this._doc.PointRewardList[list[j]].reward[k, 1], false);
					IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)this._doc.PointRewardList[list[j]].reward[k, 0];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					gameObject2.transform.parent = gameObject.transform;
					gameObject2.transform.localPosition = new Vector3(base.uiBehaviour.m_PointRewardWindow.m_ItemPool.TplPos.x - base.uiBehaviour.m_PointRewardWindow.m_RewardPool.TplPos.x + (float)(base.uiBehaviour.m_PointRewardWindow.m_ItemPool.TplWidth * k), 0f);
				}
				gameObject.transform.localPosition = base.uiBehaviour.m_PointRewardWindow.m_RewardPool.TplPos - new Vector3(0f, (float)(base.uiBehaviour.m_PointRewardWindow.m_RewardPool.TplHeight * j));
				GameObject gameObject3 = gameObject.transform.FindChild("Bg/Tip").gameObject;
				GameObject gameObject4 = gameObject.transform.FindChild("Bg/Reach").gameObject;
				GameObject gameObject5 = gameObject.transform.FindChild("Bg/UnReach").gameObject;
				IXUIButton ixuibutton = gameObject.transform.FindChild("Bg/Button").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)list[j];
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPointRewardTplClick));
				uint status = this._doc.PointRewardList[list[j]].status;
				gameObject5.SetActive(status == 0U);
				gameObject3.SetActive(status == 1U);
				gameObject4.SetActive(status == 2U);
				ixuibutton.SetVisible(status == 1U);
			}
			base.uiBehaviour.m_PointRewardWindow.m_ItemPool.ActualReturnAll(false);
			base.uiBehaviour.m_PointRewardWindow.m_RewardPool.ActualReturnAll(false);
			if (resetPos)
			{
				base.uiBehaviour.m_PointRewardWindow.m_ScrollView.ResetPosition();
			}
		}

		public void SetupRankRewardWindow()
		{
			bool flag = this._doc.MatchRank == uint.MaxValue || this._doc.MatchRank > this._doc.MaxRewardRank;
			if (flag)
			{
				base.uiBehaviour.m_RankRewardWindow.m_RankNum.SetText(this._doc.MaxRewardRank + XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc3"));
			}
			else
			{
				base.uiBehaviour.m_RankRewardWindow.m_RankNum.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), this._doc.MatchRank));
			}
			Vector3 tplPos = base.uiBehaviour.m_RankRewardWindow.m_RewardPool.TplPos;
			base.uiBehaviour.m_RankRewardWindow.m_RewardPool.FakeReturnAll();
			base.uiBehaviour.m_RankRewardWindow.m_ItemPool.FakeReturnAll();
			for (int i = 0; i < this._doc.RankRewardList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RankRewardWindow.m_RewardPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Rank/RankNum").GetComponent("XUILabel") as IXUILabel;
				bool isRange = this._doc.RankRewardList[i].isRange;
				if (isRange)
				{
					ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc2"), this._doc.RankRewardList[i].rank));
				}
				else
				{
					ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), this._doc.RankRewardList[i].rank));
				}
				for (int j = 0; j < this._doc.RankRewardList[i].reward.Count; j++)
				{
					GameObject gameObject2 = base.uiBehaviour.m_RankRewardWindow.m_ItemPool.FetchGameObject(false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)this._doc.RankRewardList[i].reward[j, 0], (int)this._doc.RankRewardList[i].reward[j, 1], false);
					IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)this._doc.RankRewardList[i].reward[j, 0];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					gameObject2.transform.parent = gameObject.transform;
					gameObject2.transform.localPosition = new Vector3(base.uiBehaviour.m_RankRewardWindow.m_ItemPool.TplPos.x + (float)(base.uiBehaviour.m_RankRewardWindow.m_ItemPool.TplWidth * j), 0f);
				}
				gameObject.transform.localPosition = base.uiBehaviour.m_RankRewardWindow.m_RewardPool.TplPos - new Vector3(0f, (float)(base.uiBehaviour.m_RankRewardWindow.m_RewardPool.TplHeight * i));
			}
			base.uiBehaviour.m_RankRewardWindow.m_ItemPool.ActualReturnAll(false);
			base.uiBehaviour.m_RankRewardWindow.m_RewardPool.ActualReturnAll(false);
			base.uiBehaviour.m_RankRewardWindow.m_ScrollView.ResetPosition();
		}

		public void SetupRankRewardFrame()
		{
			base.uiBehaviour.m_TotalRecords.SetText(this._doc.MatchTotalCount.ToString());
			uint num = (this._doc.RankRewardLeftTime + 14400U) / 604800U;
			bool flag = num > 0U;
			if (flag)
			{
				base.uiBehaviour.m_RankEndTips.SetText(string.Format(XStringDefineProxy.GetString("QualityingRankRewardEndTips1"), num));
			}
			else
			{
				base.uiBehaviour.m_RankEndTips.SetText(XStringDefineProxy.GetString("QualityingRankRewardEndTips2"));
			}
			base.uiBehaviour.m_WinRecord.SetText(this._doc.MatchTotalWin.ToString());
			base.uiBehaviour.m_LoseRecord.SetText(this._doc.MatchTotalLose.ToString());
			base.uiBehaviour.m_WinRate.SetText(string.Format("{0}%", this._doc.MatchTotalPercent));
			bool flag2 = this._doc.MatchRank == uint.MaxValue || this._doc.MatchRank > this._doc.MaxRewardRank;
			if (flag2)
			{
				base.uiBehaviour.m_CurrentRank.SetText(string.Format("{0}{1}", this._doc.MaxRewardRank, XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc3")));
			}
			else
			{
				base.uiBehaviour.m_CurrentRank.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), this._doc.MatchRank));
			}
		}

		public void SetupChallengeFrame(bool isSwitch)
		{
			base.uiBehaviour.m_Match1V1Btn.SetVisible(this._doc.CurrentSelect == 0);
			base.uiBehaviour.m_Match2V2Btn.SetVisible(this._doc.CurrentSelect != 0);
			base.uiBehaviour.m_TeamBtn.SetVisible(this._doc.CurrentSelect != 0);
			base.uiBehaviour.m_ChallengeTip.SetVisible(this._doc.CurrentSelect == 0);
			this._texStr1 = "atlas/UI/common/Pic/" + string.Format("jjc-bx-{0}", this._doc.GetIconIndex(this._doc.WinOfPoint));
			base.uiBehaviour.m_PointRewardBtn.SetTexturePath(this._texStr1);
			this._texStr2 = "atlas/UI/common/Pic/" + string.Format("tts_{0}", this._doc.GetIconIndex(this._doc.WinOfPoint));
			base.uiBehaviour.m_Tier.SetTexturePath(this._texStr2);
			base.uiBehaviour.m_PointRewardRedPoint.gameObject.SetActive(this._doc.RedPoint);
			bool flag = (ulong)this._doc.WinOfPoint == (ulong)((long)this._doc.LastWinOfPoint) || Mathf.Abs((float)((ulong)this._doc.WinOfPoint - (ulong)((long)this._doc.LastWinOfPoint))) > 500f;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.SetVirtualItem(base.uiBehaviour.m_NumberTween, (ulong)this._doc.WinOfPoint, false, "");
				this._doc.LastWinOfPoint = (int)this._doc.WinOfPoint;
			}
			else
			{
				bool flag2 = (ulong)this._doc.WinOfPoint > (ulong)((long)this._doc.LastWinOfPoint);
				if (flag2)
				{
					this._fxTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.DelayParticlePlay), null);
				}
				if (isSwitch)
				{
					XSingleton<UiUtility>.singleton.SetVirtualItem(base.uiBehaviour.m_NumberTween, (ulong)((long)this._doc.LastWinOfPoint), false, "");
				}
				this._numTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.DelaySetVirtualItem), null);
				this._doc.LastWinOfPoint = (int)this._doc.WinOfPoint;
			}
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("QualifyingFirstRewardCount");
			base.uiBehaviour.m_ChallengeTipText.SetText(string.Format(XStringDefineProxy.GetString("MATCH_FIRST_REWARD", new object[]
			{
				@int
			}), new object[0]));
			int num = Mathf.Max(@int - (int)this._doc.LeftFirstRewardCount, 0);
			base.uiBehaviour.m_ChallengeTip.InputText = string.Format("{0} ({1}/{2})", XStringDefineProxy.GetString("MATCH_FIRST_REWARD_ICON"), num, @int);
		}

		private void DelayParticlePlay(object e)
		{
			base.uiBehaviour.m_FxFireworkGo.SetActive(false);
			base.uiBehaviour.m_FxFireworkGo.SetActive(true);
		}

		private void DelaySetVirtualItem(object e)
		{
			XSingleton<UiUtility>.singleton.SetVirtualItem(base.uiBehaviour.m_NumberTween, (ulong)this._doc.WinOfPoint, true, "");
		}

		public void RefreshMatch2v2Btn()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			base.uiBehaviour.m_Match2V2BtnLabel.SetText((specificDocument.SoloMatchType == KMatchType.KMT_PKTWO) ? string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")) : XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"));
			base.uiBehaviour.m_TeamBtn.SetEnable(specificDocument.SoloMatchType != KMatchType.KMT_PKTWO, false);
		}

		public void SetBeginMatchButton(string str)
		{
			base.uiBehaviour.m_Match1V1BtnLabel.SetText(str);
		}

		public void setRewardLeftTime()
		{
			int totalSecond = (int)(this._doc.RankRewardLeftTime - Time.time + this._doc.RewardSignTime);
			base.uiBehaviour.m_RankRewardWindow.m_RewardLeftTime.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString(totalSecond, 4));
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_handler != null;
			if (flag)
			{
				this.m_handler.SetVisible(false);
			}
			base.uiBehaviour.m_PointRewardBtn.SetTexturePath("");
			base.uiBehaviour.m_Tier.SetTexturePath("");
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fxTimeToken);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._numTimeToken);
			base.uiBehaviour.m_FxFireworkGo.SetActive(false);
		}

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			base.uiBehaviour.m_FxFireworkGo.SetActive(false);
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<GuildQualifierHandler>(ref this.m_handler);
			DlgHandlerBase.EnsureUnload<XQualifyingRecordsHandler>(ref this.m_QualifyingRecordsHandler);
			DlgHandlerBase.EnsureUnload<BattleRecordHandler>(ref this.m_BattleRecord2V2Handler);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fxTimeToken);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._numTimeToken);
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_handler != null && this.m_handler.IsVisible();
			if (flag)
			{
				this.m_handler.OnUpdate();
			}
			bool flag2 = this._doc != null && this._doc.IsMatching;
			if (flag2)
			{
				this._doc.SetMatchButtonTime();
			}
			bool flag3 = base.uiBehaviour.m_RankRewardWindow.m_Go.activeInHierarchy && this._doc.RankRewardLeftTime > 0U;
			if (flag3)
			{
				this.setRewardLeftTime();
			}
		}

		private XQualifyingDocument _doc = null;

		private uint _numTimeToken;

		private uint _fxTimeToken;

		private string _texStr1;

		private string _texStr2;

		private GuildQualifierHandler m_handler;

		private XQualifyingRecordsHandler m_QualifyingRecordsHandler = null;

		private BattleRecordHandler m_BattleRecord2V2Handler = null;
	}
}
