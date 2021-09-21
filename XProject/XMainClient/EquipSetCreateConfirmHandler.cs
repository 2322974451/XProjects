using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CD8 RID: 3288
	internal class EquipSetCreateConfirmHandler : DlgHandlerBase
	{
		// Token: 0x0600B866 RID: 47206 RVA: 0x00251DA0 File Offset: 0x0024FFA0
		protected override void Init()
		{
			base.Init();
			this.mDoc = XEquipCreateDocument.Doc;
			Transform transform = base.PanelObject.transform.Find("OK");
			this.mBtnOK = (transform.GetComponent("XUIButton") as IXUIButton);
			transform = base.PanelObject.transform.Find("Cancel");
			this.mBtnCancel = (transform.GetComponent("XUIButton") as IXUIButton);
			transform = base.PanelObject.transform.Find("Level");
			this.mLbLevel = (transform.GetComponent("XUILabel") as IXUILabel);
			this.mItemView = new EquipSetItemBaseView();
			this.mItemView.FindFrom(base.PanelObject.transform);
		}

		// Token: 0x0600B867 RID: 47207 RVA: 0x00251E66 File Offset: 0x00250066
		public override void RegisterEvent()
		{
			base.Init();
			this.mBtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonOK));
			this.mBtnCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonCancel));
		}

		// Token: 0x0600B868 RID: 47208 RVA: 0x00251EA0 File Offset: 0x002500A0
		public void SetEquipInfo(int _dataID)
		{
			ItemComposeTable.RowData itemConposeDataByID = XEquipCreateDocument.GetItemConposeDataByID(_dataID);
			bool flag = itemConposeDataByID == null;
			if (!flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(itemConposeDataByID.ItemID);
				bool flag2 = itemConf == null;
				if (!flag2)
				{
					this.mLbLevel.SetText(itemConf.ReqLevel.ToString());
					bool isBind = this.mDoc.IsBind;
					bool flag3 = itemConf.ItemType == 1 || itemConf.ItemType == 31;
					if (flag3)
					{
						isBind = itemConposeDataByID.IsBind;
					}
					bool flag4 = !itemConf.CanTrade;
					if (flag4)
					{
						isBind = true;
					}
					bool flag5 = base.IsVisible() && this.mItemView != null;
					if (flag5)
					{
						EquipSetItemBaseView.stEquipInfoParam param;
						param.isShowTooltip = false;
						param.playerProf = 0;
						this.mItemView.SetItemInfo(itemConf, param, isBind);
					}
					this.mBtnOK.ID = (ulong)((long)_dataID);
				}
			}
		}

		// Token: 0x0600B869 RID: 47209 RVA: 0x00251F80 File Offset: 0x00250180
		private bool OnClickButtonOK(IXUIButton btn)
		{
			base.SetVisible(false);
			this.mDoc.StartCreateEquip((int)btn.ID);
			return true;
		}

		// Token: 0x0600B86A RID: 47210 RVA: 0x00251FB0 File Offset: 0x002501B0
		private bool OnClickButtonCancel(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600B86B RID: 47211 RVA: 0x00251FCB File Offset: 0x002501CB
		public override void OnUnload()
		{
			this.mDoc = null;
			base.OnUnload();
		}

		// Token: 0x040048F6 RID: 18678
		private IXUIButton mBtnCancel;

		// Token: 0x040048F7 RID: 18679
		private IXUIButton mBtnOK;

		// Token: 0x040048F8 RID: 18680
		private IXUILabel mLbLevel;

		// Token: 0x040048F9 RID: 18681
		private EquipSetItemBaseView mItemView;

		// Token: 0x040048FA RID: 18682
		private XEquipCreateDocument mDoc;
	}
}
