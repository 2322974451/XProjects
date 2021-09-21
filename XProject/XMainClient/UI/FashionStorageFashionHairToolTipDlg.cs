using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001806 RID: 6150
	internal class FashionStorageFashionHairToolTipDlg : FashionStorageTooltipBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>
	{
		// Token: 0x170038EF RID: 14575
		// (get) Token: 0x0600FEFB RID: 65275 RVA: 0x003C0DB8 File Offset: 0x003BEFB8
		public override string fileName
		{
			get
			{
				return "GameSystem/FashionStorageFashionHairToolTipDlg";
			}
		}

		// Token: 0x0600FEFC RID: 65276 RVA: 0x003C0DD0 File Offset: 0x003BEFD0
		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(data.ItemID);
			base._SetTopFrameLabel(goToolTip, 2, XStringDefineProxy.GetString("ToolTipText_Part"), (fashionConf != null) ? XSingleton<UiUtility>.singleton.GetFashionPartName((FashionPosition)fashionConf.EquipPos, true) : string.Empty);
			this.time = (goToolTip.transform.FindChild("TopFrame/Time/Left").GetComponent("XUILabel") as IXUILabel);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(data.ItemID);
			bool flag = itemConf == null || itemConf.TimeLimit == 0U;
			if (flag)
			{
				this.time.SetText(XStringDefineProxy.GetString("FASHION_LIMIT_ALWAYS"));
			}
			else
			{
				this.time.SetText(XStringDefineProxy.GetString("Designation_Tab_Name5"));
			}
		}

		// Token: 0x0600FEFD RID: 65277 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
		}

		// Token: 0x0600FEFE RID: 65278 RVA: 0x003C0EB0 File Offset: 0x003BF0B0
		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			this._SetupDescription(goToolTip, itemConf);
		}

		// Token: 0x0600FEFF RID: 65279 RVA: 0x003C0ED3 File Offset: 0x003BF0D3
		protected override void SetupOtherFrame(GameObject goToolTip, ItemList.RowData data)
		{
			this._SetupDescription(goToolTip, data);
		}

		// Token: 0x0600FF00 RID: 65280 RVA: 0x003C0EE0 File Offset: 0x003BF0E0
		protected void _SetupDescription(GameObject goToolTip, ItemList.RowData data)
		{
			Transform transform = goToolTip.transform;
			IXUISprite ixuisprite = transform.FindChild("ScrollPanel/Description").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = ixuisprite.gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn((data == null) ? "" : data.ItemDescription));
			ixuisprite.spriteHeight = ixuilabel.spriteHeight + -(int)ixuilabel.gameObject.transform.localPosition.y;
			this.totalFrameHeight += (float)ixuisprite.spriteHeight;
		}

		// Token: 0x040070B7 RID: 28855
		private IXUILabel time = null;
	}
}
