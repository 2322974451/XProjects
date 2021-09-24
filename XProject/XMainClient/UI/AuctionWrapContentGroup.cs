using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class AuctionWrapContentGroup
	{

		public int rowLines
		{
			get
			{
				return this.m_itemWrapContent.widthDimension;
			}
		}

		public int maxCount
		{
			get
			{
				return this.m_itemWrapContent.maxItemCount;
			}
		}

		public void SetAuctionWrapContentTemp(Transform temp, WrapItemUpdateEventHandler handler)
		{
			this.m_curTransform = temp;
			this.m_itemScrollView = (temp.gameObject.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_itemWrapContent = (temp.transform.FindChild("Table").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_itemWrapContent.RegisterItemUpdateEventHandler(handler);
		}

		public bool Active
		{
			get
			{
				return this.m_active;
			}
		}

		public void SetWrapContentSize(int listSize)
		{
			listSize = ((listSize % 2 == 1) ? (listSize + 1) : listSize);
			this.m_itemWrapContent.SetContentCount(listSize, false);
			this.m_itemScrollView.ResetPosition();
		}

		public void SetVisible(bool active)
		{
			this.m_active = active;
			this.m_curTransform.gameObject.SetActive(active);
		}

		private IXUIScrollView m_itemScrollView;

		private IXUIWrapContent m_itemWrapContent;

		private Transform m_curTransform;

		private bool m_active = false;
	}
}
