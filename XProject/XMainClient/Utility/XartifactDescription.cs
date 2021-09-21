using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016C3 RID: 5827
	internal class XartifactDescription : IXItemDescription
	{
		// Token: 0x17003730 RID: 14128
		// (get) Token: 0x0600F06B RID: 61547 RVA: 0x0034D118 File Offset: 0x0034B318
		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer;
			}
		}

		// Token: 0x17003731 RID: 14129
		// (get) Token: 0x0600F06C RID: 61548 RVA: 0x0034D134 File Offset: 0x0034B334
		public XBodyBag BodyBag
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag;
			}
		}

		// Token: 0x17003732 RID: 14130
		// (get) Token: 0x0600F06D RID: 61549 RVA: 0x0034D15C File Offset: 0x0034B35C
		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton;
			}
		}
	}
}
