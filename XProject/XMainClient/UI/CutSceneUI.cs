using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018FC RID: 6396
	public class CutSceneUI : DlgBase<CutSceneUI, CutSceneUIBehaviour>
	{
		// Token: 0x17003AA5 RID: 15013
		// (get) Token: 0x06010B08 RID: 68360 RVA: 0x00428DEC File Offset: 0x00426FEC
		public override string fileName
		{
			get
			{
				return "Common/CutSceneUI";
			}
		}

		// Token: 0x17003AA6 RID: 15014
		// (get) Token: 0x06010B09 RID: 68361 RVA: 0x00428E04 File Offset: 0x00427004
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003AA7 RID: 15015
		// (get) Token: 0x06010B0A RID: 68362 RVA: 0x00428E18 File Offset: 0x00427018
		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AA8 RID: 15016
		// (get) Token: 0x06010B0B RID: 68363 RVA: 0x00428E2C File Offset: 0x0042702C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010B0C RID: 68364 RVA: 0x00428E3F File Offset: 0x0042703F
		protected override void Init()
		{
			base.uiBehaviour.m_BG.SetVisible(true);
			base.uiBehaviour.m_Text.SetText("");
		}

		// Token: 0x06010B0D RID: 68365 RVA: 0x00428E6A File Offset: 0x0042706A
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Skip.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnSkipClick));
			base.uiBehaviour.m_Overlay.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOverlayClick));
		}

		// Token: 0x06010B0E RID: 68366 RVA: 0x00428EA8 File Offset: 0x004270A8
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Overlay.gameObject.SetActive(true);
			base.uiBehaviour.m_Skip.gameObject.SetActive(false);
			base.uiBehaviour.m_IntroTween.gameObject.SetActive(false);
		}

		// Token: 0x06010B0F RID: 68367 RVA: 0x00428F02 File Offset: 0x00427102
		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_Text.SetText("");
		}

		// Token: 0x06010B10 RID: 68368 RVA: 0x00428F24 File Offset: 0x00427124
		protected void OnSkipClick(IXUILabel uiSprite)
		{
			bool isPlaying = XSingleton<XCutScene>.singleton.IsPlaying;
			if (isPlaying)
			{
				XSingleton<XCutScene>.singleton.Stop(false);
			}
		}

		// Token: 0x06010B11 RID: 68369 RVA: 0x00428F4C File Offset: 0x0042714C
		protected void OnOverlayClick(IXUISprite go)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				base.uiBehaviour.m_Overlay.gameObject.SetActive(false);
				base.uiBehaviour.m_Skip.gameObject.SetActive(true);
			}
		}

		// Token: 0x06010B12 RID: 68370 RVA: 0x00428F98 File Offset: 0x00427198
		public void SetText(string text)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			base.uiBehaviour.m_Text.SetText(text);
		}

		// Token: 0x06010B13 RID: 68371 RVA: 0x00428FD0 File Offset: 0x004271D0
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
