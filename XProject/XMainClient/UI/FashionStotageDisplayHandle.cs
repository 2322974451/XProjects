using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStotageDisplayHandle : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this.m_fashionBagView = (base.transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_fashionWrapContent = (base.FindInChild("XUIWrapContent", "WrapContent") as IXUIWrapContent);
			this.m_fashionWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.ItemWrapContentUpdate));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

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

		private IXUIScrollView m_fashionBagView;

		private IXUIWrapContent m_fashionWrapContent;

		private IFashionStorageSelect m_Select;

		private XFashionStorageDocument m_doc;
	}
}
