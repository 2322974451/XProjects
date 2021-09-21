using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001746 RID: 5958
	internal class GuildArenaDuelFinalResultDlg : DlgBase<GuildArenaDuelFinalResultDlg, GuildArenaDuelFinalResultBehaviour>
	{
		// Token: 0x170037EC RID: 14316
		// (get) Token: 0x0600F660 RID: 63072 RVA: 0x0037E3EC File Offset: 0x0037C5EC
		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaDuelFinalResultDlg";
			}
		}

		// Token: 0x170037ED RID: 14317
		// (get) Token: 0x0600F661 RID: 63073 RVA: 0x0037E404 File Offset: 0x0037C604
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037EE RID: 14318
		// (get) Token: 0x0600F662 RID: 63074 RVA: 0x0037E418 File Offset: 0x0037C618
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F663 RID: 63075 RVA: 0x0037E42C File Offset: 0x0037C62C
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

		// Token: 0x0600F664 RID: 63076 RVA: 0x0037E4DC File Offset: 0x0037C6DC
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

		// Token: 0x0600F665 RID: 63077 RVA: 0x0037E53B File Offset: 0x0037C73B
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
		}

		// Token: 0x0600F666 RID: 63078 RVA: 0x0037E555 File Offset: 0x0037C755
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_maskSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClose));
		}

		// Token: 0x0600F667 RID: 63079 RVA: 0x0037E57C File Offset: 0x0037C77C
		private void RefreshData()
		{
			base.uiBehaviour.m_BlueInfo.Set(this._Doc.BlueDuelResult);
			base.uiBehaviour.m_RedInfo.Set(this._Doc.RedDuelResult);
		}

		// Token: 0x0600F668 RID: 63080 RVA: 0x0037E5B7 File Offset: 0x0037C7B7
		private void ClickClose(IXUISprite sprite)
		{
			this.ReturnHall();
		}

		// Token: 0x0600F669 RID: 63081 RVA: 0x0037E5C1 File Offset: 0x0037C7C1
		public void RefreahCountTime(float time, bool Done)
		{
			this.m_lastTime.LeftTime = time;
			this.Countdown = true;
			this.mDone = Done;
		}

		// Token: 0x0600F66A RID: 63082 RVA: 0x0037E5DF File Offset: 0x0037C7DF
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateCountTime();
		}

		// Token: 0x0600F66B RID: 63083 RVA: 0x0037E5F0 File Offset: 0x0037C7F0
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

		// Token: 0x0600F66C RID: 63084 RVA: 0x00160161 File Offset: 0x0015E361
		private void ReturnHall()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		// Token: 0x04006AE4 RID: 27364
		private XGuildArenaBattleDocument _Doc;

		// Token: 0x04006AE5 RID: 27365
		private XElapseTimer m_lastTime = new XElapseTimer();

		// Token: 0x04006AE6 RID: 27366
		private bool Countdown = false;

		// Token: 0x04006AE7 RID: 27367
		private bool mDone = false;
	}
}
