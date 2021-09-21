using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
	// Token: 0x02000015 RID: 21
	internal class XLoadingUI : XSingleton<XLoadingUI>
	{
		// Token: 0x06000057 RID: 87 RVA: 0x000034EC File Offset: 0x000016EC
		public override bool Init()
		{
			PlayerPrefs.SetString("Language", "Language");
			GameObject gameObject = GameObject.Find("UIRoot/StartLoadingDlg/Bg/Ailin");
			GameObject gameObject2 = GameObject.Find("UIRoot/StartLoadingDlg/Bg/JY");
			GameObject gameObject3 = GameObject.Find("UIRoot/StartLoadingDlg/Bg").transform.FindChild("Black").gameObject;
			this.StatusText = (GameObject.Find("UIRoot/StartLoadingDlg/Bg/LabelStatus").GetComponent("XUILabel") as IXUILabel);
			this.VersionText = (GameObject.Find("UIRoot/StartLoadingDlg/Bg/LabelVersion").GetComponent("XUILabel") as IXUILabel);
			this.JY = (gameObject2.GetComponent("XUISprite") as IXUISprite);
			this.Black = (gameObject3.GetComponent("XUISprite") as IXUISprite);
			this.JYPlayTween = (gameObject2.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.BlackPlayTween = (gameObject3.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.JYPlayTween.SetTargetGameObject(gameObject2);
			this.JYPlayTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnJYPlayTweenFinish));
			this.Black.SetVisible(true);
			this.BlackPlayTween.SetTargetGameObject(gameObject3);
			this.BlackPlayTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnBlackPlayTweenFinish));
			this.StatusText.SetVisible(false);
			this.VersionText.SetVisible(false);
			this.Black.SetVisible(false);
			this.JY.SetVisible(true);
			this.JYPlayTween.PlayTween(true, -1f);
			this.ClickBox = (GameObject.Find("UIRoot/StartLoadingDlg/Bg").GetComponent("XUISprite") as IXUISprite);
			this.ClickBox.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBoxClick));
			this.mTextureTransform = GameObject.Find("UIRoot/StartLoadingDlg/Bg/Texture").transform;
			this.mDialogTransform = GameObject.Find("UIRoot/StartLoadingDlg/Bg/Dialog").transform;
			this.mDialogSureBtn = (this.mDialogTransform.FindChild("OK").GetComponent("XUIButton") as IXUIButton);
			this.mDialogCancelBtn = (this.mDialogTransform.FindChild("Cancel").GetComponent("XUIButton") as IXUIButton);
			this.mDialogCapacityLabel = (this.mDialogTransform.FindChild("CapacityValue").GetComponent("XUILabel") as IXUILabel);
			this.mDialogSureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDialogSureClick));
			this.mDialogCancelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDialogCancelClick));
			this.mTextureTransform.gameObject.SetActive(false);
			this.mDialogTransform.gameObject.SetActive(false);
			this.mDownLoadTransform = GameObject.Find("UIRoot/StartLoadingDlg/Bg/DownNew").transform;
			this.mDownLoadTexture = (this.mDownLoadTransform.Find("Pic").GetComponent("XUITexture") as IXUITexture);
			this.mDownLoadNewBtn = (this.mDownLoadTransform.FindChild("OK").GetComponent("XUIButton") as IXUIButton);
			this.mDownLoadTransform.gameObject.SetActive(false);
			this.mDownLoadNewBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDownLoadCallback));
			return true;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003824 File Offset: 0x00001A24
		public bool OnDialogSureClick(IXUIButton btn)
		{
			this.mDialogTransform.gameObject.SetActive(false);
			bool flag = this.mDialogCallBack != null;
			if (flag)
			{
				this.mDialogCallBack();
			}
			return true;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003864 File Offset: 0x00001A64
		public bool OnDialogCancelClick(IXUIButton btn)
		{
			this.mDialogTransform.gameObject.SetActive(false);
			bool flag = this.mDialogCancelCallBack != null;
			if (flag)
			{
				this.mDialogCancelCallBack();
			}
			return true;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000038A4 File Offset: 0x00001AA4
		public bool OnDownLoadCallback(IXUIButton btn)
		{
			this.mDownLoadTransform.gameObject.SetActive(false);
			bool flag = this.mDownCallBack != null;
			if (flag)
			{
				this.mDownCallBack();
			}
			return true;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000038E2 File Offset: 0x00001AE2
		public void OnBoxClick(IXUISprite sp)
		{
			XSingleton<XUpdater>.singleton.OnRetry();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000038F0 File Offset: 0x00001AF0
		private void OnBlackPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			XSingleton<XUpdater>.singleton.Phase = eUPdatePhase.xUP_Finish;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003900 File Offset: 0x00001B00
		private void OnAilinPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			this.TweenOK = true;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000390A File Offset: 0x00001B0A
		private void OnJYPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			this.JY.SetVisible(false);
			this.mTextureTransform.gameObject.SetActive(true);
			this.TweenOK = true;
			XSingleton<XUpdater>.singleton.Begin();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003940 File Offset: 0x00001B40
		private void LoadFinishClean()
		{
			this.JY = null;
			this.Black = null;
			this.JYPlayTween = null;
			this.BlackPlayTween = null;
			this.StatusText = null;
			this.VersionText = null;
			this.ClickBox = null;
			this.mDialogCallBack = null;
			this.mDialogCancelCallBack = null;
			this.mDialogCancelBtn = null;
			this.mDialogSureBtn = null;
			this.mDialogCapacityLabel = null;
			this.mDialogTransform = null;
			this.mDownLoadNewBtn = null;
			this.mDownLoadTransform = null;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000039B7 File Offset: 0x00001BB7
		public void SetDialog(ulong capacity, XLoadingUI.OnSureCallBack sureCallBack, XLoadingUI.OnSureCallBack cancelCallBack)
		{
			this.mDialogCallBack = sureCallBack;
			this.mDialogCancelCallBack = cancelCallBack;
			this.mDialogTransform.gameObject.SetActive(true);
			this.mDialogCapacityLabel.SetText(this.GetCapacityValue(capacity));
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000039F0 File Offset: 0x00001BF0
		public void SetDownLoad(XLoadingUI.OnSureCallBack sureCallBack, Texture tex)
		{
			this.mDownCallBack = sureCallBack;
			this.mDownLoadTransform.gameObject.SetActive(true);
			bool flag = tex != null;
			if (flag)
			{
				this.mDownLoadTexture.SetRuntimeTex(tex, true);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003A30 File Offset: 0x00001C30
		private string GetCapacityValue(ulong capacity)
		{
			bool flag = capacity < 1048576UL;
			string result;
			if (flag)
			{
				result = string.Format("{0}K", (capacity / 1024UL).ToString("F2"));
			}
			else
			{
				result = string.Format("{0}M", (capacity / 1024UL / 1024UL).ToString("F2"));
			}
			return result;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003AA0 File Offset: 0x00001CA0
		public void SetStatus(string text, byte r = 255, byte g = 255, byte b = 255)
		{
			bool flag = !this.StatusText.IsVisible();
			if (flag)
			{
				this.StatusText.SetVisible(true);
			}
			this.StatusText.SetColor(new Color32(r, g, b, byte.MaxValue));
			this.StatusText.SetText(text);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003AFC File Offset: 0x00001CFC
		public void SetVersion(string text)
		{
			bool flag = !this.VersionText.IsVisible();
			if (flag)
			{
				this.VersionText.SetVisible(true);
			}
			this.VersionText.SetText(text);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003B38 File Offset: 0x00001D38
		public void OnUpdate()
		{
			bool flag = this.TweenOK && this.LoadingOK;
			if (flag)
			{
				this.TweenOK = (this.LoadingOK = false);
				XSingleton<XUpdater>.singleton.Phase = eUPdatePhase.xUP_Finish;
				this.LoadFinishClean();
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003284 File Offset: 0x00001484
		public override void Uninit()
		{
		}

		// Token: 0x04000045 RID: 69
		private IXUISprite JY;

		// Token: 0x04000046 RID: 70
		private IXUISprite Black;

		// Token: 0x04000047 RID: 71
		private IXUITweenTool JYPlayTween;

		// Token: 0x04000048 RID: 72
		private IXUITweenTool BlackPlayTween;

		// Token: 0x04000049 RID: 73
		private IXUILabel StatusText;

		// Token: 0x0400004A RID: 74
		private IXUILabel VersionText;

		// Token: 0x0400004B RID: 75
		private IXUISprite ClickBox;

		// Token: 0x0400004C RID: 76
		public bool LoadingOK = false;

		// Token: 0x0400004D RID: 77
		private bool TweenOK = false;

		// Token: 0x0400004E RID: 78
		private Transform mTextureTransform;

		// Token: 0x0400004F RID: 79
		private Transform mDialogTransform;

		// Token: 0x04000050 RID: 80
		private IXUIButton mDialogSureBtn;

		// Token: 0x04000051 RID: 81
		private IXUIButton mDialogCancelBtn;

		// Token: 0x04000052 RID: 82
		private IXUILabel mDialogCapacityLabel;

		// Token: 0x04000053 RID: 83
		private IXUITexture mDownLoadTexture;

		// Token: 0x04000054 RID: 84
		private IXUIButton mDownLoadNewBtn;

		// Token: 0x04000055 RID: 85
		private Transform mDownLoadTransform;

		// Token: 0x04000056 RID: 86
		private XLoadingUI.OnSureCallBack mDialogCallBack;

		// Token: 0x04000057 RID: 87
		private XLoadingUI.OnSureCallBack mDialogCancelCallBack;

		// Token: 0x04000058 RID: 88
		private XLoadingUI.OnSureCallBack mDownCallBack;

		// Token: 0x02000284 RID: 644
		// (Invoke) Token: 0x06000D95 RID: 3477
		public delegate void OnSureCallBack();
	}
}
