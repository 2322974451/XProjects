using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001835 RID: 6197
	internal class GuildArenaDefeatDlg : DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>
	{
		// Token: 0x17003935 RID: 14645
		// (get) Token: 0x06010177 RID: 65911 RVA: 0x003D7CB0 File Offset: 0x003D5EB0
		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaBattleResult";
			}
		}

		// Token: 0x17003936 RID: 14646
		// (get) Token: 0x06010178 RID: 65912 RVA: 0x003D7CC8 File Offset: 0x003D5EC8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003937 RID: 14647
		// (get) Token: 0x06010179 RID: 65913 RVA: 0x003D7CDC File Offset: 0x003D5EDC
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003938 RID: 14648
		// (get) Token: 0x0601017A RID: 65914 RVA: 0x003D7CF0 File Offset: 0x003D5EF0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601017B RID: 65915 RVA: 0x003D7D03 File Offset: 0x003D5F03
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0601017C RID: 65916 RVA: 0x003D7D10 File Offset: 0x003D5F10
		protected override void OnShow()
		{
			base.OnShow();
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisible(false, true);
				}
			}
			else
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisible(false, true);
				}
			}
			base.uiBehaviour.mRoundResult.SetActive(false);
			base.uiBehaviour.mFinalResult.SetActive(false);
		}

		// Token: 0x0601017D RID: 65917 RVA: 0x003D7D94 File Offset: 0x003D5F94
		protected override void OnHide()
		{
			base.OnHide();
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisible(true, true);
				}
			}
			else
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisible(true, true);
				}
			}
		}

		// Token: 0x0601017E RID: 65918 RVA: 0x003D7DF3 File Offset: 0x003D5FF3
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			base.uiBehaviour.mReturnSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturn));
		}

		// Token: 0x0601017F RID: 65919 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnXNGUIClick(GameObject obj, string path)
		{
		}

		// Token: 0x06010180 RID: 65920 RVA: 0x003D7E2A File Offset: 0x003D602A
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateCountTime();
		}

		// Token: 0x06010181 RID: 65921 RVA: 0x003D7E3B File Offset: 0x003D603B
		public void SetSmallResult(string descrption)
		{
			base.uiBehaviour.mRoundResult.SetActive(true);
			base.uiBehaviour.mFinalResult.SetActive(false);
			this.RoundResult();
		}

		// Token: 0x06010182 RID: 65922 RVA: 0x003D7E6C File Offset: 0x003D606C
		private void RoundResult()
		{
			base.SetXUILable("RoundResult/Score/Bluenum", this._Doc.GMFGroupBlueMatchPoint.ToString());
			base.SetXUILable("RoundResult/Blue/GuildName", this._Doc.blueBattleEndData.Guild.guildname);
			base.SetXUILable("RoundResult/Blue/name", this._Doc.blueBattleEndData.Role.rolename);
			bool isWin = this._Doc.blueBattleEndData.isWin;
			if (isWin)
			{
				base.uiBehaviour.mRoundResult.transform.Find("Blue/Result/Win").gameObject.SetActive(true);
				base.uiBehaviour.mRoundResult.transform.Find("Blue/Result/Lose").gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.mRoundResult.transform.Find("Blue/Result/Win").gameObject.SetActive(false);
				base.uiBehaviour.mRoundResult.transform.Find("Blue/Result/Lose").gameObject.SetActive(true);
			}
			base.uiBehaviour.uiBlueAvatar.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)this._Doc.blueBattleEndData.Role.profession));
			base.SetXUILable("RoundResult/Score/Rednum", this._Doc.GMFGroupRedMatchPoint.ToString());
			base.SetXUILable("RoundResult/Red/GuildName", this._Doc.redBattleEndData.Guild.guildname);
			base.SetXUILable("RoundResult/Red/name", this._Doc.redBattleEndData.Role.rolename);
			bool isWin2 = this._Doc.redBattleEndData.isWin;
			if (isWin2)
			{
				base.uiBehaviour.mRoundResult.transform.Find("Red/Result/Win").gameObject.SetActive(true);
				base.uiBehaviour.mRoundResult.transform.Find("Red/Result/Lose").gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.mRoundResult.transform.Find("Red/Result/Win").gameObject.SetActive(false);
				base.uiBehaviour.mRoundResult.transform.Find("Red/Result/Lose").gameObject.SetActive(true);
			}
			base.uiBehaviour.uiRedAvatar.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)this._Doc.redBattleEndData.Role.profession));
		}

		// Token: 0x06010183 RID: 65923 RVA: 0x003D80FA File Offset: 0x003D62FA
		public void RefreahCountTime(float time, bool Done)
		{
			this.m_lastTime.LeftTime = time;
			this.Countdown = true;
			this.mDone = Done;
		}

		// Token: 0x06010184 RID: 65924 RVA: 0x003D8118 File Offset: 0x003D6318
		private void UpdateCountTime()
		{
			bool flag = !this.Countdown;
			if (!flag)
			{
				this.m_lastTime.Update();
				bool flag2 = this.m_lastTime.LeftTime > 0f;
				if (flag2)
				{
					base.SetXUILable("CountDown/Time", XSingleton<UiUtility>.singleton.TimeFormatString((int)this.m_lastTime.LeftTime, 1, 3, 4, false, true));
				}
				else
				{
					this.Countdown = false;
					bool flag3 = this.mDone;
					if (flag3)
					{
						this.OnReturn(null);
					}
				}
			}
		}

		// Token: 0x06010185 RID: 65925 RVA: 0x00160161 File Offset: 0x0015E361
		private void OnReturn(IXUISprite spr)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		// Token: 0x06010186 RID: 65926 RVA: 0x003D819D File Offset: 0x003D639D
		public void SetGuildResult(string descrption)
		{
			base.uiBehaviour.mFinalResult.SetActive(true);
			base.uiBehaviour.mRoundResult.SetActive(false);
			this.FinalResult();
		}

		// Token: 0x06010187 RID: 65927 RVA: 0x003D81CC File Offset: 0x003D63CC
		private void FinalResult()
		{
			base.SetXUILable("FinalResult/ScoreBig/Bluenum", this._Doc.GMFGroupBlueMatchPoint.ToString());
			base.SetXUILable("FinalResult/Blue/GuildName", this._Doc.blueAllFightEnd.Guild.guildname);
			base.uiBehaviour.mBlueGuildHeadSprite.SetSprite(XGuildDocument.GetPortraitName((int)this._Doc.blueAllFightEnd.Guild.guildicon));
			bool isWin = this._Doc.blueAllFightEnd.isWin;
			if (isWin)
			{
				base.uiBehaviour.mFinalResult.transform.Find("Blue/Result/Win").gameObject.SetActive(true);
				base.uiBehaviour.mFinalResult.transform.Find("Blue/Result/Lose").gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.mFinalResult.transform.Find("Blue/Result/Win").gameObject.SetActive(false);
				base.uiBehaviour.mFinalResult.transform.Find("Blue/Result/Lose").gameObject.SetActive(true);
			}
			base.SetXUILable("FinalResult/ScoreBig/Rednum", this._Doc.GMFGroupRedMatchPoint.ToString());
			base.SetXUILable("FinalResult/Red/GuildName", this._Doc.redAllFightEnd.Guild.guildname);
			base.uiBehaviour.mRedGuildHeadSprite.SetSprite(XGuildDocument.GetPortraitName((int)this._Doc.redAllFightEnd.Guild.guildicon));
			bool isWin2 = this._Doc.redAllFightEnd.isWin;
			if (isWin2)
			{
				base.uiBehaviour.mFinalResult.transform.Find("Red/Result/Win").gameObject.SetActive(true);
				base.uiBehaviour.mFinalResult.transform.Find("Red/Result/Lose").gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.mFinalResult.transform.Find("Red/Result/Win").gameObject.SetActive(false);
				base.uiBehaviour.mFinalResult.transform.Find("Red/Result/Lose").gameObject.SetActive(true);
			}
		}

		// Token: 0x040072C6 RID: 29382
		private XGuildArenaBattleDocument _Doc;

		// Token: 0x040072C7 RID: 29383
		private XElapseTimer m_lastTime = new XElapseTimer();

		// Token: 0x040072C8 RID: 29384
		private bool Countdown = false;

		// Token: 0x040072C9 RID: 29385
		private bool mDone = false;
	}
}
