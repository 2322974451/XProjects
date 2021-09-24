using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GVGBattlePrepareBase<T, V> : DlgBase<T, V>, IGVGBattlePrepare, IXUIDlg where T : IXUIDlg, new() where V : GVGBattlePrepareBehaviour
	{

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

		protected override void OnHide()
		{
			base.OnHide();
			this.SetResurgence(0);
			this.ResetCommonUI();
		}

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

		protected override void OnLoad()
		{
			base.uiBehaviour.mInspireCD = new GuildArenaInspireCD(base.uiBehaviour.mEncourageButton.transform);
			base.uiBehaviour.mBattleDuelInfo = new GuildArenaBattleDuelInfo();
			base.uiBehaviour.mBattleDuelInfo.Init(base.uiBehaviour.mCombatInfo);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mLetmedieUpSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnUp));
			base.uiBehaviour.mLetmedieDownSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDown));
			base.uiBehaviour.mEncourageSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnInspireReq));
			base.uiBehaviour.mHelpSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelp));
			base.uiBehaviour.mLeftCloseSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLeftToogle));
		}

		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

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

		public void OnEnterSceneFinally()
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				this.RefreshSection();
			}
		}

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

		private void ShowOrHideLetmedie(bool isActive)
		{
			base.uiBehaviour.mDownSprite.SetVisible(isActive);
			base.uiBehaviour.mUpSprite.SetVisible(isActive);
			base.uiBehaviour.mUpTips.SetActive(isActive);
			base.uiBehaviour.mDownTips.SetActive(isActive);
		}

		private void InPlayerLetmedie(bool isActive)
		{
			base.uiBehaviour.mDownSprite.SetVisible(!isActive);
			base.uiBehaviour.mDownTips.SetActive(!isActive);
			base.uiBehaviour.mUpSprite.SetVisible(isActive);
			base.uiBehaviour.mUpTips.SetActive(isActive);
		}

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

		protected virtual void SelectionPattern()
		{
		}

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

		private void OnHelp(IXUISprite spr)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Arena);
		}

		public void RefreahCountTime(float time)
		{
			this.m_lastTime.LeftTime = time;
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			}
		}

		private void UpdateCountTime()
		{
			this.m_lastTime.Update();
			bool flag = this.m_lastTime.LeftTime > 0f;
			if (flag)
			{
				base.SetXUILable("Time/countdown", XSingleton<UiUtility>.singleton.TimeFormatString((int)this.m_lastTime.LeftTime, 2, 3, 4, false, true));
			}
		}

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

		private void OnDown(IXUISprite spr)
		{
			this._Doc.ReadyReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, GMFReadyType.GMF_READY_DOWN);
		}

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

		private void UpdateInspireTime()
		{
			bool flag = base.uiBehaviour.mInspireCD != null;
			if (flag)
			{
				base.uiBehaviour.mInspireCD.ExcuteInspireCD(this._Doc.InspireCDTime);
			}
		}

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

		public void SetResurgence(int leftTime)
		{
			this.m_leftTime = leftTime;
			this.SetResurgenceTime(this.m_leftTime);
		}

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

		protected virtual void SetupOtherResurgence()
		{
		}

		private void UpdateTimeFrame(object o)
		{
			this.m_leftTime--;
			this.SetResurgence(this.m_leftTime);
		}

		protected XGuildArenaBattleDocument _Doc;

		private int m_leftTime = 0;

		private uint m_leftTimerID = 0U;

		private int blue_label_num = 0;

		private int red_label_num = 0;

		private bool blueState = true;

		private XElapseTimer m_lastTime = new XElapseTimer();

		private List<int> inspires = null;
	}
}
