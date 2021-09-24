using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaDefeatDlg : DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaBattleResult";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool isMainUI
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

		protected override void Init()
		{
			base.Init();
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			base.uiBehaviour.mReturnSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturn));
		}

		public override void OnXNGUIClick(GameObject obj, string path)
		{
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateCountTime();
		}

		public void SetSmallResult(string descrption)
		{
			base.uiBehaviour.mRoundResult.SetActive(true);
			base.uiBehaviour.mFinalResult.SetActive(false);
			this.RoundResult();
		}

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

		public void RefreahCountTime(float time, bool Done)
		{
			this.m_lastTime.LeftTime = time;
			this.Countdown = true;
			this.mDone = Done;
		}

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

		private void OnReturn(IXUISprite spr)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		public void SetGuildResult(string descrption)
		{
			base.uiBehaviour.mFinalResult.SetActive(true);
			base.uiBehaviour.mRoundResult.SetActive(false);
			this.FinalResult();
		}

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

		private XGuildArenaBattleDocument _Doc;

		private XElapseTimer m_lastTime = new XElapseTimer();

		private bool Countdown = false;

		private bool mDone = false;
	}
}
