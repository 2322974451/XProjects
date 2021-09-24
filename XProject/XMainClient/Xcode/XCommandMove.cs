using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandMove : XBaseCommand
	{

		public override bool Execute()
		{
			this._time = XSingleton<XTimerMgr>.singleton.SetTimer(this._cmd.interalDelay, new XTimerMgr.ElapsedEventHandler(this.ShowVT), null);
			base.publicModule();
			return true;
		}

		protected void ShowVT(object o)
		{
			this._startTime = Time.time;
			base.SetButtomText();
			DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.ShowPanel(true, new Vector2(200f, 50f));
			bool pause = this._cmd.pause;
			if (pause)
			{
				XSingleton<XShell>.singleton.Pause = true;
			}
		}

		public override void Stop()
		{
			DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.ShowPanel(false, Vector2.zero);
			bool flag = this._time > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time);
				this._time = 0U;
			}
			base.DestroyButtomText();
			base.DestroyOverlay();
			XSingleton<XShell>.singleton.Pause = false;
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
		}

		private uint _time = 0U;
	}
}
