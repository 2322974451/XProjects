using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D05 RID: 3333
	internal class XFoodSelectorHandler : DlgHandlerBase
	{
		// Token: 0x0600BA5D RID: 47709 RVA: 0x0025FB6C File Offset: 0x0025DD6C
		protected override void Init()
		{
			base.Init();
			this._PetDoc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			GameObject gameObject = base.PanelObject.transform.Find("ItemPanel").gameObject;
			this.m_BagWindow = new XBagWindow(gameObject, new ItemUpdateHandler(this._WrapContentItemUpdated), new GetItemHandler(this._PetDoc.GetFood));
			this.m_BagWindow.Init();
			this.m_BtnOpenBag = (base.PanelObject.transform.Find("BtnFeed").GetComponent("XUIButton") as IXUIButton);
			this.m_NoFeed = gameObject.transform.Find("NoFeed");
		}

		// Token: 0x0600BA5E RID: 47710 RVA: 0x0025FC21 File Offset: 0x0025DE21
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnOpenBag.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOpenClicked));
		}

		// Token: 0x0600BA5F RID: 47711 RVA: 0x0025FC43 File Offset: 0x0025DE43
		public override void OnUnload()
		{
			this._PetDoc = null;
			base.OnUnload();
		}

		// Token: 0x0600BA60 RID: 47712 RVA: 0x0025FC54 File Offset: 0x0025DE54
		private void _WrapContentItemUpdated(Transform t, int index)
		{
			t = t.FindChild("Item");
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = t.FindChild("FullDegree").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.FindChild("Exp").GetComponent("XUILabel") as IXUILabel;
			bool flag = this.m_BagWindow.m_XItemList == null || index >= this.m_BagWindow.m_XItemList.Count || index < 0;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				ixuilabel.SetText("");
				ixuilabel2.SetText("");
			}
			else
			{
				XItem xitem = this.m_BagWindow.m_XItemList[index];
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, xitem);
				ItemList.RowData itemConf = XBagDocument.GetItemConf(xitem.itemID);
				IXUILabel ixuilabel3 = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor((int)itemConf.ItemQuality));
				PetFoodTable.RowData petFood = XPetDocument.GetPetFood((uint)xitem.itemID);
				ixuilabel.SetText(XSingleton<UiUtility>.singleton.NumberFormat((ulong)petFood.hungry));
				ixuilabel2.SetText(XSingleton<UiUtility>.singleton.NumberFormat((ulong)petFood.exp));
				ixuisprite.ID = (ulong)((long)xitem.itemID);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnFeedClicked));
			}
			this.m_NoFeed.gameObject.SetActive(this.m_BagWindow.m_XItemList.Count == 0);
		}

		// Token: 0x0600BA61 RID: 47713 RVA: 0x0025FE10 File Offset: 0x0025E010
		private List<XItem> _GetFood()
		{
			return null;
		}

		// Token: 0x0600BA62 RID: 47714 RVA: 0x0025FE24 File Offset: 0x0025E024
		public void ShowBag(bool bShow)
		{
			if (bShow)
			{
				bool flag = this._PetDoc.CanHasRedPoint && this._PetDoc.CurSelectedPet.UID == this._PetDoc.CurFightUID;
				if (flag)
				{
					this._PetDoc.CanHasRedPoint = false;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Horse, true);
					DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshPage(false);
				}
				this.m_BagWindow.PanelObject.SetActive(true);
				this.m_BagWindow.OnShow();
			}
			else
			{
				this.m_BagWindow.PanelObject.SetActive(false);
			}
		}

		// Token: 0x0600BA63 RID: 47715 RVA: 0x0025FEC6 File Offset: 0x0025E0C6
		public void UpdateContent()
		{
			this.m_BagWindow.UpdateBag();
		}

		// Token: 0x0600BA64 RID: 47716 RVA: 0x0025FED5 File Offset: 0x0025E0D5
		private void _OnCloseClicked(IXUISprite iSp)
		{
			this.ShowBag(false);
		}

		// Token: 0x0600BA65 RID: 47717 RVA: 0x0025FEE0 File Offset: 0x0025E0E0
		private bool _OnOpenClicked(IXUIButton btn)
		{
			bool activeSelf = this.m_BagWindow.PanelObject.activeSelf;
			if (activeSelf)
			{
				this.ShowBag(false);
			}
			else
			{
				this.ShowBag(true);
			}
			return true;
		}

		// Token: 0x0600BA66 RID: 47718 RVA: 0x0025FF20 File Offset: 0x0025E120
		private void _OnFeedClicked(IXUISprite iSp)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.ReqFeed((int)iSp.ID);
		}

		// Token: 0x04004A91 RID: 19089
		private XPetDocument _PetDoc;

		// Token: 0x04004A92 RID: 19090
		private XBagWindow m_BagWindow;

		// Token: 0x04004A93 RID: 19091
		private IXUIButton m_BtnOpenBag;

		// Token: 0x04004A94 RID: 19092
		private Transform m_NoFeed;
	}
}
