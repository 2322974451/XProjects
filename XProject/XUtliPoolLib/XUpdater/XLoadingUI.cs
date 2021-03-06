using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{

	internal class XLoadingUI : XSingleton<XLoadingUI>
	{

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

		public void OnBoxClick(IXUISprite sp)
		{
			XSingleton<XUpdater>.singleton.OnRetry();
		}

		private void OnBlackPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			XSingleton<XUpdater>.singleton.Phase = eUPdatePhase.xUP_Finish;
		}

		private void OnAilinPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			this.TweenOK = true;
		}

		private void OnJYPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			this.JY.SetVisible(false);
			this.mTextureTransform.gameObject.SetActive(true);
			this.TweenOK = true;
			XSingleton<XUpdater>.singleton.Begin();
		}

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

		public void SetDialog(ulong capacity, XLoadingUI.OnSureCallBack sureCallBack, XLoadingUI.OnSureCallBack cancelCallBack)
		{
			this.mDialogCallBack = sureCallBack;
			this.mDialogCancelCallBack = cancelCallBack;
			this.mDialogTransform.gameObject.SetActive(true);
			this.mDialogCapacityLabel.SetText(this.GetCapacityValue(capacity));
		}

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

		public void SetVersion(string text)
		{
			bool flag = !this.VersionText.IsVisible();
			if (flag)
			{
				this.VersionText.SetVisible(true);
			}
			this.VersionText.SetText(text);
		}

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

		public override void Uninit()
		{
		}

		private IXUISprite JY;

		private IXUISprite Black;

		private IXUITweenTool JYPlayTween;

		private IXUITweenTool BlackPlayTween;

		private IXUILabel StatusText;

		private IXUILabel VersionText;

		private IXUISprite ClickBox;

		public bool LoadingOK = false;

		private bool TweenOK = false;

		private Transform mTextureTransform;

		private Transform mDialogTransform;

		private IXUIButton mDialogSureBtn;

		private IXUIButton mDialogCancelBtn;

		private IXUILabel mDialogCapacityLabel;

		private IXUITexture mDownLoadTexture;

		private IXUIButton mDownLoadNewBtn;

		private Transform mDownLoadTransform;

		private XLoadingUI.OnSureCallBack mDialogCallBack;

		private XLoadingUI.OnSureCallBack mDialogCancelCallBack;

		private XLoadingUI.OnSureCallBack mDownCallBack;

		public delegate void OnSureCallBack();
	}
}
