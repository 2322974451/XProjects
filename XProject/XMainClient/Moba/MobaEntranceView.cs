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

	internal class MobaEntranceView : DlgBase<MobaEntranceView, MobaEntranceBehaviour>
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
				return "GameSystem/MobaEntranceDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Moba);
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
			this._heroDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this._skillDoc = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
			this.m_HeroBattleSkillHandler = DlgHandlerBase.EnsureCreate<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler, base.uiBehaviour.m_SkillPreViewTs, false, null);
			this.m_HeroBattleSkillHandler.HandlerType = 2;
			this.m_HeroBattleSkillHandler.OtherViewBuyBtn = base.uiBehaviour.m_BuyBtn;
			DlgHandlerBase.EnsureCreate<MobaBattleRecordHandler>(ref this.m_MobaBattleRecordHandler, base.uiBehaviour.m_BattleRecordFrame, false, null);
			base.uiBehaviour.m_RewardPreViewFrame.SetActive(false);
			base.uiBehaviour.m_RankBtn.gameObject.SetActive(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
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
			base.uiBehaviour.m_Privilege.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPrivilegeClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("MobaDlg");
			this._doc.ReqMobaUIInfo();
			this._heroDoc.QueryHeroBattleUIInfo();
			this.m_HeroBattleSkillHandler.SetVisible(true);
			this._skillDoc.m_HeroBattleSkillHandler = this.m_HeroBattleSkillHandler;
			this.Refresh();
		}

		protected override void OnHide()
		{
			this.ClearSelectFx();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._selectAnimToken);
			this.m_MobaBattleRecordHandler.SetVisible(false);
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
			base.Alloc3DAvatarPool("MobaDlg");
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
			this.ClearSelectFx();
			XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			this.m_Dummy = null;
		}

		protected override void OnUnload()
		{
			this.ClearSelectFx();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._selectAnimToken);
			DlgHandlerBase.EnsureUnload<HeroBattleSkillHandler>(ref this.m_HeroBattleSkillHandler);
			DlgHandlerBase.EnsureUnload<MobaBattleRecordHandler>(ref this.m_MobaBattleRecordHandler);
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		private void ClearSelectFx()
		{
			for (int i = this._selectFxList.Count - 1; i >= 0; i--)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._selectFxList[i], true);
			}
			this._selectFxList.Clear();
			foreach (uint token in this._selectFxToken)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
			}
			this._selectFxToken.Clear();
		}

		private void _SetSelectFxDelay(XGameObject gameObject, object o, int commandID)
		{
			string[] array = o as string[];
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(XGlobalConfig.SequenceSeparator);
				bool flag = array2.Length != 3;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Fx config error, each length not 3.", null, null, null, null, null);
					break;
				}
				uint item = XSingleton<XTimerMgr>.singleton.SetTimer(float.Parse(array2[1]), new XTimerMgr.ElapsedEventHandler(this.FxDelayPlay), array[i]);
				this._selectFxToken.Add(item);
			}
		}

		public void FxDelayPlay(object o)
		{
			string text = o as string;
			string[] array = text.Split(XGlobalConfig.SequenceSeparator);
			Transform transform = null;
			bool flag = array[2].Equals("#");
			if (flag)
			{
				transform = this.m_uiBehaviour.m_Snapshot.transform;
			}
			else
			{
				Transform[] componentsInChildren = this.m_uiBehaviour.m_Snapshot.transform.GetComponentsInChildren<Transform>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					bool flag2 = componentsInChildren[i].name == array[2];
					if (flag2)
					{
						transform = componentsInChildren[i];
						break;
					}
				}
				bool flag3 = transform == null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Can't find node ", array[2], ", pls check config.", null, null, null);
					return;
				}
			}
			XFx xfx = XSingleton<XFxMgr>.singleton.CreateUIFx(array[0], transform, false);
			this._selectFxList.Add(xfx);
			xfx.Play();
		}

		public void Refresh()
		{
			this.RefreshMatch();
			this.RefreshSelectMsg();
			this.RefreshPrivilegeInfo();
			this.RefreshRaward();
		}

		public void RefreshMatch()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			base.uiBehaviour.m_SingleMatchLabel.SetText((specificDocument.SoloMatchType == KMatchType.KMT_MOBA) ? string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")) : XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"));
			base.uiBehaviour.m_TeamMatch.SetEnable(specificDocument.SoloMatchType != KMatchType.KMT_MOBA, false);
		}

		public void RefreshRaward()
		{
			base.uiBehaviour.m_ClickGet.SetVisible(this._doc.RewardState == XMobaEntranceDocument.MobaRewardState.CanGet);
			base.uiBehaviour.m_HadGet.SetActive(this._doc.RewardState == XMobaEntranceDocument.MobaRewardState.GetEnd);
			MobaWeekReward.RowData byid = XMobaEntranceDocument._MobaWeekReward.GetByid(this._doc.GetRewardStage + 1U);
			string arg = (this._doc.WinThisWeek < byid.winnum) ? "[ff3e3e]" : "[00ff37]";
			base.uiBehaviour.m_WeekCurrentWin.SetText(string.Format("({0}{1}[-]/{2})", arg, this._doc.WinThisWeek.ToString(), byid.winnum));
			base.uiBehaviour.m_WeekBattleTips.SetText(string.Format(XStringDefineProxy.GetString("HeroBattleWeekRewardTips"), byid.winnum));
			base.uiBehaviour.m_RewardPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.m_RewardPool.TplPos;
			List<ItemBrief> list = new List<ItemBrief>();
			for (int i = 0; i < byid.reward.Length; i++)
			{
				ItemBrief itemBrief = new ItemBrief();
				int num;
				int num2;
				CVSReader.GetRowDataListByField<DropList.RowData, int>(XBagDocument.DropTable.Table, (int)byid.reward[i], out num, out num2, XBagDocument.comp);
				bool flag = num < 0;
				if (!flag)
				{
					itemBrief.itemID = (uint)XBagDocument.DropTable.Table[num].ItemID;
					itemBrief.itemCount = (uint)XBagDocument.DropTable.Table[num].ItemCount;
					itemBrief.isbind = XBagDocument.DropTable.Table[num].ItemBind;
					list.Add(itemBrief);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject.transform.parent = base.uiBehaviour.m_WeekRewardTs;
				gameObject.transform.localPosition = new Vector3((float)(j * base.uiBehaviour.m_RewardPool.TplWidth), tplPos.y) + base.uiBehaviour.m_RewardPool.TplPos;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)list[j].itemID);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf, (int)list[j].itemCount, false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject, (int)list[j].itemID);
				GameObject gameObject2 = gameObject.transform.Find("Other/RedPoint").gameObject;
				gameObject2.SetActive(j == list.Count - 1 && this._doc.RewardState == XMobaEntranceDocument.MobaRewardState.CanGet);
				GameObject gameObject3 = gameObject.transform.Find("Other/OutterLight").gameObject;
				gameObject3.SetActive(this._doc.RewardState == XMobaEntranceDocument.MobaRewardState.CanGet);
			}
		}

		public void RefreshSelectMsg()
		{
			bool flag = !this._skillDoc.IsPreViewShow && !this._skillDoc.AlreadyGetList.Contains(this._skillDoc.CurrentSelect);
			base.uiBehaviour.m_BuyBtn.SetVisible(flag);
			bool flag2 = flag;
			if (flag2)
			{
				OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(this._skillDoc.CurrentSelect);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)byHeroID.Price[0]);
				IXUISprite ixuisprite = base.uiBehaviour.m_BuyBtn.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteName = itemConf.ItemIcon1[0];
				IXUILabel ixuilabel = base.uiBehaviour.m_BuyBtn.gameObject.transform.Find("Cost").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(byHeroID.Price[1].ToString());
			}
			OverWatchTable.RowData byHeroID2 = this._heroDoc.OverWatchReader.GetByHeroID(this._skillDoc.CurrentSelect);
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
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(byHeroID2.StatisticsID[2]);
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
						this.ClearSelectFx();
						bool flag7 = byHeroID2.SelectFx != null;
						if (flag7)
						{
							this.m_Dummy.EngineObject.CallCommand(new CommandCallback(this._SetSelectFxDelay), byHeroID2.SelectFx, -1, false);
						}
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("set model error.  id =  ", this._skillDoc.CurrentSelect.ToString(), null, null, null, null);
				}
				string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("MobaAttributesType").Split(new char[]
				{
					'|'
				});
				base.uiBehaviour.m_AttributesPool.FakeReturnAll();
				for (int i = 0; i < byHeroID2.MobaAttributes.Length; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_AttributesPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)i * base.uiBehaviour.m_AttributesPool.TplHeight), 0f) + base.uiBehaviour.m_AttributesPool.TplPos;
					IXUILabel ixuilabel2 = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
					bool flag8 = i < array.Length;
					if (flag8)
					{
						ixuilabel2.SetText(array[i]);
					}
					else
					{
						ixuilabel2.SetText(XSingleton<XGlobalConfig>.singleton.GetValue(""));
					}
					IXUIProgress ixuiprogress = gameObject.transform.Find("Slider").GetComponent("XUIProgress") as IXUIProgress;
					ixuiprogress.value = byHeroID2.MobaAttributes[i];
				}
				base.uiBehaviour.m_AttributesPool.ActualReturnAll(false);
				this.RefreshSkillInfo();
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

		private void RefreshSkillInfo()
		{
			List<uint> list = this.m_HeroBattleSkillHandler.SkillInfo();
			base.uiBehaviour.m_SkillsPool.FakeReturnAll();
			int num = 0;
			while (num < list.Count && (long)num < (long)((ulong)MobaEntranceView.SKILL_MAX))
			{
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(list[num], 0U, this._skillDoc.CurrentEntityStatisticsID[2]);
				bool flag = skillConfig == null;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_SkillsPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3((float)(num * base.uiBehaviour.m_SkillsPool.TplHeight), 0f, 0f) + base.uiBehaviour.m_SkillsPool.TplPos;
					gameObject.name = list[num].ToString();
					IXUISprite ixuisprite = gameObject.transform.Find("P").GetComponent("XUISprite") as IXUISprite;
					bool flag2 = skillConfig.SkillType == 2;
					if (flag2)
					{
						ixuisprite.SetSprite("JN_dk_0");
					}
					else
					{
						ixuisprite.SetSprite("JN_dk");
					}
					IXUISprite ixuisprite2 = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.SetSprite(skillConfig.Icon, skillConfig.Atlas, false);
					IXUIButton ixuibutton = gameObject.transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)num);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSkillBtnClick));
				}
				num++;
			}
			base.uiBehaviour.m_SkillsPool.ActualReturnAll(false);
		}

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Moba);
			return true;
		}

		private void OnGetRewardClick(IXUISprite iSp)
		{
			this._doc.ReqMobaGetReward();
		}

		private bool OnMonsterDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.RotateDummy(this.m_Dummy, -delta.x / 2f);
			}
			return true;
		}

		private bool OnBattleRecordBtnClick(IXUIButton btn)
		{
			this.m_MobaBattleRecordHandler.SetVisible(true);
			return true;
		}

		private bool OnShopBtnClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		private bool OnSkillBtnClick(IXUIButton btn)
		{
			this.m_HeroBattleSkillHandler.SetSkillPreViewState(true, (int)btn.ID);
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
				KMatchOp op = (specificDocument.SoloMatchType != KMatchType.KMT_MOBA) ? KMatchOp.KMATCH_OP_START : KMatchOp.KMATCH_OP_STOP;
				specificDocument.ReqMatchStateChange(KMatchType.KMT_MOBA, op, false);
				result = true;
			}
			return result;
		}

		private bool OnTeamMatchBtnClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelMoba);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
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

		private void SetupRewardPreView()
		{
			base.uiBehaviour.m_PreViewItemPool.ReturnAll(true);
			base.uiBehaviour.m_PreViewBgPool.ReturnAll(false);
			base.uiBehaviour.m_CurrentWinThisWeek.SetText("");
			List<ItemBrief> list = new List<ItemBrief>();
			Vector3 tplPos = base.uiBehaviour.m_PreViewItemPool.TplPos;
			for (int i = 0; i < XMobaEntranceDocument._MobaWeekReward.Table.Length; i++)
			{
				MobaWeekReward.RowData rowData = XMobaEntranceDocument._MobaWeekReward.Table[i];
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

		private void OnPrivilegeClick(IXUISprite btn)
		{
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);
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

		private XMobaEntranceDocument _doc = null;

		private XHeroBattleDocument _heroDoc = null;

		private XHeroBattleSkillDocument _skillDoc = null;

		public HeroBattleSkillHandler m_HeroBattleSkillHandler;

		public MobaBattleRecordHandler m_MobaBattleRecordHandler;

		private XDummy m_Dummy;

		private uint _selectAnimToken;

		private HashSet<uint> _selectFxToken = new HashSet<uint>();

		private List<XFx> _selectFxList = new List<XFx>();

		public static readonly uint SKILL_MAX = 4U;
	}
}
