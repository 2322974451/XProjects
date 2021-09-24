using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{

	internal class XEquipDescription : IXItemDescription
	{

		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.equipItemDrawer;
			}
		}

		public XBodyBag BodyBag
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag;
			}
		}

		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton;
			}
		}
	}
}
