using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A59 RID: 2649
	internal class XGuildTaskRefreshResultDlg : DlgBase<XGuildTaskRefreshResultDlg, XGuildTaskRefreshResultDlgBehavior>
	{
		// Token: 0x17002F05 RID: 12037
		// (get) Token: 0x0600A0BE RID: 41150 RVA: 0x001AF740 File Offset: 0x001AD940
		public override string fileName
		{
			get
			{
				return "Guild/DailyTaskResult";
			}
		}

		// Token: 0x17002F06 RID: 12038
		// (get) Token: 0x0600A0BF RID: 41151 RVA: 0x001AF758 File Offset: 0x001AD958
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F07 RID: 12039
		// (get) Token: 0x0600A0C0 RID: 41152 RVA: 0x001AF76B File Offset: 0x001AD96B
		// (set) Token: 0x0600A0C1 RID: 41153 RVA: 0x001AF773 File Offset: 0x001AD973
		public uint AfterScore { get; set; }

		// Token: 0x17002F08 RID: 12040
		// (get) Token: 0x0600A0C2 RID: 41154 RVA: 0x001AF77C File Offset: 0x001AD97C
		// (set) Token: 0x0600A0C3 RID: 41155 RVA: 0x001AF784 File Offset: 0x001AD984
		public uint BeforeScore { get; set; }

		// Token: 0x0600A0C4 RID: 41156 RVA: 0x001AF78D File Offset: 0x001AD98D
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600A0C5 RID: 41157 RVA: 0x001AF797 File Offset: 0x001AD997
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600A0C6 RID: 41158 RVA: 0x001AF7A4 File Offset: 0x001AD9A4
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fx1Token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fx2Token);
			this._fx1Token = 0U;
			this._fx2Token = 0U;
			bool flag = this._fx1 != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx1, true);
				this._fx1 = null;
			}
			bool flag2 = this._fx2 != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx2, true);
				this._fx2 = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600A0C7 RID: 41159 RVA: 0x001AF839 File Offset: 0x001ADA39
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.blockBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		// Token: 0x0600A0C8 RID: 41160 RVA: 0x001AF860 File Offset: 0x001ADA60
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.TweenGroup.ResetTween(true);
			base.uiBehaviour.TweenGroup.PlayTween(true);
			base.uiBehaviour.beforeSprite.SetSprite(base.uiBehaviour.beforeSprite.spriteName.Substring(0, base.uiBehaviour.beforeSprite.spriteName.Length - 1) + this.BeforeScore);
			base.uiBehaviour.afterSprite.SetSprite(base.uiBehaviour.afterSprite.spriteName.Substring(0, base.uiBehaviour.afterSprite.spriteName.Length - 1) + this.AfterScore);
			bool flag = this.BeforeScore < this.AfterScore;
			if (flag)
			{
				base.uiBehaviour.resultLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("DailyTaskRefreshUp")));
			}
			else
			{
				bool flag2 = this.BeforeScore == this.AfterScore;
				if (flag2)
				{
					base.uiBehaviour.resultLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("DailyTaskRefreshEqual")));
				}
				else
				{
					base.uiBehaviour.resultLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("DailyTaskRefreshDown")));
				}
			}
			IXPositionGroup ixpositionGroup = base.uiBehaviour.transform.GetComponent("PositionGroup") as IXPositionGroup;
			this._fx1Token = XSingleton<XTimerMgr>.singleton.SetTimer(ixpositionGroup.GetGroup(0).x, new XTimerMgr.ElapsedEventHandler(this.DelayCreateFx), 1);
			this._fx2Token = XSingleton<XTimerMgr>.singleton.SetTimer(ixpositionGroup.GetGroup(1).x, new XTimerMgr.ElapsedEventHandler(this.DelayCreateFx), 2);
		}

		// Token: 0x0600A0C9 RID: 41161 RVA: 0x001AFA4C File Offset: 0x001ADC4C
		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fx1Token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fx2Token);
			this._fx1Token = 0U;
			this._fx2Token = 0U;
			bool flag = this._fx1 != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx1, true);
				this._fx1 = null;
			}
			bool flag2 = this._fx2 != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx2, true);
				this._fx2 = null;
			}
			base.OnHide();
		}

		// Token: 0x0600A0CA RID: 41162 RVA: 0x001AFAE4 File Offset: 0x001ADCE4
		private void DelayCreateFx(object o = null)
		{
			int num = (int)o;
			bool flag = num == 1;
			if (flag)
			{
				this._fx1 = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_fptx_Clip01", base.uiBehaviour.m_FxDepth, false);
			}
			else
			{
				this._fx2 = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_fptx_Clip02", base.uiBehaviour.m_FxDepth2, false);
			}
		}

		// Token: 0x0600A0CB RID: 41163 RVA: 0x001AFB45 File Offset: 0x001ADD45
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600A0CC RID: 41164 RVA: 0x001AFB50 File Offset: 0x001ADD50
		private bool OnClose(IXUIButton uiSprite)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x040039A4 RID: 14756
		private XFx _fx1;

		// Token: 0x040039A5 RID: 14757
		private XFx _fx2;

		// Token: 0x040039A6 RID: 14758
		private uint _fx1Token;

		// Token: 0x040039A7 RID: 14759
		private uint _fx2Token;
	}
}
