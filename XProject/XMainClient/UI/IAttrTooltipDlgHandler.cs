using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal interface IAttrTooltipDlgHandler
	{

		AttrTooltipDlg tooltipDlg { get; set; }

		void Init(AttrTooltipDlg parent);

		void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, XItem instanceData = null, XItem compareData = null);

		void SetupOtherFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain);

		void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain);

		bool OnButton2Clicked(IXUIButton button);

		bool OnButton3Clicked(IXUIButton button);

		bool OnButton1Clicked(IXUIButton button);

		void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain);

		bool HideToolTip(bool forceHide = false);

		int _GetPPT(XItem item, bool bMain, ref string valueText);

		string _PPTTitle { get; }
	}
}
