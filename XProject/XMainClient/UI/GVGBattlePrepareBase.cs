using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016EC RID: 5868
	internal class GVGBattlePrepareBase<T, V> : DlgBase<T, V>, IGVGBattlePrepare, IXUIDlg where T : IXUIDlg, new() where V : GVGBattlePrepareBehaviour
	{
		// Token: 0x17003756 RID: 14166
		// (get) Token: 0x0600F205 RID: 61957 RVA: 0x00359A58 File Offset: 0x00357C58
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003757 RID: 14167
		// (get) Token: 0x0600F206 RID: 61958 RVA: 0x00359A6C File Offset: 0x00357C6C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F207 RID: 61959 RVA: 0x00359A80 File Offset: 0x00357C80
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			this.SetResurgence(0);
			bool flag = !DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisible(true, true);
			}
			this.RefreshSection();
			this.blueState = true;
			this.OnLeftToogle(null);
			this.OnInitInspire();
		}

		// Token: 0x0600F208 RID: 61960 RVA: 0x00359AE8 File Offset: 0x00357CE8
		private void OnInitInspire()
		{
			int num = 0;
			float value = 0f;
			bool progress = this.GetProgress(this._Doc.BlueInfo.Inspire, out num, out value);
			if (progress)
			{
				base.SetXUILable("Battle/Encourage/Blue/Time", XSingleton<XCommon>.singleton.StringCombine("x", num.ToString()));
				base.uiBehaviour.mBlueCourageBar.Value = value;
			}
			bool progress2 = this.GetProgress(this._Doc.RedInfo.Inspire, out num, out value);
			if (progress2)
			{
				base.SetXUILable("Battle/Encourage/Red/Time", XSingleton<XCommon>.singleton.StringCombine("x", num.ToString()));
				base.uiBehaviour.mRedCourageBar.Value = value;
			}
		}

		// Token: 0x0600F209 RID: 61961 RVA: 0x00359BB4 File Offset: 0x00357DB4
		protected override void OnHide()
		{
			base.OnHide();
			this.SetResurgence(0);
			this.ResetCommonUI();
		}

		// Token: 0x0600F20A RID: 61962 RVA: 0x00359BD0 File Offset: 0x00357DD0
		protected override void OnUnload()
		{
			bool flag = base.uiBehaviour.mBluePanel != null;
			if (flag)
			{
				base.uiBehaviour.mBluePanel.Recycle();
				base.uiBehaviour.mBluePanel = null;
			}
			this.ResetCommonUI();
			base.OnUnload();
		}

		// Token: 0x0600F20B RID: 61963 RVA: 0x00359C2C File Offset: 0x00357E2C
		public override void OnUpdate()
		{
			this.UpdateCountTime();
			this.UpdateInspireTime();
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.LeftTime.SetVisible(false);
				}
			}
			else
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.WarTimeLabel.SetVisible(false);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.LeftTimeLabel.SetVisible(false);
				}
			}
		}

		// Token: 0x0600F20C RID: 61964 RVA: 0x00359CB0 File Offset: 0x00357EB0
		protected override void OnLoad()
		{
			base.uiBehaviour.mInspireCD = new GuildArenaInspireCD(base.uiBehaviour.mEncourageButton.transform);
			base.uiBehaviour.mBattleDuelInfo = new GuildArenaBattleDuelInfo();
			base.uiBehaviour.mBattleDuelInfo.Init(base.uiBehaviour.mCombatInfo);
		}

		// Token: 0x0600F20D RID: 61965 RVA: 0x00359D24 File Offset: 0x00357F24
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mLetmedieUpSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnUp));
			base.uiBehaviour.mLetmedieDownSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDown));
			base.uiBehaviour.mEncourageSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnInspireReq));
			base.uiBehaviour.mHelpSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelp));
			base.uiBehaviour.mLeftCloseSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLeftToogle));
		}

		// Token: 0x0600F20E RID: 61966 RVA: 0x00359DE3 File Offset: 0x00357FE3
		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		// Token: 0x0600F20F RID: 61967 RVA: 0x00359DF0 File Offset: 0x00357FF0
		private void OnLeftToogle(IXUISprite spr)
		{
			bool flag = this.blueState;
			if (flag)
			{
				this.m_uiBehaviour.mBlueView.transform.localPosition = new Vector3(-413f, 49f, 0f);
				base.uiBehaviour.mUpSprite.transform.localPosition = new Vector3(-406f, -160f, 0f);
				base.uiBehaviour.mDownSprite.transform.localPosition = new Vector3(-406f, -160f, 0f);
				base.uiBehaviour.mDownTips.transform.localPosition = new Vector3(-406f, -112f, 0f);
				base.uiBehaviour.mUpTips.transform.localPosition = new Vector3(-406f, -112f, 0f);
				this.blueState = false;
			}
			else
			{
				this.m_uiBehaviour.mBlueView.transform.localPosition = new Vector3(-665f, 49f, 0f);
				base.uiBehaviour.mUpSprite.transform.localPosition = new Vector3(-740f, -160f, 0f);
				base.uiBehaviour.mDownSprite.transform.localPosition = new Vector3(-740f, -160f, 0f);
				base.uiBehaviour.mUpTips.transform.localPosition = new Vector3(-740f, -112f, 0f);
				base.uiBehaviour.mDownTips.transform.localPosition = new Vector3(-740f, -112f, 0f);
				this.blueState = true;
			}
		}

		// Token: 0x0600F210 RID: 61968 RVA: 0x00359FF8 File Offset: 0x003581F8
		public void OnEnterSceneFinally()
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				this.RefreshSection();
			}
		}

		// Token: 0x0600F211 RID: 61969 RVA: 0x0035A01C File Offset: 0x0035821C
		private void RefreshCommonUI()
		{
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.LeftTime.SetVisible(false);
				}
			}
			else
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(false);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetVisible(false);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.WarTimeLabel.SetVisible(false);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.LeftTimeLabel.SetVisible(false);
				}
			}
		}

		// Token: 0x0600F212 RID: 61970 RVA: 0x0035A0C4 File Offset: 0x003582C4
		private void ResetCommonUI()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(true);
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetVisible(true);
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.WarTimeLabel.SetVisible(true);
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.LeftTimeLabel.SetVisible(true);
			}
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.LeftTime.SetVisible(true);
				}
			}
		}

		// Token: 0x0600F213 RID: 61971 RVA: 0x0035A164 File Offset: 0x00358364
		public void RefreshSection()
		{
			this.RefreshCommonUI();
			XGuildArenaBattleDocument.GuildArenaSection mArenaSection = this._Doc.mArenaSection;
			if (mArenaSection != XGuildArenaBattleDocument.GuildArenaSection.Prepare)
			{
				if (mArenaSection == XGuildArenaBattleDocument.GuildArenaSection.Battle)
				{
					base.uiBehaviour.mGoPrepare.SetActive(false);
					base.uiBehaviour.mGoBattle.SetActive(true);
					this.ShowOrHideLetmedie(false);
					base.uiBehaviour.mRoundLabel.SetVisible(this._Doc.IsGPR() || this._Doc.IsGCF());
					base.uiBehaviour.mRoundLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_ROUNDLABEL", new object[]
					{
						this._Doc.Round + 1U
					}));
				}
			}
			else
			{
				base.uiBehaviour.mGoPrepare.SetActive(true);
				base.uiBehaviour.mGoBattle.SetActive(false);
				this.ShowOrHideLetmedie(true);
				base.uiBehaviour.mRoundLabel.SetVisible(false);
			}
			this.OnSectionShow();
		}

		// Token: 0x0600F214 RID: 61972 RVA: 0x0035A290 File Offset: 0x00358490
		private void ShowOrHideLetmedie(bool isActive)
		{
			base.uiBehaviour.mDownSprite.SetVisible(isActive);
			base.uiBehaviour.mUpSprite.SetVisible(isActive);
			base.uiBehaviour.mUpTips.SetActive(isActive);
			base.uiBehaviour.mDownTips.SetActive(isActive);
		}

		// Token: 0x0600F215 RID: 61973 RVA: 0x0035A2FC File Offset: 0x003584FC
		private void InPlayerLetmedie(bool isActive)
		{
			base.uiBehaviour.mDownSprite.SetVisible(!isActive);
			base.uiBehaviour.mDownTips.SetActive(!isActive);
			base.uiBehaviour.mUpSprite.SetVisible(isActive);
			base.uiBehaviour.mUpTips.SetActive(isActive);
		}

		// Token: 0x0600F216 RID: 61974 RVA: 0x0035A36C File Offset: 0x0035856C
		public void OnSectionShow()
		{
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				base.uiBehaviour.mGoBg.SetActive(this._Doc.IsGMF());
				this.ShowOrHideLetmedie(false);
			}
			else
			{
				base.uiBehaviour.mEncourageButton.SetActive(false);
			}
			XGuildArenaBattleDocument.GuildArenaSection mArenaSection = this._Doc.mArenaSection;
			if (mArenaSection != XGuildArenaBattleDocument.GuildArenaSection.Prepare)
			{
				if (mArenaSection == XGuildArenaBattleDocument.GuildArenaSection.Battle)
				{
					this.SectionShowBattle();
				}
			}
			else
			{
				this.SectionShowReady();
			}
			this.SelectionPattern();
			this.ReFreshGroup();
		}

		// Token: 0x0600F217 RID: 61975 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SelectionPattern()
		{
		}

		// Token: 0x0600F218 RID: 61976 RVA: 0x0035A408 File Offset: 0x00358608
		protected virtual void SectionShowReady()
		{
			this.RefreshCommonUI();
			base.uiBehaviour.mGoBg.SetActive(true);
			base.SetXUILable("Prepare/T", XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_READY"));
			switch (this._Doc.MyReadyType)
			{
			case XGuildArenaBattleDocument.ReadyType.Ready:
				this.InPlayerLetmedie(false);
				break;
			case XGuildArenaBattleDocument.ReadyType.NoReady:
				this.InPlayerLetmedie(true);
				break;
			case XGuildArenaBattleDocument.ReadyType.Observer:
				this.ShowOrHideLetmedie(false);
				break;
			}
		}

		// Token: 0x0600F219 RID: 61977 RVA: 0x0035A490 File Offset: 0x00358690
		protected virtual void SectionShowBattle()
		{
			base.uiBehaviour.mGoBg.SetActive(false);
			this.ShowOrHideLetmedie(false);
			base.uiBehaviour.mEncourageButton.SetActive(false);
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag = this._Doc.MyReadyType == XGuildArenaBattleDocument.ReadyType.NoReady || this._Doc.MyReadyType == XGuildArenaBattleDocument.ReadyType.Ready;
				if (flag)
				{
					base.uiBehaviour.mGoBg.SetActive(this._Doc.IsGMF());
					base.uiBehaviour.mEncourageButton.SetActive(true);
				}
			}
			bool flag2 = this._Doc.MyFightState == GuildMatchFightState.GUILD_MF_FIGHTING;
			if (flag2)
			{
				base.uiBehaviour.mEncourageButton.SetActive(false);
				bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(true);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetVisible(true);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.WarTimeLabel.SetVisible(false);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.LeftTimeLabel.SetVisible(false);
				}
			}
		}

		// Token: 0x0600F21A RID: 61978 RVA: 0x0035A5C0 File Offset: 0x003587C0
		private void OnHelp(IXUISprite spr)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Arena);
		}

		// Token: 0x0600F21B RID: 61979 RVA: 0x0035A5D0 File Offset: 0x003587D0
		public void RefreahCountTime(float time)
		{
			this.m_lastTime.LeftTime = time;
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			}
		}

		// Token: 0x0600F21C RID: 61980 RVA: 0x0035A614 File Offset: 0x00358814
		private void UpdateCountTime()
		{
			this.m_lastTime.Update();
			bool flag = this.m_lastTime.LeftTime > 0f;
			if (flag)
			{
				base.SetXUILable("Time/countdown", XSingleton<UiUtility>.singleton.TimeFormatString((int)this.m_lastTime.LeftTime, 2, 3, 4, false, true));
			}
		}

		// Token: 0x0600F21D RID: 61981 RVA: 0x0035A66C File Offset: 0x0035886C
		private void OnUp(IXUISprite spr)
		{
			bool bCantUpForKicked = this._Doc.bCantUpForKicked;
			if (bCantUpForKicked)
			{
				double num = 0.0;
				bool flag = this._Doc._kicked_token > 0U;
				if (flag)
				{
					num = XSingleton<XTimerMgr>.singleton.TimeLeft(this._Doc._kicked_token);
				}
				string text = string.Format(XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_UP_HINT_BY_KICKED"), num.ToString("f0"));
				XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
			}
			else
			{
				bool flag2 = this._Doc.BlueInfo.Size >= this._Doc.GetBattleSignNumber();
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_TAB_FULL"), "fece00");
				}
				else
				{
					this._Doc.ReadyReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, GMFReadyType.GMF_READY_UP);
				}
			}
		}

		// Token: 0x0600F21E RID: 61982 RVA: 0x0035A754 File Offset: 0x00358954
		private void OnDown(IXUISprite spr)
		{
			this._Doc.ReadyReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, GMFReadyType.GMF_READY_DOWN);
		}

		// Token: 0x0600F21F RID: 61983 RVA: 0x0035A774 File Offset: 0x00358974
		public void UpdateDownUp()
		{
			switch (this._Doc.MyReadyType)
			{
			case XGuildArenaBattleDocument.ReadyType.Ready:
				this.InPlayerLetmedie(false);
				base.SetXUILable("Bg/LetmedieDownBg/T", XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_DOWN_HINT"));
				break;
			case XGuildArenaBattleDocument.ReadyType.NoReady:
				this.InPlayerLetmedie(true);
				base.SetXUILable("Bg/LetmedieDownBg/T", "");
				break;
			case XGuildArenaBattleDocument.ReadyType.Observer:
				this.ShowOrHideLetmedie(false);
				base.SetXUILable("Bg/LetmedieDownBg/T", XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_UP_HINT"));
				break;
			}
			base.uiBehaviour.mUpSprite.SetGrey(!this._Doc.bCantUpForKicked);
			base.uiBehaviour.mDownSprite.SetGrey(!this._Doc.bCantUpForKicked);
		}

		// Token: 0x0600F220 RID: 61984 RVA: 0x0035A850 File Offset: 0x00358A50
		public virtual void ReFreshGroup()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("targetBlueCourage:", this._Doc.BlueInfo.Inspire.ToString(), "   targetRedCourage", this._Doc.RedInfo.Inspire.ToString(), null, null);
			this.SetProgress(this._Doc.BlueInfo.Inspire, base.uiBehaviour.mBlueCourageBar, ref this.blue_label_num, "Battle/Encourage/Blue/Time", base.uiBehaviour.BlueInspireTween, base.uiBehaviour.mBlueCourage, "Effects/FX_Particle/UIfx/UI_GuildArenaPrepareDlg_Blue");
			this.SetProgress(this._Doc.RedInfo.Inspire, base.uiBehaviour.mRedCourageBar, ref this.red_label_num, "Battle/Encourage/Red/Time", base.uiBehaviour.RedInspireTween, base.uiBehaviour.mRedCourage, "Effects/FX_Particle/UIfx/UI_GuildArenaPrepareDlg_Red");
			base.uiBehaviour.mBluePanel.ReFreshData(this._Doc.BlueInfo);
			bool flag = this._Doc.Pattern == GuildArenaBattlePattern.GMF;
			if (flag)
			{
				base.SetXUILable("Battle/Score/Bluenum", this._Doc.GMFGroupBlueMatchPoint.ToString());
				base.SetXUILable("Battle/Score/Rednum", this._Doc.GMFGroupRedMatchPoint.ToString());
			}
			else
			{
				base.uiBehaviour.mBattleDuelInfo.RedInfo.Set(this._Doc.redCombatInfo);
				base.uiBehaviour.mBattleDuelInfo.BlueInfo.Set(this._Doc.blueCombatInfo);
			}
			this.UpdateDownUp();
		}

		// Token: 0x0600F221 RID: 61985 RVA: 0x0035AA1C File Offset: 0x00358C1C
		private void UpdateInspireTime()
		{
			bool flag = base.uiBehaviour.mInspireCD != null;
			if (flag)
			{
				base.uiBehaviour.mInspireCD.ExcuteInspireCD(this._Doc.InspireCDTime);
			}
		}

		// Token: 0x0600F222 RID: 61986 RVA: 0x0035AA64 File Offset: 0x00358C64
		private void OnInspireReq(IXUISprite spr)
		{
			bool flag = this._Doc.InspireCDTime > 0.0;
			if (flag)
			{
				string @string = XStringDefineProxy.GetString("GUILD_ARENA_UP_HINT_BY_INSPIRT", new object[]
				{
					this._Doc.InspireCDTime.ToString("f0")
				});
				XSingleton<UiUtility>.singleton.ShowSystemTip(@string, "fece00");
			}
			else
			{
				this._Doc.InspireReq();
			}
		}

		// Token: 0x0600F223 RID: 61987 RVA: 0x0035AAD8 File Offset: 0x00358CD8
		public void RefreshInspire()
		{
			bool flag = this._Doc.fxEncourageButton != null;
			if (flag)
			{
				this._Doc.fxEncourageButton.Play(base.uiBehaviour.mEncourageButton.transform, Vector3.zero, Vector3.one, 1f, true, false);
			}
			bool flag2 = this._Doc.fxEncourageProgressAdd != null;
			if (flag2)
			{
				this._Doc.fxEncourageProgressAdd.Play(base.uiBehaviour.mEncourageButton.transform, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		// Token: 0x0600F224 RID: 61988 RVA: 0x0035AB78 File Offset: 0x00358D78
		private bool GetProgress(float spiritCount, out int label, out float progress)
		{
			label = 0;
			progress = 0f;
			bool flag = this.inspires == null;
			if (flag)
			{
				this.inspires = XSingleton<XGlobalConfig>.singleton.GetIntList("GuildArenaInspireCount");
			}
			bool flag2 = this.inspires == null;
			bool result;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XMainClient.UI.GuildArenaBattlePrepareDlg.GetProgress inspires == null", null, null, null, null, null);
				result = false;
			}
			else
			{
				int num = 0;
				int num2 = 0;
				int i = 0;
				int count = this.inspires.Count;
				while (i < count)
				{
					bool flag3 = spiritCount <= (float)this.inspires[i];
					if (flag3)
					{
						label = i;
						num = this.inspires[i];
						break;
					}
					num2 = this.inspires[i];
					i++;
				}
				bool flag4 = spiritCount >= (float)num;
				if (flag4)
				{
					spiritCount = (float)num;
				}
				progress = (spiritCount - (float)num2) / (float)(num - num2);
				result = true;
			}
			return result;
		}

		// Token: 0x0600F225 RID: 61989 RVA: 0x0035AC6C File Offset: 0x00358E6C
		private void SetProgress(float cour, IXUISlider progress, ref int cur_label_num, string labelName, GameObject labelTween, GameObject effectParent, string effectName)
		{
			int num = 0;
			float value = 0f;
			bool progress2 = this.GetProgress(cour, out num, out value);
			if (progress2)
			{
				progress.Value = value;
				base.SetXUILable(labelName, num.ToString());
				bool flag = cur_label_num != num;
				if (flag)
				{
					cur_label_num = num;
					bool flag2 = this._Doc.fxEncourageProgressNum != null;
					if (flag2)
					{
						this._Doc.fxEncourageProgressNum.Play(labelTween.transform, Vector3.zero, Vector3.one, 1f, true, false);
					}
					bool flag3 = this._Doc.fxEncourageProgressAdd != null;
					if (flag3)
					{
						this._Doc.fxEncourageProgressAdd.Play(base.uiBehaviour.mEncourageButtonBg.transform, Vector3.zero, Vector3.one, 1f, true, false);
					}
					bool flag4 = !string.IsNullOrEmpty(effectName);
					if (flag4)
					{
						XSingleton<XFxMgr>.singleton.CreateAndPlay(effectName, effectParent.transform, Vector3.zero, Vector3.one, 1f, true, 3f, true);
					}
				}
			}
		}

		// Token: 0x0600F226 RID: 61990 RVA: 0x0035AD86 File Offset: 0x00358F86
		public void SetResurgence(int leftTime)
		{
			this.m_leftTime = leftTime;
			this.SetResurgenceTime(this.m_leftTime);
		}

		// Token: 0x0600F227 RID: 61991 RVA: 0x0035ADA0 File Offset: 0x00358FA0
		private void SetResurgenceTime(int time)
		{
			bool flag = time > 0;
			base.uiBehaviour.mLeftTime.SetVisible(flag);
			bool flag2 = flag;
			if (flag2)
			{
				base.uiBehaviour.mLeftTime.SetText(time.ToString());
				this.m_leftTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.UpdateTimeFrame), null);
				this.SetupOtherResurgence();
			}
			else
			{
				bool flag3 = this.m_leftTimerID > 0U;
				if (flag3)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this.m_leftTimerID);
				}
			}
		}

		// Token: 0x0600F228 RID: 61992 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetupOtherResurgence()
		{
		}

		// Token: 0x0600F229 RID: 61993 RVA: 0x0035AE39 File Offset: 0x00359039
		private void UpdateTimeFrame(object o)
		{
			this.m_leftTime--;
			this.SetResurgence(this.m_leftTime);
		}

		// Token: 0x040067A5 RID: 26533
		protected XGuildArenaBattleDocument _Doc;

		// Token: 0x040067A6 RID: 26534
		private int m_leftTime = 0;

		// Token: 0x040067A7 RID: 26535
		private uint m_leftTimerID = 0U;

		// Token: 0x040067A8 RID: 26536
		private int blue_label_num = 0;

		// Token: 0x040067A9 RID: 26537
		private int red_label_num = 0;

		// Token: 0x040067AA RID: 26538
		private bool blueState = true;

		// Token: 0x040067AB RID: 26539
		private XElapseTimer m_lastTime = new XElapseTimer();

		// Token: 0x040067AC RID: 26540
		private List<int> inspires = null;
	}
}
