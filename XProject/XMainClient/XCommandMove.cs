using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DD1 RID: 3537
	internal class XCommandMove : XBaseCommand
	{
		// Token: 0x0600C0B0 RID: 49328 RVA: 0x0028CE64 File Offset: 0x0028B064
		public override bool Execute()
		{
			this._time = XSingleton<XTimerMgr>.singleton.SetTimer(this._cmd.interalDelay, new XTimerMgr.ElapsedEventHandler(this.ShowVT), null);
			base.publicModule();
			return true;
		}

		// Token: 0x0600C0B1 RID: 49329 RVA: 0x0028CEA8 File Offset: 0x0028B0A8
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

		// Token: 0x0600C0B2 RID: 49330 RVA: 0x0028CF00 File Offset: 0x0028B100
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

		// Token: 0x04005075 RID: 20597
		private uint _time = 0U;
	}
}
