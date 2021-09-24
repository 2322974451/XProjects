using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{

	internal class XNormalDescription : IXItemDescription
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
				return DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton;
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
