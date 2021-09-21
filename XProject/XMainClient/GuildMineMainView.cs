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
	// Token: 0x02000C1D RID: 3101
	internal class GuildMineMainView : DlgBase<GuildMineMainView, GuildMineMainBehaviour>
	{
		// Token: 0x17003107 RID: 12551
		// (get) Token: 0x0600AFEE RID: 45038 RVA: 0x002175E0 File Offset: 0x002157E0
		public override string fileName
		{
			get
			{
				return "Guild/GuildMine/GuildMineMain";
			}
		}

		// Token: 0x17003108 RID: 12552
		// (get) Token: 0x0600AFEF RID: 45039 RVA: 0x002175F8 File Offset: 0x002157F8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003109 RID: 12553
		// (get) Token: 0x0600AFF0 RID: 45040 RVA: 0x0021760C File Offset: 0x0021580C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700310A RID: 12554
		// (get) Token: 0x0600AFF1 RID: 45041 RVA: 0x00217620 File Offset: 0x00215820
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700310B RID: 12555
		// (get) Token: 0x0600AFF2 RID: 45042 RVA: 0x00217634 File Offset: 0x00215834
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700310C RID: 12556
		// (get) Token: 0x0600AFF3 RID: 45043 RVA: 0x00217648 File Offset: 0x00215848
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700310D RID: 12557
		// (get) Token: 0x0600AFF4 RID: 45044 RVA: 0x0021765C File Offset: 0x0021585C
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700310E RID: 12558
		// (get) Token: 0x0600AFF5 RID: 45045 RVA: 0x00217670 File Offset: 0x00215870
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildMineMain);
			}
		}

		// Token: 0x1700310F RID: 12559
		// (get) Token: 0x0600AFF6 RID: 45046 RVA: 0x0021768C File Offset: 0x0021588C
		// (set) Token: 0x0600AFF7 RID: 45047 RVA: 0x002176A4 File Offset: 0x002158A4
		internal GuildBuffOperationHandler GuildBuffHandler
		{
			get
			{
				return this._guildBuffHandler;
			}
			set
			{
				this._guildBuffHandler = value;
			}
		}

		// Token: 0x0600AFF8 RID: 45048 RVA: 0x002176B0 File Offset: 0x002158B0
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			this.doc.View = this;
			DlgHandlerBase.EnsureCreate<GuildBuffOperationHandler>(ref this._guildBuffHandler, base.uiBehaviour.m_PropsFrame, false, this);
			DlgHandlerBase.EnsureCreate<GuildMineRankHandler>(ref this._rankHanler, base.uiBehaviour.m_RankFrame, false, this);
			DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this);
		}

		// Token: 0x0600AFF9 RID: 45049 RVA: 0x00217728 File Offset: 0x00215928
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_BtnExplore.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExploreClicked));
			base.uiBehaviour.m_BtnExploreAgain.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExploreClicked));
			base.uiBehaviour.m_BtnChallenge.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChallengeClicked));
			base.uiBehaviour.m_BtnTeam.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTeamClicked));
			base.uiBehaviour.m_BtnWarehouse.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickBuffStorage));
			base.uiBehaviour.m_BtnRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickRankBtn));
		}

		// Token: 0x0600AFFA RID: 45050 RVA: 0x00217820 File Offset: 0x00215A20
		private bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AFFB RID: 45051 RVA: 0x0021783C File Offset: 0x00215A3C
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildMine);
			return true;
		}

		// Token: 0x0600AFFC RID: 45052 RVA: 0x0021785C File Offset: 0x00215A5C
		protected override void OnShow()
		{
			base.OnShow();
			this.InitShow();
			XGuildResContentionBuffDocument.Doc.StartCDTimer();
			this.ShowChat();
			this._yuyinHandler.Show(YuyinIconType.GuildResWar, 7);
			this._yuyinHandler.Show(true);
		}

		// Token: 0x0600AFFD RID: 45053 RVA: 0x002178AC File Offset: 0x00215AAC
		protected override void OnHide()
		{
			XGuildResContentionBuffDocument.Doc.StopCDTimer();
			this.HideBuffTips();
			this.HideChatMini();
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			base.OnHide();
		}

		// Token: 0x0600AFFE RID: 45054 RVA: 0x002178E5 File Offset: 0x00215AE5
		protected override void OnUnload()
		{
			this.HideBuffTips();
			XGuildResContentionBuffDocument.Doc.StopCDTimer();
			DlgHandlerBase.EnsureUnload<GuildBuffOperationHandler>(ref this._guildBuffHandler);
			DlgHandlerBase.EnsureUnload<GuildMineRankHandler>(ref this._rankHanler);
			DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
			base.OnUnload();
		}

		// Token: 0x0600AFFF RID: 45055 RVA: 0x00217928 File Offset: 0x00215B28
		public override void OnUpdate()
		{
			base.OnUpdate();
			base.uiBehaviour.m_ActivityCDCounter.Update();
			base.uiBehaviour.m_ExploreCDCounter.Update();
			float floatLeftTime = base.uiBehaviour.m_ExploreCDCounter.GetFloatLeftTime();
			bool flag = floatLeftTime > 0f;
			if (flag)
			{
				bool flag2 = this.ExploreTimeMax > 0U;
				if (flag2)
				{
					base.uiBehaviour.m_ExploreTimeSlider.Value = floatLeftTime / this.ExploreTimeMax;
				}
				else
				{
					base.uiBehaviour.m_ExploreTimeSlider.Value = 0f;
				}
			}
		}

		// Token: 0x0600B000 RID: 45056 RVA: 0x002179C0 File Offset: 0x00215BC0
		private void InitShow()
		{
			base.uiBehaviour.m_BtnExplore.gameObject.SetActive(false);
			base.uiBehaviour.m_BtnChallenge.gameObject.SetActive(false);
			base.uiBehaviour.m_BtnExploreAgain.gameObject.SetActive(false);
			base.uiBehaviour.m_NewFindTween.gameObject.SetActive(false);
			base.uiBehaviour.m_Exploring.gameObject.SetActive(false);
		}

		// Token: 0x0600B001 RID: 45057 RVA: 0x00217A44 File Offset: 0x00215C44
		public override void StackRefresh()
		{
			base.StackRefresh();
			XGuildMineEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
			bool flag = !specificDocument.MainInterfaceState;
			if (flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				DlgBase<GuildMineEntranceView, GuildMineEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				this.RefreshUI();
				this.ShowChat();
			}
		}

		// Token: 0x0600B002 RID: 45058 RVA: 0x00217A9C File Offset: 0x00215C9C
		public void RefreshUI()
		{
			this.RefreshButton();
			this.RefreshBoss();
			this.RefreshMemberTips();
			this.RefreshExploreTime();
			this.RefreshActivityTime();
			this.RefreshTopRightBuffs();
			this.RefreshRoleDetail();
			this.RefreshBuffsRecord();
			this.RefreshMySelfActingBuff();
		}

		// Token: 0x0600B003 RID: 45059 RVA: 0x00217AEC File Offset: 0x00215CEC
		private void RefreshRoleDetail()
		{
			base.uiBehaviour.m_RoleName.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
			int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
			string profHeadIcon = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(profID);
			base.uiBehaviour.m_RoleProtrait.SetSprite(profHeadIcon);
		}

		// Token: 0x0600B004 RID: 45060 RVA: 0x00217B50 File Offset: 0x00215D50
		public void HideChatMini()
		{
			ShowSettingArgs showSettingArgs = new ShowSettingArgs();
			showSettingArgs.needforceshow = true;
			showSettingArgs.forceshow = false;
			showSettingArgs.needdepth = true;
			showSettingArgs.depth = 0;
			showSettingArgs.anim = false;
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatMiniUI(showSettingArgs);
		}

		// Token: 0x0600B005 RID: 45061 RVA: 0x00217B94 File Offset: 0x00215D94
		public void RefreshActivityTime()
		{
			base.uiBehaviour.m_ActivityCDCounter.SetLeftTime(this.CurActivityLeftTime, -1);
			bool flag = this.ActivityStatus == GuildMineActivityStatus.Ready;
			if (flag)
			{
				base.uiBehaviour.m_ActivityTimeDescription.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_TIME_READY"));
			}
			else
			{
				bool flag2 = this.ActivityStatus == GuildMineActivityStatus.Start;
				if (flag2)
				{
					base.uiBehaviour.m_ActivityTimeDescription.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_TIME_START"));
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("GuildMineActivityStatus Is None", null, null, null, null, null);
				}
			}
		}

		// Token: 0x0600B006 RID: 45062 RVA: 0x00217C34 File Offset: 0x00215E34
		public void RefreshExploreTime()
		{
			bool flag = this.CurExploreLeftTime > 0f;
			if (flag)
			{
				base.uiBehaviour.m_Exploring.gameObject.SetActive(true);
				base.uiBehaviour.m_ExploreCDCounter.SetLeftTime(this.CurExploreLeftTime, -1);
				bool flag2 = this.ExploreTimeMax > 0U;
				if (flag2)
				{
					base.uiBehaviour.m_ExploreTimeSlider.Value = this.CurExploreLeftTime / this.ExploreTimeMax;
				}
				else
				{
					base.uiBehaviour.m_ExploreTimeSlider.Value = 0f;
				}
			}
			else
			{
				base.uiBehaviour.m_Exploring.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600B007 RID: 45063 RVA: 0x00217CE4 File Offset: 0x00215EE4
		public void RefreshMemberTips()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = specificDocument.MyTeam != null && specificDocument.MyTeam.members.Count != 0;
			if (flag)
			{
				base.uiBehaviour.m_MemberNum.gameObject.SetActive(true);
				base.uiBehaviour.m_MemberNum.SetText(specificDocument.MyTeam.members.Count.ToString());
			}
			else
			{
				base.uiBehaviour.m_MemberNum.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600B008 RID: 45064 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _OnLeftTimeOver(object o)
		{
		}

		// Token: 0x0600B009 RID: 45065 RVA: 0x00217D7C File Offset: 0x00215F7C
		public void RefreshButton()
		{
			bool flag = this.BossMine.Count == 0;
			if (flag)
			{
				base.uiBehaviour.m_BtnExplore.gameObject.SetActive(true);
				base.uiBehaviour.m_BtnChallenge.gameObject.SetActive(false);
				base.uiBehaviour.m_BtnExploreAgain.gameObject.SetActive(false);
				bool flag2 = this.CurExploreLeftTime > 0f;
				if (flag2)
				{
					base.uiBehaviour.m_TExplore.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_EXPLORE_CANCEL"));
				}
				else
				{
					base.uiBehaviour.m_TExplore.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_EXPLORE"));
				}
			}
			else
			{
				base.uiBehaviour.m_BtnExplore.gameObject.SetActive(false);
				base.uiBehaviour.m_BtnChallenge.gameObject.SetActive(true);
				base.uiBehaviour.m_BtnExploreAgain.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600B00A RID: 45066 RVA: 0x00217E88 File Offset: 0x00216088
		public void RefreshBoss()
		{
			base.uiBehaviour.m_BossTween.gameObject.SetActive(this.BossMine.Count != 0);
			bool flag = this.CanPlayNewFindAnim && this.BossMine.Count != 0;
			if (flag)
			{
				base.uiBehaviour.m_NewFindTween.PlayTween(true, -1f);
				base.uiBehaviour.m_BossTween.PlayTween(true, -1f);
				this.CanPlayNewFindAnim = false;
			}
			int num = 0;
			while ((long)num < (long)((ulong)XGuildMineMainDocument.BOSS_NUM_MAX))
			{
				bool flag2 = num < this.BossMine.Count;
				if (flag2)
				{
					bool flag3 = this.BossMine[num] == 0U;
					if (flag3)
					{
						base.uiBehaviour.m_NoLook[num].gameObject.SetActive(true);
						base.uiBehaviour.m_BossSelect[num].gameObject.SetActive(this.CurSelectMine == num + 1);
					}
					else
					{
						base.uiBehaviour.m_NoLook[num].gameObject.SetActive(false);
						base.uiBehaviour.m_BossSelect[num].gameObject.SetActive(this.CurSelectMine == num + 1);
						GuildMineralBattle.RowData mineData = XGuildMineMainDocument.GetMineData(this.BossMine[num]);
						bool flag4 = mineData == null;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("GuildMineralBattle MineId No Find:" + this.BossMine[num], null, null, null, null, null);
						}
						int num2 = mineData.DifficultLevel - 1;
						bool flag5 = num2 < this.BossDifficult.Length && num2 < this.BossColor.Length;
						if (flag5)
						{
							base.uiBehaviour.m_BossLevel[num].SetText(this.BossDifficult[num2]);
							base.uiBehaviour.m_BossLevel[num].SetColor(XSingleton<UiUtility>.singleton.ParseColor(this.BossColor[num2], 0));
						}
						else
						{
							XSingleton<XDebug>.singleton.AddErrorLog("GuildMineBossDifficultIndex Error:" + num2, null, null, null, null, null);
							base.uiBehaviour.m_BossLevel[num].SetText("");
						}
						uint num3 = Math.Min(mineData.Mineralcounts, XGuildMineMainDocument.MINE_NUM_MAX);
						int num4 = 0;
						while ((long)num4 < (long)((ulong)XGuildMineMainDocument.MINE_NUM_MAX))
						{
							base.uiBehaviour.m_BossMine[num, num4].gameObject.SetActive((long)num4 < (long)((ulong)num3));
							num4++;
						}
						XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(mineData.BossID);
						base.uiBehaviour.m_BossName[num].SetText(byID.Name);
						base.uiBehaviour.m_BossName[num].SetColor(XSingleton<UiUtility>.singleton.ParseColor(this.BossColor[num2], 0));
						XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
						base.uiBehaviour.m_BossSp[num].SetSprite(byPresentID.Avatar, byPresentID.Atlas, false);
						bool flag6 = num < this.BossMineBuff.Count;
						if (flag6)
						{
							GuildMineralBufflist.RowData mineBuffData = XGuildMineMainDocument.GetMineBuffData(this.BossMineBuff[num]);
							bool flag7 = mineBuffData == null;
							if (flag7)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("GuildMineralBufflist BuffId No Find:" + this.BossMineBuff[num], null, null, null, null, null);
							}
							uint num5 = mineBuffData.Quality - 1U;
							base.uiBehaviour.m_BossBuff[num].SetSprite(mineBuffData.icon);
							base.uiBehaviour.m_BossBuff[num].SetColor(XSingleton<UiUtility>.singleton.ParseColor(this.BossColor[(int)num5], 0));
							base.uiBehaviour.m_BossBuffText[num].SetText(mineBuffData.ratestring);
							base.uiBehaviour.m_BossBuffText[num].SetColor(XSingleton<UiUtility>.singleton.ParseColor(this.BossColor[(int)num5], 0));
						}
					}
					base.uiBehaviour.m_BossTex[num].ID = (ulong)((long)(num + 1));
					base.uiBehaviour.m_BossTex[num].RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnBossClicked));
				}
				else
				{
					base.uiBehaviour.m_NoLook[num].gameObject.SetActive(false);
				}
				num++;
			}
		}

		// Token: 0x0600B00B RID: 45067 RVA: 0x002182FC File Offset: 0x002164FC
		public void RefreshMySelfActingBuff()
		{
			List<GuildUsingBuffInfo> mySelfActingBuffList = XGuildResContentionBuffDocument.Doc.MySelfActingBuffList;
			int num = Mathf.Min(mySelfActingBuffList.Count, base.uiBehaviour.m_selfBuffIcons.childCount);
			int i;
			for (i = 0; i < num; i++)
			{
				GuildUsingBuffInfo guildUsingBuffInfo = mySelfActingBuffList[i];
				Transform child = base.uiBehaviour.m_selfBuffIcons.GetChild(i);
				child.gameObject.SetActive(true);
				IXUISprite ixuisprite = child.Find("BuffIcon").GetComponent("XUISprite") as IXUISprite;
				uint itemIDByBuffID = XHomeCookAndPartyDocument.Doc.GetItemIDByBuffID(guildUsingBuffInfo.buffID);
				bool flag = itemIDByBuffID == 0U;
				if (!flag)
				{
					GuildMineralStorage.RowData mineralStorageByID = XGuildResContentionBuffDocument.Doc.GetMineralStorageByID(itemIDByBuffID);
					ixuisprite.spriteName = mineralStorageByID.bufficon;
					IXUILabel ixuilabel = child.Find("CD").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(guildUsingBuffInfo.time.ToString());
				}
			}
			while (i < base.uiBehaviour.m_selfBuffIcons.childCount)
			{
				Transform child2 = base.uiBehaviour.m_selfBuffIcons.GetChild(i);
				child2.gameObject.SetActive(false);
				i++;
			}
		}

		// Token: 0x0600B00C RID: 45068 RVA: 0x00218444 File Offset: 0x00216644
		public void RefreshBuffsRecord()
		{
			base.uiBehaviour.m_GuildBuffRecordPool.ReturnAll(false);
			List<GuildBuffUsedRecordItem> mineUsedBuffRecordList = XGuildResContentionBuffDocument.Doc.MineUsedBuffRecordList;
			for (int i = mineUsedBuffRecordList.Count - 1; i >= 0; i--)
			{
				Transform transform = base.uiBehaviour.m_GuildBuffRecordPool.FetchGameObject(false).transform;
				IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(mineUsedBuffRecordList[i].MainMessage);
				ixuilabel.gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_GuildBuffRecordPool.TplPos.x, base.uiBehaviour.m_GuildBuffRecordPool.TplPos.y - (float)(i * base.uiBehaviour.m_GuildBuffRecordPool.TplHeight), 0f);
			}
			base.uiBehaviour.m_RecordScrollView.SetPosition(1f);
		}

		// Token: 0x0600B00D RID: 45069 RVA: 0x00218540 File Offset: 0x00216740
		private void ShowChat()
		{
			ShowSettingArgs showSettingArgs = new ShowSettingArgs();
			showSettingArgs.position = 0;
			showSettingArgs.needforceshow = true;
			showSettingArgs.forceshow = true;
			showSettingArgs.needdepth = true;
			showSettingArgs.depth = 6;
			showSettingArgs.forceshow = true;
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatMiniUI(showSettingArgs);
		}

		// Token: 0x0600B00E RID: 45070 RVA: 0x0021858C File Offset: 0x0021678C
		public void RefreshOwnedBuffItem(uint itemID, uint cd)
		{
			bool flag = this._guildBuffHandler != null && this._guildBuffHandler.IsVisible();
			if (flag)
			{
				this._guildBuffHandler.RefreshOwnedBuffItem(itemID, cd);
			}
		}

		// Token: 0x0600B00F RID: 45071 RVA: 0x002185C4 File Offset: 0x002167C4
		private bool OnExploreClicked(IXUIButton btn)
		{
			bool flag = this.ActivityStatus == GuildMineActivityStatus.Ready;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_READY_TIP"), base.uiBehaviour.m_ActivityCDCounter.GetLeftTime().ToString()), "fece00");
				result = true;
			}
			else
			{
				this.CurSelectMine = 0;
				bool flag2 = this.CurExploreLeftTime > 0f;
				if (flag2)
				{
					this.doc.ReqExplore(true);
				}
				else
				{
					this.doc.ReqExplore(false);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600B010 RID: 45072 RVA: 0x00218660 File Offset: 0x00216860
		private bool OnChallengeClicked(IXUIButton btn)
		{
			bool flag = this.CurSelectMine != 0;
			if (flag)
			{
				this.doc.ReqChallenge(this.CurSelectMine);
				this.CurSelectMine = 0;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_NO_SELECT_TIP"), "fece00");
			}
			return true;
		}

		// Token: 0x0600B011 RID: 45073 RVA: 0x002186C0 File Offset: 0x002168C0
		private bool OnTeamClicked(IXUIButton btn)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelGuildMine);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
				this.HideChatMini();
			}
			return true;
		}

		// Token: 0x0600B012 RID: 45074 RVA: 0x00218720 File Offset: 0x00216920
		private void OnBossClicked(IXUITexture tex)
		{
			this.CurSelectMine = (int)tex.ID;
			int num = 0;
			while ((long)num < (long)((ulong)XGuildMineMainDocument.BOSS_NUM_MAX))
			{
				bool flag = num < this.BossMine.Count;
				if (flag)
				{
					base.uiBehaviour.m_BossSelect[num].gameObject.SetActive(this.CurSelectMine == num + 1);
				}
				num++;
			}
		}

		// Token: 0x0600B013 RID: 45075 RVA: 0x0021878C File Offset: 0x0021698C
		private bool OnclickBuffStorage(IXUIButton button)
		{
			bool flag = this.GuildBuffHandler != null && !this.GuildBuffHandler.IsVisible();
			if (flag)
			{
				this.GuildBuffHandler.SetVisible(true);
			}
			return true;
		}

		// Token: 0x0600B014 RID: 45076 RVA: 0x002187CC File Offset: 0x002169CC
		private bool OnclickRankBtn(IXUIButton button)
		{
			bool flag = this._rankHanler != null && !this._rankHanler.IsVisible();
			if (flag)
			{
				this._rankHanler.SetVisible(true);
			}
			return true;
		}

		// Token: 0x0600B015 RID: 45077 RVA: 0x0021880C File Offset: 0x00216A0C
		private bool OnPressGuildBuffs(IXUISprite uiSprite, bool isPressed)
		{
			if (isPressed)
			{
				this.ShowBuffTips(uiSprite.ID);
			}
			else
			{
				this.HideBuffTips();
			}
			return true;
		}

		// Token: 0x0600B016 RID: 45078 RVA: 0x00218840 File Offset: 0x00216A40
		public void RefreshTopRightBuffs()
		{
			this._guildReviewItemDic.Clear();
			base.uiBehaviour.m_GuildBuffReviewPool.ReturnAll(false);
			List<WarResGuildInfo> allGuildInfos = XGuildResContentionBuffDocument.Doc.GetAllGuildInfos();
			bool flag = allGuildInfos != null;
			if (flag)
			{
				for (int i = 0; i < allGuildInfos.Count; i++)
				{
					Transform transform = base.uiBehaviour.m_GuildBuffReviewPool.FetchGameObject(false).transform;
					this._guildReviewItemDic.Add(allGuildInfos[i].guildID, transform);
					this.UpdateOneGuildBuff(transform, i);
				}
			}
		}

		// Token: 0x0600B017 RID: 45079 RVA: 0x002188D4 File Offset: 0x00216AD4
		private void UpdateOneGuildBuff(Transform guildBuff, int i)
		{
			List<WarResGuildInfo> allGuildInfos = XGuildResContentionBuffDocument.Doc.GetAllGuildInfos();
			guildBuff.localPosition = new Vector3(base.uiBehaviour.m_GuildBuffReviewPool.TplPos.x + (float)(i * base.uiBehaviour.m_GuildBuffReviewPool.TplWidth), base.uiBehaviour.m_GuildBuffReviewPool.TplPos.y, 0f);
			IXUISprite ixuisprite = guildBuff.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = allGuildInfos[i].guildID;
			ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnPressGuildBuffs));
			IXUISprite ixuisprite2 = guildBuff.Find("GuildIcon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.SetSprite(XGuildDocument.GetPortraitName((int)allGuildInfos[i].guildIcon));
			IXUILabel ixuilabel = guildBuff.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(allGuildInfos[i].guildName);
			IXUILabel ixuilabel2 = guildBuff.Find("Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(allGuildInfos[i].resValue.ToString());
			List<GuildUsingBuffInfo> guildUsedBuffList = XGuildResContentionBuffDocument.Doc.GetGuildUsedBuffList(allGuildInfos[i].guildID);
			Transform transform = guildBuff.Find("BuffIcon");
			int childCount = transform.childCount;
			int num = (guildUsedBuffList == null) ? 0 : Math.Min(childCount, guildUsedBuffList.Count);
			int j;
			for (j = 0; j < num; j++)
			{
				uint buffID = guildUsedBuffList[j].buffID;
				GuildBuffTable.RowData guildBuffDataByBuffID = XGuildResContentionBuffDocument.Doc.GetGuildBuffDataByBuffID(buffID);
				GuildMineralStorage.RowData mineralStorageByID = XGuildResContentionBuffDocument.Doc.GetMineralStorageByID(guildBuffDataByBuffID.itemid);
				Transform child = transform.GetChild(j);
				IXUILabel ixuilabel3 = child.Find("CD").GetComponent("XUILabel") as IXUILabel;
				child.gameObject.SetActive(true);
				bool flag = string.IsNullOrEmpty(mineralStorageByID.bufficon);
				if (flag)
				{
					child.gameObject.SetActive(false);
					ixuilabel3.SetText("");
				}
				else
				{
					IXUISprite ixuisprite3 = child.Find("BuffIcon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite3.spriteName = mineralStorageByID.bufficon;
					ixuilabel3.SetText(guildUsedBuffList[j].time.ToString());
				}
			}
			while (j < childCount)
			{
				transform.GetChild(j).gameObject.SetActive(false);
				j++;
			}
		}

		// Token: 0x0600B018 RID: 45080 RVA: 0x00218B7C File Offset: 0x00216D7C
		private void ShowBuffTips(ulong guildID)
		{
			this._pressedGuildID = guildID;
			Transform transform = null;
			bool flag = this._guildReviewItemDic.TryGetValue(this._pressedGuildID, out transform);
			if (flag)
			{
				Transform parent = transform.Find("BuffsInfo");
				this._guildBuffChildrenDic.Clear();
				base.uiBehaviour.m_BuffTipPool.ReturnAll(false);
				List<GuildUsingBuffInfo> guildUsedBuffList = XGuildResContentionBuffDocument.Doc.GetGuildUsedBuffList(this._pressedGuildID);
				bool flag2 = guildUsedBuffList == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("invalid guildID" + guildID, null, null, null, null, null);
				}
				else
				{
					bool flag3 = guildUsedBuffList.Count > 0;
					if (flag3)
					{
						for (int i = 0; i < guildUsedBuffList.Count; i++)
						{
							GuildUsingBuffInfo guildUsingBuffInfo = guildUsedBuffList[i];
							GameObject gameObject = base.uiBehaviour.m_BuffTipPool.FetchGameObject(false);
							gameObject.transform.parent = parent;
							gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)base.uiBehaviour.m_BuffTipPool.TplHeight * i), 0f);
							this._guildBuffChildrenDic.Add(guildUsingBuffInfo.buffID, gameObject.transform);
							this.UpdatePressedTip(gameObject, guildUsingBuffInfo);
						}
					}
				}
			}
		}

		// Token: 0x0600B019 RID: 45081 RVA: 0x00218CD4 File Offset: 0x00216ED4
		private void UpdatePressedTip(GameObject item, GuildUsingBuffInfo info)
		{
			GuildBuffTable.RowData guildBuffDataByBuffID = XGuildResContentionBuffDocument.Doc.GetGuildBuffDataByBuffID(info.buffID);
			GuildMineralStorage.RowData mineralStorageByID = XGuildResContentionBuffDocument.Doc.GetMineralStorageByID(guildBuffDataByBuffID.itemid);
			IXUISprite ixuisprite = item.transform.Find("BuffIcon/Tpl/BuffIcon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = mineralStorageByID.bufficon;
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)mineralStorageByID.itemid);
			IXUILabel ixuilabel = item.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(itemConf.ItemName[0]);
			IXUILabel ixuilabel2 = item.transform.Find("Effect").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(mineralStorageByID.buffdescribe);
			IXUILabel ixuilabel3 = item.transform.Find("Remain").GetComponent("XUILabel") as IXUILabel;
			ixuilabel3.SetText(info.time.ToString());
		}

		// Token: 0x0600B01A RID: 45082 RVA: 0x00218DD1 File Offset: 0x00216FD1
		private void HideBuffTips()
		{
			this._pressedGuildID = 0UL;
			this._guildBuffChildrenDic.Clear();
			base.uiBehaviour.m_BuffTipPool.ReturnAll(false);
		}

		// Token: 0x0600B01B RID: 45083 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void PlayNewFindAnim()
		{
		}

		// Token: 0x0600B01C RID: 45084 RVA: 0x00218DFC File Offset: 0x00216FFC
		public void RefreshGuildBuffCD()
		{
			List<WarResGuildInfo> allGuildInfos = XGuildResContentionBuffDocument.Doc.GetAllGuildInfos();
			for (int i = 0; i < allGuildInfos.Count; i++)
			{
				Transform guildBuff = null;
				bool flag = this._guildReviewItemDic.TryGetValue(allGuildInfos[i].guildID, out guildBuff);
				if (flag)
				{
					this.UpdateOneGuildBuff(guildBuff, i);
				}
			}
			bool flag2 = this._pressedGuildID > 0UL;
			if (flag2)
			{
				List<GuildUsingBuffInfo> guildUsedBuffList = XGuildResContentionBuffDocument.Doc.GetGuildUsedBuffList(this._pressedGuildID);
				bool flag3 = guildUsedBuffList == null;
				if (!flag3)
				{
					bool flag4 = guildUsedBuffList.Count > 0;
					if (flag4)
					{
						for (int j = 0; j < guildUsedBuffList.Count; j++)
						{
							GuildUsingBuffInfo guildUsingBuffInfo = guildUsedBuffList[j];
							Transform transform = null;
							bool flag5 = this._guildBuffChildrenDic.TryGetValue(guildUsingBuffInfo.buffID, out transform);
							if (flag5)
							{
								this.UpdatePressedTip(transform.gameObject, guildUsingBuffInfo);
							}
						}
					}
				}
			}
		}

		// Token: 0x04004355 RID: 17237
		private XGuildMineMainDocument doc = null;

		// Token: 0x04004356 RID: 17238
		private GuildBuffOperationHandler _guildBuffHandler;

		// Token: 0x04004357 RID: 17239
		private GuildMineRankHandler _rankHanler;

		// Token: 0x04004358 RID: 17240
		private XYuyinView _yuyinHandler;

		// Token: 0x04004359 RID: 17241
		private Dictionary<ulong, Transform> _guildReviewItemDic = new Dictionary<ulong, Transform>();

		// Token: 0x0400435A RID: 17242
		private Dictionary<uint, Transform> _guildBuffChildrenDic = new Dictionary<uint, Transform>();

		// Token: 0x0400435B RID: 17243
		public string[] BossDifficult = XSingleton<XGlobalConfig>.singleton.GetValue("GuildMineBossDifficult").Split(new char[]
		{
			'|'
		});

		// Token: 0x0400435C RID: 17244
		public string[] BossColor = XSingleton<XGlobalConfig>.singleton.GetValue("GuildMineBossColor").Split(new char[]
		{
			'|'
		});

		// Token: 0x0400435D RID: 17245
		public int CurSelectMine;

		// Token: 0x0400435E RID: 17246
		public bool CanPlayNewFindAnim = true;

		// Token: 0x0400435F RID: 17247
		public float CurActivityLeftTime;

		// Token: 0x04004360 RID: 17248
		public GuildMineActivityStatus ActivityStatus;

		// Token: 0x04004361 RID: 17249
		public float CurExploreLeftTime;

		// Token: 0x04004362 RID: 17250
		public uint ExploreTimeMax;

		// Token: 0x04004363 RID: 17251
		public List<uint> BossMine = new List<uint>();

		// Token: 0x04004364 RID: 17252
		public List<uint> BossMineBuff = new List<uint>();

		// Token: 0x04004365 RID: 17253
		private ulong _pressedGuildID = 0UL;
	}
}
