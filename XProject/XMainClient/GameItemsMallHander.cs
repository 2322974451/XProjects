using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CE4 RID: 3300
	internal class GameItemsMallHander : DlgHandlerBase
	{
		// Token: 0x0600B8CD RID: 47309 RVA: 0x00255568 File Offset: 0x00253768
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			this.m_scrollView = (base.PanelObject.transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600B8CE RID: 47310 RVA: 0x002555EF File Offset: 0x002537EF
		protected override void OnHide()
		{
			this._selectItemIndex = -1;
			base.OnHide();
		}

		// Token: 0x0600B8CF RID: 47311 RVA: 0x00255600 File Offset: 0x00253800
		public void Refresh()
		{
			this._selectItemIndex = -1;
			int count = this._doc.mallItemUIList.Count;
			this.m_WrapContent.SetContentCount(count, false);
			bool flag = !this._doc.isBuying;
			if (flag)
			{
				this.m_scrollView.ResetPosition();
				List<CUIIBShop> mallItemUIList = this._doc.mallItemUIList;
				for (int i = 0; i < mallItemUIList.Count; i++)
				{
					CIBShop item = mallItemUIList[i].item1;
					CIBShop item2 = mallItemUIList[i].item2;
					bool flag2 = (ulong)item.row.itemid == (ulong)((long)this._doc.currItemID) || (item2 != null && (ulong)item2.row.itemid == (ulong)((long)this._doc.currItemID));
					if (flag2)
					{
						this._selectItemIndex = i;
						break;
					}
				}
				bool flag3 = this._selectItemIndex >= this.m_WrapContent.heightDimensionMax;
				if (flag3)
				{
					this.m_scrollView.MoveRelative(new Vector3(0f, (float)(this._selectItemIndex + 1 - this.m_WrapContent.heightDimensionMax) * this.m_WrapContent.itemSize.y, 0f));
				}
			}
		}

		// Token: 0x0600B8D0 RID: 47312 RVA: 0x0025574C File Offset: 0x0025394C
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this._doc != null;
			if (flag)
			{
				bool flag2 = index < this._doc.mallItemUIList.Count && index >= 0;
				if (flag2)
				{
					CUIIBShop info = this._doc.mallItemUIList[index];
					this.SetHItem(t, info);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("_doc is nil or index: ", index.ToString(), null, null, null, null);
			}
		}

		// Token: 0x0600B8D1 RID: 47313 RVA: 0x002557C8 File Offset: 0x002539C8
		protected void SetHItem(Transform t, CUIIBShop info)
		{
			Transform t2 = t.Find("item1");
			Transform transform = t.Find("item2");
			this.SetItem(t2, info.item1, -1);
			transform.gameObject.SetActive(info.item2 != null);
			bool flag = info.item2 != null;
			if (flag)
			{
				this.SetItem(transform, info.item2, -1);
			}
		}

		// Token: 0x0600B8D2 RID: 47314 RVA: 0x00255830 File Offset: 0x00253A30
		private void SetItem(Transform t, CIBShop info, int index = -1)
		{
			IXUISprite ixuisprite = t.Find("Have to buy").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = t.Find("redPoint").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite3 = t.Find("diamond").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = t.Find("Price").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite4 = t.Find("Sold out").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite5 = t.Find("New product").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite6 = t.Find("Time limit2").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite7 = t.Find("discount").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite8 = t.Find("pp").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.Find("discount/t").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			int itemid = (int)info.row.itemid;
			uint id = info.row.id;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.gameObject, itemid, 0, false);
			IXUISprite ixuisprite9 = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite10 = t.FindChild("Bind").GetComponent("XUISprite") as IXUISprite;
			ixuisprite9.ID = (ulong)((long)itemid);
			ixuisprite9.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnIconClick));
			ixuisprite10.SetVisible(info.row.bind);
			ixuilabel3.ID = (ulong)((long)itemid);
			ixuilabel3.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnSelectItem));
			ixuisprite8.SetVisible(itemid == this._doc.currItemID);
			ixuisprite4.SetVisible(info.finish);
			ixuisprite5.SetVisible(info.row.newproduct == 1U);
			ixuisprite6.SetVisible(info.sinfo.nlimittime > 0U);
			ixuisprite7.SetVisible(info.row.discount > 0U && info.row.discount < 100U);
			float num = (info.row.discount == 0U) ? 10f : (info.row.discount / 10f);
			ixuilabel2.SetText((num < 1f) ? num.ToString("0.0") : (" " + num.ToString()));
			ixuilabel.SetText((info.row.currencycount * num / 10f).ToString("0"));
			ixuisprite.SetVisible(false);
			ixuisprite2.SetVisible(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType == MallType.VIP && this._doc.currCIBShop.sinfo.nbuycount <= 0U && this._doc.hotGoods.Contains(id));
			string strSprite;
			string strAtlas;
			XBagDocument.GetItemSmallIconAndAtlas((int)DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.item, out strSprite, out strAtlas, 0U);
			ixuisprite3.SetSprite(strSprite, strAtlas, false);
		}

		// Token: 0x0600B8D3 RID: 47315 RVA: 0x00255B94 File Offset: 0x00253D94
		private void OnIconClick(IXUISprite sp)
		{
			int num = (int)sp.ID;
			CIBShop cibshop = this._doc.SearchIBShop(num);
			XItem xitem = XBagDocument.MakeXItem(num, false);
			bool flag = cibshop != null;
			if (flag)
			{
				xitem.bBinding = cibshop.row.bind;
			}
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(xitem, null, sp, false, 0U);
		}

		// Token: 0x0600B8D4 RID: 47316 RVA: 0x00255BE8 File Offset: 0x00253DE8
		private void OnSelectItem(IXUILabel s)
		{
			int itemid = (int)s.ID;
			this.CloseSelectAll();
			Transform parent = s.gameObject.transform.parent;
			IXUISprite ixuisprite = parent.Find("pp").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetVisible(true);
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton._gameBuyCardHander.ResetCurrCnt();
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.Refresh(itemid);
		}

		// Token: 0x0600B8D5 RID: 47317 RVA: 0x00255C58 File Offset: 0x00253E58
		private void CloseSelectAll()
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			this.m_WrapContent.GetActiveList(list);
			for (int i = 0; i < list.Count; i++)
			{
				IXUISprite ixuisprite = list[i].transform.Find("item1/pp").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetVisible(false);
				Transform transform = list[i].transform.Find("item2/pp");
				bool flag = transform != null;
				if (flag)
				{
					IXUISprite ixuisprite2 = transform.GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.SetVisible(false);
				}
			}
			ListPool<GameObject>.Release(list);
		}

		// Token: 0x0400495E RID: 18782
		public IXUIWrapContent m_WrapContent;

		// Token: 0x0400495F RID: 18783
		public IXUIScrollView m_scrollView;

		// Token: 0x04004960 RID: 18784
		private XGameMallDocument _doc = null;

		// Token: 0x04004961 RID: 18785
		private int _selectItemIndex = -1;
	}
}
