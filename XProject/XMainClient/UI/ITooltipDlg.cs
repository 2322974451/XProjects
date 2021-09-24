using System;
using UILib;

namespace XMainClient.UI
{

	internal interface ITooltipDlg
	{

		IXUISprite ShowToolTip(XItem mainItem, XItem compareItem, bool _bShowButtons, uint prof);

		XItemSelector ItemSelector { get; }

		void SetPosition(IXUISprite clickIcon);
	}
}
