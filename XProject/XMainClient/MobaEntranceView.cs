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
	// Token: 0x02000C90 RID: 3216
	internal class MobaEntranceView : DlgBase<MobaEntranceView, MobaEntranceBehaviour>
	{
		// Token: 0x17003223 RID: 12835
		// (get) Token: 0x0600B599 RID: 46489 RVA: 0x0023DDB4 File Offset: 0x0023BFB4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003224 RID: 12836
		// (get) Token: 0x0600B59A RID: 46490 RVA: 0x0023DDC8 File Offset: 0x0023BFC8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003225 RID: 12837
		// (get) Token: 0x0600B59B RID: 46491 RVA: 0x0023DDDC File Offset: 0x0023BFDC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003226 RID: 12838
		// (get) Token: 0x0600B59C RID: 46492 RVA: 0x0023DDF0 File Offset: 0x0023BFF0
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003227 RID: 12839
		// (get) Token: 0x0600B59D RID: 46493 RVA: 0x0023DE04 File Offset: 0x0023C004
		public override string fileName
		{
			get
			{
				return "GameSystem/MobaEntranceDlg";
			}
		}

		// Token: 0x17003228 RID: 12840
		// (get) Token: 0x0600B59E RID: 46494 RVA: 0x0023DE1C File Offset: 0x0023C01C
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Moba);
			}
		}

		// Token: 0x0600B59F RID: 46495 RVA: 0x0023DE38 File Offset: 0x0023C038
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

		// Token: 0x0600B5A0 RID: 46496 RVA: 0x0023DF00 File Offset: 0x0023C100
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

		// Token: 0x0600B5A1 RID: 46497 RVA: 0x0023E08C File Offset: 0x0023C28C
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

		// Token: 0x0600B5A2 RID: 46498 RVA: 0x0023E0EC File Offset: 0x0023C2EC
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

		// Token: 0x0600B5A3 RID: 46499 RVA: 0x0023E15C File Offset: 0x0023C35C
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

		// Token: 0x0600B5A4 RID: 46500 RVA: 0x0023E1A0 File Offset: 0x0023C3A0
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

		// Token: 0x0600B5A5 RID: 46501 RVA: 0x0023E204 File Offset: 0x0023C404
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

		// Token: 0x0600B5A6 RID: 46502 RVA: 0x0023E258 File Offset: 0x0023C458
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

		// Token: 0x0600B5A7 RID: 46503 RVA: 0x0023E304 File Offset: 0x0023C504
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

		// Token: 0x0600B5A8 RID: 46504 RVA: 0x0023E394 File Offset: 0x0023C594
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

		// Token: 0x0600B5A9 RID: 46505 RVA: 0x0023E486 File Offset: 0x0023C686
		public void Refresh()
		{
			this.RefreshMatch();
			this.RefreshSelectMsg();
			this.RefreshPrivilegeInfo();
			this.RefreshRaward();
		}

		// Token: 0x0600B5AA RID: 46506 RVA: 0x0023E4A8 File Offset: 0x0023C6A8
		public void RefreshMatch()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			base.uiBehaviour.m_SingleMatchLabel.SetText((specificDocument.SoloMatchType == KMatchType.KMT_MOBA) ? string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")) : XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"));
			base.uiBehaviour.m_TeamMatch.SetEnable(specificDocument.SoloMatchType != KMatchType.KMT_MOBA, false);
		}

		// Token: 0x0600B5AB RID: 46507 RVA: 0x0023E51C File Offset: 0x0023C71C
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

		// Token: 0x0600B5AC RID: 46508 RVA: 0x0023E82C File Offset: 0x0023CA2C
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

		// Token: 0x0600B5AD RID: 46509 RVA: 0x0023ED24 File Offset: 0x0023CF24
		public void SetIdleAnimation(object o)
		{
			string animationGetLength = o as string;
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.SetAnimationGetLength(animationGetLength);
			}
		}

		// Token: 0x0600B5AE RID: 46510 RVA: 0x0023ED54 File Offset: 0x0023CF54
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

		// Token: 0x0600B5AF RID: 46511 RVA: 0x0023EF10 File Offset: 0x0023D110
		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B5B0 RID: 46512 RVA: 0x0023EF2C File Offset: 0x0023D12C
		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Moba);
			return true;
		}

		// Token: 0x0600B5B1 RID: 46513 RVA: 0x0023EF4F File Offset: 0x0023D14F
		private void OnGetRewardClick(IXUISprite iSp)
		{
			this._doc.ReqMobaGetReward();
		}

		// Token: 0x0600B5B2 RID: 46514 RVA: 0x0023EF60 File Offset: 0x0023D160
		private bool OnMonsterDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.RotateDummy(this.m_Dummy, -delta.x / 2f);
			}
			return true;
		}

		// Token: 0x0600B5B3 RID: 46515 RVA: 0x0023EFA0 File Offset: 0x0023D1A0
		private bool OnBattleRecordBtnClick(IXUIButton btn)
		{
			this.m_MobaBattleRecordHandler.SetVisible(true);
			return true;
		}

		// Token: 0x0600B5B4 RID: 46516 RVA: 0x0023EFC0 File Offset: 0x0023D1C0
		private bool OnShopBtnClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		// Token: 0x0600B5B5 RID: 46517 RVA: 0x0023EFE8 File Offset: 0x0023D1E8
		private bool OnSkillBtnClick(IXUIButton btn)
		{
			this.m_HeroBattleSkillHandler.SetSkillPreViewState(true, (int)btn.ID);
			return true;
		}

		// Token: 0x0600B5B6 RID: 46518 RVA: 0x0023F010 File Offset: 0x0023D210
		private bool OnSkillPreViewBtnClick(IXUIButton btn)
		{
			this.m_HeroBattleSkillHandler.SetSkillPreViewState(true, 0);
			return true;
		}

		// Token: 0x0600B5B7 RID: 46519 RVA: 0x0023F034 File Offset: 0x0023D234
		private bool OnBuyBtnClick(IXUIButton btn)
		{
			this._skillDoc.QueryBuyHero(this._skillDoc.CurrentSelect);
			return true;
		}

		// Token: 0x0600B5B8 RID: 46520 RVA: 0x0023F060 File Offset: 0x0023D260
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

		// Token: 0x0600B5B9 RID: 46521 RVA: 0x0023F0C0 File Offset: 0x0023D2C0
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

		// Token: 0x0600B5BA RID: 46522 RVA: 0x0023F120 File Offset: 0x0023D320
		private bool OnRewardPreViewBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_RewardPreViewFrame.SetActive(true);
			this.SetupRewardPreView();
			return true;
		}

		// Token: 0x0600B5BB RID: 46523 RVA: 0x0023F14C File Offset: 0x0023D34C
		private bool OnRewardPreViewCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_RewardPreViewFrame.SetActive(false);
			return true;
		}

		// Token: 0x0600B5BC RID: 46524 RVA: 0x0023F174 File Offset: 0x0023D374
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

		// Token: 0x0600B5BD RID: 46525 RVA: 0x0023F430 File Offset: 0x0023D630
		private void OnPrivilegeClick(IXUISprite btn)
		{
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);
		}

		// Token: 0x0600B5BE RID: 46526 RVA: 0x0023F440 File Offset: 0x0023D640
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

		// Token: 0x0400471F RID: 18207
		private XMobaEntranceDocument _doc = null;

		// Token: 0x04004720 RID: 18208
		private XHeroBattleDocument _heroDoc = null;

		// Token: 0x04004721 RID: 18209
		private XHeroBattleSkillDocument _skillDoc = null;

		// Token: 0x04004722 RID: 18210
		public HeroBattleSkillHandler m_HeroBattleSkillHandler;

		// Token: 0x04004723 RID: 18211
		public MobaBattleRecordHandler m_MobaBattleRecordHandler;

		// Token: 0x04004724 RID: 18212
		private XDummy m_Dummy;

		// Token: 0x04004725 RID: 18213
		private uint _selectAnimToken;

		// Token: 0x04004726 RID: 18214
		private HashSet<uint> _selectFxToken = new HashSet<uint>();

		// Token: 0x04004727 RID: 18215
		private List<XFx> _selectFxList = new List<XFx>();

		// Token: 0x04004728 RID: 18216
		public static readonly uint SKILL_MAX = 4U;
	}
}
