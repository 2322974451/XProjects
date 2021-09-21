using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200180A RID: 6154
	internal class FashionStotageDisplayHandle : DlgHandlerBase
	{
		// Token: 0x0600FF1E RID: 65310 RVA: 0x003C1F38 File Offset: 0x003C0138
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this.m_fashionBagView = (base.transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_fashionWrapContent = (base.FindInChild("XUIWrapContent", "WrapContent") as IXUIWrapContent);
			this.m_fashionWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.ItemWrapContentUpdate));
		}

		// Token: 0x0600FF1F RID: 65311 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600FF20 RID: 65312 RVA: 0x003C1FAC File Offset: 0x003C01AC
		private void ItemWrapContentUpdate(Transform t, int index)
		{
			uint num = (this.m_Select != null && index >= 0 && index < this.m_Select.GetItems().Count) ? this.m_Select.GetItems()[index] : 0U;
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = t.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.gameObject, (int)num, 0, false);
			ixuisprite.ID = (ulong)num;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ItemClick));
			ixuisprite2.SetAlpha(this.m_doc.FashionInBody((int)num) ? 1f : 0f);
		}

		// Token: 0x0600FF21 RID: 65313 RVA: 0x003C2070 File Offset: 0x003C0270
		private void ItemClick(IXUISprite iconSprite)
		{
			bool flag = iconSprite.ID == 0UL;
			if (!flag)
			{
				int itemID = (int)iconSprite.ID;
				XItem item = XBagDocument.MakeXItem(itemID, true);
				XSingleton<UiUtility>.singleton.ShowOutLookDialog(item, iconSprite, 0U);
			}
		}

		// Token: 0x0600FF22 RID: 65314 RVA: 0x003C20AC File Offset: 0x003C02AC
		public void SetFashionStorageSelect(IFashionStorageSelect select = null)
		{
			this.m_Select = select;
			int num = (this.m_Select == null) ? 0 : this.m_Select.GetItems().Count;
			int num2 = this.m_fashionWrapContent.widthDimension * this.m_fashionWrapContent.heightDimensionMax;
			bool flag = num > this.m_fashionWrapContent.widthDimension * this.m_fashionWrapContent.heightDimensionMax;
			if (flag)
			{
				bool flag2 = num % this.m_fashionWrapContent.widthDimension > 0;
				if (flag2)
				{
					num = (num / this.m_fashionWrapContent.widthDimension + 1) * this.m_fashionWrapContent.widthDimension;
				}
			}
			else
			{
				num = num2;
			}
			this.m_fashionWrapContent.SetContentCount(num, false);
			this.m_fashionBagView.ResetPosition();
		}

		// Token: 0x040070C7 RID: 28871
		private IXUIScrollView m_fashionBagView;

		// Token: 0x040070C8 RID: 28872
		private IXUIWrapContent m_fashionWrapContent;

		// Token: 0x040070C9 RID: 28873
		private IFashionStorageSelect m_Select;

		// Token: 0x040070CA RID: 28874
		private XFashionStorageDocument m_doc;
	}
}
