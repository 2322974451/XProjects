using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonActivateFashion : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("FASHION_PUT_STORAGE");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

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

		private bool OnActivateFashion(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			specificDocument.ActivateFashion(this.mainItemUID);
			return true;
		}
	}
}
