using System;

namespace XMainClient
{

	internal class TooltipButtonOperateFashionTakeOff : TooltipButtonOperateBase
	{

		public override bool IsButtonVisible(XItem item)
		{
			return true;
		}

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFF");
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
			bool flag = clientFashionData != null;
			if (flag)
			{
				specificDocument.EquipFashion(false, this.mainItemUID, (int)clientFashionData.itemID);
			}
		}
	}
}
