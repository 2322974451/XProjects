using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.Utility
{

	internal class XJadeDescription : IXItemDescription
	{

		public XItemDrawer ItemDrawer
		{
			get
			{
				return XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer;
			}
		}

		public ITooltipDlg TooltipDlg
		{
			get
			{
				return DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton;
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
