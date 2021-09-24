using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class LoadingDlg : DlgBase<LoadingDlg, LoadingDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/LoadingDlg";
			}
		}

		public override int layer
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

		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.SetWaitForOthersTip("");
		}

		public void SetLoadingProgress(float f)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				bool flag2 = this.m_uiBehaviour.m_LoadingProgress.IsVisible();
				if (flag2)
				{
					this.m_uiBehaviour.m_LoadingProgress.value = f;
					bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !XSingleton<XScene>.singleton.IsPVPScene && XSingleton<XGame>.singleton.SyncMode;
					if (flag3)
					{
						this.SetWaitForOthersTip((f == 1f) ? XStringDefineProxy.GetString("WAIT_FOR_OTHERS") : "");
					}
				}
			}
		}

		public void SetLoadingPrompt(List<string> otherPalyerName)
		{
			bool flag = !base.IsLoaded() || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.World || !XSingleton<XGame>.singleton.SyncMode;
			if (!flag)
			{
				bool flag2 = otherPalyerName == null || otherPalyerName.Count == 0;
				if (flag2)
				{
					this.SetWaitForOthersTip(XStringDefineProxy.GetString("WAIT_FOR_OTHERS"));
				}
				else
				{
					string waitForOthersTip = string.Format(XSingleton<XStringTable>.singleton.GetString("WAIT_OTHER_PLAYER_PVE"), otherPalyerName.Count, otherPalyerName[0]);
					this.SetWaitForOthersTip(waitForOthersTip);
				}
			}
		}

		private void SetWaitForOthersTip(string tips)
		{
			base.uiBehaviour.m_WaitForOthersTip.SetText(tips);
			base.uiBehaviour.m_WaitForOthersTip.SetVisible(!string.IsNullOrEmpty(tips));
		}

		public void SetLoadingTip(string tip)
		{
			base.uiBehaviour.m_LoadingTips.SetText(tip);
		}

		public void SetLoadingPic(string pic)
		{
			this._pic = pic;
			bool flag = string.IsNullOrEmpty(pic);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("null laoding pic", null, null, null, null, null);
			}
			else
			{
				base.uiBehaviour.m_LoadingPic.SetTexturePath("atlas/UI/common/Pic/" + this._pic);
			}
			bool flag2 = base.uiBehaviour.m_Dog != null;
			if (flag2)
			{
				base.uiBehaviour.m_Dog.SetSprite("Animation");
			}
		}

		public void HideSelf(bool bFadeIn)
		{
			if (bFadeIn)
			{
				base.uiBehaviour.m_LoadingBg.gameObject.SetActive(false);
				base.uiBehaviour.m_Canvas.gameObject.SetActive(true);
				IXUITweenTool ixuitweenTool = base.uiBehaviour.m_Canvas.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.SetTweenEnabledWhenFinish(false);
				ixuitweenTool.SetTargetGameObject(base.uiBehaviour.m_Canvas.gameObject);
				ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnFinish));
				ixuitweenTool.PlayTween(true, -1f);
			}
			else
			{
				this.ReleaseTexture();
				this.SetVisible(false, true);
			}
		}

		protected void OnFinish(IXUITweenTool tween)
		{
			base.uiBehaviour.m_LoadingBg.gameObject.SetActive(true);
			base.uiBehaviour.m_Canvas.gameObject.SetActive(false);
			this.ReleaseTexture();
			this.SetVisible(false, true);
		}

		private void ReleaseTexture()
		{
			bool flag = base.uiBehaviour != null;
			if (flag)
			{
				bool flag2 = base.uiBehaviour.m_LoadingPic != null;
				if (flag2)
				{
					base.uiBehaviour.m_LoadingPic.SetTexturePath("");
				}
				bool flag3 = base.uiBehaviour.m_Dog != null;
				if (flag3)
				{
					base.uiBehaviour.m_Dog.SetSprite("", "", false);
				}
			}
		}

		private string _pic = null;
	}
}
