using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSetCreateConfirmHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.Init();
			this.mBtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonOK));
			this.mBtnCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonCancel));
		}

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

		private bool OnClickButtonOK(IXUIButton btn)
		{
			base.SetVisible(false);
			this.mDoc.StartCreateEquip((int)btn.ID);
			return true;
		}

		private bool OnClickButtonCancel(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		public override void OnUnload()
		{
			this.mDoc = null;
			base.OnUnload();
		}

		private IXUIButton mBtnCancel;

		private IXUIButton mBtnOK;

		private IXUILabel mLbLevel;

		private EquipSetItemBaseView mItemView;

		private XEquipCreateDocument mDoc;
	}
}
