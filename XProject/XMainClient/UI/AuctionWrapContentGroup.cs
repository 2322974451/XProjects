using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x0200171F RID: 5919
	internal class AuctionWrapContentGroup
	{
		// Token: 0x170037A6 RID: 14246
		// (get) Token: 0x0600F482 RID: 62594 RVA: 0x0036EF08 File Offset: 0x0036D108
		public int rowLines
		{
			get
			{
				return this.m_itemWrapContent.widthDimension;
			}
		}

		// Token: 0x170037A7 RID: 14247
		// (get) Token: 0x0600F483 RID: 62595 RVA: 0x0036EF28 File Offset: 0x0036D128
		public int maxCount
		{
			get
			{
				return this.m_itemWrapContent.maxItemCount;
			}
		}

		// Token: 0x0600F484 RID: 62596 RVA: 0x0036EF48 File Offset: 0x0036D148
		public void SetAuctionWrapContentTemp(Transform temp, WrapItemUpdateEventHandler handler)
		{
			this.m_curTransform = temp;
			this.m_itemScrollView = (temp.gameObject.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_itemWrapContent = (temp.transform.FindChild("Table").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_itemWrapContent.RegisterItemUpdateEventHandler(handler);
		}

		// Token: 0x170037A8 RID: 14248
		// (get) Token: 0x0600F485 RID: 62597 RVA: 0x0036EFAC File Offset: 0x0036D1AC
		public bool Active
		{
			get
			{
				return this.m_active;
			}
		}

		// Token: 0x0600F486 RID: 62598 RVA: 0x0036EFC4 File Offset: 0x0036D1C4
		public void SetWrapContentSize(int listSize)
		{
			listSize = ((listSize % 2 == 1) ? (listSize + 1) : listSize);
			this.m_itemWrapContent.SetContentCount(listSize, false);
			this.m_itemScrollView.ResetPosition();
		}

		// Token: 0x0600F487 RID: 62599 RVA: 0x0036EFEF File Offset: 0x0036D1EF
		public void SetVisible(bool active)
		{
			this.m_active = active;
			this.m_curTransform.gameObject.SetActive(active);
		}

		// Token: 0x04006962 RID: 26978
		private IXUIScrollView m_itemScrollView;

		// Token: 0x04006963 RID: 26979
		private IXUIWrapContent m_itemWrapContent;

		// Token: 0x04006964 RID: 26980
		private Transform m_curTransform;

		// Token: 0x04006965 RID: 26981
		private bool m_active = false;
	}
}
