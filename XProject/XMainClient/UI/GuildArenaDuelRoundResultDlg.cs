using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001749 RID: 5961
	internal class GuildArenaDuelRoundResultDlg : DlgBase<GuildArenaDuelRoundResultDlg, GuildArenaDuelRoundResultBehaviour>
	{
		// Token: 0x170037EF RID: 14319
		// (get) Token: 0x0600F673 RID: 63091 RVA: 0x0037E8F0 File Offset: 0x0037CAF0
		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaDuelRoundResultDlg";
			}
		}

		// Token: 0x170037F0 RID: 14320
		// (get) Token: 0x0600F674 RID: 63092 RVA: 0x0037E908 File Offset: 0x0037CB08
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037F1 RID: 14321
		// (get) Token: 0x0600F675 RID: 63093 RVA: 0x0037E91C File Offset: 0x0037CB1C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F676 RID: 63094 RVA: 0x0037E92F File Offset: 0x0037CB2F
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
		}

		// Token: 0x0600F677 RID: 63095 RVA: 0x0037E949 File Offset: 0x0037CB49
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F678 RID: 63096 RVA: 0x0037E953 File Offset: 0x0037CB53
		protected override void OnShow()
		{
			base.OnShow();
			this.OnHideBattle();
			this.RefreshData();
			this.RefreahCountTime((float)XSingleton<XGlobalConfig>.singleton.GetInt("GPRFightAfterTime"), true);
		}

		// Token: 0x0600F679 RID: 63097 RVA: 0x0037E984 File Offset: 0x0037CB84
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

		// Token: 0x0600F67A RID: 63098 RVA: 0x0037E9DC File Offset: 0x0037CBDC
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

		// Token: 0x0600F67B RID: 63099 RVA: 0x0037EB38 File Offset: 0x0037CD38
		private void ClickClose(IXUISprite sprite)
		{
			this.ReturnHall();
		}

		// Token: 0x0600F67C RID: 63100 RVA: 0x0037EB42 File Offset: 0x0037CD42
		protected override void OnUnload()
		{
			this.m_lastTime = null;
			base.OnUnload();
		}

		// Token: 0x0600F67D RID: 63101 RVA: 0x0037EB54 File Offset: 0x0037CD54
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

		// Token: 0x0600F67E RID: 63102 RVA: 0x0037EBBC File Offset: 0x0037CDBC
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateCountTime();
		}

		// Token: 0x0600F67F RID: 63103 RVA: 0x0037EBD0 File Offset: 0x0037CDD0
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

		// Token: 0x0600F680 RID: 63104 RVA: 0x0037ECC8 File Offset: 0x0037CEC8
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

		// Token: 0x04006AF5 RID: 27381
		private XGuildArenaBattleDocument _Doc;

		// Token: 0x04006AF6 RID: 27382
		private XElapseTimer m_lastTime;

		// Token: 0x04006AF7 RID: 27383
		private bool Countdown = false;

		// Token: 0x04006AF8 RID: 27384
		private bool mDone = false;
	}
}
