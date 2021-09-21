using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001805 RID: 6149
	internal class FashionStorageEquipToolTipDlg : FashionStorageTooltipBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>
	{
		// Token: 0x170038EE RID: 14574
		// (get) Token: 0x0600FEF4 RID: 65268 RVA: 0x003C0C84 File Offset: 0x003BEE84
		public override string fileName
		{
			get
			{
				return "GameSystem/FashionStorageEquipToolTipDlg";
			}
		}

		// Token: 0x0600FEF5 RID: 65269 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
		}

		// Token: 0x0600FEF6 RID: 65270 RVA: 0x003C0C9B File Offset: 0x003BEE9B
		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			base._SetupType(goToolTip, data, 2);
		}

		// Token: 0x0600FEF7 RID: 65271 RVA: 0x003C0CD0 File Offset: 0x003BEED0
		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			this._SetupDescription(goToolTip, itemConf);
		}

		// Token: 0x0600FEF8 RID: 65272 RVA: 0x003C0CF3 File Offset: 0x003BEEF3
		protected override void SetupOtherFrame(GameObject goToolTip, ItemList.RowData data)
		{
			this._SetupDescription(goToolTip, data);
		}

		// Token: 0x0600FEF9 RID: 65273 RVA: 0x003C0D00 File Offset: 0x003BEF00
		protected void _SetupDescription(GameObject goToolTip, ItemList.RowData data)
		{
			Transform transform = goToolTip.transform;
			IXUISprite ixuisprite = transform.FindChild("ScrollPanel/Description").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = ixuisprite.gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn((data == null) ? "" : data.ItemDescription));
			ixuisprite.spriteHeight = ixuilabel.spriteHeight + -(int)ixuilabel.gameObject.transform.localPosition.y;
			this.totalFrameHeight += (float)ixuisprite.spriteHeight;
		}
	}
}
