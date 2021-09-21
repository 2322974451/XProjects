using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C64 RID: 3172
	internal class ItemListHandler : DlgHandlerBase
	{
		// Token: 0x170031BB RID: 12731
		// (get) Token: 0x0600B38B RID: 45963 RVA: 0x0022F35C File Offset: 0x0022D55C
		protected override string FileName
		{
			get
			{
				return "GameSystem/ItemListHandler";
			}
		}

		// Token: 0x0600B38C RID: 45964 RVA: 0x0022F374 File Offset: 0x0022D574
		protected override void Init()
		{
			this.m_TypeList.Clear();
			this.m_TypeTitle.Clear();
			this.m_Close = (base.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			for (int i = 1; i < XFastEnumIntEqualityComparer<ItemQuality>.ToInt(ItemQuality.MAX); i++)
			{
				ItemQuality itemQuality = (ItemQuality)i;
				string s = itemQuality.ToString();
				Transform item = base.PanelObject.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Bg/ScrollView/Table/", s));
				this.m_TypeTitle.Add(item);
				IXUIList ixuilist = base.PanelObject.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Bg/ScrollView/Table/", s, "/Grid")).GetComponent("XUIList") as IXUIList;
				ixuilist.RegisterRepositionHandle(new OnAfterRepostion(this.OnListRefreshFinished));
				this.m_TypeList.Add(ixuilist);
			}
			Transform transform = base.PanelObject.transform.Find("Bg/ScrollView/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_ScrollView = (base.PanelObject.transform.Find("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Table = (base.PanelObject.transform.Find("Bg/ScrollView/Table").GetComponent("XUITable") as IXUITable);
		}

		// Token: 0x0600B38D RID: 45965 RVA: 0x0022F504 File Offset: 0x0022D704
		private void OnListRefreshFinished()
		{
			this.m_Table.Reposition();
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600B38E RID: 45966 RVA: 0x0022F51F File Offset: 0x0022D71F
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B38F RID: 45967 RVA: 0x0022F53C File Offset: 0x0022D73C
		private void ClassifySpritesByQuality(List<uint> itemList)
		{
			this.m_ItemID.Clear();
			List<uint> list = new List<uint>();
			List<uint> list2 = new List<uint>();
			List<uint> list3 = new List<uint>();
			List<uint> list4 = new List<uint>();
			List<uint> list5 = new List<uint>();
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemList[i]);
				switch (itemConf.ItemQuality)
				{
				case 1:
					list5.Add(itemList[i]);
					break;
				case 2:
					list4.Add(itemList[i]);
					break;
				case 3:
					list3.Add(itemList[i]);
					break;
				case 4:
					list2.Add(itemList[i]);
					break;
				case 5:
					list.Add(itemList[i]);
					break;
				}
			}
			this.m_ItemID.Add(list5);
			this.m_ItemID.Add(list4);
			this.m_ItemID.Add(list3);
			this.m_ItemID.Add(list2);
			this.m_ItemID.Add(list);
		}

		// Token: 0x0600B390 RID: 45968 RVA: 0x0022F668 File Offset: 0x0022D868
		public void ShowItemList(List<uint> itemList)
		{
			base.SetVisible(true);
			this.m_ScrollView.ResetPosition();
			this.ClassifySpritesByQuality(itemList);
			this.m_ItemPool.FakeReturnAll();
			this.CreateItemIcon(ItemQuality.L);
			this.CreateItemIcon(ItemQuality.S);
			this.CreateItemIcon(ItemQuality.A);
			this.CreateItemIcon(ItemQuality.B);
			this.CreateItemIcon(ItemQuality.C);
			this.m_ItemPool.ActualReturnAll(true);
		}

		// Token: 0x0600B391 RID: 45969 RVA: 0x0022F6D4 File Offset: 0x0022D8D4
		private void CreateItemIcon(ItemQuality quality)
		{
			int index = XFastEnumIntEqualityComparer<ItemQuality>.ToInt(quality) - 1;
			IXUIList ixuilist = this.m_TypeList[index];
			List<uint> list = this.m_ItemID[index];
			this.m_TypeTitle[index].gameObject.SetActive(list.Count > 0);
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.parent = ixuilist.gameObject.transform;
				this.SetitemInfo(gameObject, list[i]);
				XSingleton<XGameUI>.singleton.m_uiTool.ChangePanel(gameObject, ixuilist.GetParentUIRect(), ixuilist.GetParentPanel());
			}
			ixuilist.Refresh();
		}

		// Token: 0x0600B392 RID: 45970 RVA: 0x0022F79C File Offset: 0x0022D99C
		private void SetitemInfo(GameObject obj, uint itemID)
		{
			IXUISprite ixuisprite = obj.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)itemID;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(obj, (int)itemID, 0, false);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		// Token: 0x0600B393 RID: 45971 RVA: 0x0022F800 File Offset: 0x0022DA00
		private string GetQualityFrame(uint quality)
		{
			return string.Format("kuang_dj_{0}", quality);
		}

		// Token: 0x0600B394 RID: 45972 RVA: 0x0022F824 File Offset: 0x0022DA24
		private bool OnCloseClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04004593 RID: 17811
		private IXUIButton m_Close;

		// Token: 0x04004594 RID: 17812
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004595 RID: 17813
		private IXUIScrollView m_ScrollView;

		// Token: 0x04004596 RID: 17814
		private IXUITable m_Table;

		// Token: 0x04004597 RID: 17815
		private List<IXUIList> m_TypeList = new List<IXUIList>();

		// Token: 0x04004598 RID: 17816
		private List<List<uint>> m_ItemID = new List<List<uint>>();

		// Token: 0x04004599 RID: 17817
		private List<Transform> m_TypeTitle = new List<Transform>();
	}
}
