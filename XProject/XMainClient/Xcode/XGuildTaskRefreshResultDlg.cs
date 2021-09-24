using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildTaskRefreshResultDlg : DlgBase<XGuildTaskRefreshResultDlg, XGuildTaskRefreshResultDlgBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/DailyTaskResult";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public uint AfterScore { get; set; }

		public uint BeforeScore { get; set; }

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

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

		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.blockBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		private bool OnClose(IXUIButton uiSprite)
		{
			this.SetVisible(false, true);
			return true;
		}

		private XFx _fx1;

		private XFx _fx2;

		private uint _fx1Token;

		private uint _fx2Token;
	}
}
