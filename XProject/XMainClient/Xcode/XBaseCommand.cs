using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBaseCommand
	{

		public void SetCommand(XTutorialCmd cmd)
		{
			this._cmd = cmd;
		}

		public virtual bool Execute()
		{
			return true;
		}

		public virtual void Update()
		{
		}

		public virtual void Stop()
		{
			this.DestroyButtomText();
			this.DestroyText();
			this.DestroyOverlay();
		}

		public virtual void OnFinish()
		{
			this.Stop();
		}

		protected void SetTutorialText(Vector3 startPos, Transform parent)
		{
			bool flag = this._cmd.text != null && this._cmd.text.Length > 0;
			if (flag)
			{
				bool flag2 = this._text == null;
				if (flag2)
				{
					this._text = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/TutorialText", true, false) as GameObject);
				}
				startPos.z = 0f;
				this._text.transform.parent = parent;
				this._text.transform.localPosition = startPos;
				this._text.transform.localScale = Vector3.one;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(this._text);
				bool flipHorizontal = false;
				IXUISprite ixuisprite = this._text.transform.FindChild("TutorialText").GetComponent("XUISprite") as IXUISprite;
				bool flag3 = startPos.x > 0f;
				if (flag3)
				{
					flipHorizontal = true;
				}
				ixuisprite.SetFlipHorizontal(flipHorizontal);
				IXUILabel ixuilabel = this._text.transform.GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this._cmd.text);
				this._text.SetActive(false);
				this._text.SetActive(true);
			}
		}

		protected void SetOverlay()
		{
			bool flag = XBaseCommand._Overlay == null;
			if (flag)
			{
				XBaseCommand._Overlay = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/TutorialTemp", true, false) as GameObject);
				XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.UIRoot, XBaseCommand._Overlay.transform);
				XBaseCommand._Overlay.SetActive(false);
				XBaseCommand._Overlay.SetActive(true);
			}
			IXUISprite ixuisprite = XBaseCommand._Overlay.transform.FindChild("Left").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(null);
			Input.ResetInputAxes();
		}

		protected virtual void OnMouseClick(IXUISprite sp)
		{
			bool flag = (this.ailin_index == 1 && string.IsNullOrEmpty(this._cmd.ailinText2)) || this.ailin_index == 2;
			if (flag)
			{
				XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
			}
			else
			{
				bool flag2 = !string.IsNullOrEmpty(this._cmd.ailinText2);
				if (flag2)
				{
					IXUILabel ixuilabel = this._ailin.transform.FindChild("TutorialText").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(this._cmd.ailinText2);
					this.ailin_index = 2;
				}
			}
		}

		protected void SetAilin()
		{
			bool flag = !string.IsNullOrEmpty(this._cmd.ailinText);
			if (flag)
			{
				XSingleton<XVirtualTab>.singleton.Cancel();
				this.ailin_index = 1;
				this._ailin = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/Ailin", true, false) as GameObject);
				float num = -84f;
				Transform transform = XSingleton<XGameUI>.singleton.UIRoot.FindChild("TutorialPanel");
				XSingleton<UiUtility>.singleton.AddChild((XBaseCommand._Overlay == null) ? transform : XBaseCommand._Overlay.transform, this._ailin.transform);
				IXUITweenTool ixuitweenTool = this._ailin.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.SetPositionTweenPos(0, new Vector3(-800f, num, 0f), new Vector3((float)this._cmd.ailinPos, num, 0f));
				ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnAilinMoveOver));
				ixuitweenTool.PlayTween(true, -1f);
				IXUILabel ixuilabel = this._ailin.transform.FindChild("TutorialText").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this._cmd.ailinText);
				IXUISprite ixuisprite = this._ailin.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.RegisterSpriteClickEventHandler(null);
				ixuilabel.gameObject.SetActive(false);
			}
		}

		protected void OnAilinMoveOver(IXUITweenTool tween)
		{
			IXUITweenTool ixuitweenTool = this._ailin.transform.FindChild("TutorialText").GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.PlayTween(true, -1f);
			bool flag = XBaseCommand._Overlay != null;
			if (flag)
			{
				IXUISprite ixuisprite = XBaseCommand._Overlay.transform.FindChild("Left").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMouseClick));
			}
			Transform transform = this._ailin.transform.FindChild("Bg");
			bool flag2 = string.IsNullOrEmpty(this._cmd.ailinText2);
			if (flag2)
			{
				transform.gameObject.SetActive(false);
			}
			else
			{
				transform.gameObject.SetActive(true);
				IXUISprite ixuisprite2 = transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMouseClick));
			}
		}

		protected void SetButtomText()
		{
			bool flag = string.IsNullOrEmpty(this._cmd.buttomtext);
			if (!flag)
			{
				bool flag2 = this._buttomText == null;
				if (flag2)
				{
					this._buttomText = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/TutorialButtomText", true, false) as GameObject);
				}
				this._buttomText.transform.parent = XSingleton<XGameUI>.singleton.UIRoot;
				this._buttomText.transform.localPosition = Vector3.zero;
				this._buttomText.transform.localScale = Vector3.one;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(this._buttomText);
				IXUILabel ixuilabel = this._buttomText.transform.FindChild("TutorialText").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this._cmd.buttomtext);
				IXUITweenTool ixuitweenTool = this._buttomText.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.PlayTween(true, -1f);
			}
		}

		protected void publicModule()
		{
			bool flag = this._cmd.audio != null;
			if (flag)
			{
				this.SetAudio(this._cmd.audio);
			}
			bool flag2 = this._cmd.scroll != null;
			if (flag2)
			{
				this.SetScroll(this._cmd.scroll, this._cmd.scrollPos);
			}
			bool flag3 = this._cmd.function != null;
			if (flag3)
			{
				this.DoFunction(this._cmd.function);
			}
		}

		private void SetAudio(string path)
		{
			XSingleton<XAudioMgr>.singleton.StopSoundForCutscene();
			XSingleton<XAudioMgr>.singleton.PlayUISound(path, true, AudioChannel.Motion);
		}

		private void SetScroll(string scroll, int pos)
		{
			bool flag = scroll == "Activity";
			if (flag)
			{
				XActivityDocument specificDocument = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
				specificDocument.SetScrollView(pos);
			}
		}

		private void DoFunction(string function)
		{
			bool flag = function == "showsprite";
			if (flag)
			{
				bool flag2 = this._cmd.functionparam1 == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"TutorialId:",
						this._cmd.TutorialID,
						" Error\ntag:",
						this._cmd.tag,
						" Command:tasktop  Param Num Error"
					}), null, null, null, null, null);
				}
				DlgBase<XSpriteShowView, XSpriteShowBehaviour>.singleton.ShowDetail(uint.Parse(this._cmd.functionparam1), 0U, false);
			}
			bool flag3 = function == "refreshtitle";
			if (flag3)
			{
				XTitleDocument specificDocument = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
				specificDocument.RefreshTitleLevelUp();
			}
			bool flag4 = function == "tasktop";
			if (flag4)
			{
				bool flag5 = this._cmd.functionparam1 == null;
				if (flag5)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"TutorialId:",
						this._cmd.TutorialID,
						" Error\ntag:",
						this._cmd.tag,
						" Command:tasktop  Param Num Error"
					}), null, null, null, null, null);
				}
				XTaskDocument specificDocument2 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
				specificDocument2.SetHighestPriorityTask(uint.Parse(this._cmd.functionparam1));
			}
		}

		protected void DestroyAilin()
		{
			bool flag = this._ailin != null;
			if (flag)
			{
				IXUITweenTool ixuitweenTool = this._ailin.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.RegisterOnFinishEventHandler(null);
				XResourceLoaderMgr.SafeDestroy(ref this._ailin, false);
			}
		}

		protected void DestroyOverlay()
		{
			bool flag = XBaseCommand._Overlay != null;
			if (flag)
			{
				bool flag2 = !this._cmd.isCanDestroyOverlay;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("Overlay No Close", null, null, null, null, null);
				}
				else
				{
					IXUISprite ixuisprite = XBaseCommand._Overlay.transform.FindChild("Left").GetComponent("XUISprite") as IXUISprite;
					bool flag3 = ixuisprite != null;
					if (flag3)
					{
						ixuisprite.RegisterSpriteClickEventHandler(null);
					}
					XResourceLoaderMgr.SafeDestroy(ref XBaseCommand._Overlay, false);
				}
			}
		}

		protected void DestroyButtomText()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._buttomText, false);
		}

		protected void DestroyText()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._text, false);
		}

		protected XTutorialCmd _cmd;

		protected GameObject _text;

		protected static GameObject _Overlay = null;

		protected GameObject _ailin;

		protected GameObject _buttomText;

		public float _startTime = 0f;

		public int ailin_index = 0;
	}
}
