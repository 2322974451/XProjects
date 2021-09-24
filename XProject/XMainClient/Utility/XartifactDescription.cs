using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{

	internal class XartifactDescription : IXItemDescription
	{

		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer;
			}
		}

		public XBodyBag BodyBag
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag;
			}
		}

		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton;
			}
		}
	}
}
