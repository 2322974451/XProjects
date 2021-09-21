using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001921 RID: 6433
	internal class LoadingDlg : DlgBase<LoadingDlg, LoadingDlgBehaviour>
	{
		// Token: 0x17003AFC RID: 15100
		// (get) Token: 0x06010D92 RID: 69010 RVA: 0x004429C8 File Offset: 0x00440BC8
		public override string fileName
		{
			get
			{
				return "Common/LoadingDlg";
			}
		}

		// Token: 0x17003AFD RID: 15101
		// (get) Token: 0x06010D93 RID: 69011 RVA: 0x004429E0 File Offset: 0x00440BE0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003AFE RID: 15102
		// (get) Token: 0x06010D94 RID: 69012 RVA: 0x004429F4 File Offset: 0x00440BF4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AFF RID: 15103
		// (get) Token: 0x06010D95 RID: 69013 RVA: 0x00442A08 File Offset: 0x00440C08
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010D96 RID: 69014 RVA: 0x00442A1B File Offset: 0x00440C1B
		protected override void Init()
		{
			this.SetWaitForOthersTip("");
		}

		// Token: 0x06010D97 RID: 69015 RVA: 0x00442A2C File Offset: 0x00440C2C
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

		// Token: 0x06010D98 RID: 69016 RVA: 0x00442AC4 File Offset: 0x00440CC4
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

		// Token: 0x06010D99 RID: 69017 RVA: 0x00442B58 File Offset: 0x00440D58
		private void SetWaitForOthersTip(string tips)
		{
			base.uiBehaviour.m_WaitForOthersTip.SetText(tips);
			base.uiBehaviour.m_WaitForOthersTip.SetVisible(!string.IsNullOrEmpty(tips));
		}

		// Token: 0x06010D9A RID: 69018 RVA: 0x00442B87 File Offset: 0x00440D87
		public void SetLoadingTip(string tip)
		{
			base.uiBehaviour.m_LoadingTips.SetText(tip);
		}

		// Token: 0x06010D9B RID: 69019 RVA: 0x00442B9C File Offset: 0x00440D9C
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

		// Token: 0x06010D9C RID: 69020 RVA: 0x00442C20 File Offset: 0x00440E20
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

		// Token: 0x06010D9D RID: 69021 RVA: 0x00442CD8 File Offset: 0x00440ED8
		protected void OnFinish(IXUITweenTool tween)
		{
			base.uiBehaviour.m_LoadingBg.gameObject.SetActive(true);
			base.uiBehaviour.m_Canvas.gameObject.SetActive(false);
			this.ReleaseTexture();
			this.SetVisible(false, true);
		}

		// Token: 0x06010D9E RID: 69022 RVA: 0x00442D24 File Offset: 0x00440F24
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

		// Token: 0x04007BF1 RID: 31729
		private string _pic = null;
	}
}
