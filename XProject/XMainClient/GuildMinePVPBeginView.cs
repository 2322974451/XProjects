using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C0E RID: 3086
	internal class GuildMinePVPBeginView : DlgBase<GuildMinePVPBeginView, GuildMinePVPBeginBehaviour>
	{
		// Token: 0x170030E4 RID: 12516
		// (get) Token: 0x0600AF3D RID: 44861 RVA: 0x00212AE0 File Offset: 0x00210CE0
		public override string fileName
		{
			get
			{
				return "Guild/GuildMine/GuildMinePVPBegin";
			}
		}

		// Token: 0x170030E5 RID: 12517
		// (get) Token: 0x0600AF3E RID: 44862 RVA: 0x00212AF8 File Offset: 0x00210CF8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030E6 RID: 12518
		// (get) Token: 0x0600AF3F RID: 44863 RVA: 0x00212B0C File Offset: 0x00210D0C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030E7 RID: 12519
		// (get) Token: 0x0600AF40 RID: 44864 RVA: 0x00212B20 File Offset: 0x00210D20
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030E8 RID: 12520
		// (get) Token: 0x0600AF41 RID: 44865 RVA: 0x00212B34 File Offset: 0x00210D34
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AF42 RID: 44866 RVA: 0x00212B47 File Offset: 0x00210D47
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(10f, new XTimerMgr.ElapsedEventHandler(this.AutoClose), null);
		}

		// Token: 0x0600AF43 RID: 44867 RVA: 0x00212B84 File Offset: 0x00210D84
		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			base.OnHide();
		}

		// Token: 0x0600AF44 RID: 44868 RVA: 0x00212BA6 File Offset: 0x00210DA6
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			base.OnUnload();
		}

		// Token: 0x0600AF45 RID: 44869 RVA: 0x00212BC8 File Offset: 0x00210DC8
		private void AutoClose(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ENTER_TIME_OUT"), "fece00");
				DlgBase<GuildMinePVPBeginView, GuildMinePVPBeginBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			}
		}

		// Token: 0x040042CD RID: 17101
		private uint _TimerID = 0U;
	}
}
