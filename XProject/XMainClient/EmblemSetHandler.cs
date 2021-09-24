using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EmblemSetHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.mDoc = XEquipCreateDocument.Doc;
			this.mLastItem = null;
			this.mPurchaseDoc = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			this.btnCreate = (base.PanelObject.transform.Find("Create").GetComponent("XUIButton") as IXUIButton);
			this.btnMaterialAccess = (base.PanelObject.transform.Find("BtnMaterialAccess").GetComponent("XUIButton") as IXUIButton);
			this.lbBtnCost = (this.btnCreate.gameObject.transform.Find("V").GetComponent("XUILabel") as IXUILabel);
			this.lbAttrs = (base.PanelObject.transform.Find("Attrs").GetComponent("XUILabel") as IXUILabel);
			this.lbLevel = (this.lbAttrs.gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel);
			this.lbJob = (this.lbAttrs.gameObject.transform.Find("Job").GetComponent("XUILabel") as IXUILabel);
			this.lbTips = (this.lbAttrs.gameObject.transform.Find("TipsLab").GetComponent("XUILabel") as IXUILabel);
			this.goNullHint = base.PanelObject.transform.Find("Null").gameObject;
			this.goItem = base.PanelObject.transform.Find("Item").gameObject;
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.goItem, null);
			Transform transform = base.PanelObject.transform.Find("ItemNeeds");
			this.goNeedItems = new NeedItemView[transform.childCount];
			for (int i = 0; i < this.goNeedItems.Length; i++)
			{
				this.goNeedItems[i] = new NeedItemView(true);
				this.goNeedItems[i].FindFrom(transform.GetChild(i));
				this.goNeedItems[i].ResetItem();
				this.goNeedItems[i].sprIcon.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickNeedItem));
			}
			this.lbTips.SetText(this.mDoc.EmblemAttrEndString);
			this.lbTips.gameObject.SetActive(false);
			this.lbLevel.SetVisible(false);
			this.bagWindow = new XBagWindow(base.PanelObject, new ItemUpdateHandler(this._RankWrapItemListUpdated), new GetItemHandler(this.mDoc.GetEmblemList));
			this.bagWindow.Init();
			this.itemSelector = new XItemSelector(0U);
		}

		public override void RegisterEvent()
		{
			base.Init();
			this.btnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCreateButton));
			this.btnMaterialAccess.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickMaterialAccessButton));
		}

		public void RefreshItemList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.OnShow();
			}
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.OnShow();
		}

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.goItem, null);
			this.goNullHint.SetActive(true);
			this.lbAttrs.Alpha = 0f;
			this.lbTips.gameObject.SetActive(false);
			this.lbBtnCost.SetText("0");
			this.mComposeData = null;
			this.bagWindow.UpdateBag();
			this.bagWindow.ResetPosition();
			bool flag = this.mLastItem != null;
			if (flag)
			{
				XItem bagItemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetBagItemByUID(this.mLastItem.uid);
				bool flag2 = bagItemByUID == null || bagItemByUID.itemCount <= 0;
				if (flag2)
				{
					this.mLastItem = null;
					this.itemSelector.Hide();
					for (int i = 0; i < this.goNeedItems.Length; i++)
					{
						this.goNeedItems[i].ResetItem();
					}
				}
				else
				{
					Transform transform = this.bagWindow.FindChildByName(this.mLastItem.itemID.ToString());
					bool flag3 = transform != null;
					if (flag3)
					{
						IXUISprite icon = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						this.OnItemClicked(icon);
					}
				}
			}
		}

		protected override void OnHide()
		{
			this.itemSelector.Hide();
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		public override void OnUnload()
		{
			this.mLastItem = null;
			this.mComposeData = null;
			this.mDoc = null;
			this.mPurchaseDoc = null;
			this.mNeedList.Clear();
			this.bagWindow = null;
			this.itemSelector.Unload();
			this.itemSelector = null;
			base.OnUnload();
		}

		private void _RankWrapItemListUpdated(Transform t, int index)
		{
			IXUISprite ixuisprite = t.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject = t.Find("Redpoint").gameObject;
			bool active = false;
			bool flag = this.bagWindow.m_XItemList == null || index >= this.bagWindow.m_XItemList.Count || index < 0;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				t.gameObject.name = "empty";
				ixuisprite.RegisterSpriteClickEventHandler(null);
			}
			else
			{
				XItem xitem = this.bagWindow.m_XItemList[index];
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, xitem);
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
				t.gameObject.name = xitem.itemID.ToString();
				active = this.mDoc.IsHadRedDot(xitem.itemID);
			}
			gameObject.SetActive(active);
		}

		private bool OnClickMaterialAccessButton(IXUIButton btn)
		{
			int num = 184;
			ItemList.RowData itemConf = XBagDocument.GetItemConf(num);
			bool flag = itemConf != null && itemConf.Access.Count > 0;
			if (flag)
			{
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				for (int i = 0; i < itemConf.Access.Count; i++)
				{
					list.Add(itemConf.Access[i, 0]);
					list2.Add(itemConf.Access[i, 1]);
				}
				DlgBase<ItemAccessDlg, ItemAccessDlgBehaviour>.singleton.ShowAccess(num, list, list2, null);
			}
			return true;
		}

		private bool OnClickCreateButton(IXUIButton btn)
		{
			this.mDoc.CurUid = this.m_itemUid;
			bool flag = this.mComposeData != null;
			if (flag)
			{
				bool flag2 = this.mIsNeedEnough;
				if (flag2)
				{
					XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
					int vipLevel = (int)specificDocument.VipLevel;
					bool flag3 = (long)this.mComposeData.Coin <= (long)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.GOLD);
					if (flag3)
					{
						VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP(vipLevel);
						ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM);
						List<XItem> list = new List<XItem>();
						XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref list);
						bool flag4 = (long)list.Count >= (long)((ulong)byVIP.EmblemMax);
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EmblemBagFull"), "fece00");
							return true;
						}
						DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateConfirmHandler.SetVisible(true);
						DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateConfirmHandler.SetEquipInfo(this.mComposeData.ItemID);
					}
					else
					{
						int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
						XPurchaseInfo purchaseInfo = this.mPurchaseDoc.GetPurchaseInfo(level, vipLevel, ItemEnum.GOLD);
						bool flag5 = purchaseInfo.totalBuyNum > purchaseInfo.curBuyNum;
						if (flag5)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLotteryGoldNotEnough"), "fece00");
							DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EQUIPCREATE_COIN_CANNOT_EXCHANGE"), "fece00");
						}
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_REINFORCE_LACKMONEY"), "fece00");
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EQUIPCREATE_EMBLEMSET_NO_SELECT"), "fece00");
			}
			return true;
		}

		private void OnClickMainItem(IXUISprite icon)
		{
			XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(this.m_itemUid);
			bool bBinding = false;
			bool flag = bagItemByUID != null;
			if (flag)
			{
				bBinding = bagItemByUID.bBinding;
			}
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(XBagDocument.MakeXItem((int)icon.ID, bBinding), icon, false, 0U);
		}

		private void OnItemClicked(IXUISprite icon)
		{
			XItem xitem = this.bagWindow.m_XItemList[(int)icon.ID];
			this.m_itemUid = xitem.uid;
			bool flag = xitem == null;
			if (flag)
			{
				this.mDoc.IsBind = false;
			}
			else
			{
				this.mDoc.IsBind = xitem.bBinding;
			}
			this.goNullHint.SetActive(false);
			this.lbAttrs.Alpha = 1f;
			this.itemSelector.Select(icon);
			this.mComposeData = this.mDoc.GetEmblemComposeDataByMetalID(xitem.itemID);
			this.mLastItem = xitem;
			this.mNeedList.Clear();
			bool flag2 = this.mComposeData != null;
			if (flag2)
			{
				XItemDrawerMgr.Param.bBinding = xitem.bBinding;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.goItem, this.mComposeData.ItemID, 0, false);
				IXUISprite ixuisprite = this.goItem.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)this.mComposeData.ItemID);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickMainItem));
				ItemList.RowData itemConf = XBagDocument.GetItemConf(this.mComposeData.ItemID);
				this.lbJob.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)itemConf.Profession));
				this.mIsNeedEnough = true;
				string text;
				int emblemComposeAttrByEmblemID = this.mDoc.GetEmblemComposeAttrByEmblemID(this.mComposeData.ItemID, out text);
				this.lbAttrs.SetText(text);
				bool flag3 = emblemComposeAttrByEmblemID == -1 || emblemComposeAttrByEmblemID > 2;
				if (flag3)
				{
					this.lbTips.gameObject.SetActive(false);
				}
				else
				{
					this.lbTips.gameObject.SetActive(true);
				}
				this.lbBtnCost.SetText(this.mComposeData.Coin.ToString());
				bool flag4 = this.mComposeData.SrcItem1[0] > 0;
				if (flag4)
				{
					this.mNeedList.Add(new Seq2<int>(this.mComposeData.SrcItem1[0], this.mComposeData.SrcItem1[1]));
				}
				bool flag5 = this.mComposeData.SrcItem2[0] > 0;
				if (flag5)
				{
					this.mNeedList.Add(new Seq2<int>(this.mComposeData.SrcItem2[0], this.mComposeData.SrcItem2[1]));
				}
				bool flag6 = this.mComposeData.SrcItem3[0] > 0;
				if (flag6)
				{
					this.mNeedList.Add(new Seq2<int>(this.mComposeData.SrcItem3[0], this.mComposeData.SrcItem3[1]));
				}
				bool flag7 = this.mComposeData.SrcItem4[0] > 0;
				if (flag7)
				{
					this.mNeedList.Add(new Seq2<int>(this.mComposeData.SrcItem4[0], this.mComposeData.SrcItem4[1]));
				}
			}
			else
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.goItem, xitem);
				this.lbBtnCost.SetText("0");
				this.lbAttrs.SetText(this.mDoc.DefaultEmblemAttrString);
				this.lbJob.SetText(string.Empty);
			}
			int count = this.mNeedList.Count;
			for (int i = 0; i < this.goNeedItems.Length; i++)
			{
				bool flag8 = i < count;
				if (flag8)
				{
					bool flag9 = !this.goNeedItems[i].SetItem(this.mNeedList[i].value0, this.mNeedList[i].value1);
					if (flag9)
					{
						this.mIsNeedEnough = false;
					}
				}
				else
				{
					this.goNeedItems[i].ResetItem();
				}
			}
		}

		private void OnClickNeedItem(IXUISprite icon)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)icon.ID, null);
		}

		private bool mIsNeedEnough;

		private XItem mLastItem;

		private XBagWindow bagWindow;

		private XItemSelector itemSelector;

		private List<Seq2<int>> mNeedList = new List<Seq2<int>>();

		private IXUIButton btnCreate;

		private IXUIButton btnMaterialAccess;

		private IXUILabel lbBtnCost;

		private IXUILabel lbLevel;

		private IXUILabel lbJob;

		private IXUILabel lbTips;

		private IXUILabel lbAttrs;

		private GameObject goItem;

		private GameObject goNullHint;

		private NeedItemView[] goNeedItems;

		private XEquipCreateDocument mDoc;

		private XPurchaseDocument mPurchaseDoc;

		private ItemComposeTable.RowData mComposeData;

		private ulong m_itemUid = 0UL;
	}
}
