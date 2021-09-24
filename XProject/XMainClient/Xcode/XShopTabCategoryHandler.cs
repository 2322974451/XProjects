using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShopTabCategoryHandler : XNormalShopView
	{

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			this.UpdateTabs();
			this.SetDefaultTabCheck();
			base.OnShow();
		}

		private void SetDefaultTabCheck()
		{
			int shopViewDefaultTab = XNormalShopDocument.ShopDoc.GetShopViewDefaultTab();
			bool flag = this._tabCheckList.Count > 0;
			if (flag)
			{
				bool flag2 = shopViewDefaultTab > 0;
				if (flag2)
				{
					for (int i = 0; i < this._tabCheckList.Count; i++)
					{
						bool flag3 = (int)this._tabCheckList[i].ID == shopViewDefaultTab;
						if (flag3)
						{
							bool bChecked = this._tabCheckList[i].bChecked;
							if (bChecked)
							{
								this._curTabId = (int)this._tabCheckList[0].ID;
							}
							else
							{
								this._tabCheckList[i].bChecked = true;
							}
							break;
						}
					}
				}
				else
				{
					bool bChecked2 = this._tabCheckList[0].bChecked;
					if (bChecked2)
					{
						this._curTabId = (int)this._tabCheckList[0].ID;
					}
					else
					{
						this._tabCheckList[0].bChecked = true;
					}
				}
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._tabCheckList.Clear();
			this._tabs.Clear();
			this._tabItemPool.ReturnAll(false);
			base.OnUnload();
		}

		private void UpdateTabs()
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			this._tabs = specificDocument.GetTabListOfShop(this.m_SysShop);
			this._tabs.Sort();
			this._tabCheckList.Clear();
			this._tabItemPool.ReturnAll(false);
			for (int i = 0; i < this._tabs.Count; i++)
			{
				GameObject item = this._tabItemPool.FetchGameObject(false);
				this.InitTabItem(item, i);
			}
		}

		private void InitTabItem(GameObject item, int tabIndex)
		{
			List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("ShopTabTypeList");
			IXUICheckBox ixuicheckBox = item.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ForceSetFlag(false);
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnItemTypeChecked));
			ixuicheckBox.ID = (ulong)((long)this._tabs[tabIndex]);
			this._tabCheckList.Add(ixuicheckBox);
			item.transform.localPosition = new Vector3(this._tabItemPool.TplPos.x + (float)(this._tabItemPool.TplWidth * tabIndex), this._tabItemPool.TplPos.y, this._tabItemPool.TplPos.z);
			string text = (this._tabs[tabIndex] <= stringList.Count) ? stringList[this._tabs[tabIndex] - 1] : "";
			IXUILabel ixuilabel = item.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(text);
			IXUILabel ixuilabel2 = item.transform.Find("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(text);
		}

		private bool OnItemTypeChecked(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._curTabId = (int)iXUICheckBox.ID;
				this.RefreshTabItems();
				result = true;
			}
			return result;
		}

		private void RefreshTabItems()
		{
			base.RefreshGoodsList();
		}

		private void InitProperties()
		{
			this._tabItemPool.SetupPool(base.PanelObject, base.PanelObject.transform.FindChild("TabItem").gameObject, 4U, false);
		}

		protected override bool CheckGoodsShowing(ShopTable.RowData shopGoods)
		{
			bool flag = base.CheckGoodsShowing(shopGoods);
			return flag && (int)shopGoods.ShopItemType == this._curTabId;
		}

		private XUIPool _tabItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<int> _tabs = new List<int>();

		private List<IXUICheckBox> _tabCheckList = new List<IXUICheckBox>();

		private int _curTabId = -1;
	}
}
