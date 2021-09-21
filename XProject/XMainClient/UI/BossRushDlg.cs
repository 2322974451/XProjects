using System;
using System.Collections;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200181D RID: 6173
	internal class BossRushDlg : DlgBase<BossRushDlg, BossRushBehavior>
	{
		// Token: 0x1700390D RID: 14605
		// (get) Token: 0x06010040 RID: 65600 RVA: 0x003CD9A8 File Offset: 0x003CBBA8
		public override string fileName
		{
			get
			{
				return "Hall/BossRushNewDlg";
			}
		}

		// Token: 0x1700390E RID: 14606
		// (get) Token: 0x06010041 RID: 65601 RVA: 0x003CD9C0 File Offset: 0x003CBBC0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700390F RID: 14607
		// (get) Token: 0x06010042 RID: 65602 RVA: 0x003CD9D4 File Offset: 0x003CBBD4
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_BossRush);
			}
		}

		// Token: 0x17003910 RID: 14608
		// (get) Token: 0x06010043 RID: 65603 RVA: 0x003CD9F0 File Offset: 0x003CBBF0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003911 RID: 14609
		// (get) Token: 0x06010044 RID: 65604 RVA: 0x003CDA04 File Offset: 0x003CBC04
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003912 RID: 14610
		// (get) Token: 0x06010045 RID: 65605 RVA: 0x003CDA18 File Offset: 0x003CBC18
		public bool isHallUI
		{
			get
			{
				return XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			}
		}

		// Token: 0x17003913 RID: 14611
		// (get) Token: 0x06010046 RID: 65606 RVA: 0x003CDA3C File Offset: 0x003CBC3C
		public bool isBattle
		{
			get
			{
				return XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;
			}
		}

		// Token: 0x17003914 RID: 14612
		// (get) Token: 0x06010047 RID: 65607 RVA: 0x003CDA60 File Offset: 0x003CBC60
		public uint killAllMonster
		{
			get
			{
				bool flag = this._doc == null || this._doc.respData == null;
				uint result;
				if (flag)
				{
					result = 1U;
				}
				else
				{
					XLevelState ls = XSingleton<XLevelStatistics>.singleton.ls;
					result = ((this._doc.respData.currank >= this._doc.respData.maxrank && ls._boss_rush_kill > this.killedboss) ? 1U : 0U);
				}
				return result;
			}
		}

		// Token: 0x17003915 RID: 14613
		// (get) Token: 0x06010048 RID: 65608 RVA: 0x003CDAD4 File Offset: 0x003CBCD4
		public bool isWin
		{
			get
			{
				bool flag = this._doc == null || this._doc.respData == null;
				bool result;
				if (flag)
				{
					result = true;
				}
				else
				{
					XLevelState ls = XSingleton<XLevelStatistics>.singleton.ls;
					result = (this._doc.respData.currank >= this._doc.respData.maxrank && ls._boss_rush_kill > this.killedboss);
				}
				return result;
			}
		}

		// Token: 0x17003916 RID: 14614
		// (get) Token: 0x06010049 RID: 65609 RVA: 0x003CDB48 File Offset: 0x003CBD48
		private bool isPrivilege
		{
			get
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				bool flag = specificDocument == null;
				return !flag && specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);
			}
		}

		// Token: 0x0601004A RID: 65610 RVA: 0x003CDB78 File Offset: 0x003CBD78
		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XBossBushDocument.uuID) as XBossBushDocument);
			this._sweepDoc = XDocuments.GetSpecificDocument<XSweepDocument>(XSweepDocument.uuID);
			this._welfareDoc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.m_animPanel = this.m_uiBehaviour.transform.FindChild("Bg/RefreshAnim").gameObject;
			XSingleton<XBossRefreshAnimHander>.singleton.Init(this.m_animPanel);
			this.colors[0] = "[" + XSingleton<XGlobalConfig>.singleton.GetValue("Diff0Color") + "]";
			this.colors[1] = "[" + XSingleton<XGlobalConfig>.singleton.GetValue("Diff1Color") + "]";
			this.colors[2] = "[" + XSingleton<XGlobalConfig>.singleton.GetValue("Diff2Color") + "]";
			this.colors[3] = "[" + XSingleton<XGlobalConfig>.singleton.GetValue("Diff3Color") + "]";
		}

		// Token: 0x0601004B RID: 65611 RVA: 0x003CDC98 File Offset: 0x003CBE98
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_uiBehaviour.m_btnRefesh.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenAnimDlg));
			this.m_uiBehaviour.m_btnBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoBattle));
			base.uiBehaviour.m_SweepButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSweepButtonClicked));
			this.m_uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			this.m_uiBehaviour.m_sprBg.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnMonsterDrag));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_sprPrivilegeBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMemberPrivilegeClicked));
		}

		// Token: 0x0601004C RID: 65612 RVA: 0x0023F430 File Offset: 0x0023D630
		private void OnMemberPrivilegeClicked(IXUISprite btn)
		{
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);
		}

		// Token: 0x0601004D RID: 65613 RVA: 0x003CDD78 File Offset: 0x003CBF78
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_BossRush);
			return true;
		}

		// Token: 0x0601004E RID: 65614 RVA: 0x003CDD98 File Offset: 0x003CBF98
		protected override void OnShow()
		{
			this.m_animPanel.SetActive(false);
			this.m_uiBehaviour.m_objFx.SetActive(false);
			base.OnShow();
			base.Alloc3DAvatarPool("BossRushDlg");
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XBossBushDocument.uuID) as XBossBushDocument);
			this._doc.ParseRefresh();
			this.isProcessFighting = false;
		}

		// Token: 0x0601004F RID: 65615 RVA: 0x003CDE0C File Offset: 0x003CC00C
		protected bool OnMonsterDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.EngineObject.Rotate(Vector3.up, -delta.x / 2f);
			}
			return true;
		}

		// Token: 0x06010050 RID: 65616 RVA: 0x003CDE4F File Offset: 0x003CC04F
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("BossRushDlg");
			this.RefreshBoss();
		}

		// Token: 0x06010051 RID: 65617 RVA: 0x003CDE6C File Offset: 0x003CC06C
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			base.uiBehaviour.m_objFx.SetActive(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timertoken);
			XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			this.m_Dummy = null;
		}

		// Token: 0x06010052 RID: 65618 RVA: 0x003CDEC4 File Offset: 0x003CC0C4
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool activeSelf = this.m_animPanel.activeSelf;
			if (activeSelf)
			{
				XSingleton<XBossRefreshAnimHander>.singleton.OnUpdate();
			}
		}

		// Token: 0x06010053 RID: 65619 RVA: 0x003CDEF3 File Offset: 0x003CC0F3
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timertoken);
			base.Return3DAvatarPool();
			this.m_Dummy = null;
		}

		// Token: 0x06010054 RID: 65620 RVA: 0x003CDF1C File Offset: 0x003CC11C
		protected override void OnUnload()
		{
			XSingleton<XBossRefreshAnimHander>.singleton.OnUnload();
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			bool flag = this.m_timertoken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timertoken);
			}
			this.isDelayRefresh = false;
			base.OnUnload();
		}

		// Token: 0x06010055 RID: 65621 RVA: 0x003CDF74 File Offset: 0x003CC174
		private bool OnClose(IXUIButton btn)
		{
			bool isHallUI = this.isHallUI;
			if (isHallUI)
			{
				this.SetVisible(false, true);
			}
			else
			{
				this.backHall = true;
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
			return true;
		}

		// Token: 0x06010056 RID: 65622 RVA: 0x003CDFB0 File Offset: 0x003CC1B0
		private bool OnGoBattle(IXUIButton btn)
		{
			bool flag = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnGoBattle), btn) || this.isProcessFighting;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.isProcessFighting = true;
				bool isBattle = this.isBattle;
				if (isBattle)
				{
					base.uiBehaviour.LoadBossAndStart();
				}
				else
				{
					this.GoBattle();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06010057 RID: 65623 RVA: 0x003CE014 File Offset: 0x003CC214
		private bool OnSweepButtonClicked(IXUIButton button)
		{
			bool flag = DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
			if (flag)
			{
				this._sweepDoc.TrySweepQuery(2010U, 1U);
			}
			return true;
		}

		// Token: 0x06010058 RID: 65624 RVA: 0x003CE04A File Offset: 0x003CC24A
		public void MakeTips()
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BOSSRUSH_NOTE"), "fece00");
		}

		// Token: 0x06010059 RID: 65625 RVA: 0x003CE068 File Offset: 0x003CC268
		public bool GoBattle()
		{
			XLevelState ls = XSingleton<XLevelStatistics>.singleton.ls;
			bool flag = ls != null;
			if (flag)
			{
				this.killedboss = ls._boss_rush_kill;
			}
			this.startFromHall = this.isHallUI;
			bool isHallUI = this.isHallUI;
			if (isHallUI)
			{
				List<uint> list = ListPool<uint>.Get();
				XSingleton<XSceneMgr>.singleton.GetSceneListByType(XChapterType.SCENE_BOSSRUSH, list);
				bool flag2 = list != null && list.Count > 0;
				if (flag2)
				{
					PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
					ptcC2G_EnterSceneReq.Data.sceneID = list[0];
					XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("not config bossrush in scenelist", null, null, null, null, null);
				}
				ListPool<uint>.Release(list);
			}
			else
			{
				bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(true);
					DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(true);
					DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(true, true);
				}
				bool flag4 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag4)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisiblePure(true);
					DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(true);
					DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(true, true);
				}
				this.OnBossFadein();
				this.SetVisible(false, true);
			}
			return true;
		}

		// Token: 0x0601005A RID: 65626 RVA: 0x003CE1AC File Offset: 0x003CC3AC
		public IEnumerator LoadBossAssets()
		{
			DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(true, true);
			XEntityStatistics.RowData data = this._doc.entityRow;
			XEntityPresentation.RowData presentData = this._doc.presentRow;
			XSingleton<XEntityMgr>.singleton.PreloadTemp(data.PresentID, data.ID, (EntitySpecies)data.Type);
			yield return null;
			DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);
			this._doc.SendQuery(BossRushReqStatus.BOSSRUSH_REQ_CONTINUE);
			yield break;
		}

		// Token: 0x0601005B RID: 65627 RVA: 0x003CE1BC File Offset: 0x003CC3BC
		public void OnBossFadein()
		{
			this.MakeTips();
			this.ResetState();
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.RefreshBossRush();
			this.isProcessFighting = false;
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.timeConnter != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetTimeRecord();
			}
		}

		// Token: 0x0601005C RID: 65628 RVA: 0x003CE208 File Offset: 0x003CC408
		public void ResetState()
		{
			XBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID);
			specificDocument.OnCoolDown(null);
		}

		// Token: 0x0601005D RID: 65629 RVA: 0x003CE22C File Offset: 0x003CC42C
		private bool OpenAnimDlg(IXUIButton btn)
		{
			bool flag = this.isDelayRefresh || this.isProcessFighting;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.refreshCost > 0 && XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(this.refreshItemid) < (ulong)((long)this.refreshCost);
				if (flag2)
				{
					bool flag3 = this.refreshItemid == XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_AUCTGOLDLESS"), "fece00");
					}
					else
					{
						bool flag4 = this.refreshItemid == XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN);
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TEAMBUY_DRAGONCOIN_LESS"), "fece00");
						}
						else
						{
							bool flag5 = this.refreshItemid == XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DIAMOND);
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TEAMBUY_DIAMOND_LESS"), "fece00");
							}
						}
					}
				}
				else
				{
					bool flag6 = this._doc.respData.currefreshcount >= this._doc.respData.maxrefreshcount;
					if (flag6)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BOSSRUSH_LIMIT"), "fece00");
					}
					else
					{
						bool flag7 = !this._doc.isSendingRefreshMsg;
						if (flag7)
						{
							this._doc.isSendingRefreshMsg = true;
							this._doc.SendQuery(BossRushReqStatus.BOSSRUSH_REQ_REFRESH);
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0601005E RID: 65630 RVA: 0x003CE39C File Offset: 0x003CC59C
		public void OnResOpenAnimDlg()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				XSingleton<XBossRefreshAnimHander>.singleton.Show();
				this.m_uiBehaviour.m_objFx.SetActive(false);
			}
		}

		// Token: 0x0601005F RID: 65631 RVA: 0x003CE3D3 File Offset: 0x003CC5D3
		public void DelayRefresh()
		{
			this.isDelayRefresh = true;
			this.m_timertoken = XSingleton<XTimerMgr>.singleton.SetTimer(0.3f, new XTimerMgr.ElapsedEventHandler(this.Refresh), null);
		}

		// Token: 0x06010060 RID: 65632 RVA: 0x003CE3FF File Offset: 0x003CC5FF
		public void Refresh()
		{
			this.Refresh(null);
		}

		// Token: 0x06010061 RID: 65633 RVA: 0x003CE40C File Offset: 0x003CC60C
		public void Refresh(object obj)
		{
			this.isDelayRefresh = false;
			bool flag = this._doc == null;
			if (flag)
			{
				this.Init();
			}
			bool flag2 = this._doc.respData != null;
			if (flag2)
			{
				base.uiBehaviour.ResetPool();
				this.RefreshBoss();
				this.RefreshRwd();
				this.RefreshBtns();
			}
		}

		// Token: 0x17003917 RID: 14615
		// (get) Token: 0x06010062 RID: 65634 RVA: 0x003CE46C File Offset: 0x003CC66C
		public string bossName
		{
			get
			{
				bool flag = this._doc == null;
				if (flag)
				{
					this._doc = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
				}
				byte[] bossdifficult = this._doc.bossRushRow.bossdifficult;
				bool flag2 = bossdifficult == null && bossdifficult.Length < 1;
				string result;
				if (flag2)
				{
					result = "";
				}
				else
				{
					result = this.colors[(int)(bossdifficult[0] - 1)] + this._doc.entityRow.Name;
				}
				return result;
			}
		}

		// Token: 0x06010063 RID: 65635 RVA: 0x003CE4E8 File Offset: 0x003CC6E8
		private void RefreshBoss()
		{
			byte[] bossdifficult = this._doc.bossRushRow.bossdifficult;
			bool flag = bossdifficult == null && bossdifficult.Length < 4;
			if (!flag)
			{
				base.uiBehaviour.m_lblLayer.SetText(this._doc.respData.currank.ToString());
				base.uiBehaviour.m_lblProgress.SetText(this._doc.respData.currank + "/" + this._doc.respData.maxrank);
				base.uiBehaviour.m_lblTitle.SetText(this.bossName);
				base.uiBehaviour.m_lblDesc.SetText(this._doc.bossRushRow.bosstip);
				base.uiBehaviour.m_lblDiff.SetText(XStringDefineProxy.GetString("BOSSRUSH_DIF" + bossdifficult[0]));
				base.uiBehaviour.m_lblLeft.SetText(this._doc.leftChanllageCnt + "/" + this._doc.respData.joincountmax);
				for (int i = 0; i < (int)bossdifficult[1]; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_attpool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3((float)(-6 + 24 * i), 3f, 0f);
				}
				for (int j = 0; j < (int)bossdifficult[2]; j++)
				{
					GameObject gameObject2 = base.uiBehaviour.m_defpool.FetchGameObject(false);
					gameObject2.transform.localPosition = new Vector3((float)(-6 + 24 * j), -23f, 0f);
				}
				for (int k = 0; k < (int)bossdifficult[3]; k++)
				{
					GameObject gameObject3 = base.uiBehaviour.m_lifepool.FetchGameObject(false);
					gameObject3.transform.localPosition = new Vector3((float)(-6 + 24 * k), -49f, 0f);
				}
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._doc.entityRow.ID);
				bool flag2 = byID != null && base.uiBehaviour != null;
				if (flag2)
				{
					this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, byID.PresentID, this.m_uiBehaviour.m_BossSnapshot, this.m_Dummy, 1f);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("id: ", this._doc.entityRow.ID.ToString(), " mono: " + (base.uiBehaviour == null).ToString(), " enemydata: " + (byID == null).ToString(), null, null);
				}
			}
		}

		// Token: 0x06010064 RID: 65636 RVA: 0x003CE7F0 File Offset: 0x003CC9F0
		private void RefreshRwd()
		{
			for (int i = 0; i < this._doc.bossRushRow.reward.Count; i++)
			{
				uint num = this._doc.bossRushRow.reward[i, 0];
				uint num2 = this._doc.bossRushRow.reward[i, 1];
				GameObject gameObject = base.uiBehaviour.m_rwdpool.FetchGameObject(false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num, (int)(num2 * this._doc.rwdRate), false);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnIconClick));
				gameObject.transform.localPosition = new Vector3((float)(36 + 90 * i), -63f, 0f);
			}
			this.m_uiBehaviour.m_sprBuff1.SetSprite(this._doc.bossBuff1Row.icon);
			this.m_uiBehaviour.m_lblBuff1.SetText(this._doc.bossBuff1Row.Comment);
			this.m_uiBehaviour.m_sprBuff2.SetSprite(this._doc.bossBuff2Row.icon);
			this.m_uiBehaviour.m_lblBuff2.SetText(this._doc.bossBuff2Row.Comment);
			int quality = this._doc.bossBuff1Row.Quality;
			int quality2 = this._doc.bossBuff2Row.Quality;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + quality + "Color");
			string value2 = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + quality2 + "Color");
			this.m_uiBehaviour.m_lblBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value, 0));
			this.m_uiBehaviour.m_sprBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value, 0));
			this.m_uiBehaviour.m_lblBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value2, 0));
			this.m_uiBehaviour.m_sprBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value2, 0));
		}

		// Token: 0x06010065 RID: 65637 RVA: 0x003CEA53 File Offset: 0x003CCC53
		private void OnIconClick(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)spr.ID, spr.gameObject);
		}

		// Token: 0x06010066 RID: 65638 RVA: 0x003CEA70 File Offset: 0x003CCC70
		private void RefreshBtns()
		{
			bool flag = this._doc == null || this._doc.respData == null || !base.IsVisible();
			if (!flag)
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				bool flag2 = !this.isPrivilege;
				if (flag2)
				{
					this.RefreshNoPriviedge();
				}
				else
				{
					this.RefreshPriviledge();
				}
				this.m_uiBehaviour.m_btnBattle.SetEnable(this._doc.leftChanllageCnt > 0, false);
				this.m_uiBehaviour.m_lblBattle.SetText((this._doc.respData.currank > 1) ? XStringDefineProxy.GetString("BOSSRUSH_CHANG") : XStringDefineProxy.GetString("BOSSRUSH_CHAN"));
				base.uiBehaviour.m_lblRefresh.SetVisible(false);
				base.uiBehaviour.m_sprVip.SetGrey(this.isPrivilege);
				base.uiBehaviour.m_lblPrivilege.SetEnabled(this.isPrivilege);
				base.uiBehaviour.m_sprVip.SetSprite(specificDocument.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Adventurer));
			}
		}

		// Token: 0x06010067 RID: 65639 RVA: 0x003CEB84 File Offset: 0x003CCD84
		private void RefreshPriviledge()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			PayMemberTable.RowData memberPrivilegeConfig = specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Adventurer);
			int num = (memberPrivilegeConfig == null) ? 0 : memberPrivilegeConfig.BossRushCount;
			int num2 = (specificDocument.PayMemberPrivilege == null) ? 0 : specificDocument.PayMemberPrivilege.usedBossRushCount;
			int currefreshcount = this._doc.respData.currefreshcount;
			bool flag = num2 < num || currefreshcount < num + this._doc.refreshConfig.freeIndex;
			this.m_uiBehaviour.m_lblFree.SetVisible(flag);
			this.m_uiBehaviour.m_sprCoin.gameObject.SetActive(!flag);
			bool flag2 = !flag;
			if (flag2)
			{
				bool flag3 = this._doc.refreshConfig.item1Index > currefreshcount - num2;
				if (flag3)
				{
					this.refreshItemid = this._doc.refreshConfig.item1Id;
					this.refreshCost = this._doc.refreshConfig.item1Start + this._doc.refreshConfig.item1Add * (currefreshcount - this._doc.refreshConfig.freeIndex - num2);
					ItemList.RowData itemConf = XBagDocument.GetItemConf(this._doc.refreshConfig.item1Id);
					string sprite = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon1, XItemDrawerMgr.Param.Profession);
					base.uiBehaviour.m_sprCoin.SetSprite(sprite);
				}
				else
				{
					this.refreshItemid = this._doc.refreshConfig.item2Id;
					this.refreshCost = this._doc.refreshConfig.item2Start + this._doc.refreshConfig.item2Add * (currefreshcount - this._doc.refreshConfig.item1Index - num2);
					ItemList.RowData itemConf2 = XBagDocument.GetItemConf(this._doc.refreshConfig.item2Id);
					bool flag4 = itemConf2 != null;
					if (flag4)
					{
						string sprite2 = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf2.ItemIcon1, XItemDrawerMgr.Param.Profession);
						base.uiBehaviour.m_sprCoin.SetSprite(sprite2);
					}
				}
				this.m_uiBehaviour.m_lblCost.SetText(this.refreshCost.ToString());
			}
			else
			{
				this.refreshCost = 0;
			}
			base.uiBehaviour.m_lblPrivilege.SetText(XStringDefineProxy.GetString("BOSSRUSH_PRIVILEGE", new object[]
			{
				num
			}));
		}

		// Token: 0x06010068 RID: 65640 RVA: 0x003CEDF4 File Offset: 0x003CCFF4
		private void RefreshNoPriviedge()
		{
			int currefreshcount = this._doc.respData.currefreshcount;
			bool flag = this._doc.refreshConfig.freeIndex > currefreshcount;
			this.m_uiBehaviour.m_lblFree.SetVisible(flag);
			this.m_uiBehaviour.m_sprCoin.gameObject.SetActive(!flag);
			bool flag2 = !flag;
			if (flag2)
			{
				bool flag3 = this._doc.refreshConfig.item1Index > currefreshcount;
				if (flag3)
				{
					this.refreshItemid = this._doc.refreshConfig.item1Id;
					this.refreshCost = this._doc.refreshConfig.item1Start + this._doc.refreshConfig.item1Add * (currefreshcount - this._doc.refreshConfig.freeIndex);
					ItemList.RowData itemConf = XBagDocument.GetItemConf(this._doc.refreshConfig.item1Id);
					bool flag4 = itemConf != null;
					if (flag4)
					{
						string sprite = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon1, XItemDrawerMgr.Param.Profession);
						base.uiBehaviour.m_sprCoin.SetSprite(sprite);
					}
				}
				else
				{
					this.refreshItemid = this._doc.refreshConfig.item2Id;
					this.refreshCost = this._doc.refreshConfig.item2Start + this._doc.refreshConfig.item2Add * (currefreshcount - this._doc.refreshConfig.item1Index);
					ItemList.RowData itemConf2 = XBagDocument.GetItemConf(this._doc.refreshConfig.item2Id);
					bool flag5 = itemConf2 != null;
					if (flag5)
					{
						string sprite2 = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf2.ItemIcon1, XItemDrawerMgr.Param.Profession);
						base.uiBehaviour.m_sprCoin.SetSprite(sprite2);
					}
				}
				this.m_uiBehaviour.m_lblCost.SetText(this.refreshCost.ToString());
			}
			else
			{
				this.refreshCost = 0;
			}
		}

		// Token: 0x06010069 RID: 65641 RVA: 0x003CEFF2 File Offset: 0x003CD1F2
		public void PlayRefreshEff()
		{
			base.uiBehaviour.m_objFx.SetActive(true);
		}

		// Token: 0x040071E0 RID: 29152
		private XBossBushDocument _doc = null;

		// Token: 0x040071E1 RID: 29153
		private XSweepDocument _sweepDoc = null;

		// Token: 0x040071E2 RID: 29154
		private XWelfareDocument _welfareDoc = null;

		// Token: 0x040071E3 RID: 29155
		public GameObject m_animPanel;

		// Token: 0x040071E4 RID: 29156
		private XDummy m_Dummy;

		// Token: 0x040071E5 RID: 29157
		private uint m_timertoken = 0U;

		// Token: 0x040071E6 RID: 29158
		public string[] colors = new string[]
		{
			"[00e901]",
			"[ffffff]",
			"[ffaf00]",
			"[aa7de4]"
		};

		// Token: 0x040071E7 RID: 29159
		public bool startFromHall = false;

		// Token: 0x040071E8 RID: 29160
		private int killedboss = 0;

		// Token: 0x040071E9 RID: 29161
		public bool backHall = false;

		// Token: 0x040071EA RID: 29162
		private int refreshCost = 0;

		// Token: 0x040071EB RID: 29163
		private int refreshItemid = 1;

		// Token: 0x040071EC RID: 29164
		private bool isProcessFighting = false;

		// Token: 0x040071ED RID: 29165
		private bool isDelayRefresh = false;
	}
}
