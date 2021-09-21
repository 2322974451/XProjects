using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016C0 RID: 5824
	internal class XFashionDescription : IXItemDescription
	{
		// Token: 0x17003727 RID: 14119
		// (get) Token: 0x0600F05F RID: 61535 RVA: 0x0034D040 File Offset: 0x0034B240
		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer;
			}
		}

		// Token: 0x17003728 RID: 14120
		// (get) Token: 0x0600F060 RID: 61536 RVA: 0x0034D05C File Offset: 0x0034B25C
		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<FashionTooltipDlg, FashionTooltipDlgBehaviour>.singleton;
			}
		}

		// Token: 0x17003729 RID: 14121
		// (get) Token: 0x0600F061 RID: 61537 RVA: 0x0034D074 File Offset: 0x0034B274
		public XBodyBag BodyBag
		{
			get
			{
				return null;
			}
		}
	}
}
