using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	[Hotfix]
	internal class ActivityRiftDlg : DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/TeamMysteriousDlg";
			}
		}

		public override int layer
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

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.xSys_Mysterious);
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._doc.TeamMysteriourView = this;
			this._mdoc = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_RankRewardWindow = new XQualifyingRankRewardWindow(base.uiBehaviour.m_frameRankRwd);
			this.m_WeekFirstPassWindow = new XQualifyingPointRewardWindow(base.uiBehaviour.m_frameWeek);
			this.m_WelfareWindow = new XQualifyingPointRewardWindow(base.uiBehaviour.m_frameWelfare);
			DlgHandlerBase.EnsureCreate<ActivityRiftItemsHandler>(ref this._itemListHandler, base.uiBehaviour.transform, false, null);
			base.uiBehaviour.m_guildInfoPanel.SetActive(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mMainClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_btnFight.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFightClick));
			base.uiBehaviour.m_btnShop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClick));
			base.uiBehaviour.m_btnIntro.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnIntroClick));
			base.uiBehaviour.m_btnMember.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMemberClick));
			base.uiBehaviour.m_btnRwd.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdClick));
			int i = 0;
			int num = base.uiBehaviour.m_tabs.Length;
			while (i < num)
			{
				base.uiBehaviour.m_tabs[i].ID = (ulong)((long)i);
				base.uiBehaviour.m_tabs[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRwdTabClick));
				i++;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_tab.gameObject.SetActive(false);
			this.CloseAllRwd();
			this.m_RankRewardWindow.SetVisible(false);
			this.m_WeekFirstPassWindow.SetVisible(false);
			base.uiBehaviour.m_lbldesc.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("RIFT_SYSTEM_HELP")));
			base.uiBehaviour.m_btnShop.gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Mall_Rift));
			base.uiBehaviour.m_lbltip.SetVisible(false);
			this._mdoc.ReqMyRiftInfo();
			this._mdoc.ReqFirstPassRwd(RiftFirstPassOpType.Rift_FirstPass_Op_GetInfo, 0U);
			this._mdoc.ReqRankSelf();
		}

		public void Refresh()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("RiftRewardWeekLimitOpen");
			bool flag = @int == 1;
			base.uiBehaviour.m_lbltime.SetVisible(flag);
			base.uiBehaviour.m_weekRwd.SetActive(!flag);
			this._mdoc.CulFirstPass();
			this._mdoc.ReculRankList();
			bool flag2 = !flag;
			if (flag2)
			{
				this.RefreshWeekRwd(base.uiBehaviour.m_weekRwd.transform);
			}
			base.uiBehaviour.m_lbltime.SetText(XStringDefineProxy.GetString("RiftTimeString"));
			string text = this._mdoc.currFloor.ToString();
			base.uiBehaviour.m_lblMFloor.SetText(text);
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._mdoc.sceneid);
			bool flag3 = sceneData != null;
			if (flag3)
			{
				base.uiBehaviour.m_lblMName.SetText(sceneData.Comment);
				bool flag4 = this._mdoc.currRiftRow != null;
				if (flag4)
				{
					base.uiBehaviour.m_lblFight.SetText(this._mdoc.currRiftRow.RecommendPower.ToString());
				}
				else
				{
					base.uiBehaviour.m_lblFight.SetText(sceneData.RecommendPower.ToString());
				}
				for (int i = 0; i < (int)sceneData.LoseCondition.count; i++)
				{
					bool flag5 = sceneData.LoseCondition[i, 0] == 3;
					if (flag5)
					{
						int num = sceneData.LoseCondition[i, 1];
						base.uiBehaviour.m_lbblMTime.SetText(this.TranNum2Date(num));
					}
				}
			}
			this.RefreshFloorRwd();
			this.RefreshBuff();
			this.RefreshRwdOpen();
		}

		private string TranNum2Date(int num)
		{
			int num2 = num / 60;
			int num3 = num % 60;
			return num2.ToString("D2") + ":" + num3.ToString("D2");
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ActivityRiftItemsHandler>(ref this._itemListHandler);
			DlgHandlerBase.EnsureUnload<ActivityRiftGuidInfoHandler>(ref this._guildinfoHandler);
			this.m_WeekFirstPassWindow = null;
			this.m_RankRewardWindow = null;
			base.OnUnload();
		}

		private void RefreshRwdOpen()
		{
			bool active = XSingleton<XGlobalConfig>.singleton.GetInt("RiftGuaranteeAwardShowOpen") == 1;
			base.uiBehaviour.m_tabs[2].gameObject.SetActive(active);
		}

		public void RefreshRed()
		{
			base.uiBehaviour.m_sprRwdRed.SetVisible(this._mdoc.hasNewFirstPass);
			base.uiBehaviour.m_reds[0].SetVisible(this._mdoc.hasNewFirstPass);
			base.uiBehaviour.m_reds[1].SetVisible(false);
			base.uiBehaviour.m_reds[2].SetVisible(false);
		}

		private void RefreshWeekRwd(Transform t)
		{
			IXUIProgress ixuiprogress = t.FindChild("Icon1/Progress Bar").GetComponent("XUIProgress") as IXUIProgress;
			IXUIProgress ixuiprogress2 = t.FindChild("Icon2/Progress Bar").GetComponent("XUIProgress") as IXUIProgress;
			IXUILabel ixuilabel = t.FindChild("Icon1/value").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.FindChild("Icon2/value").GetComponent("XUILabel") as IXUILabel;
			bool flag = this._mdoc.items != null && this._mdoc.items.Count > 0;
			if (flag)
			{
				ixuilabel.SetText(this._mdoc.items[0].key + "/" + this._mdoc.items[0].value);
				ixuilabel2.SetText(this._mdoc.items[1].key + "/" + this._mdoc.items[1].value);
				ixuiprogress.value = this._mdoc.items[0].key / this._mdoc.items[0].value;
				ixuiprogress2.value = this._mdoc.items[1].key / this._mdoc.items[1].value;
			}
			else
			{
				SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("RiftRewardWeekLimit", true);
				ixuilabel.SetText(0 + "/" + sequenceList[0, 1]);
				ixuilabel2.SetText(0 + "/" + sequenceList[1, 0]);
				ixuiprogress.value = 0f / (float)sequenceList[0, 1];
				ixuiprogress2.value = 0f / (float)sequenceList[1, 1];
			}
		}

		private bool OnRwdTabClick(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				this.OnRwdSelect(box.ID);
			}
			return true;
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.xSys_Mysterious);
			return true;
		}

		private bool OnCloseDlg(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnFightClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("OnFightClick", null, null, null, null, null, XDebugColor.XDebug_None);
			List<ExpeditionTable.RowData> expeditionList = this._doc.GetExpeditionList(TeamLevelType.TeamLevelRift);
			int dnexpeditionID = expeditionList[0].DNExpeditionID;
			ExpeditionTable.RowData expeditionDataByID = this._doc.GetExpeditionDataByID(dnexpeditionID);
			float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SceneGotoPower"));
			bool flag = XSingleton<PPTCheckMgr>.singleton.CheckMyPPT(Mathf.FloorToInt(expeditionDataByID.DisplayPPT * num));
			if (flag)
			{
				this.OnRealEnter(dnexpeditionID);
			}
			else
			{
				XSingleton<PPTCheckMgr>.singleton.ShowPPTNotEnoughDlg((ulong)((long)dnexpeditionID), new ButtonClickEventHandler(this.OnRealEnterClicked));
			}
			return true;
		}

		private bool OnRealEnterClicked(IXUIButton go)
		{
			this.OnRealEnter((int)go.ID);
			return true;
		}

		private void OnRealEnter(int id)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(id);
		}

		private bool OnShopClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Rift, 0UL);
			return true;
		}

		private bool OnMemberClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("onguildinfo click", null, null, null, null, null, XDebugColor.XDebug_None);
			this._mdoc.ReqGuildRank();
			return true;
		}

		public void OpenGuildInfoHanlder()
		{
			DlgHandlerBase.EnsureCreate<ActivityRiftGuidInfoHandler>(ref this._guildinfoHandler, base.uiBehaviour.m_guildInfoPanel, this, true);
		}

		private bool OnIntroClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("OnIntroClick", null, null, null, null, null, XDebugColor.XDebug_None);
			DlgHandlerBase.EnsureCreate<ActivityRiftItemsHandler>(ref this._itemListHandler, base.uiBehaviour.transform, false, null);
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("RiftAffixID", false);
			PandoraDocument specificDocument = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
			specificDocument.GetShowItemList((uint)sequenceList[this._mdoc.currRift, 1]);
			this._itemListHandler.ShowItemList(PandoraDocument.ItemList);
			return true;
		}

		private bool OnRwdClick(IXUIButton btn)
		{
			base.uiBehaviour.m_tab.gameObject.SetActive(true);
			base.uiBehaviour.m_tabs[0].bChecked = true;
			this.OnRwdSelect(0UL);
			return true;
		}

		private void OnRwdSelect(ulong index)
		{
			this.CloseAllRwd();
			this.RefreshRed();
			bool flag = index == 0UL;
			if (flag)
			{
				this.m_WeekFirstPassWindow.SetVisible(true);
				this.RefreshFirstPassRift();
			}
			bool flag2 = index == 1UL;
			if (flag2)
			{
				this.m_RankRewardWindow.SetVisible(true);
				this.RefreshRankRwd();
			}
			bool flag3 = index == 2UL;
			if (flag3)
			{
				this.m_WelfareWindow.SetVisible(true);
				this.RefreshWelfare();
			}
		}

		private void CloseAllRwd()
		{
			this.m_RankRewardWindow.SetVisible(false);
			this.m_WelfareWindow.SetVisible(false);
			this.m_WeekFirstPassWindow.SetVisible(false);
		}

		private void RefreshFloorRwd()
		{
			bool flag = this._mdoc != null && this._mdoc.currRiftRow != null;
			if (flag)
			{
				int count = (int)this._mdoc.currRiftRow.weekfirstpass.count;
				for (int i = 0; i < count; i++)
				{
					base.uiBehaviour.m_goRwd[i].SetActive(true);
					uint num = this._mdoc.currRiftRow.weekfirstpass[i, 0];
					uint itemCount = this._mdoc.currRiftRow.weekfirstpass[i, 1];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_goRwd[i], (int)num, (int)itemCount, false);
					IXUISprite ixuisprite = base.uiBehaviour.m_goRwd[i].transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)num;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				for (int j = count; j < base.uiBehaviour.m_goRwd.Length; j++)
				{
					base.uiBehaviour.m_goRwd[j].SetActive(false);
				}
			}
		}

		private void RefreshBuff()
		{
			Rift.RowData currRiftRow = this._mdoc.currRiftRow;
			this.RefreshBuff(base.uiBehaviour.m_goBuff[0], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftAttr"), currRiftRow.attack + "%");
			this.RefreshBuff(base.uiBehaviour.m_goBuff[1], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftHP"), currRiftRow.hp + "%");
			bool flag = this._mdoc != null && this._mdoc.currRiftRow != null;
			if (flag)
			{
				int num = this._mdoc.buffIDS.Count + 2;
				for (int i = 2; i < num; i++)
				{
					RiftBuffSuitMonsterType.RowData buffSuitRow = this._mdoc.GetBuffSuitRow((uint)this._mdoc.buffIDS[i - 2], this._mdoc.buffLevels[i - 2]);
					base.uiBehaviour.m_goBuff[i].SetActive(true);
					this.RefreshBuff(base.uiBehaviour.m_goBuff[i], buffSuitRow.atlas, buffSuitRow.icon, string.Empty);
					IXUISprite ixuisprite = base.uiBehaviour.m_goBuff[i].transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)(i - 2));
					ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnBuffPress));
				}
				for (int j = num; j < base.uiBehaviour.m_goBuff.Length; j++)
				{
					base.uiBehaviour.m_goBuff[j].SetActive(false);
				}
			}
		}

		private bool OnBuffPress(IXUISprite spr, bool ispress)
		{
			int index = (int)spr.ID;
			RiftBuffSuitMonsterType.RowData buffSuitRow = this._mdoc.GetBuffSuitRow((uint)this._mdoc.buffIDS[index], this._mdoc.buffLevels[index]);
			base.uiBehaviour.m_lbltip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(buffSuitRow.scription));
			base.uiBehaviour.m_lbltip.SetVisible(ispress);
			return true;
		}

		private void RefreshBuff(GameObject go, string atlas, string sp, string text)
		{
			IXUILabel ixuilabel = go.transform.FindChild("value").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(text));
			bool flag = string.IsNullOrEmpty(atlas);
			if (flag)
			{
				ixuisprite.SetSprite(sp);
			}
			else
			{
				ixuisprite.SetSprite(sp, atlas, false);
			}
		}

		private void RefreshWelfare()
		{
			this._mdoc.CulWelfare();
			this.RefreshRwd(this.m_WelfareWindow, this._mdoc.WelfareList, true);
			IXUILabel ixuilabel = base.uiBehaviour.m_frameWelfare.transform.FindChild("Bg/CurrentPoint/Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(this._mdoc.all_finish ? this._mdoc.currFloor.ToString() : (this._mdoc.currFloor - 1).ToString());
		}

		public void RefreshFirstPassRift()
		{
			this.RefreshRwd(this.m_WeekFirstPassWindow, this._mdoc.WeekFirstPassList, true);
			IXUILabel ixuilabel = base.uiBehaviour.m_frameWeek.transform.FindChild("Bg/LeftTime").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(this._mdoc.all_finish ? this._mdoc.currFloor.ToString() : (this._mdoc.currFloor - 1).ToString());
		}

		private void RefreshRwd(XQualifyingPointRewardWindow window, List<PointRewardStatus> list, bool resetPos)
		{
			window.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdCloseClicked));
			Vector3 tplPos = window.m_RewardPool.TplPos;
			window.m_RewardPool.FakeReturnAll();
			window.m_ItemPool.FakeReturnAll();
			list.Sort(new Comparison<PointRewardStatus>(this._mdoc.RewardCompare));
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = window.m_RewardPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Point/Num").GetComponent("XUILabel") as IXUILabel;
				uint point = list[i].point;
				ixuilabel.SetText(point.ToString());
				Transform transform = gameObject.transform.FindChild("Bg/Tip");
				bool flag = transform != null;
				if (flag)
				{
					IXUILabel ixuilabel2 = transform.GetComponent("XUILabel") as IXUILabel;
					IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
					ixuilabel2.ID = (ulong)list[i].point;
					ixuilabel2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnClaimFirstpassClick));
					GameObject gameObject2 = transform.Find("redp").gameObject;
					uint status = list[i].status;
					gameObject2.SetActive(status == 3U);
					bool flag2 = status == 3U;
					if (flag2)
					{
						ixuilabel2.SetText(XStringDefineProxy.GetString("SRS_FETCH"));
					}
					bool flag3 = status == 2U;
					if (flag3)
					{
						ixuilabel2.SetText(XStringDefineProxy.GetString("LEVEL_CHALLENGE_FINISH"));
					}
					else
					{
						bool flag4 = status == 1U;
						if (flag4)
						{
							ixuilabel2.SetText(XStringDefineProxy.GetString("CAREER_TROPHY_UNREACH"));
						}
						else
						{
							bool flag5 = status == 0U;
							if (flag5)
							{
								ixuilabel2.SetText(XStringDefineProxy.GetString("SRS_FETCHED"));
							}
						}
					}
					ixuibutton.SetEnable(status == 3U, false);
				}
				for (int j = 0; j < list[i].reward.Count; j++)
				{
					GameObject gameObject3 = window.m_ItemPool.FetchGameObject(false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject3, (int)list[i].reward[j, 0], (int)list[i].reward[j, 1], false);
					IXUISprite ixuisprite = gameObject3.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)list[i].reward[j, 0];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					gameObject3.transform.parent = gameObject.transform;
					gameObject3.transform.localPosition = new Vector3(window.m_ItemPool.TplPos.x - window.m_RewardPool.TplPos.x + (float)(window.m_ItemPool.TplWidth * j), 0f);
				}
				gameObject.transform.localPosition = window.m_RewardPool.TplPos - new Vector3(0f, (float)(window.m_RewardPool.TplHeight * i));
			}
			window.m_ItemPool.ActualReturnAll(false);
			window.m_RewardPool.ActualReturnAll(false);
			if (resetPos)
			{
				window.m_ScrollView.ResetPosition();
			}
		}

		private void RefreshRankRwd()
		{
			this.m_RankRewardWindow.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdCloseClicked));
			IXUILabel ixuilabel = base.uiBehaviour.m_frameRankRwd.transform.Find("Bg/LeftTime").GetComponent("XUILabel") as IXUILabel;
			bool flag = this._mdoc.self_rank > 0U;
			if (flag)
			{
				ixuilabel.SetText(XStringDefineProxy.GetString("SMALLMONSTER_RANK", new object[]
				{
					this._mdoc.self_rank
				}));
			}
			else
			{
				ixuilabel.SetText(XStringDefineProxy.GetString("ARENA_NO_RANK"));
			}
			Vector3 tplPos = this.m_RankRewardWindow.m_RewardPool.TplPos;
			this.m_RankRewardWindow.m_RewardPool.FakeReturnAll();
			this.m_RankRewardWindow.m_ItemPool.FakeReturnAll();
			for (int i = 0; i < this._mdoc.RankRewardList.Count; i++)
			{
				GameObject gameObject = this.m_RankRewardWindow.m_RewardPool.FetchGameObject(false);
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Bg/Rank/RankNum").GetComponent("XUILabel") as IXUILabel;
				bool isRange = this._mdoc.RankRewardList[i].isRange;
				if (isRange)
				{
					ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc2"), this._mdoc.RankRewardList[i].rank));
				}
				else
				{
					ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), this._mdoc.RankRewardList[i].rank));
				}
				for (int j = 0; j < this._mdoc.RankRewardList[i].reward.Count; j++)
				{
					GameObject gameObject2 = this.m_RankRewardWindow.m_ItemPool.FetchGameObject(false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)this._mdoc.RankRewardList[i].reward[j, 0], (int)this._mdoc.RankRewardList[i].reward[j, 1], false);
					IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)this._mdoc.RankRewardList[i].reward[j, 0];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					gameObject2.transform.parent = gameObject.transform;
					gameObject2.transform.localPosition = new Vector3(this.m_RankRewardWindow.m_ItemPool.TplPos.x + (float)(this.m_RankRewardWindow.m_ItemPool.TplWidth * j), 0f);
				}
				gameObject.transform.localPosition = this.m_RankRewardWindow.m_RewardPool.TplPos - new Vector3(0f, (float)(this.m_RankRewardWindow.m_RewardPool.TplHeight * i));
			}
			this.m_RankRewardWindow.m_ItemPool.ActualReturnAll(false);
			this.m_RankRewardWindow.m_RewardPool.ActualReturnAll(false);
			this.m_RankRewardWindow.m_ScrollView.ResetPosition();
		}

		private void OnClaimFirstpassClick(IXUILabel l)
		{
			ulong id = l.ID;
			this._mdoc.ReqFirstPassRwd(RiftFirstPassOpType.Rift_FirstPass_Op_GetReward, (uint)id);
		}

		private bool OnRwdCloseClicked(IXUIButton button)
		{
			this.CloseAllRwd();
			base.uiBehaviour.m_tab.gameObject.SetActive(false);
			return true;
		}

		private XExpeditionDocument _doc;

		private XRiftDocument _mdoc;

		private ActivityRiftItemsHandler _itemListHandler;

		private ActivityRiftGuidInfoHandler _guildinfoHandler;

		private XQualifyingRankRewardWindow m_RankRewardWindow;

		private XQualifyingPointRewardWindow m_WeekFirstPassWindow;

		private XQualifyingPointRewardWindow m_WelfareWindow;
	}
}
