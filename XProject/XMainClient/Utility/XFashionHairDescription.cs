using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{

	internal class XFashionHairDescription : IXItemDescription
	{

		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer;
			}
		}

		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton;
			}
		}

		public XBodyBag BodyBag
		{
			get
			{
				return null;
			}
		}
	}
}
