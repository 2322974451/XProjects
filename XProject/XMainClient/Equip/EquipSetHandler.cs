using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSetHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.mCurItemType2nd = null;
			this.mDoc = XEquipCreateDocument.Doc;
			this.mPurchaseDoc = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			this._InitItemType();
			this._InitItemList();
			this.equipSetProfFrame = base.PanelObject.transform.Find("EquipSetProfFrame").gameObject;
			DlgHandlerBase.EnsureCreate<EquipSetProfHandler>(ref this.equipSetProfHandler, this.equipSetProfFrame, null, false);
			this.m_levelCheck = (base.PanelObject.transform.FindChild("BtnHighPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.mNoLevelLimitString = XStringDefineProxy.GetString("EQUIPCREATE_EQUIPSET_NO_LEVEL_LIMIT");
			this.mDoc.RefreshEquipSuitListUIByProf(this.mDoc.CurRoleProf, false);
			this.mQualityRedpointDic = new Dictionary<int, GameObject>();
			this.mEquipSuitIDRedpointDic = new Dictionary<int, GameObject>();
			this.mSelectLevel = this.mDoc.CurShowLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level, -1);
		}

		public override void RegisterEvent()
		{
			base.Init();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("Prof/Bg").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickProfMenuSelect));
			this.m_levelCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnLevelCheckClicked));
		}

		public override void StackRefresh()
		{
			this.mDoc.RefreshEquipSuitListUIByLevel(this.mSelectLevel, true);
			this.RefreshItemType();
			this.RefreshRedPoint();
			base.StackRefresh();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.mDoc.RefreshEquipSuitListUIByLevel(this.mSelectLevel, true);
			this.RefreshItemType();
			this.RefreshRedPoint();
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		public override void OnUnload()
		{
			this.mEquipSuitIDRedpointDic.Clear();
			this.mEquipSuitIDRedpointDic = null;
			this.mQualityRedpointDic.Clear();
			this.mQualityRedpointDic = null;
			DlgHandlerBase.EnsureUnload<EquipSetProfHandler>(ref this.equipSetProfHandler);
			this.equipSetProfFrame = null;
			this.mDoc = null;
			this.mPurchaseDoc = null;
			this.mCurItemType2nd = null;
			base.OnUnload();
		}

		public void RefreshRedPoint()
		{
			bool flag = !base.IsVisible() || 0 >= this.mItemType1stPool.ActiveCount;
			if (!flag)
			{
				List<EquipSuitMenuData> updateItemTypeList = this.mDoc.GetUpdateItemTypeList(true);
				foreach (KeyValuePair<int, GameObject> keyValuePair in this.mQualityRedpointDic)
				{
					keyValuePair.Value.SetActive(false);
				}
				foreach (KeyValuePair<int, GameObject> keyValuePair2 in this.mEquipSuitIDRedpointDic)
				{
					keyValuePair2.Value.SetActive(false);
				}
				for (int i = 0; i < updateItemTypeList.Count; i++)
				{
					GameObject gameObject = null;
					bool flag2 = this.mQualityRedpointDic.TryGetValue(updateItemTypeList[i].quality, out gameObject);
					if (flag2)
					{
						gameObject.SetActive(updateItemTypeList[i].redpoint);
					}
					for (int j = 0; j < updateItemTypeList[i].list.Count; j++)
					{
						GameObject gameObject2 = null;
						bool flag3 = this.mEquipSuitIDRedpointDic.TryGetValue(updateItemTypeList[i].list[j].suitData.SuitID, out gameObject2);
						if (flag3)
						{
							gameObject2.SetActive(updateItemTypeList[i].list[j].redpoint);
						}
					}
				}
			}
		}

		public void RefreshItemList(List<EquipSuitItemData> _uiList)
		{
			bool flag = !base.IsVisible() || _uiList == null;
			if (!flag)
			{
				this.mItemListWrapContent.SetContentCount(_uiList.Count, false);
				this.mItemListScrollView.ResetPosition();
			}
		}

		public void RefreshItemList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.mCurItemType2nd != null;
				if (flag2)
				{
					this.OnClickItemType2nd(this.mCurItemType2nd);
				}
			}
		}

		public void RefreshItemType()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				List<EquipSuitMenuData> updateItemTypeList = this.mDoc.GetUpdateItemTypeList(true);
				bool flag2 = updateItemTypeList == null;
				if (flag2)
				{
					this.RefreshItemList();
				}
				else
				{
					List<EquipSuitMenuData> list = new List<EquipSuitMenuData>();
					for (int i = 0; i < updateItemTypeList.Count; i++)
					{
						bool show = updateItemTypeList[i].show;
						if (show)
						{
							list.Add(updateItemTypeList[i]);
						}
					}
					this.mEquipSuitIDRedpointDic.Clear();
					this.mQualityRedpointDic.Clear();
					this.mItemType1stPool.ReturnAll(false);
					this.mItemType2ndPool.ReturnAll(true);
					this.mCurItemType2nd = null;
					bool flag3 = true;
					bool flag4 = true;
					for (int j = 0; j < list.Count; j++)
					{
						GameObject gameObject = this.mItemType1stPool.FetchGameObject(false);
						gameObject.name = list[j].quality.ToString();
						this.mQualityRedpointDic[list[j].quality] = gameObject.transform.Find("RedPoint").gameObject;
						GameObject gameObject2 = gameObject.transform.Find("UnSelectLab").gameObject;
						GameObject gameObject3 = gameObject.transform.Find("SelectLab").gameObject;
						IXUISprite ixuisprite = gameObject.transform.Find("Switch").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemType1st));
						IXUISprite ixuisprite2 = gameObject.transform.Find("P").GetComponent("XUISprite") as IXUISprite;
						bool flag5 = ixuisprite2 != null;
						if (flag5)
						{
							ixuisprite2.spriteName = XSingleton<UiUtility>.singleton.GetItemQualityIcon(list[j].quality);
						}
						Transform transform = gameObject.transform.Find("ChildList");
						bool flag6 = 0f == transform.localScale.y;
						if (flag6)
						{
							ixuisprite.SetSprite("l_add_01");
							IXUITweenTool ixuitweenTool = ixuisprite.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
							ixuitweenTool.PlayTween(true, -1f);
						}
						bool flag7 = flag3;
						if (flag7)
						{
							flag3 = false;
						}
						List<EquipSuitMenuDataItem> list2 = new List<EquipSuitMenuDataItem>();
						for (int k = 0; k < list[j].list.Count; k++)
						{
							bool show2 = list[j].list[k].show;
							if (show2)
							{
								list2.Add(list[j].list[k]);
							}
						}
						for (int l = 0; l < list2.Count; l++)
						{
							GameObject gameObject4 = this.mItemType2ndPool.FetchGameObject(false);
							gameObject4.name = list2[l].suitData.SuitID.ToString();
							this.mEquipSuitIDRedpointDic[list2[l].suitData.SuitID] = gameObject4.transform.Find("RedPoint").gameObject;
							IXUICheckBox ixuicheckBox = gameObject4.GetComponent("XUICheckBox") as IXUICheckBox;
							ixuicheckBox.ID = (ulong)((long)list2[l].suitData.SuitID);
							ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickItemType2nd));
							gameObject4.transform.parent = transform;
							gameObject4.transform.localScale = Vector3.one;
							gameObject4.transform.localPosition = new Vector3(0f, -((float)transform.childCount - 0.5f) * (float)ixuicheckBox.spriteHeight, 0f);
							IXUILabel ixuilabel = gameObject4.transform.Find("SelectLab").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(list2[l].suitData.SuitName);
							IXUILabel ixuilabel2 = gameObject4.transform.Find("UnSelectLab").GetComponent("XUILabel") as IXUILabel;
							ixuilabel2.SetText(list2[l].suitData.SuitName);
							ixuicheckBox.ForceSetFlag(false);
							bool flag8 = l == list2.Count - 1 && !flag3 && flag4;
							if (flag8)
							{
								flag4 = false;
								this.mCurItemType2nd = ixuicheckBox;
								ixuicheckBox.ForceSetFlag(true);
								this.RefreshItemList();
								ixuilabel.gameObject.SetActive(true);
								ixuilabel2.gameObject.SetActive(false);
								gameObject3.SetActive(true);
								gameObject2.SetActive(false);
							}
							else
							{
								ixuicheckBox.ForceSetFlag(false);
								ixuilabel2.gameObject.SetActive(true);
								ixuilabel.gameObject.SetActive(false);
								gameObject2.SetActive(true);
								gameObject3.SetActive(false);
							}
						}
					}
					this.mItemTypeTable.RePositionNow();
				}
				this.RefreshRedPoint();
			}
		}

		private void OnClickItemType1st(IXUISprite sp)
		{
			bool flag = sp.spriteName == "l_add_00";
			if (flag)
			{
				sp.SetSprite("l_add_01");
			}
			else
			{
				sp.SetSprite("l_add_00");
			}
		}

		private bool OnClickItemType2nd(IXUICheckBox cb)
		{
			bool flag = !cb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.mCurItemType2nd != null;
				if (flag2)
				{
					this.SetSelectStatus(false);
				}
				this.mCurItemType2nd = cb;
				this.SetSelectStatus(true);
				List<EquipSuitItemData> updateRefreshEquipSuitList = this.mDoc.GetUpdateRefreshEquipSuitList((int)cb.ID);
				this.RefreshItemList(updateRefreshEquipSuitList);
				result = true;
			}
			return result;
		}

		private void SetSelectStatus(bool isSelected)
		{
			this.mCurItemType2nd.gameObject.transform.FindChild("UnSelectLab").gameObject.SetActive(!isSelected);
			this.mCurItemType2nd.gameObject.transform.FindChild("SelectLab").gameObject.SetActive(isSelected);
			Transform parent = this.mCurItemType2nd.gameObject.transform.parent.parent;
			parent.FindChild("UnSelectLab").gameObject.SetActive(!isSelected);
			parent.FindChild("SelectLab").gameObject.SetActive(isSelected);
		}

		private void OnClickProfMenuSelect(IXUISprite _spr)
		{
			this.equipSetProfHandler.SetVisible(true);
		}

		private bool OnClickItemCreateButton(IXUIButton btn)
		{
			int num = (int)btn.ID;
			ItemComposeTable.RowData itemConposeDataByID = XEquipCreateDocument.GetItemConposeDataByID(num);
			bool flag = itemConposeDataByID != null;
			if (flag)
			{
				this.mDoc.CurUid = 0UL;
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				int vipLevel = (int)specificDocument.VipLevel;
				bool flag2 = (long)itemConposeDataByID.Coin <= (long)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.GOLD);
				if (flag2)
				{
					VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP(vipLevel);
					ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EQUIP);
					List<XItem> list = new List<XItem>();
					XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref list);
					bool flag3 = (long)list.Count >= (long)((ulong)byVIP.EquipMax);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EquipBagFull"), "fece00");
						return true;
					}
					this.mDoc.IsBind = true;
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateConfirmHandler.SetVisible(true);
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateConfirmHandler.SetEquipInfo(num);
				}
				else
				{
					XPurchaseInfo purchaseInfo = this.mPurchaseDoc.GetPurchaseInfo(level, vipLevel, ItemEnum.GOLD);
					bool flag4 = purchaseInfo.totalBuyNum > purchaseInfo.curBuyNum;
					if (flag4)
					{
						DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLotteryGoldNotEnough"), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EQUIPCREATE_COIN_CANNOT_EXCHANGE"), "fece00");
					}
				}
			}
			return true;
		}

		private bool OnClickGetNeedItemButton(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)btn.ID, null);
			return true;
		}

		private void OnNeedItemClick(IXUISprite item)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)item.ID, null);
		}

		private bool OnLevelCheckClicked(IXUICheckBox box)
		{
			this.mSelectLevel = (this.m_levelCheck.bChecked ? this.mDoc.CurShowLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level, -1) : 0);
			this.mDoc.RefreshEquipSuitListUIByLevel(this.mSelectLevel, true);
			return true;
		}

		private void _InitItemList()
		{
			Transform transform = base.PanelObject.transform.Find("ItemList");
			this.mItemListScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.Find("WrapContent");
			this.mItemListWrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.mItemListWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._RankWrapItemListUpdated));
		}

		private void _InitItemType()
		{
			Transform transform = base.PanelObject.transform.Find("TypeList");
			this.mItemTypeScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.Find("Table");
			this.mItemTypeTable = (transform.GetComponent("XUITable") as IXUITable);
			transform = base.PanelObject.transform.Find("TypeList/Table/LevelOneTpl");
			this.mItemType1stPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			transform = base.PanelObject.transform.Find("TypeList/Table/LevelTwoTpl");
			this.mItemType2ndPool.SetupPool(transform.parent.gameObject, transform.gameObject, 16U, false);
		}

		private bool _RankWrapItemListUpdatedNeedItem(GameObject _goItem, IXUILabel _lbCount, int _SrcItem0, int _SrcItem1)
		{
			_goItem.SetActive(true);
			ulong num = (ulong)((long)_SrcItem1);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(_SrcItem0);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(_goItem, _SrcItem0, 0, false);
			IXUISprite ixuisprite = _goItem.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)_SrcItem0);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNeedItemClick));
			bool flag = itemCount >= num;
			bool result;
			if (flag)
			{
				_lbCount.SetText(string.Format("[{0}]{1}/{2}[-]", XStringDefineProxy.GetString("ZongColor"), itemCount, num));
				result = true;
			}
			else
			{
				_lbCount.SetText(string.Format("[{0}]{1}[-][{2}]/{3}[-]", new object[]
				{
					XStringDefineProxy.GetString("NotEnoughColor"),
					itemCount,
					XStringDefineProxy.GetString("ZongColor"),
					num
				}));
				result = false;
			}
			return result;
		}

		private void _RankWrapItemListUpdated(Transform t, int index)
		{
			EquipSuitItemData equipSuitListItem = this.mDoc.GetEquipSuitListItem(index);
			t.name = index.ToString();
			EquipSetItemView equipSetItemView = new EquipSetItemView();
			equipSetItemView.FindFrom(t);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(equipSuitListItem.itemData.ItemID);
			bool isBind = equipSuitListItem.itemComposeData.IsBind;
			bool flag = !itemConf.CanTrade;
			if (flag)
			{
				isBind = true;
			}
			EquipSetItemBaseView.stEquipInfoParam param;
			param.isShowTooltip = true;
			param.playerProf = this.mDoc.CurRoleProf;
			equipSetItemView.SetItemInfo(equipSuitListItem.itemData.ItemID, param, isBind);
			equipSetItemView.lbLevel.SetText(this._GetLevelString(equipSuitListItem.itemComposeData.Level));
			bool flag2 = true;
			int num = -1;
			bool flag3 = equipSuitListItem.itemComposeData.SrcItem1[0] <= 0;
			if (flag3)
			{
				equipSetItemView.goItem1.SetActive(false);
			}
			else
			{
				bool flag4 = this._RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem1, equipSetItemView.lbItemCount1, equipSuitListItem.itemComposeData.SrcItem1[0], equipSuitListItem.itemComposeData.SrcItem1[1]);
				flag2 = (flag2 && flag4);
				bool flag5 = !flag4;
				if (flag5)
				{
					num = equipSuitListItem.itemComposeData.SrcItem1[0];
				}
			}
			bool flag6 = equipSuitListItem.itemComposeData.SrcItem2[1] <= 0;
			if (flag6)
			{
				equipSetItemView.goItem2.SetActive(false);
			}
			else
			{
				bool flag4 = this._RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem2, equipSetItemView.lbItemCount2, equipSuitListItem.itemComposeData.SrcItem2[0], equipSuitListItem.itemComposeData.SrcItem2[1]);
				flag2 = (flag2 && flag4);
				bool flag7 = !flag4;
				if (flag7)
				{
					num = equipSuitListItem.itemComposeData.SrcItem2[0];
				}
			}
			bool flag8 = equipSuitListItem.itemComposeData.SrcItem3[1] <= 0;
			if (flag8)
			{
				equipSetItemView.goItem3.SetActive(false);
			}
			else
			{
				bool flag4 = this._RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem3, equipSetItemView.lbItemCount3, equipSuitListItem.itemComposeData.SrcItem3[0], equipSuitListItem.itemComposeData.SrcItem3[1]);
				flag2 = (flag2 && flag4);
				bool flag9 = !flag4;
				if (flag9)
				{
					num = equipSuitListItem.itemComposeData.SrcItem3[0];
				}
			}
			bool flag10 = 0 >= equipSuitListItem.itemComposeData.SrcItem4[1];
			if (flag10)
			{
				equipSetItemView.goItem4.SetActive(false);
			}
			else
			{
				bool flag4 = this._RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem4, equipSetItemView.lbItemCount4, equipSuitListItem.itemComposeData.SrcItem4[0], equipSuitListItem.itemComposeData.SrcItem4[1]);
				flag2 = (flag2 && flag4);
				bool flag11 = !flag4;
				if (flag11)
				{
					num = equipSuitListItem.itemComposeData.SrcItem4[0];
				}
			}
			bool flag12 = equipSuitListItem.itemComposeData.Coin > 0;
			if (flag12)
			{
				equipSetItemView.lbCost.SetText(equipSuitListItem.itemComposeData.Coin.ToString());
			}
			else
			{
				equipSetItemView.lbCost.SetText("0");
			}
			bool flag13 = flag2;
			if (flag13)
			{
				equipSetItemView.btnCreate.SetEnable(true, false);
				equipSetItemView.btnCreate.ID = (ulong)((long)equipSuitListItem.itemComposeData.ID);
				equipSetItemView.btnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickItemCreateButton));
			}
			else
			{
				equipSetItemView.btnCreate.SetEnable(true, false);
				equipSetItemView.btnCreate.ID = (ulong)((long)num);
				equipSetItemView.btnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGetNeedItemButton));
			}
			equipSetItemView.goRedpoint.SetActive(equipSuitListItem.redpoint);
		}

		private string _GetLevelString(int _level)
		{
			bool flag = _level > 0;
			string result;
			if (flag)
			{
				result = _level.ToString();
			}
			else
			{
				result = this.mNoLevelLimitString;
			}
			return result;
		}

		private IXUIWrapContent mItemListWrapContent;

		private IXUIScrollView mItemListScrollView;

		private IXUICheckBox mCurItemType2nd;

		private IXUITable mItemTypeTable;

		private IXUIScrollView mItemTypeScrollView;

		private IXUICheckBox m_levelCheck;

		private XUIPool mItemType1stPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool mItemType2ndPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Dictionary<int, GameObject> mQualityRedpointDic;

		private Dictionary<int, GameObject> mEquipSuitIDRedpointDic;

		private XEquipCreateDocument mDoc;

		private XPurchaseDocument mPurchaseDoc;

		private int mSelectLevel = 0;

		public EquipSetProfHandler equipSetProfHandler;

		private GameObject equipSetProfFrame;

		private string mNoLevelLimitString;
	}
}
