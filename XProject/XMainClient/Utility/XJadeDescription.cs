using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016BF RID: 5823
	internal class XJadeDescription : IXItemDescription
	{
		// Token: 0x17003724 RID: 14116
		// (get) Token: 0x0600F05B RID: 61531 RVA: 0x0034CFF8 File Offset: 0x0034B1F8
		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer;
			}
		}

		// Token: 0x17003725 RID: 14117
		// (get) Token: 0x0600F05C RID: 61532 RVA: 0x0034D014 File Offset: 0x0034B214
		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton;
			}
		}

		// Token: 0x17003726 RID: 14118
		// (get) Token: 0x0600F05D RID: 61533 RVA: 0x0034D02C File Offset: 0x0034B22C
		public XBodyBag BodyBag
		{
			get
			{
				return null;
			}
		}
	}
}
