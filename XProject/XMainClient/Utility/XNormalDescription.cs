using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016C2 RID: 5826
	internal class XNormalDescription : IXItemDescription
	{
		// Token: 0x1700372D RID: 14125
		// (get) Token: 0x0600F067 RID: 61543 RVA: 0x0034D0D0 File Offset: 0x0034B2D0
		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer;
			}
		}

		// Token: 0x1700372E RID: 14126
		// (get) Token: 0x0600F068 RID: 61544 RVA: 0x0034D0EC File Offset: 0x0034B2EC
		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton;
			}
		}

		// Token: 0x1700372F RID: 14127
		// (get) Token: 0x0600F069 RID: 61545 RVA: 0x0034D104 File Offset: 0x0034B304
		public XBodyBag BodyBag
		{
			get
			{
				return null;
			}
		}
	}
}
