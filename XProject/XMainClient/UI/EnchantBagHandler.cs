using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EnchantBagHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/EnchantListPanel";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnBagWrapContentUpdated));
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			this.m_BtnObtain.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnObtainClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._doc._EnchantBagHandler = null;
			base.OnUnload();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this._doc.GetEnchantItems();
			this.m_WrapContent.SetContentCount(this._doc.ItemList.Count, false);
			this.m_Empty.SetActive(this._doc.ItemList.Count == 0);
			this.m_ScrollView.ResetPosition();
		}

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

		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

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

		private bool OnObtainClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(240, null);
			return true;
		}

		private XEnchantDocument _doc = null;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ScrollView;

		private IXUISprite m_Close;

		private IXUIButton m_BtnObtain;

		private GameObject m_Empty;
	}
}
