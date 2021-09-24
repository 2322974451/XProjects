using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMinePVPBeginView : DlgBase<GuildMinePVPBeginView, GuildMinePVPBeginBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildMine/GuildMinePVPBegin";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
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

		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(10f, new XTimerMgr.ElapsedEventHandler(this.AutoClose), null);
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			base.OnHide();
		}

		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			base.OnUnload();
		}

		private void AutoClose(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ENTER_TIME_OUT"), "fece00");
				DlgBase<GuildMinePVPBeginView, GuildMinePVPBeginBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			}
		}

		private uint _TimerID = 0U;
	}
}
