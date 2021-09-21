using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016BD RID: 5821
	internal class XEquipDescription : IXItemDescription
	{
		// Token: 0x1700371E RID: 14110
		// (get) Token: 0x0600F053 RID: 61523 RVA: 0x0034CF40 File Offset: 0x0034B140
		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.equipItemDrawer;
			}
		}

		// Token: 0x1700371F RID: 14111
		// (get) Token: 0x0600F054 RID: 61524 RVA: 0x0034CF5C File Offset: 0x0034B15C
		public XBodyBag BodyBag
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag;
			}
		}

		// Token: 0x17003720 RID: 14112
		// (get) Token: 0x0600F055 RID: 61525 RVA: 0x0034CF84 File Offset: 0x0034B184
		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton;
			}
		}
	}
}
