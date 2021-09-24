using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandPrefab : XBaseCommand
	{

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

		protected void TweenFinish(object o)
		{
			this.RegisterOnMouseClick();
		}

		protected void OnTweenFinish(IXUITweenTool tool)
		{
			this.RegisterOnMouseClick();
		}

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

		protected override void OnMouseClick(IXUISprite sp)
		{
			base.OnMouseClick(sp);
			XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
		}

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

		private GameObject _Prefab;

		private uint _time = 0U;

		private uint _time2 = 0U;
	}
}
