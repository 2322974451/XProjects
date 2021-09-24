using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaDuelFinalResultDlg : DlgBase<GuildArenaDuelFinalResultDlg, GuildArenaDuelFinalResultBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaDuelFinalResultDlg";
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

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this.RefreahCountTime(10f, true);
			bool flag = DlgBase<GuildArenaDuelRoundResultDlg, GuildArenaDuelRoundResultBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildArenaDuelRoundResultDlg, GuildArenaDuelRoundResultBehaviour>.singleton.SetVisible(false, true);
			}
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisible(false, true);
				}
			}
			else
			{
				bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisible(false, true);
				}
			}
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

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_maskSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClose));
		}

		private void RefreshData()
		{
			base.uiBehaviour.m_BlueInfo.Set(this._Doc.BlueDuelResult);
			base.uiBehaviour.m_RedInfo.Set(this._Doc.RedDuelResult);
		}

		private void ClickClose(IXUISprite sprite)
		{
			this.ReturnHall();
		}

		public void RefreahCountTime(float time, bool Done)
		{
			this.m_lastTime.LeftTime = time;
			this.Countdown = true;
			this.mDone = Done;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateCountTime();
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
					base.uiBehaviour.m_timeLabel.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.m_lastTime.LeftTime, 5));
				}
				else
				{
					this.Countdown = false;
					bool flag3 = this.mDone;
					if (flag3)
					{
						this.ReturnHall();
					}
				}
			}
		}

		private void ReturnHall()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		private XGuildArenaBattleDocument _Doc;

		private XElapseTimer m_lastTime = new XElapseTimer();

		private bool Countdown = false;

		private bool mDone = false;
	}
}
