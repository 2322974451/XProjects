using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001763 RID: 5987
	internal class GuildInheritProcessDlg : DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>
	{
		// Token: 0x1700380C RID: 14348
		// (get) Token: 0x0600F733 RID: 63283 RVA: 0x00383494 File Offset: 0x00381694
		public override string fileName
		{
			get
			{
				return "Guild/GuildInheritProcessDlg";
			}
		}

		// Token: 0x1700380D RID: 14349
		// (get) Token: 0x0600F734 RID: 63284 RVA: 0x003834AC File Offset: 0x003816AC
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F735 RID: 63285 RVA: 0x003834C0 File Offset: 0x003816C0
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

		// Token: 0x0600F736 RID: 63286 RVA: 0x00383534 File Offset: 0x00381734
		public void HideProcess()
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x0600F737 RID: 63287 RVA: 0x00383540 File Offset: 0x00381740
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600F738 RID: 63288 RVA: 0x0038354A File Offset: 0x0038174A
		protected override void OnUnload()
		{
			this.m_lastTime = null;
			base.OnUnload();
		}

		// Token: 0x0600F739 RID: 63289 RVA: 0x0038355B File Offset: 0x0038175B
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateTime();
		}

		// Token: 0x0600F73A RID: 63290 RVA: 0x0038356C File Offset: 0x0038176C
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

		// Token: 0x04006B7E RID: 27518
		private XElapseTimer m_lastTime;

		// Token: 0x04006B7F RID: 27519
		private float m_totalTime;

		// Token: 0x04006B80 RID: 27520
		private GuildInheritProcessDlg.OnSliderProcessEnd _endEvent;

		// Token: 0x02001A0B RID: 6667
		// (Invoke) Token: 0x06011114 RID: 69908
		public delegate void OnSliderProcessEnd();
	}
}
