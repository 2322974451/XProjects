using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStorageEquipToolTipDlg : FashionStorageTooltipBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FashionStorageEquipToolTipDlg";
			}
		}

		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
		}

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			base._SetupType(goToolTip, data, 2);
		}

		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			this._SetupDescription(goToolTip, itemConf);
		}

		protected override void SetupOtherFrame(GameObject goToolTip, ItemList.RowData data)
		{
			this._SetupDescription(goToolTip, data);
		}

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
