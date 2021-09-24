using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{

	internal class XEmblemDescription : IXItemDescription
	{

		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.emblemItemDrawer;
			}
		}

		public XBodyBag BodyBag
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag;
			}
		}

		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton;
			}
		}
	}
}
