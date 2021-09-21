using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CD3 RID: 3283
	internal class EmblemSetHandler : DlgHandlerBase
	{
		// Token: 0x0600B835 RID: 47157 RVA: 0x0024F940 File Offset: 0x0024DB40
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

		// Token: 0x0600B836 RID: 47158 RVA: 0x0024FC0F File Offset: 0x0024DE0F
		public override void RegisterEvent()
		{
			base.Init();
			this.btnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCreateButton));
			this.btnMaterialAccess.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickMaterialAccessButton));
		}

		// Token: 0x0600B837 RID: 47159 RVA: 0x0024FC4C File Offset: 0x0024DE4C
		public void RefreshItemList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.OnShow();
			}
		}

		// Token: 0x0600B838 RID: 47160 RVA: 0x0024FC70 File Offset: 0x0024DE70
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.OnShow();
		}

		// Token: 0x0600B839 RID: 47161 RVA: 0x0024FC84 File Offset: 0x0024DE84
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

		// Token: 0x0600B83A RID: 47162 RVA: 0x0024FDE6 File Offset: 0x0024DFE6
		protected override void OnHide()
		{
			this.itemSelector.Hide();
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		// Token: 0x0600B83B RID: 47163 RVA: 0x0024FE0C File Offset: 0x0024E00C
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

		// Token: 0x0600B83C RID: 47164 RVA: 0x0024FE64 File Offset: 0x0024E064
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

		// Token: 0x0600B83D RID: 47165 RVA: 0x0024FF74 File Offset: 0x0024E174
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

		// Token: 0x0600B83E RID: 47166 RVA: 0x0025001C File Offset: 0x0024E21C
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

		// Token: 0x0600B83F RID: 47167 RVA: 0x002501FC File Offset: 0x0024E3FC
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

		// Token: 0x0600B840 RID: 47168 RVA: 0x00250248 File Offset: 0x0024E448
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

		// Token: 0x0600B841 RID: 47169 RVA: 0x001AE886 File Offset: 0x001ACA86
		private void OnClickNeedItem(IXUISprite icon)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)icon.ID, null);
		}

		// Token: 0x040048BE RID: 18622
		private bool mIsNeedEnough;

		// Token: 0x040048BF RID: 18623
		private XItem mLastItem;

		// Token: 0x040048C0 RID: 18624
		private XBagWindow bagWindow;

		// Token: 0x040048C1 RID: 18625
		private XItemSelector itemSelector;

		// Token: 0x040048C2 RID: 18626
		private List<Seq2<int>> mNeedList = new List<Seq2<int>>();

		// Token: 0x040048C3 RID: 18627
		private IXUIButton btnCreate;

		// Token: 0x040048C4 RID: 18628
		private IXUIButton btnMaterialAccess;

		// Token: 0x040048C5 RID: 18629
		private IXUILabel lbBtnCost;

		// Token: 0x040048C6 RID: 18630
		private IXUILabel lbLevel;

		// Token: 0x040048C7 RID: 18631
		private IXUILabel lbJob;

		// Token: 0x040048C8 RID: 18632
		private IXUILabel lbTips;

		// Token: 0x040048C9 RID: 18633
		private IXUILabel lbAttrs;

		// Token: 0x040048CA RID: 18634
		private GameObject goItem;

		// Token: 0x040048CB RID: 18635
		private GameObject goNullHint;

		// Token: 0x040048CC RID: 18636
		private NeedItemView[] goNeedItems;

		// Token: 0x040048CD RID: 18637
		private XEquipCreateDocument mDoc;

		// Token: 0x040048CE RID: 18638
		private XPurchaseDocument mPurchaseDoc;

		// Token: 0x040048CF RID: 18639
		private ItemComposeTable.RowData mComposeData;

		// Token: 0x040048D0 RID: 18640
		private ulong m_itemUid = 0UL;
	}
}
