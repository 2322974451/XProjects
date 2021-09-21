using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000D0E RID: 3342
	internal class XLoginTipBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600BAA0 RID: 47776 RVA: 0x0026277C File Offset: 0x0026097C
		private void Awake()
		{
			this.m_TipTween = (base.transform.Find("Bg/Tip").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_TipLabel = (base.transform.Find("Bg/Tip/Text").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04004B0B RID: 19211
		public IXUITweenTool m_TipTween;

		// Token: 0x04004B0C RID: 19212
		public IXUILabel m_TipLabel;
	}
}
