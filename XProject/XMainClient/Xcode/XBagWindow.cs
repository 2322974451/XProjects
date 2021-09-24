using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBagWindow
	{

		public XBagWindow(GameObject PanelGo, ItemUpdateHandler updateHandler, GetItemHandler getHandler)
		{
			this.PanelObject = PanelGo;
			this.itemUpdateHandler = updateHandler;
			this.getItemHandler = getHandler;
		}

		public void Init()
		{
			Transform transform = this.PanelObject.transform.FindChild("Panel/WrapContent/ItemTpl");
			this.m_ScrollView = (this.PanelObject.transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (this.PanelObject.transform.FindChild("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.COL_COUNT = this.m_WrapContent.widthDimension;
			this.ROW_COUNT = this.m_WrapContent.heightDimensionMax;
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			this.itemUpdateHandler(t, index);
		}

		public void ChangeData(ItemUpdateHandler updateHandler, GetItemHandler getHandler)
		{
			this.itemUpdateHandler = updateHandler;
			this.getItemHandler = getHandler;
		}

		public void OnShow()
		{
			this.UpdateBag();
			this.m_ScrollView.ResetPosition();
		}

		public void OnHide()
		{
			this.m_ItemPool.ReturnAll(true);
			this.m_XItemIDList.Clear();
		}

		protected void _RefreshBag()
		{
			int num = Math.Max(this.m_XItemList.Count, this.COL_COUNT * this.ROW_COUNT);
			this.m_WrapContent.SetContentCount(num, false);
		}

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

		public void RefreshWindow()
		{
			this.m_WrapContent.RefreshAllVisibleContents();
		}

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

		public void ResetPosition()
		{
			this.m_ScrollView.ResetPosition();
		}

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

		public int COL_COUNT = 6;

		public int ROW_COUNT = 4;

		public GameObject PanelObject;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ScrollView;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public List<ulong> m_XItemIDList = new List<ulong>();

		public List<XItem> m_XItemList;

		private ItemUpdateHandler itemUpdateHandler = null;

		private GetItemHandler getItemHandler = null;
	}
}
