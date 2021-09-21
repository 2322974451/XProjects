using System;
using XMainClient.UI;

namespace XMainClient.Utility
{
	// Token: 0x020016BC RID: 5820
	internal interface IXItemDescription
	{
		// Token: 0x1700371B RID: 14107
		// (get) Token: 0x0600F050 RID: 61520
		XItemDrawer ItemDrawer { get; }

		// Token: 0x1700371C RID: 14108
		// (get) Token: 0x0600F051 RID: 61521
		XBodyBag BodyBag { get; }

		// Token: 0x1700371D RID: 14109
		// (get) Token: 0x0600F052 RID: 61522
		ITooltipDlg TooltipDlg { get; }
	}
}
