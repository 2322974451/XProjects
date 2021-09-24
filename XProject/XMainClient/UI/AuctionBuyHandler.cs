using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AuctionBuyHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Auction/AuctionBuyFrame";
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.RefreshFreeRefreshCount();
			bool freeRefresh = this.m_freeRefresh;
			if (freeRefresh)
			{
				this.UpdateNextFreshTime();
			}
		}

		public override void OnUnload()
		{
			this.m_ItemContentGroup = null;
			this.m_AuctionItemGroup = null;
			bool flag = this.m_ShowAuctionList != null;
			if (flag)
			{
				this.m_ShowAuctionList.Clear();
				this.m_ShowAuctionList = null;
			}
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.m_ShowAuctionList = new List<ItemList.RowData>();
			this._Doc = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			this.m_typeListScrollView = (base.PanelObject.transform.Find("TypeList").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.PanelObject.transform.Find("TypeList/Table/LevelOneTpl");
			this.m_levelOnePool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			transform = base.PanelObject.transform.Find("TypeList/Table/LevelTwoTpl");
			this.m_levelTwoPool.SetupPool(transform.parent.gameObject, transform.gameObject, 30U, false);
			this.m_ItemWrap = base.PanelObject.transform.FindChild("Item");
			this.m_GoodWrap = base.PanelObject.transform.FindChild("Good");
			this.m_ailinTransform = base.PanelObject.transform.FindChild("ailin");
			this.m_refreshTime = (base.PanelObject.transform.FindChild("RefreshTime").GetComponent("XUILabel") as IXUILabel);
			this.m_refreshButton = (base.PanelObject.transform.FindChild("RefreshBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_refreshButtonLabel = (base.PanelObject.transform.Find("RefreshBtn/Label").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_ItemLevelCheck = (base.PanelObject.transform.FindChild("Item/TitleTip/ItemLevel").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ItemBlockCheck = (base.PanelObject.transform.FindChild("Item/TitleTip/ItemBlock").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ItemContentGroup = new AuctionWrapContentGroup();
			this.m_ItemContentGroup.SetAuctionWrapContentTemp(base.PanelObject.transform.FindChild("Item/ItemList"), new WrapItemUpdateEventHandler(this.OnItemWrapContentUpdate));
			this.m_AuctionItemGroup = new AuctionWrapContentGroup();
			this.m_AuctionItemGroup.SetAuctionWrapContentTemp(base.PanelObject.transform.FindChild("Good/GoodList"), new WrapItemUpdateEventHandler(this.OnAuctionItemUpdate));
			this.SetupTypeList();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ItemBlockCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnItemFilterCheckClicked));
			this.m_ItemLevelCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnItemFilterCheckClicked));
			this.m_refreshButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTimeFreshClick));
		}

		private void OnItemWrapContentUpdate(Transform t, int index)
		{
			bool flag = t == null;
			if (!flag)
			{
				Transform transform = t.FindChild("DetailTpl");
				bool flag2 = transform == null;
				if (!flag2)
				{
					IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
					bool flag3 = ixuicheckBox != null;
					if (flag3)
					{
						ixuicheckBox.bChecked = false;
					}
					bool flag4 = index < 0 || index >= this.m_ShowAuctionList.Count;
					if (flag4)
					{
						transform.gameObject.SetActive(false);
					}
					else
					{
						transform.gameObject.SetActive(true);
						Transform transform2 = transform.FindChild("ItemTpl");
						IXUILabel ixuilabel = transform.FindChild("Price").GetComponent("XUILabel") as IXUILabel;
						IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
						ItemList.RowData rowData = this.m_ShowAuctionList[index];
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform2.gameObject, rowData, 0, false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(transform2.gameObject, rowData.ItemID);
						uint num = 0U;
						this._Doc.TryGetAuctionBriefCount((uint)rowData.ItemID, out num);
						ixuilabel.SetText(XStringDefineProxy.GetString("AUCTION_PURCHASE_ONLINE", new object[]
						{
							num
						}));
						ixuisprite.ID = (ulong)((long)rowData.ItemID);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCheckBoxOnCheckEventHandler));
					}
				}
			}
		}

		private void OnAuctionItemUpdate(Transform t, int index)
		{
			bool flag = t == null;
			if (!flag)
			{
				Transform transform = t.FindChild("DetailTpl");
				bool flag2 = this.m_showSelectItems == null || transform == null;
				if (!flag2)
				{
					IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
					bool flag3 = ixuicheckBox != null;
					if (flag3)
					{
						ixuicheckBox.bChecked = false;
					}
					bool flag4 = index < 0 || index >= this.m_showSelectItems.Count;
					if (flag4)
					{
						transform.gameObject.SetActive(false);
					}
					else
					{
						transform.gameObject.SetActive(true);
						Transform transform2 = transform.FindChild("ItemTpl");
						IXUISprite ixuisprite = transform.FindChild("ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite;
						IXUILabelSymbol ixuilabelSymbol = transform.FindChild("Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
						IXUISprite ixuisprite2 = transform.GetComponent("XUISprite") as IXUISprite;
						IXUILabel ixuilabel = transform.FindChild("AptValue").GetComponent("XUILabel") as IXUILabel;
						AuctionItem auctionItem = this.m_showSelectItems[index];
						ixuilabel.Alpha = 0f;
						ixuilabel.SetText(string.Empty);
						XSingleton<XItemDrawerMgr>.singleton.DrawItem(transform2.gameObject, auctionItem.itemData);
						ixuisprite.ID = (ulong)((long)index);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
						ixuilabelSymbol.InputText = XLabelSymbolHelper.FormatCostWithIconLast((int)auctionItem.perprice, ItemEnum.DRAGON_COIN);
						ixuisprite2.ID = (ulong)((long)index);
						ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickAuctionDetailHandler));
					}
				}
			}
		}

		private bool OnTimeFreshClick(IXUIButton btn)
		{
			this._Doc.RequestAuctionRefresh();
			return false;
		}

		private void OnCheckBoxOnCheckEventHandler(IXUISprite sprite)
		{
			uint itemid = (uint)sprite.ID;
			this._Doc.RequestAuctionItemData(itemid);
		}

		private void OnClickAuctionDetailHandler(IXUISprite checkBox)
		{
			int num = (int)checkBox.ID;
			bool flag = this.m_showSelectItems.Count > num;
			if (flag)
			{
				DlgBase<AuctionPurchaseView, AuctionPurchaseBehaviour>.singleton.Set(this.m_showSelectItems[num]);
			}
		}

		private void OnItemClicked(IXUISprite sp)
		{
			bool flag = this.m_showSelectItems.Count > (int)sp.ID;
			if (flag)
			{
				XItem itemData = this.m_showSelectItems[(int)sp.ID].itemData;
				bool flag2 = itemData == null;
				if (!flag2)
				{
					bool flag3 = itemData.type == 1U;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowTooltipDialog(itemData.itemConf.ItemID, sp, 0U);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(this.m_showSelectItems[(int)sp.ID].itemData, sp, false, 0U);
					}
				}
			}
		}

		private void ShowSelectItem()
		{
			this.m_ItemWrap.gameObject.SetActive(false);
			this.m_GoodWrap.gameObject.SetActive(true);
			this.m_showSelectItems = this._Doc.GetOverlapItems();
			this.m_AuctionItemGroup.SetWrapContentSize(this.m_showSelectItems.Count);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.RequestAuctionAllItemBrief();
			this.m_freeRefresh = false;
		}

		public override void RefreshData()
		{
			bool showItemData = this._Doc.ShowItemData;
			if (showItemData)
			{
				this.ShowSelectItem();
			}
			else
			{
				this.CalculateAuctionSelect();
				this.SetNextFreeTime();
				this.RefreshFreeRefreshCount();
			}
		}

		private void RefreshFreeRefreshCount()
		{
			bool flag = this._Doc.NextFreeRefreshTime > 0.0;
			if (flag)
			{
				this.m_refreshButtonLabel.InputText = XStringDefineProxy.GetString("AUCTION_FREE", new object[]
				{
					XSingleton<XCommon>.singleton.StringCombine("\n(", XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this._Doc.NextFreeRefreshTime, 5), ")")
				});
			}
			else
			{
				this.m_refreshButtonLabel.InputText = XStringDefineProxy.GetString("AUCTION_FREE", new object[]
				{
					string.Empty
				});
			}
		}

		private void SetNextFreeTime()
		{
			this.m_freeRefreshTime.LeftTime = this._Doc.NextOutoRefreshTime;
			this.UpdateNextFreshTime();
		}

		private void UpdateNextFreshTime()
		{
			this.m_freeRefreshTime.Update();
			bool flag = this.m_freeRefreshTime.LeftTime > 0f;
			if (flag)
			{
				this.m_freeRefresh = true;
				this.m_refreshTime.SetText(XStringDefineProxy.GetString("AUCTION_FRESHTIME_LABEL", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.m_freeRefreshTime.LeftTime, 5)
				}));
			}
			else
			{
				this.m_freeRefresh = false;
				this.m_refreshTime.SetText(string.Empty);
				this._Doc.RequestAuctionAuto();
			}
		}

		private void SetNormalSelect()
		{
			GameObject gameObject;
			bool flag = this.m_typeDictionary.TryGetValue(this.m_curAuctionType, out gameObject);
			if (flag)
			{
				IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag2 = ixuicheckBox == null;
				if (!flag2)
				{
					ixuicheckBox.bChecked = true;
				}
			}
		}

		private void SetupTypeList()
		{
			this.m_levelOnePool.ReturnAll(false);
			this.m_levelTwoPool.ReturnAll(true);
			this.m_typeDictionary.Clear();
			for (int i = 0; i < this._Doc.AuctionTypeList.Table.Length; i++)
			{
				bool flag = this._Doc.AuctionTypeList.Table[i].pretype == 0;
				if (flag)
				{
					GameObject gameObject = this.m_levelOnePool.FetchGameObject(false);
					IXUILabel ixuilabel = gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = gameObject.transform.Find("Switch").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)this._Doc.AuctionTypeList.Table[i].id;
					gameObject.name = this._Doc.AuctionTypeList.Table[i].id.ToString();
					ixuilabel.SetText(this._Doc.AuctionTypeList.Table[i].name);
					ixuilabel2.SetText(this._Doc.AuctionTypeList.Table[i].name);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeCheckBoxClicked));
					ixuisprite.SetAlpha(0f);
					bool flag2 = !this.m_typeDictionary.ContainsKey(this._Doc.AuctionTypeList.Table[i].id);
					if (flag2)
					{
						this.m_typeDictionary.Add(this._Doc.AuctionTypeList.Table[i].id, gameObject);
					}
				}
			}
			int j = 0;
			while (j < this._Doc.AuctionTypeList.Table.Length)
			{
				bool flag3 = this._Doc.AuctionTypeList.Table[j].pretype != 0;
				if (flag3)
				{
					bool flag4 = !this.m_typeDictionary.ContainsKey(this._Doc.AuctionTypeList.Table[j].pretype);
					if (!flag4)
					{
						GameObject gameObject2 = this.m_levelTwoPool.FetchGameObject(false);
						IXUILabel ixuilabel3 = gameObject2.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel4 = gameObject2.transform.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel;
						IXUISprite ixuisprite3 = gameObject2.GetComponent("XUISprite") as IXUISprite;
						ixuisprite3.ID = (ulong)this._Doc.AuctionTypeList.Table[j].id;
						gameObject2.name = this._Doc.AuctionTypeList.Table[j].id.ToString();
						ixuilabel3.SetText(this._Doc.AuctionTypeList.Table[j].name);
						ixuilabel4.SetText(this._Doc.AuctionTypeList.Table[j].name);
						ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeCheckBoxClicked));
						Transform transform = this.m_typeDictionary[this._Doc.AuctionTypeList.Table[j].pretype].transform.Find("ChildList");
						IXUISprite ixuisprite4 = this.m_typeDictionary[this._Doc.AuctionTypeList.Table[j].pretype].transform.Find("Switch").GetComponent("XUISprite") as IXUISprite;
						ixuisprite4.SetAlpha(1f);
						gameObject2.transform.parent = transform;
						gameObject2.transform.localScale = Vector3.one;
						gameObject2.transform.localPosition = new Vector3(0f, -((float)transform.childCount - 0.5f) * (float)ixuisprite3.spriteHeight, 0f);
						bool flag5 = !this.m_typeDictionary.ContainsKey(this._Doc.AuctionTypeList.Table[j].id);
						if (flag5)
						{
							this.m_typeDictionary.Add(this._Doc.AuctionTypeList.Table[j].id, gameObject2);
						}
					}
				}
				IL_476:
				j++;
				continue;
				goto IL_476;
			}
			this.ShowNormalSelect();
		}

		private void ShowNormalSelect()
		{
			int parentID = 0;
			GameObject gameObject;
			bool flag = this.m_typeDictionary.TryGetValue(this.m_NormalSelect, out gameObject);
			if (flag)
			{
				this.m_curAuctionType = this.m_NormalSelect;
				IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.bChecked = true;
				bool flag2 = AuctionDocument.TryGetAuctionTypeParentID(this.m_NormalSelect, out parentID);
				if (flag2)
				{
					this.ShowSelectParent(parentID);
				}
			}
		}

		private void ShowSelectParent(int parentID)
		{
			bool flag = parentID == 0;
			if (!flag)
			{
				GameObject gameObject;
				bool flag2 = this.m_typeDictionary.TryGetValue(parentID, out gameObject);
				if (flag2)
				{
					IXUIPlayTweenGroup ixuiplayTweenGroup = gameObject.GetComponent("XUIPlayTweenGroup") as IXUIPlayTweenGroup;
					bool flag3 = ixuiplayTweenGroup == null;
					if (!flag3)
					{
						ixuiplayTweenGroup.PlayTween(true);
					}
				}
			}
		}

		private bool OnItemFilterCheckClicked(IXUICheckBox box)
		{
			this.CalculateAuctionSelect();
			return true;
		}

		private void OnTypeCheckBoxClicked(IXUISprite box)
		{
			bool flag = this.m_curAuctionType != (int)box.ID || !this.m_ItemContentGroup.Active;
			if (flag)
			{
				this.m_curAuctionType = (int)box.ID;
				this.CalculateAuctionSelect();
			}
		}

		private void CalculateAuctionSelect()
		{
			this.m_ItemWrap.gameObject.SetActive(true);
			this.m_GoodWrap.gameObject.SetActive(false);
			this.m_ShowAuctionList.Clear();
			int selectCount = this.m_ItemBlockCheck.bChecked ? 1 : 0;
			bool bChecked = this.m_ItemLevelCheck.bChecked;
			int minLevel;
			int sealLevel;
			if (bChecked)
			{
				XLevelSealDocument.GetSealLevelRange((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level, out minLevel, out sealLevel);
			}
			else
			{
				XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
				sealLevel = (int)specificDocument.SealLevel;
				minLevel = 0;
			}
			this.SelectItemList(this.m_curAuctionType, selectCount, sealLevel, minLevel);
			List<int> list;
			bool flag = AuctionDocument.TryGetChildren(this.m_curAuctionType, out list);
			if (flag)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					this.SelectItemList(list[i], selectCount, sealLevel, minLevel);
					i++;
				}
			}
			this.m_ailinTransform.gameObject.SetActive(this.m_ShowAuctionList.Count == 0);
			this.m_ShowAuctionList.Sort(new Comparison<ItemList.RowData>(this.Compare));
			this.m_ItemContentGroup.SetWrapContentSize(this.m_ShowAuctionList.Count);
			bool flag2 = this._Doc.CurrentSelectRefresh && this.m_ShowAuctionList.Count == 0;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowLoginTip(XStringDefineProxy.GetString("AUCTION_EMPTY_MESSAGE"));
			}
			this._Doc.CurrentSelectRefresh = false;
		}

		private void SelectItemList(int auctionType, int selectCount, int maxLeavl, int minLevel)
		{
			List<ItemList.RowData> list;
			bool flag = XBagDocument.TryGetAuctionList((uint)auctionType, out list);
			if (flag)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					bool flag2 = this.FilterAuctionItem(list[i], selectCount, maxLeavl, minLevel);
					if (flag2)
					{
						this.m_ShowAuctionList.Add(list[i]);
					}
					i++;
				}
			}
		}

		private int Compare(ItemList.RowData f, ItemList.RowData l)
		{
			bool flag = l.ReqLevel == f.ReqLevel;
			int result;
			if (flag)
			{
				bool flag2 = l.ItemQuality == f.ItemQuality;
				if (flag2)
				{
					result = l.SortID - f.SortID;
				}
				else
				{
					result = (int)(l.ItemQuality - f.ItemQuality);
				}
			}
			else
			{
				result = (int)(l.ReqLevel - f.ReqLevel);
			}
			return result;
		}

		private bool FilterAuctionItem(ItemList.RowData rowData, int selectCount, int maxLeavl, int minLevel)
		{
			uint auctionBriefCount = this._Doc.GetAuctionBriefCount((uint)rowData.ItemID);
			bool flag = (ulong)auctionBriefCount < (ulong)((long)selectCount);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = rowData.ReqLevel > 1 && ((int)rowData.ReqLevel < minLevel || (int)rowData.ReqLevel > maxLeavl);
				result = !flag2;
			}
			return result;
		}

		private AuctionDocument _Doc;

		private IXUIScrollView m_typeListScrollView;

		private XUIPool m_levelOnePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_levelTwoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Dictionary<int, GameObject> m_typeDictionary = new Dictionary<int, GameObject>();

		private int m_NormalSelect = 6;

		private IXUILabel m_refreshTime;

		private IXUILabelSymbol m_refreshButtonLabel;

		private IXUIButton m_refreshButton;

		private Transform m_ailinTransform;

		private IXUICheckBox m_ItemLevelCheck;

		private IXUICheckBox m_ItemBlockCheck;

		private int m_curAuctionType = 0;

		private Transform m_ItemWrap;

		private Transform m_GoodWrap;

		private List<ItemList.RowData> m_ShowAuctionList;

		private List<AuctionItem> m_showSelectItems;

		private AuctionWrapContentGroup m_ItemContentGroup;

		private AuctionWrapContentGroup m_AuctionItemGroup;

		private XElapseTimer m_freeRefreshTime = new XElapseTimer();

		private bool m_freeRefresh = false;
	}
}
