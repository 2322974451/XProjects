using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DD2 RID: 3538
	internal class XCommandPrefab : XBaseCommand
	{
		// Token: 0x0600C0B4 RID: 49332 RVA: 0x0028CF7C File Offset: 0x0028B17C
		public override bool Execute()
		{
			bool flag = this._cmd.param2 == "SelectSight";
			bool result;
			if (flag)
			{
				bool pause = this._cmd.pause;
				if (pause)
				{
					XSingleton<XShell>.singleton.Pause = true;
				}
				DlgBase<CutoverViewView, CutoverViewBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			else
			{
				bool flag2 = this._cmd.param2 == "SelectSkipTutorial";
				if (flag2)
				{
					DlgBase<TutorialSkipView, TutorialSkipBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					result = true;
				}
				else
				{
					this._time = XSingleton<XTimerMgr>.singleton.SetTimer(this._cmd.interalDelay, new XTimerMgr.ElapsedEventHandler(this.ShowVT), null);
					base.publicModule();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600C0B5 RID: 49333 RVA: 0x0028D034 File Offset: 0x0028B234
		protected void ShowVT(object o)
		{
			base.SetOverlay();
			this.ShowPic();
			bool pause = this._cmd.pause;
			if (pause)
			{
				XSingleton<XShell>.singleton.Pause = true;
			}
		}

		// Token: 0x0600C0B6 RID: 49334 RVA: 0x0028D070 File Offset: 0x0028B270
		protected void ShowPic()
		{
			bool flag = this._Prefab == null;
			if (flag)
			{
				this._Prefab = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(this._cmd.param1, true, false) as GameObject);
			}
			XSingleton<UiUtility>.singleton.AddChild(XBaseCommand._Overlay, this._Prefab);
			IXUITweenTool ixuitweenTool = this._Prefab.GetComponent("XUIPlayTween") as IXUITweenTool;
			bool flag2 = this._cmd.param2 == "Time";
			if (flag2)
			{
				this._time2 = XSingleton<XTimerMgr>.singleton.SetTimer(float.Parse(this._cmd.param3), new XTimerMgr.ElapsedEventHandler(this.TweenFinish), null);
			}
			else
			{
				bool flag3 = this._cmd.param2 == "PlayFinished";
				if (flag3)
				{
					ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnTweenFinish));
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Tutorial ShowPrefab No Finish Way!\nTag:" + this._cmd.tag, null, null, null, null, null);
				}
			}
			ixuitweenTool.PlayTween(true, -1f);
		}

		// Token: 0x0600C0B7 RID: 49335 RVA: 0x0028D18C File Offset: 0x0028B38C
		protected void TweenFinish(object o)
		{
			this.RegisterOnMouseClick();
		}

		// Token: 0x0600C0B8 RID: 49336 RVA: 0x0028D18C File Offset: 0x0028B38C
		protected void OnTweenFinish(IXUITweenTool tool)
		{
			this.RegisterOnMouseClick();
		}

		// Token: 0x0600C0B9 RID: 49337 RVA: 0x0028D198 File Offset: 0x0028B398
		protected void RegisterOnMouseClick()
		{
			bool flag = this._Prefab != null;
			if (flag)
			{
				IXUISprite ixuisprite = this._Prefab.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMouseClick));
			}
			else
			{
				this.OnMouseClick(null);
			}
		}

		// Token: 0x0600C0BA RID: 49338 RVA: 0x0028D1FD File Offset: 0x0028B3FD
		protected override void OnMouseClick(IXUISprite sp)
		{
			base.OnMouseClick(sp);
			XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
		}

		// Token: 0x0600C0BB RID: 49339 RVA: 0x0028D214 File Offset: 0x0028B414
		public override void Stop()
		{
			bool flag = this._time > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time);
				this._time = 0U;
			}
			bool flag2 = this._time2 > 0U;
			if (flag2)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time2);
				this._time2 = 0U;
			}
			XResourceLoaderMgr.SafeDestroy(ref this._Prefab, false);
			base.DestroyAilin();
			base.DestroyOverlay();
			XSingleton<XShell>.singleton.Pause = false;
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
		}

		// Token: 0x04005076 RID: 20598
		private GameObject _Prefab;

		// Token: 0x04005077 RID: 20599
		private uint _time = 0U;

		// Token: 0x04005078 RID: 20600
		private uint _time2 = 0U;
	}
}
