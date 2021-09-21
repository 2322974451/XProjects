using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000D0F RID: 3343
	internal class XLoginTipView : DlgBase<XLoginTipView, XLoginTipBehaviour>
	{
		// Token: 0x170032DC RID: 13020
		// (get) Token: 0x0600BAA2 RID: 47778 RVA: 0x002627D4 File Offset: 0x002609D4
		public override string fileName
		{
			get
			{
				return "GameSystem/LoginTip";
			}
		}

		// Token: 0x170032DD RID: 13021
		// (get) Token: 0x0600BAA3 RID: 47779 RVA: 0x002627EC File Offset: 0x002609EC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170032DE RID: 13022
		// (get) Token: 0x0600BAA4 RID: 47780 RVA: 0x00262800 File Offset: 0x00260A00
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600BAA5 RID: 47781 RVA: 0x00262814 File Offset: 0x00260A14
		public void ShowTips(string str)
		{
			DlgBase<XLoginTipView, XLoginTipBehaviour>.singleton.SetVisible(true, true);
			base.uiBehaviour.m_TipTween.gameObject.SetActive(true);
			base.uiBehaviour.m_TipTween.ResetTween(true);
			base.uiBehaviour.m_TipLabel.SetText(str);
			base.uiBehaviour.m_TipTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnWelcomeTweenFinish));
			base.uiBehaviour.m_TipTween.PlayTween(true, -1f);
		}

		// Token: 0x0600BAA6 RID: 47782 RVA: 0x0026289E File Offset: 0x00260A9E
		public void StopTips()
		{
			DlgBase<XLoginTipView, XLoginTipBehaviour>.singleton.SetVisible(false, true);
		}

		// Token: 0x0600BAA7 RID: 47783 RVA: 0x002628B0 File Offset: 0x00260AB0
		public void OnWelcomeTweenFinish(IXUITweenTool iPlayTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_TipTween.PlayTween(false, -1f);
			}
		}
	}
}
