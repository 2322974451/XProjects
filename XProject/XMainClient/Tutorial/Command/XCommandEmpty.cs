using System;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.Tutorial.Command
{

	internal class XCommandEmpty : XBaseCommand
	{

		public override bool Execute()
		{
			this._startTime = Time.time;
			bool flag = this._cmd.interalDelay > 0f;
			if (flag)
			{
				base.SetOverlay();
			}
			this._time = XSingleton<XTimerMgr>.singleton.SetTimer(this._cmd.interalDelay, new XTimerMgr.ElapsedEventHandler(this.ShowFinger), null);
			base.publicModule();
			return true;
		}

		protected void ShowFinger(object o)
		{
			base.SetOverlay();
			base.SetAilin();
			bool flag = string.IsNullOrEmpty(this._cmd.ailinText) && XBaseCommand._Overlay != null;
			if (flag)
			{
				IXUISprite ixuisprite = XBaseCommand._Overlay.transform.FindChild("Left").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMouseClick));
			}
			bool pause = this._cmd.pause;
			if (pause)
			{
				XSingleton<XShell>.singleton.Pause = true;
			}
		}

		protected override void OnMouseClick(IXUISprite sp)
		{
			base.OnMouseClick(sp);
			bool flag = string.IsNullOrEmpty(this._cmd.ailinText);
			if (flag)
			{
				XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
			}
		}

		public override void Stop()
		{
			bool flag = this._time > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time);
				this._time = 0U;
			}
			base.DestroyText();
			base.DestroyAilin();
			base.DestroyOverlay();
			XSingleton<XShell>.singleton.Pause = false;
			XSingleton<XTutorialMgr>.singleton.NoforceClick = false;
		}

		private uint _time = 0U;
	}
}
