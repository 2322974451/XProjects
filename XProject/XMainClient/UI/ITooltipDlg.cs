using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x0200191A RID: 6426
	internal interface ITooltipDlg
	{
		// Token: 0x06010CDC RID: 68828
		IXUISprite ShowToolTip(XItem mainItem, XItem compareItem, bool _bShowButtons, uint prof);

		// Token: 0x17003AE6 RID: 15078
		// (get) Token: 0x06010CDD RID: 68829
		XItemSelector ItemSelector { get; }

		// Token: 0x06010CDE RID: 68830
		void SetPosition(IXUISprite clickIcon);
	}
}
