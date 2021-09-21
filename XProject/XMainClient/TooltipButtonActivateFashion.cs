using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA0 RID: 3232
	internal class TooltipButtonActivateFashion : TooltipButtonOperateBase
	{
		// Token: 0x0600B629 RID: 46633 RVA: 0x00241248 File Offset: 0x0023F448
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("FASHION_PUT_STORAGE");
		}

		// Token: 0x0600B62A RID: 46634 RVA: 0x00241264 File Offset: 0x0023F464
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B62B RID: 46635 RVA: 0x00241278 File Offset: 0x0023F478
		public override bool IsButtonVisible(XItem item)
		{
			bool flag = item.itemConf.TimeLimit == 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
				ClientFashionData clientFashionData = specificDocument.FindFashion(item.uid);
				result = (clientFashionData != null && clientFashionData.timeleft < 0.0);
			}
			return result;
		}

		// Token: 0x0600B62C RID: 46636 RVA: 0x002412D0 File Offset: 0x0023F4D0
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			ClientFashionData clientFashionData = specificDocument.FindFashion(this.mainItemUID);
			bool flag = clientFashionData == null || clientFashionData.timeleft > -1.0;
			if (!flag)
			{
				string @string = XStringDefineProxy.GetString("COMMON_OK");
				string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("FASHION_STORAGE_SURE"), @string, string2, new ButtonClickEventHandler(this.OnActivateFashion), 100);
			}
		}

		// Token: 0x0600B62D RID: 46637 RVA: 0x0024135C File Offset: 0x0023F55C
		private bool OnActivateFashion(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			specificDocument.ActivateFashion(this.mainItemUID);
			return true;
		}
	}
}
