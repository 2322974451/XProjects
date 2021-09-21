using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C44 RID: 3140
	internal class ArtifactTooltipButtonOperate : TooltipButtonOperateBase
	{
		// Token: 0x0600B210 RID: 45584 RVA: 0x00224770 File Offset: 0x00222970
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUTON");
		}

		// Token: 0x0600B211 RID: 45585 RVA: 0x0022478C File Offset: 0x0022298C
		public override bool HasRedPoint(XItem item)
		{
			ArtifactBagDocument doc = ArtifactBagDocument.Doc;
			EquipCompare mix = doc.IsEquipMorePowerful(item.uid);
			EquipCompare final = ArtifactBagDocument.GetFinal(mix);
			return final == EquipCompare.EC_MORE_POWERFUL;
		}

		// Token: 0x0600B212 RID: 45586 RVA: 0x002247BC File Offset: 0x002229BC
		public override bool IsButtonVisible(XItem item)
		{
			bool flag = XSingleton<TooltipParam>.singleton.bShowTakeOutBtn || XSingleton<TooltipParam>.singleton.bShowPutInBtn;
			return !flag;
		}

		// Token: 0x0600B213 RID: 45587 RVA: 0x002247F0 File Offset: 0x002229F0
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
