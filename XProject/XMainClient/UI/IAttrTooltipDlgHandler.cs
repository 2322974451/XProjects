using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001906 RID: 6406
	internal interface IAttrTooltipDlgHandler
	{
		// Token: 0x17003AC3 RID: 15043
		// (get) Token: 0x06010B99 RID: 68505
		// (set) Token: 0x06010B9A RID: 68506
		AttrTooltipDlg tooltipDlg { get; set; }

		// Token: 0x06010B9B RID: 68507
		void Init(AttrTooltipDlg parent);

		// Token: 0x06010B9C RID: 68508
		void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, XItem instanceData = null, XItem compareData = null);

		// Token: 0x06010B9D RID: 68509
		void SetupOtherFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain);

		// Token: 0x06010B9E RID: 68510
		void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain);

		// Token: 0x06010B9F RID: 68511
		bool OnButton2Clicked(IXUIButton button);

		// Token: 0x06010BA0 RID: 68512
		bool OnButton3Clicked(IXUIButton button);

		// Token: 0x06010BA1 RID: 68513
		bool OnButton1Clicked(IXUIButton button);

		// Token: 0x06010BA2 RID: 68514
		void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain);

		// Token: 0x06010BA3 RID: 68515
		bool HideToolTip(bool forceHide = false);

		// Token: 0x06010BA4 RID: 68516
		int _GetPPT(XItem item, bool bMain, ref string valueText);

		// Token: 0x17003AC4 RID: 15044
		// (get) Token: 0x06010BA5 RID: 68517
		string _PPTTitle { get; }
	}
}
