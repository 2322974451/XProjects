using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017BC RID: 6076
	internal class EnchantBagHandler : DlgHandlerBase
	{
		// Token: 0x17003886 RID: 14470
		// (get) Token: 0x0600FB94 RID: 64404 RVA: 0x003A7168 File Offset: 0x003A5368
		protected override string FileName
		{
			get
			{
				return "ItemNew/EnchantListPanel";
			}
		}

		// Token: 0x0600FB95 RID: 64405 RVA: 0x003A7180 File Offset: 0x003A5380
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			this._doc._EnchantBagHandler = this;
			this.m_WrapContent = (base.PanelObject.transform.Find("BagPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ScrollView = (base.PanelObject.transform.Find("BagPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnObtain = (base.PanelObject.transform.Find("Empty/BtnObtain").GetComponent("XUIButton") as IXUIButton);
			this.m_Empty = base.PanelObject.transform.Find("Empty").gameObject;
		}

		// Token: 0x0600FB96 RID: 64406 RVA: 0x003A727C File Offset: 0x003A547C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnBagWrapContentUpdated));
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			this.m_BtnObtain.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnObtainClicked));
		}

		// Token: 0x0600FB97 RID: 64407 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600FB98 RID: 64408 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FB99 RID: 64409 RVA: 0x003A72D9 File Offset: 0x003A54D9
		public override void OnUnload()
		{
			this._doc._EnchantBagHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600FB9A RID: 64410 RVA: 0x0035654D File Offset: 0x0035474D
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		// Token: 0x0600FB9B RID: 64411 RVA: 0x003A72F0 File Offset: 0x003A54F0
		public override void RefreshData()
		{
			base.RefreshData();
			this._doc.GetEnchantItems();
			this.m_WrapContent.SetContentCount(this._doc.ItemList.Count, false);
			this.m_Empty.SetActive(this._doc.ItemList.Count == 0);
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600FB9C RID: 64412 RVA: 0x003A735C File Offset: 0x003A555C
		private void _OnBagWrapContentUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.ItemList.Count;
			if (!flag)
			{
				IXUILabel ixuilabel = t.Find("AttrName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("AttrValue").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject = t.Find("ItemTpl").gameObject;
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(gameObject, this._doc.ItemList[index]);
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
			}
		}

		// Token: 0x0600FB9D RID: 64413 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600FB9E RID: 64414 RVA: 0x003A7424 File Offset: 0x003A5624
		private void _OnItemClicked(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			bool flag = num < 0 || num >= this._doc.ItemList.Count;
			if (!flag)
			{
				XItem xitem = this._doc.ItemList[num];
				EnchantEquip.RowData enchantEquipData = this._doc.GetEnchantEquipData(xitem.itemID);
				EnchantCheckResult enchantCheckResult = this._doc.CanEnchant(enchantEquipData);
				bool flag2 = enchantCheckResult == EnchantCheckResult.ECR_OK;
				if (flag2)
				{
					this._doc.SelectEnchantItem(xitem.itemID);
				}
				else
				{
					bool flag3 = xitem.itemConf != null;
					if (flag3)
					{
						EnchantCheckResult enchantCheckResult2 = enchantCheckResult;
						if (enchantCheckResult2 != EnchantCheckResult.ECR_ITEM_TOO_LOW)
						{
							if (enchantCheckResult2 == EnchantCheckResult.ECR_ITEM_TOO_HIGH)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EnchantIntervalRequired", new object[]
								{
									xitem.itemConf.ReqLevel,
									XEnchantDocument.EnchantNeedLevel[(int)enchantEquipData.EnchantLevel]
								}), "fece00");
							}
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EnchantMaxLevelRequired", new object[]
							{
								xitem.itemConf.ReqLevel,
								xitem.itemConf.ReqLevel
							}), "fece00");
						}
					}
				}
			}
		}

		// Token: 0x0600FB9F RID: 64415 RVA: 0x003A7574 File Offset: 0x003A5774
		private bool OnObtainClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(240, null);
			return true;
		}

		// Token: 0x04006E6E RID: 28270
		private XEnchantDocument _doc = null;

		// Token: 0x04006E6F RID: 28271
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04006E70 RID: 28272
		private IXUIScrollView m_ScrollView;

		// Token: 0x04006E71 RID: 28273
		private IXUISprite m_Close;

		// Token: 0x04006E72 RID: 28274
		private IXUIButton m_BtnObtain;

		// Token: 0x04006E73 RID: 28275
		private GameObject m_Empty;
	}
}
