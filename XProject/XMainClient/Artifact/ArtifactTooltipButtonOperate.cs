using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactTooltipButtonOperate : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUTON");
		}

		public override bool HasRedPoint(XItem item)
		{
			ArtifactBagDocument doc = ArtifactBagDocument.Doc;
			EquipCompare mix = doc.IsEquipMorePowerful(item.uid);
			EquipCompare final = ArtifactBagDocument.GetFinal(mix);
			return final == EquipCompare.EC_MORE_POWERFUL;
		}

		public override bool IsButtonVisible(XItem item)
		{
			bool flag = XSingleton<TooltipParam>.singleton.bShowTakeOutBtn || XSingleton<TooltipParam>.singleton.bShowPutInBtn;
			return !flag;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(mainUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 0U);
			}
		}
	}
}
