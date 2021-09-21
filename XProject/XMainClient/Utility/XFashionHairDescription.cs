using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016C1 RID: 5825
	internal class XFashionHairDescription : IXItemDescription
	{
		// Token: 0x1700372A RID: 14122
		// (get) Token: 0x0600F063 RID: 61539 RVA: 0x0034D088 File Offset: 0x0034B288
		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer;
			}
		}

		// Token: 0x1700372B RID: 14123
		// (get) Token: 0x0600F064 RID: 61540 RVA: 0x0034D0A4 File Offset: 0x0034B2A4
		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton;
			}
		}

		// Token: 0x1700372C RID: 14124
		// (get) Token: 0x0600F065 RID: 61541 RVA: 0x0034D0BC File Offset: 0x0034B2BC
		public XBodyBag BodyBag
		{
			get
			{
				return null;
			}
		}
	}
}
