using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaDuelRoundResultDlg : DlgBase<GuildArenaDuelRoundResultDlg, GuildArenaDuelRoundResultBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaDuelRoundResultDlg";
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

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnHideBattle();
			this.RefreshData();
			this.RefreahCountTime((float)XSingleton<XGlobalConfig>.singleton.GetInt("GPRFightAfterTime"), true);
		}

		private void OnHideBattle()
		{
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
		}

		private void RefreshData()
		{
			base.uiBehaviour.m_RoundLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_ROUNDLABEL", new object[]
			{
				this._Doc.Round
			}));
			base.uiBehaviour.m_Blue.Set(this._Doc.BlueDuelResult);
			base.uiBehaviour.m_Red.Set(this._Doc.RedDuelResult);
			bool flag = this._Doc.BlueDuelResult.RoleCombats.Count == 0 && this._Doc.RedDuelResult.RoleCombats.Count == 0;
			base.uiBehaviour.m_EmptyWin.gameObject.SetActive(flag);
			bool flag2 = flag;
			if (flag2)
			{
				bool isWinner = this._Doc.BlueDuelResult.isWinner;
				if (isWinner)
				{
					base.uiBehaviour.m_GuildName.SetText(this._Doc.BlueDuelResult.Guild.guildname);
				}
				else
				{
					bool isWinner2 = this._Doc.RedDuelResult.isWinner;
					if (isWinner2)
					{
						base.uiBehaviour.m_GuildName.SetText(this._Doc.RedDuelResult.Guild.guildname);
					}
					else
					{
						base.uiBehaviour.m_GuildName.SetText(string.Empty);
					}
				}
			}
		}

		private void ClickClose(IXUISprite sprite)
		{
			this.ReturnHall();
		}

		protected override void OnUnload()
		{
			this.m_lastTime = null;
			base.OnUnload();
		}

		public void RefreahCountTime(float time, bool Done)
		{
			bool flag = this.m_lastTime == null;
			if (flag)
			{
				this.m_lastTime = new XElapseTimer();
			}
			bool flag2 = !this._Doc.InBattleGroup;
			if (flag2)
			{
				this.m_lastTime.LeftTime = time - 2f;
			}
			else
			{
				this.m_lastTime.LeftTime = time;
			}
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
			bool flag = !this.Countdown || this.m_lastTime == null;
			if (!flag)
			{
				this.m_lastTime.Update();
				bool flag2 = this.m_lastTime.LeftTime > 0f;
				if (flag2)
				{
					bool flag3 = this._Doc.Round == 3U;
					if (flag3)
					{
						base.uiBehaviour.m_TimeLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_FINALWATTING", new object[]
						{
							XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.m_lastTime.LeftTime, 5)
						}));
					}
					else
					{
						base.uiBehaviour.m_TimeLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_ROUNDWATTING", new object[]
						{
							XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.m_lastTime.LeftTime, 5)
						}));
					}
				}
				else
				{
					this.Countdown = false;
					bool flag4 = this.mDone;
					if (flag4)
					{
						this.ReturnHall();
					}
				}
			}
		}

		public void ReturnHall()
		{
			bool flag = !this._Doc.InBattleGroup;
			if (flag)
			{
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
			else
			{
				this.SetVisibleWithAnimation(false, null);
			}
		}

		private XGuildArenaBattleDocument _Doc;

		private XElapseTimer m_lastTime;

		private bool Countdown = false;

		private bool mDone = false;
	}
}
