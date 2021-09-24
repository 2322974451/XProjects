using System;

namespace XMainClient
{

	internal class TooltipButtonOperateFashionPutOnSuit : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUTSUIT");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			bool flag = !specificDocument.ValidPart(item.itemID) || specificDocument.GetFashionSuit(item.itemID) == 0;
			return !flag && specificDocument.ShowSuitAllButton(item.uid);
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			ClientFashionData clientFashionData = specificDocument.FindFashion(this.mainItemUID);
			bool flag = clientFashionData != null;
			if (flag)
			{
				specificDocument.EquipFashionSuit(true, (int)clientFashionData.itemID);
			}
		}
	}
}
