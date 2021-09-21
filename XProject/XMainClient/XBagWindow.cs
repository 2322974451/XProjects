using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E62 RID: 3682
	internal class XBagWindow
	{
		// Token: 0x0600C529 RID: 50473 RVA: 0x002B5C9C File Offset: 0x002B3E9C
		public XBagWindow(GameObject PanelGo, ItemUpdateHandler updateHandler, GetItemHandler getHandler)
		{
			this.PanelObject = PanelGo;
			this.itemUpdateHandler = updateHandler;
			this.getItemHandler = getHandler;
		}

		// Token: 0x0600C52A RID: 50474 RVA: 0x002B5D04 File Offset: 0x002B3F04
		public void Init()
		{
			Transform transform = this.PanelObject.transform.FindChild("Panel/WrapContent/ItemTpl");
			this.m_ScrollView = (this.PanelObject.transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (this.PanelObject.transform.FindChild("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.COL_COUNT = this.m_WrapContent.widthDimension;
			this.ROW_COUNT = this.m_WrapContent.heightDimensionMax;
		}

		// Token: 0x0600C52B RID: 50475 RVA: 0x002B5DB6 File Offset: 0x002B3FB6
		private void WrapContentItemUpdated(Transform t, int index)
		{
			this.itemUpdateHandler(t, index);
		}

		// Token: 0x0600C52C RID: 50476 RVA: 0x002B5DC7 File Offset: 0x002B3FC7
		public void ChangeData(ItemUpdateHandler updateHandler, GetItemHandler getHandler)
		{
			this.itemUpdateHandler = updateHandler;
			this.getItemHandler = getHandler;
		}

		// Token: 0x0600C52D RID: 50477 RVA: 0x002B5DD8 File Offset: 0x002B3FD8
		public void OnShow()
		{
			this.UpdateBag();
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600C52E RID: 50478 RVA: 0x002B5DEE File Offset: 0x002B3FEE
		public void OnHide()
		{
			this.m_ItemPool.ReturnAll(true);
			this.m_XItemIDList.Clear();
		}

		// Token: 0x0600C52F RID: 50479 RVA: 0x002B5E0C File Offset: 0x002B400C
		protected void _RefreshBag()
		{
			int num = Math.Max(this.m_XItemList.Count, this.COL_COUNT * this.ROW_COUNT);
			this.m_WrapContent.SetContentCount(num, false);
		}

		// Token: 0x0600C530 RID: 50480 RVA: 0x002B5E48 File Offset: 0x002B4048
		public void UpdateBag()
		{
			this.GetItemData(this.getItemHandler());
			this.m_XItemIDList.Clear();
			for (int i = 0; i < this.m_XItemList.Count; i++)
			{
				bool flag = this.m_XItemList[i] != null;
				if (flag)
				{
					this.m_XItemIDList.Add(this.m_XItemList[i].uid);
				}
				else
				{
					this.m_XItemIDList.Add(0UL);
				}
			}
			this._RefreshBag();
		}

		// Token: 0x0600C531 RID: 50481 RVA: 0x002B5ED8 File Offset: 0x002B40D8
		private void GetItemData(List<XItem> lst)
		{
			bool flag = this.m_XItemList != null;
			if (flag)
			{
				this.m_XItemList.Clear();
			}
			else
			{
				this.m_XItemList = new List<XItem>();
			}
			for (int i = 0; i < lst.Count; i++)
			{
				this.m_XItemList.Add(lst[i]);
			}
		}

		// Token: 0x0600C532 RID: 50482 RVA: 0x002B5F36 File Offset: 0x002B4136
		public void RefreshWindow()
		{
			this.m_WrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x0600C533 RID: 50483 RVA: 0x002B5F48 File Offset: 0x002B4148
		public void UpdateItem(XItem item)
		{
			for (int i = 0; i < this.m_XItemList.Count; i++)
			{
				bool flag = this.m_XItemIDList[i] == item.uid;
				if (flag)
				{
					this.m_XItemList[i] = item;
					break;
				}
			}
			this.RefreshWindow();
		}

		// Token: 0x0600C534 RID: 50484 RVA: 0x002B5FA4 File Offset: 0x002B41A4
		public void ReplaceItem(XItem from, XItem to)
		{
			for (int i = 0; i < this.m_XItemList.Count; i++)
			{
				bool flag = this.m_XItemIDList[i] == from.uid;
				if (flag)
				{
					this.m_XItemList[i] = to;
					this.m_XItemIDList[i] = to.uid;
					break;
				}
			}
			this.RefreshWindow();
		}

		// Token: 0x0600C535 RID: 50485 RVA: 0x002B6011 File Offset: 0x002B4211
		public void ResetPosition()
		{
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600C536 RID: 50486 RVA: 0x002B6020 File Offset: 0x002B4220
		public Transform FindChildByName(string name)
		{
			bool flag = this.m_WrapContent != null;
			Transform result;
			if (flag)
			{
				result = this.m_WrapContent.gameObject.transform.Find(name);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x04005628 RID: 22056
		public int COL_COUNT = 6;

		// Token: 0x04005629 RID: 22057
		public int ROW_COUNT = 4;

		// Token: 0x0400562A RID: 22058
		public GameObject PanelObject;

		// Token: 0x0400562B RID: 22059
		private IXUIWrapContent m_WrapContent;

		// Token: 0x0400562C RID: 22060
		private IXUIScrollView m_ScrollView;

		// Token: 0x0400562D RID: 22061
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400562E RID: 22062
		public List<ulong> m_XItemIDList = new List<ulong>();

		// Token: 0x0400562F RID: 22063
		public List<XItem> m_XItemList;

		// Token: 0x04005630 RID: 22064
		private ItemUpdateHandler itemUpdateHandler = null;

		// Token: 0x04005631 RID: 22065
		private GetItemHandler getItemHandler = null;
	}
}
