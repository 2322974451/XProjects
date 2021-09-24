using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XYYMallCategoryHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/YYMallCategory";
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowIllustration();
		}

		protected override void Init()
		{
			this.m_TypeList.Clear();
			this.m_TypeTitle.Clear();
			this.m_Close = (base.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			for (int i = 1; i < XFastEnumIntEqualityComparer<YYMallCategory>.ToInt(YYMallCategory.MAX); i++)
			{
				YYMallCategory yymallCategory = (YYMallCategory)i;
				string s = yymallCategory.ToString();
				Transform item = base.PanelObject.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Bg/ScrollView/Table/", s));
				this.m_TypeTitle.Add(item);
				IXUIList ixuilist = base.PanelObject.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Bg/ScrollView/Table/", s, "/Grid")).GetComponent("XUIList") as IXUIList;
				ixuilist.RegisterRepositionHandle(new OnAfterRepostion(this.OnListRefreshFinished));
				this.m_TypeList.Add(ixuilist);
			}
			Transform transform = base.PanelObject.transform.Find("Bg/ScrollView/ItemTpl");
			this.m_SpritePool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_ScrollView = (base.PanelObject.transform.Find("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Table = (base.PanelObject.transform.Find("Bg/ScrollView/Table").GetComponent("XUITable") as IXUITable);
		}

		private void OnListRefreshFinished()
		{
			this.m_Table.Reposition();
			this.m_ScrollView.ResetPosition();
		}

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnHide()
		{
			this.m_CategoryList.Clear();
			base.OnHide();
		}

		private void ShowIllustration()
		{
			this.m_CategoryList = XNormalShopDocument.ShopDoc.GetShopItemByPlayLevelAndShopType(XSysDefine.XSys_Welfare_YyMall);
			this.m_ScrollView.ResetPosition();
			this.m_SpritePool.FakeReturnAll();
			this.CreateIcon(YYMallCategory.Resource);
			this.CreateIcon(YYMallCategory.Special);
			this.CreateIcon(YYMallCategory.Privilege);
			this.m_SpritePool.ActualReturnAll(true);
		}

		private void CreateIcon(YYMallCategory category)
		{
			int index = XFastEnumIntEqualityComparer<YYMallCategory>.ToInt(category) - 1;
			IXUIList ixuilist = this.m_TypeList[index];
			List<uint> list = this.m_CategoryList[index];
			this.m_TypeTitle[index].gameObject.SetActive(list.Count > 0);
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = this.m_SpritePool.FetchGameObject(false);
				gameObject.transform.parent = ixuilist.gameObject.transform;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)list[i], 1, false);
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)list[i];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
				XSingleton<XGameUI>.singleton.m_uiTool.ChangePanel(gameObject, ixuilist.GetParentUIRect(), ixuilist.GetParentPanel());
			}
			ixuilist.Refresh();
		}

		private void OnClickItemIcon(IXUISprite spr)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)spr.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
		}

		private void SetItemInfo(GameObject obj, uint itemID)
		{
			IXUISprite ixuisprite = obj.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)itemID;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(obj, (int)itemID, 0, false);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		private void SetSpriteInfo(GameObject obj, uint spriteID)
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(obj, (int)spriteID, 0, false);
			IXUISprite ixuisprite = obj.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)spriteID;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSpriteIconClicked));
		}

		private void OnSpriteIconClicked(IXUISprite spr)
		{
			uint spriteID = (uint)spr.ID;
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			DlgBase<XSpriteDetailView, XSpriteDetailBehaviour>.singleton.ShowDetail(spriteID);
		}

		private bool OnCloseClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		private IXUIButton m_Close;

		private XUIPool m_SpritePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIScrollView m_ScrollView;

		private IXUITable m_Table;

		private List<IXUIList> m_TypeList = new List<IXUIList>();

		private List<List<uint>> m_CategoryList = new List<List<uint>>();

		private List<Transform> m_TypeTitle = new List<Transform>();
	}
}
