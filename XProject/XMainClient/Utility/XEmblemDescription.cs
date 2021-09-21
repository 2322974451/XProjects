using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016BE RID: 5822
	internal class XEmblemDescription : IXItemDescription
	{
		// Token: 0x17003721 RID: 14113
		// (get) Token: 0x0600F057 RID: 61527 RVA: 0x0034CF9C File Offset: 0x0034B19C
		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.emblemItemDrawer;
			}
		}

		// Token: 0x17003722 RID: 14114
		// (get) Token: 0x0600F058 RID: 61528 RVA: 0x0034CFB8 File Offset: 0x0034B1B8
		public XBodyBag BodyBag
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag;
			}
		}

		// Token: 0x17003723 RID: 14115
		// (get) Token: 0x0600F059 RID: 61529 RVA: 0x0034CFE0 File Offset: 0x0034B1E0
		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton;
			}
		}
	}
}
