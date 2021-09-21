using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C49 RID: 3145
	internal class XShopTabCategoryHandler : XNormalShopView
	{
		// Token: 0x0600B265 RID: 45669 RVA: 0x00226B3F File Offset: 0x00224D3F
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600B266 RID: 45670 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600B267 RID: 45671 RVA: 0x00226B50 File Offset: 0x00224D50
		protected override void OnShow()
		{
			this.UpdateTabs();
			this.SetDefaultTabCheck();
			base.OnShow();
		}

		// Token: 0x0600B268 RID: 45672 RVA: 0x00226B68 File Offset: 0x00224D68
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

		// Token: 0x0600B269 RID: 45673 RVA: 0x00226C6D File Offset: 0x00224E6D
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B26A RID: 45674 RVA: 0x00226C77 File Offset: 0x00224E77
		public override void OnUnload()
		{
			this._tabCheckList.Clear();
			this._tabs.Clear();
			this._tabItemPool.ReturnAll(false);
			base.OnUnload();
		}

		// Token: 0x0600B26B RID: 45675 RVA: 0x00226CA8 File Offset: 0x00224EA8
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

		// Token: 0x0600B26C RID: 45676 RVA: 0x00226D2C File Offset: 0x00224F2C
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

		// Token: 0x0600B26D RID: 45677 RVA: 0x00226E78 File Offset: 0x00225078
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

		// Token: 0x0600B26E RID: 45678 RVA: 0x00226EB0 File Offset: 0x002250B0
		private void RefreshTabItems()
		{
			base.RefreshGoodsList();
		}

		// Token: 0x0600B26F RID: 45679 RVA: 0x00226EBA File Offset: 0x002250BA
		private void InitProperties()
		{
			this._tabItemPool.SetupPool(base.PanelObject, base.PanelObject.transform.FindChild("TabItem").gameObject, 4U, false);
		}

		// Token: 0x0600B270 RID: 45680 RVA: 0x00226EEC File Offset: 0x002250EC
		protected override bool CheckGoodsShowing(ShopTable.RowData shopGoods)
		{
			bool flag = base.CheckGoodsShowing(shopGoods);
			return flag && (int)shopGoods.ShopItemType == this._curTabId;
		}

		// Token: 0x040044BE RID: 17598
		private XUIPool _tabItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040044BF RID: 17599
		private List<int> _tabs = new List<int>();

		// Token: 0x040044C0 RID: 17600
		private List<IXUICheckBox> _tabCheckList = new List<IXUICheckBox>();

		// Token: 0x040044C1 RID: 17601
		private int _curTabId = -1;
	}
}
