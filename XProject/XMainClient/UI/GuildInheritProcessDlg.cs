using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildInheritProcessDlg : DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildInheritProcessDlg";
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		public void ShowProcess(float countdownTime, string mess, string tips, GuildInheritProcessDlg.OnSliderProcessEnd events = null)
		{
			bool flag = this.m_lastTime == null;
			if (flag)
			{
				this.m_lastTime = new XElapseTimer();
			}
			this._endEvent = events;
			this.m_totalTime = countdownTime;
			this.m_lastTime.LeftTime = this.m_totalTime;
			this.SetVisibleWithAnimation(true, null);
			base.uiBehaviour.mProcessLabel.SetText(mess);
			base.uiBehaviour.mContentLabel.SetText(tips);
		}

		public void HideProcess()
		{
			this.SetVisibleWithAnimation(false, null);
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnUnload()
		{
			this.m_lastTime = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateTime();
		}

		private void UpdateTime()
		{
			this.m_lastTime.Update();
			bool flag = this.m_lastTime.LeftTime > 0f;
			if (flag)
			{
				float value = this.m_lastTime.LeftTime / this.m_totalTime;
				base.uiBehaviour.mProcessSlider.Value = value;
			}
			else
			{
				this.SetVisibleWithAnimation(false, null);
				bool flag2 = this._endEvent != null;
				if (flag2)
				{
					this._endEvent();
				}
			}
		}

		private XElapseTimer m_lastTime;

		private float m_totalTime;

		private GuildInheritProcessDlg.OnSliderProcessEnd _endEvent;

		public delegate void OnSliderProcessEnd();
	}
}
