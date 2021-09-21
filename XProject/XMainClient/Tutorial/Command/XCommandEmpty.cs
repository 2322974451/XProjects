using System;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.Tutorial.Command
{
	// Token: 0x020016C5 RID: 5829
	internal class XCommandEmpty : XBaseCommand
	{
		// Token: 0x0600F072 RID: 61554 RVA: 0x0034D210 File Offset: 0x0034B410
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

		// Token: 0x0600F073 RID: 61555 RVA: 0x0034D27C File Offset: 0x0034B47C
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

		// Token: 0x0600F074 RID: 61556 RVA: 0x0034D314 File Offset: 0x0034B514
		protected override void OnMouseClick(IXUISprite sp)
		{
			base.OnMouseClick(sp);
			bool flag = string.IsNullOrEmpty(this._cmd.ailinText);
			if (flag)
			{
				XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
			}
		}

		// Token: 0x0600F075 RID: 61557 RVA: 0x0034D34C File Offset: 0x0034B54C
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

		// Token: 0x0400667C RID: 26236
		private uint _time = 0U;
	}
}
