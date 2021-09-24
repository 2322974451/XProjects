using System;

namespace XMainClient
{

	internal class TooltipButtonOperateFashionPutOn : TooltipButtonOperateBase
	{

		public override bool IsButtonVisible(XItem item)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			return specificDocument.ValidPart(item.itemID);
		}

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUTON");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			ClientFashionData clientFashionData = specificDocument.FindFashion(this.mainItemUID);
			bool flag = clientFashionData == null;
			if (!flag)
			{
				specificDocument.EquipFashion(true, this.mainItemUID, (int)clientFashionData.itemID);
			}
		}
	}
}
