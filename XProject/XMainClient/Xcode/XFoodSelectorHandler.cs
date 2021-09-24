using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFoodSelectorHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnOpenBag.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOpenClicked));
		}

		public override void OnUnload()
		{
			this._PetDoc = null;
			base.OnUnload();
		}

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

		private List<XItem> _GetFood()
		{
			return null;
		}

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

		public void UpdateContent()
		{
			this.m_BagWindow.UpdateBag();
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			this.ShowBag(false);
		}

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

		private void _OnFeedClicked(IXUISprite iSp)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.ReqFeed((int)iSp.ID);
		}

		private XPetDocument _PetDoc;

		private XBagWindow m_BagWindow;

		private IXUIButton m_BtnOpenBag;

		private Transform m_NoFeed;
	}
}
