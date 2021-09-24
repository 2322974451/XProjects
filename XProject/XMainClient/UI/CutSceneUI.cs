using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class CutSceneUI : DlgBase<CutSceneUI, CutSceneUIBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/CutSceneUI";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.uiBehaviour.m_BG.SetVisible(true);
			base.uiBehaviour.m_Text.SetText("");
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Skip.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnSkipClick));
			base.uiBehaviour.m_Overlay.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOverlayClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Overlay.gameObject.SetActive(true);
			base.uiBehaviour.m_Skip.gameObject.SetActive(false);
			base.uiBehaviour.m_IntroTween.gameObject.SetActive(false);
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_Text.SetText("");
		}

		protected void OnSkipClick(IXUILabel uiSprite)
		{
			bool isPlaying = XSingleton<XCutScene>.singleton.IsPlaying;
			if (isPlaying)
			{
				XSingleton<XCutScene>.singleton.Stop(false);
			}
		}

		protected void OnOverlayClick(IXUISprite go)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				base.uiBehaviour.m_Overlay.gameObject.SetActive(false);
				base.uiBehaviour.m_Skip.gameObject.SetActive(true);
			}
		}

		public void SetText(string text)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			base.uiBehaviour.m_Text.SetText(text);
		}

		public void SetIntroText(bool enabled, string name, string text, float x, float y)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				if (enabled)
				{
					base.uiBehaviour.m_Name.SetText(name);
					base.uiBehaviour.m_IntroTween.gameObject.transform.localPosition = new Vector2(x, y);
					base.uiBehaviour.m_IntroText.SetText(text);
					base.uiBehaviour.m_IntroTween.SetTweenGroup(0);
					base.uiBehaviour.m_IntroTween.ResetTweenByGroup(true, 0);
					base.uiBehaviour.m_IntroTween.PlayTween(true, -1f);
				}
				else
				{
					base.uiBehaviour.m_IntroTween.SetTweenGroup(1);
					base.uiBehaviour.m_IntroTween.ResetTweenByGroup(true, 1);
					base.uiBehaviour.m_IntroTween.PlayTween(true, -1f);
				}
			}
		}
	}
}
