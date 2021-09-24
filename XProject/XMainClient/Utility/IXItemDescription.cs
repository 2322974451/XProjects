using System;
using XMainClient.UI;

namespace XMainClient.Utility
{

	internal interface IXItemDescription
	{

		XItemDrawer ItemDrawer { get; }

		XBodyBag BodyBag { get; }

		ITooltipDlg TooltipDlg { get; }
	}
}
