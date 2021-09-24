using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HeroBattleDlg : DlgBase<HeroBattleDlg, HeroBattleBehaviour>
	{

		public override bool autoload
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

		public override bool hideMainMenu
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

		public override string fileName
		{
			get
			{
				return "GameSystem/HeroBattleDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_HeroBattle);
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this._skillDoc = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
			this.m_HeroBattleSkillHandler = DlgHandlerBase.EnsureCreate<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler, base.uiBehaviour.m_SkillPreViewTs, false, null);
			this.m_HeroBattleSkillHandler.HandlerType = 0;
			this.m_HeroBattleSkillHandler.OtherViewBuyBtn = base.uiBehaviour.m_BuyBtn;
			DlgHandlerBase.EnsureCreate<BattleRecordHandler>(ref this.m_HeroBattleRecordHandler, base.uiBehaviour.m_BattleRecordFrame, null, false);
			base.uiBehaviour.m_RewardPreViewFrame.SetActive(false);
			base.uiBehaviour.m_RankFrame.SetActive(false);
			this._InitUI = true;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_SkillPreViewBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSkillPreViewBtnClick));
			base.uiBehaviour.m_BuyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClick));
			base.uiBehaviour.m_ClickGet.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetRewardClick));
			base.uiBehaviour.m_BattleRecordBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleRecordBtnClick));
			base.uiBehaviour.m_RewardPreViewBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardPreViewBtnClick));
			base.uiBehaviour.m_RewardPreViewCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardPreViewCloseBtnClick));
			base.uiBehaviour.m_ShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopBtnClick));
			base.uiBehaviour.m_SingleMatch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSingleMatchBtnClick));
			base.uiBehaviour.m_TeamMatch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTeamMatchBtnClick));
			base.uiBehaviour.m_SnapDrag.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnMonsterDrag));
			IXUIButton ixuibutton = base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
			base.uiBehaviour.m_RankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankBtnClick));
			base.uiBehaviour.m_RankCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankCloseBtnClick));
			base.uiBehaviour.m_RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdated));
			base.uiBehaviour.m_Privilege.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPrivilegeClick));
			base.uiBehaviour.m_ResearchBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnResearchBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_BgTex.SetTexturePath("atlas/UI/GameSystem/HeroBattle/l_herozcbj_h2Split");
			base.Alloc3DAvatarPool("HeroBattleDlg");
			bool initUI = this._InitUI;
			if (initUI)
			{
				this._InitUI = false;
			}
			else
			{
				this.RefreshSelectMsg();
			}
			this._doc.QueryHeroBattleUIInfo();
			this.m_HeroBattleSkillHandler.SetVisible(true);
			this._skillDoc.m_HeroBattleSkillHandler = this.m_HeroBattleSkillHandler;
			this.Refresh();
			DlgBase<RandomGiftView, RandomGiftBehaviour>.singleton.TryOpenUI();
			this.RefreshPrivilegeInfo();
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._selectAnimToken);
			this.m_HeroBattleRecordHandler.SetVisible(false);
			base.uiBehaviour.m_BgTex.SetTexturePath("");
			bool flag = this.m_HeroBattleSkillHandler != null;
			if (flag)
			{
				this.m_HeroBattleSkillHandler.SetVisible(false);
				this._skillDoc.m_HeroBattleSkillHandler = null;
			}
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = this.m_HeroBattleSkillHandler != null;
			if (flag)
			{
				this.m_HeroBattleSkillHandler.SetVisible(true);
			}
			base.Alloc3DAvatarPool("HeroBattleDlg");
			this.RefreshSelectMsg();
		}

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			bool flag = this.m_HeroBattleSkillHandler != null;
			if (flag)
			{
				this.m_HeroBattleSkillHandler.SetSkillPreViewState(false, 0);
				this.m_HeroBattleSkillHandler.SetVisible(false);
			}
			XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			this.m_Dummy = null;
		}

		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._selectAnimToken);
			DlgHandlerBase.EnsureUnload<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler);
			DlgHandlerBase.EnsureUnload<BattleRecordHandler>(ref this.m_HeroBattleRecordHandler);
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		public void Refresh()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			base.uiBehaviour.m_SingleMatchLabel.SetText((specificDocument.SoloMatchType == KMatchType.KMT_HERO) ? string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")) : XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"));
			base.uiBehaviour.m_TeamMatch.SetEnable(specificDocument.SoloMatchType != KMatchType.KMT_HERO, false);
		}

		public void RefreshInfo()
		{
			base.uiBehaviour.m_BattleTotal.SetText(this._doc.BattleTotal.ToString());
			base.uiBehaviour.m_BattleWin.SetText(this._doc.BattleWin.ToString());
			base.uiBehaviour.m_BattleLose.SetText(this._doc.BattleLose.ToString());
			bool flag = this._doc.BattleTotal == 0U;
			if (flag)
			{
				base.uiBehaviour.m_BattleRate.SetText("0%");
			}
			else
			{
				base.uiBehaviour.m_BattleRate.SetText(string.Format("{0}%", (int)(this._doc.BattleWin * 100f / this._doc.BattleTotal)));
			}
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("HeroBattleSpecialNum");
			base.uiBehaviour.m_WeekCurrentWin.SetText(this._doc.WinThisWeek.ToString());
			base.uiBehaviour.m_ClickGet.SetVisible(this._doc.RewardState == HeroBattleRewardState.CanGet);
			base.uiBehaviour.m_HadGet.SetActive(this._doc.RewardState == HeroBattleRewardState.GetEnd);
			int num = Math.Max(@int - (int)this._doc.JoinToday, 0);
			string arg = (num == 0) ? "[ff3e3e]" : "[00ff37]";
			string arg2 = string.Format("{0}{1}[-]", arg, num);
			HeroBattleWeekReward.RowData byid = this._doc.HeroBattleWeekRewardReader.GetByid(this._doc.GetRewardStage + 1U);
			base.uiBehaviour.m_WeekBattleTips.SetText(string.Format(XStringDefineProxy.GetString("HeroBattleWeekRewardTips"), byid.winnum));
			base.uiBehaviour.m_BattleTips.SetText(string.Format(XStringDefineProxy.GetString("HeroBattleRewardTips"), @int.ToString(), arg2, @int.ToString()));
			base.uiBehaviour.m_RewardPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.m_RewardPool.TplPos;
			List<ItemBrief> list = new List<ItemBrief>();
			for (int i = 0; i < byid.reward.Length; i++)
			{
				ItemBrief itemBrief = new ItemBrief();
				int num2;
				int num3;
				CVSReader.GetRowDataListByField<DropList.RowData, int>(XBagDocument.DropTable.Table, (int)byid.reward[i], out num2, out num3, XBagDocument.comp);
				bool flag2 = num2 < 0;
				if (!flag2)
				{
					itemBrief.itemID = (uint)XBagDocument.DropTable.Table[num2].ItemID;
					itemBrief.itemCount = (uint)XBagDocument.DropTable.Table[num2].ItemCount;
					itemBrief.isbind = XBagDocument.DropTable.Table[num2].ItemBind;
					list.Add(itemBrief);
				}
			}
			float num4 = tplPos.x - ((float)list.Count - 1f) / 2f * (float)base.uiBehaviour.m_RewardPool.TplWidth;
			for (int j = 0; j < list.Count; j++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject.transform.parent = base.uiBehaviour.m_WeekRewardTs;
				gameObject.transform.localPosition = new Vector3(num4 + (float)(j * base.uiBehaviour.m_RewardPool.TplWidth), tplPos.y);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)list[j].itemID);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf, (int)list[j].itemCount, false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject, (int)list[j].itemID);
				GameObject gameObject2 = gameObject.transform.Find("Other/RedPoint").gameObject;
				gameObject2.SetActive(j == list.Count - 1 && this._doc.RewardState == HeroBattleRewardState.CanGet);
				GameObject gameObject3 = gameObject.transform.Find("Other/OutterLight").gameObject;
				gameObject3.SetActive(this._doc.RewardState == HeroBattleRewardState.CanGet);
			}
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("HeroBattleSpecialReward");
			list.Clear();
			for (int k = 0; k < intList.Count; k++)
			{
				ItemBrief itemBrief2 = new ItemBrief();
				int num2;
				int num3;
				CVSReader.GetRowDataListByField<DropList.RowData, int>(XBagDocument.DropTable.Table, intList[k], out num2, out num3, XBagDocument.comp);
				bool flag3 = num2 < 0;
				if (!flag3)
				{
					itemBrief2.itemID = (uint)XBagDocument.DropTable.Table[num2].ItemID;
					itemBrief2.itemCount = (uint)XBagDocument.DropTable.Table[num2].ItemCount;
					itemBrief2.isbind = XBagDocument.DropTable.Table[num2].ItemBind;
					list.Add(itemBrief2);
				}
			}
			num4 = tplPos.x - ((float)list.Count - 1f) / 2f * (float)base.uiBehaviour.m_RewardPool.TplWidth;
			for (int l = 0; l < list.Count; l++)
			{
				GameObject gameObject4 = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject4.transform.parent = base.uiBehaviour.m_DayRewardTs;
				gameObject4.transform.localPosition = new Vector3(num4 + (float)(l * base.uiBehaviour.m_RewardPool.TplWidth), tplPos.y);
				ItemList.RowData itemConf2 = XBagDocument.GetItemConf((int)list[l].itemID);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject4, itemConf2, (int)list[l].itemCount, false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject4, (int)list[l].itemID);
				GameObject gameObject5 = gameObject4.transform.Find("Other/RedPoint").gameObject;
				gameObject5.SetActive(false);
				GameObject gameObject6 = gameObject4.transform.Find("Other/OutterLight").gameObject;
				gameObject6.SetActive(false);
			}
		}

		private void SetupRewardPreView()
		{
			base.uiBehaviour.m_PreViewItemPool.ReturnAll(true);
			base.uiBehaviour.m_PreViewBgPool.ReturnAll(false);
			base.uiBehaviour.m_CurrentWinThisWeek.SetText(this._doc.WinThisWeek.ToString());
			List<ItemBrief> list = new List<ItemBrief>();
			Vector3 tplPos = base.uiBehaviour.m_PreViewItemPool.TplPos;
			for (int i = 0; i < this._doc.HeroBattleWeekRewardReader.Table.Length; i++)
			{
				HeroBattleWeekReward.RowData rowData = this._doc.HeroBattleWeekRewardReader.Table[i];
				GameObject gameObject = base.uiBehaviour.m_PreViewBgPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_PreViewBgPool.TplPos.x, base.uiBehaviour.m_PreViewBgPool.TplPos.y - (float)(i * base.uiBehaviour.m_PreViewBgPool.TplHeight));
				IXUILabel ixuilabel = gameObject.transform.Find("Bg/Point/Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(rowData.winnum.ToString());
				list.Clear();
				for (int j = 0; j < rowData.reward.Length; j++)
				{
					ItemBrief itemBrief = new ItemBrief();
					int num;
					int num2;
					CVSReader.GetRowDataListByField<DropList.RowData, int>(XBagDocument.DropTable.Table, (int)rowData.reward[j], out num, out num2, XBagDocument.comp);
					bool flag = num < 0;
					if (!flag)
					{
						itemBrief.itemID = (uint)XBagDocument.DropTable.Table[num].ItemID;
						itemBrief.itemCount = (uint)XBagDocument.DropTable.Table[num].ItemCount;
						itemBrief.isbind = XBagDocument.DropTable.Table[num].ItemBind;
						list.Add(itemBrief);
					}
				}
				for (int k = 0; k < list.Count; k++)
				{
					GameObject gameObject2 = base.uiBehaviour.m_PreViewItemPool.FetchGameObject(false);
					gameObject2.transform.localPosition = new Vector3(tplPos.x + (float)(k * base.uiBehaviour.m_PreViewItemPool.TplWidth), tplPos.y);
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)list[k].itemID);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, itemConf, (int)list[k].itemCount, false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject2, (int)list[k].itemID);
				}
				tplPos.y -= (float)base.uiBehaviour.m_PreViewBgPool.TplHeight;
			}
		}

		public void RefreshSelectMsg()
		{
			bool flag = !this._skillDoc.IsPreViewShow && !this._skillDoc.AlreadyGetList.Contains(this._skillDoc.CurrentSelect);
			base.uiBehaviour.m_BuyBtn.SetVisible(flag);
			bool flag2 = flag;
			if (flag2)
			{
				OverWatchTable.RowData byHeroID = this._doc.OverWatchReader.GetByHeroID(this._skillDoc.CurrentSelect);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)byHeroID.Price[0]);
				IXUISprite ixuisprite = base.uiBehaviour.m_BuyBtn.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteName = itemConf.ItemIcon1[0];
				IXUILabel ixuilabel = base.uiBehaviour.m_BuyBtn.gameObject.transform.Find("Cost").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(byHeroID.Price[1].ToString());
			}
			OverWatchTable.RowData byHeroID2 = this._doc.OverWatchReader.GetByHeroID(this._skillDoc.CurrentSelect);
			bool flag3 = byHeroID2 == null;
			if (flag3)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("get hero data error! id = ", this._skillDoc.CurrentSelect.ToString(), null, null, null, null);
			}
			else
			{
				base.uiBehaviour.m_HeroDescription.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(byHeroID2.Description));
				base.uiBehaviour.m_HeroName.SetText(byHeroID2.Name);
				bool flag4 = !this._skillDoc.AlreadyGetList.Contains(this._skillDoc.CurrentSelect) && this._skillDoc.ExperienceList.Contains(this._skillDoc.CurrentSelect);
				if (flag4)
				{
					base.uiBehaviour.m_ExperienceTime.SetVisible(true);
					int totalSecond = (int)this._skillDoc.ExperienceTimeDict[this._skillDoc.CurrentSelect];
					string text = string.Format(XStringDefineProxy.GetString("HeroBattleExperienceTime", new object[]
					{
						XSingleton<UiUtility>.singleton.TimeAccFormatString(totalSecond, 3, 0)
					}), new object[0]);
					base.uiBehaviour.m_ExperienceTime.SetText(text);
				}
				else
				{
					base.uiBehaviour.m_ExperienceTime.SetVisible(false);
				}
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(byHeroID2.StatisticsID[0]);
				XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
				bool flag5 = byID != null;
				if (flag5)
				{
					this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, byID.PresentID, this.m_uiBehaviour.m_Snapshot, this.m_Dummy, 1f);
					bool flag6 = this.m_Dummy != null;
					if (flag6)
					{
						float interval = this.m_Dummy.SetAnimationGetLength(byHeroID2.SelectAnim);
						XSingleton<XTimerMgr>.singleton.KillTimer(this._selectAnimToken);
						this._selectAnimToken = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.SetIdleAnimation), byPresentID.AvatarPos[0]);
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("set model error.  id =  ", this._skillDoc.CurrentSelect.ToString(), null, null, null, null);
				}
			}
		}

		public void SetIdleAnimation(object o)
		{
			string animationGetLength = o as string;
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.SetAnimationGetLength(animationGetLength);
			}
		}

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_HeroBattle);
			return true;
		}

		private void OnGetRewardClick(IXUISprite iSp)
		{
			this._doc.QueryGetReward();
		}

		private bool OnMonsterDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.EngineObject.Rotate(Vector3.up, -delta.x / 2f);
			}
			return true;
		}

		private bool OnBattleRecordBtnClick(IXUIButton btn)
		{
			this._doc.QueryBattleRecord();
			this.m_HeroBattleRecordHandler.SetupRecord(this._doc.RecordList);
			return true;
		}

		private bool OnRewardPreViewBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_RewardPreViewFrame.SetActive(true);
			this.SetupRewardPreView();
			return true;
		}

		private bool OnRewardPreViewCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_RewardPreViewFrame.SetActive(false);
			return true;
		}

		private bool OnShopBtnClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		private bool OnSkillPreViewBtnClick(IXUIButton btn)
		{
			this.m_HeroBattleSkillHandler.SetSkillPreViewState(true, 0);
			return true;
		}

		private bool OnBuyBtnClick(IXUIButton btn)
		{
			this._skillDoc.QueryBuyHero(this._skillDoc.CurrentSelect);
			return true;
		}

		private bool OnSingleMatchBtnClick(IXUIButton btn)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			bool result;
			if (bInTeam)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CAPTAIN_SINGLE_MATCH_TIP"), "fece00");
				result = false;
			}
			else
			{
				KMatchOp op = (specificDocument.SoloMatchType != KMatchType.KMT_HERO) ? KMatchOp.KMATCH_OP_START : KMatchOp.KMATCH_OP_STOP;
				specificDocument.ReqMatchStateChange(KMatchType.KMT_HERO, op, false);
				result = true;
			}
			return result;
		}

		private bool OnTeamMatchBtnClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelHeroBattle);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
			return true;
		}

		private bool OnRankBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_RankFrame.SetActive(true);
			this._doc.QueryRankInfo();
			this.SetupRankFrame();
			return true;
		}

		private bool OnRankCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_RankFrame.SetActive(false);
			return true;
		}

		public void SetupRankFrame()
		{
			bool flag = !base.uiBehaviour.m_RankFrame.activeInHierarchy;
			if (!flag)
			{
				this.SetRankTpl(base.uiBehaviour.m_MyRankTs, 0, true);
				base.uiBehaviour.m_RankWrapContent.SetContentCount(this._doc.MainRankList.Count, false);
				base.uiBehaviour.m_RankScrollView.ResetPosition();
			}
		}

		public void WrapListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.MainRankList.Count;
			if (!flag)
			{
				this.SetRankTpl(t, index, false);
			}
		}

		public void SetRankTpl(Transform t, int index, bool isMy)
		{
			HeroBattleRankData heroBattleRankData = isMy ? this._doc.MyRankData : this._doc.MainRankList[index];
			IXUILabel ixuilabel = t.Find("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("Value1").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = t.Find("Value2").GetComponent("XUILabel") as IXUILabel;
			bool flag = heroBattleRankData.rank < 3U;
			if (flag)
			{
				ixuisprite.SetVisible(true);
				ixuilabel.SetVisible(false);
				ixuisprite.spriteName = string.Format("N{0}", heroBattleRankData.rank + 1U);
			}
			else
			{
				ixuisprite.SetVisible(false);
				ixuilabel.SetVisible(true);
				ixuilabel.SetText(string.Format("No.{0}", heroBattleRankData.rank + 1U));
			}
			if (isMy)
			{
				bool flag2 = heroBattleRankData.rank == uint.MaxValue;
				if (flag2)
				{
					base.uiBehaviour.m_OutOfRank.SetActive(true);
					ixuisprite.SetVisible(false);
					ixuilabel.SetVisible(false);
				}
				else
				{
					base.uiBehaviour.m_OutOfRank.SetActive(false);
				}
			}
			bool flag3 = heroBattleRankData.fightTotal == 0U;
			int num;
			if (flag3)
			{
				num = 0;
			}
			else
			{
				num = (int)Mathf.Floor(heroBattleRankData.winTotal * 100U / heroBattleRankData.fightTotal);
			}
			ixuilabel2.SetText(heroBattleRankData.name);
			ixuilabel3.SetText(string.Format("{0}%", num));
			ixuilabel4.SetText(heroBattleRankData.fightTotal.ToString());
			ixuilabel2.ID = heroBattleRankData.roleID;
			ixuilabel2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnPlayerInfoClick));
		}

		private void OnPlayerInfoClick(IXUILabel label)
		{
			bool flag = label.ID == 0UL;
			if (!flag)
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
			}
		}

		private void OnPrivilegeClick(IXUISprite btn)
		{
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);
		}

		private void OnResearchBtnClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.OpenHtmlUrl("HeroBattlePlayUrl");
		}

		private void RefreshPrivilegeInfo()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			base.uiBehaviour.m_PrivilegeIcon.SetGrey(specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer));
			base.uiBehaviour.m_PrivilegeIcon.SetSprite(specificDocument.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Adventurer));
			base.uiBehaviour.m_PrivilegeName.SetEnabled(specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer));
			PayMemberTable.RowData memberPrivilegeConfig = specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Adventurer);
			bool flag = memberPrivilegeConfig != null;
			if (flag)
			{
				base.uiBehaviour.m_PrivilegeName.SetText(XStringDefineProxy.GetString("HeroBattlePrevilege", new object[]
				{
					memberPrivilegeConfig.HeroBattleFree
				}));
			}
		}

		private XHeroBattleDocument _doc = null;

		private XHeroBattleSkillDocument _skillDoc = null;

		public HeroBattleSkillHandler m_HeroBattleSkillHandler;

		public BattleRecordHandler m_HeroBattleRecordHandler;

		private XDummy m_Dummy;

		private bool _InitUI;

		private uint _selectAnimToken;
	}
}
