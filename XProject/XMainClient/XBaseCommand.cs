using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DF5 RID: 3573
	internal class XBaseCommand
	{
		// Token: 0x0600C137 RID: 49463 RVA: 0x00291002 File Offset: 0x0028F202
		public void SetCommand(XTutorialCmd cmd)
		{
			this._cmd = cmd;
		}

		// Token: 0x0600C138 RID: 49464 RVA: 0x0029100C File Offset: 0x0028F20C
		public virtual bool Execute()
		{
			return true;
		}

		// Token: 0x0600C139 RID: 49465 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Update()
		{
		}

		// Token: 0x0600C13A RID: 49466 RVA: 0x0029101F File Offset: 0x0028F21F
		public virtual void Stop()
		{
			this.DestroyButtomText();
			this.DestroyText();
			this.DestroyOverlay();
		}

		// Token: 0x0600C13B RID: 49467 RVA: 0x001E3B34 File Offset: 0x001E1D34
		public virtual void OnFinish()
		{
			this.Stop();
		}

		// Token: 0x0600C13C RID: 49468 RVA: 0x00291038 File Offset: 0x0028F238
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

		// Token: 0x0600C13D RID: 49469 RVA: 0x0029118C File Offset: 0x0028F38C
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

		// Token: 0x0600C13E RID: 49470 RVA: 0x00291230 File Offset: 0x0028F430
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

		// Token: 0x0600C13F RID: 49471 RVA: 0x002912D0 File Offset: 0x0028F4D0
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

		// Token: 0x0600C140 RID: 49472 RVA: 0x00291450 File Offset: 0x0028F650
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

		// Token: 0x0600C141 RID: 49473 RVA: 0x0029154C File Offset: 0x0028F74C
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

		// Token: 0x0600C142 RID: 49474 RVA: 0x00291658 File Offset: 0x0028F858
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

		// Token: 0x0600C143 RID: 49475 RVA: 0x002916E3 File Offset: 0x0028F8E3
		private void SetAudio(string path)
		{
			XSingleton<XAudioMgr>.singleton.StopSoundForCutscene();
			XSingleton<XAudioMgr>.singleton.PlayUISound(path, true, AudioChannel.Motion);
		}

		// Token: 0x0600C144 RID: 49476 RVA: 0x00291700 File Offset: 0x0028F900
		private void SetScroll(string scroll, int pos)
		{
			bool flag = scroll == "Activity";
			if (flag)
			{
				XActivityDocument specificDocument = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
				specificDocument.SetScrollView(pos);
			}
		}

		// Token: 0x0600C145 RID: 49477 RVA: 0x00291734 File Offset: 0x0028F934
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

		// Token: 0x0600C146 RID: 49478 RVA: 0x002918A0 File Offset: 0x0028FAA0
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

		// Token: 0x0600C147 RID: 49479 RVA: 0x002918EC File Offset: 0x0028FAEC
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

		// Token: 0x0600C148 RID: 49480 RVA: 0x00291975 File Offset: 0x0028FB75
		protected void DestroyButtomText()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._buttomText, false);
		}

		// Token: 0x0600C149 RID: 49481 RVA: 0x00291985 File Offset: 0x0028FB85
		protected void DestroyText()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._text, false);
		}

		// Token: 0x0400516E RID: 20846
		protected XTutorialCmd _cmd;

		// Token: 0x0400516F RID: 20847
		protected GameObject _text;

		// Token: 0x04005170 RID: 20848
		protected static GameObject _Overlay = null;

		// Token: 0x04005171 RID: 20849
		protected GameObject _ailin;

		// Token: 0x04005172 RID: 20850
		protected GameObject _buttomText;

		// Token: 0x04005173 RID: 20851
		public float _startTime = 0f;

		// Token: 0x04005174 RID: 20852
		public int ailin_index = 0;
	}
}
