using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA1 RID: 3233
	internal class TooltipButtonOperateItemUse : TooltipButtonOperateBase
	{
		// Token: 0x0600B62F RID: 46639 RVA: 0x00241392 File Offset: 0x0023F592
		public TooltipButtonOperateItemUse()
		{
			this.m_EndlessabyssShopItem = XSingleton<XGlobalConfig>.singleton.GetIntList("EndlessabyssShopItem");
		}

		// Token: 0x0600B630 RID: 46640 RVA: 0x002413B4 File Offset: 0x0023F5B4
		public override string GetButtonText()
		{
			bool flag = this.m_RowData != null;
			string result;
			if (flag)
			{
				result = this.m_RowData.ButtonName;
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x0600B631 RID: 46641 RVA: 0x002413E8 File Offset: 0x0023F5E8
		public override bool IsButtonVisible(XItem item)
		{
			this.m_biShowPutInBtn = XSingleton<TooltipParam>.singleton.bShowPutInBtn;
			XCharacterItemDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			this.m_RowData = specificDocument.GetButtonData((uint)item.itemID, item.type);
			bool flag = this.m_RowData != null;
			bool result;
			if (flag)
			{
				this.m_SystemID = this.m_RowData.SystemID;
				for (int i = 0; i < this.m_EndlessabyssShopItem.Count; i++)
				{
					bool flag2 = item.itemID == this.m_EndlessabyssShopItem[i];
					if (flag2)
					{
						this.m_SystemID = (uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(ActivityHandler.GetShopSystem());
						break;
					}
				}
				bool flag3 = item.Type == ItemType.EMBLEM_MATERIAL;
				if (flag3)
				{
					bool flag4 = this.m_SystemID != 0U && (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)this.m_SystemID) || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Char_Emblem));
					if (flag4)
					{
						return false;
					}
				}
				else
				{
					bool flag5 = this.m_SystemID != 0U && !XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)this.m_SystemID);
					if (flag5)
					{
						return false;
					}
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600B632 RID: 46642 RVA: 0x0024151C File Offset: 0x0023F71C
		public override bool HasRedPoint(XItem item)
		{
			XCharacterItemDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			return specificDocument.AvailableItems.IsNew(item.uid);
		}

		// Token: 0x0600B633 RID: 46643 RVA: 0x0024154C File Offset: 0x0023F74C
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = this.m_SystemID == 0U;
			if (flag)
			{
				bool flag2 = itemByUID != null;
				if (flag2)
				{
					ItemType type = itemByUID.Type;
					if (type != ItemType.LOTTERY_BOX)
					{
						switch (type)
						{
						case ItemType.FOOD_MENU:
							XHomeCookAndPartyDocument.Doc.SendActiveFoodMenu((uint)itemByUID.itemID);
							goto IL_136;
						case ItemType.Food_Eaten:
						{
							XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 7U);
							bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
							if (flag3)
							{
								DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.PlayUseItemEffect(false);
							}
							goto IL_136;
						}
						case (ItemType)24:
						case (ItemType)25:
							break;
						case ItemType.PANDORA:
						{
							PandoraHeart.RowData pandoraHeartConf = XBagDocument.GetPandoraHeartConf(itemByUID.itemID, XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID);
							PandoraDocument specificDocument = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
							specificDocument.ShowPandoraLotteryView(pandoraHeartConf.PandoraID, pandoraHeartConf);
							goto IL_136;
						}
						default:
							if (type == ItemType.BagExpandTicket)
							{
								this.UseBagExpandTicket(itemByUID);
								goto IL_136;
							}
							break;
						}
						this.OpenOnceTip(itemByUID);
					}
					else
					{
						XCharacterItemDocument specificDocument2 = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
						specificDocument2.ShowWheelView(itemByUID);
					}
					IL_136:;
				}
			}
			else
			{
				bool flag4 = itemByUID != null;
				if (flag4)
				{
					ItemType type2 = itemByUID.Type;
					if (type2 != ItemType.Inscription)
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)this.m_SystemID, 0UL);
					}
					else
					{
						bool biShowPutInBtn = this.m_biShowPutInBtn;
						if (biShowPutInBtn)
						{
							ArtifactDeityStoveDocument.Doc.Additem(mainUID);
						}
						else
						{
							XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)this.m_SystemID, 0UL);
						}
					}
				}
				else
				{
					XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)this.m_SystemID, 0UL);
				}
			}
		}

		// Token: 0x0600B634 RID: 46644 RVA: 0x0024170C File Offset: 0x0023F90C
		private void OpenOnceTip(XItem item)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			bool flag = !item.bBinding && itemConf != null && itemConf.IsNeedShowTipsPanel == 1;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("CanNotSeal"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.UseOnceItem));
			}
			else
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(item, 0U);
			}
		}

		// Token: 0x0600B635 RID: 46645 RVA: 0x00241794 File Offset: 0x0023F994
		private bool UseOnceItem(IXUIButton btn)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 0U);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600B636 RID: 46646 RVA: 0x002417EC File Offset: 0x0023F9EC
		private void UseBagExpandTicket(XItem item)
		{
			BagExpandItemListTable.RowData expandItemConf = XBagDocument.GetExpandItemConf((uint)item.itemID);
			bool flag = expandItemConf != null;
			if (flag)
			{
				ulong itemCount = XBagDocument.BagDoc.GetItemCount(item.itemID);
				BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData((BagType)expandItemConf.Type);
				bool flag2 = bagExpandData != null;
				if (flag2)
				{
					bool flag3 = (uint)expandItemConf.NeedAndOpen.count > bagExpandData.ExpandTimes;
					if (flag3)
					{
						bool flag4 = itemCount >= (ulong)expandItemConf.NeedAndOpen[(int)bagExpandData.ExpandTimes, 0];
						if (flag4)
						{
							XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(item, 0U);
						}
						else
						{
							bool flag5 = item.itemConf != null;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("BagExpandNeedNum"), expandItemConf.NeedAndOpen[(int)bagExpandData.ExpandTimes, 0], item.itemConf.ItemName[0], expandItemConf.NeedAndOpen[(int)bagExpandData.ExpandTimes, 1]), "fece00");
							}
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<UiUtility>.singleton.GetBagExpandFullTips((BagType)expandItemConf.Type), "fece00");
					}
				}
			}
		}

		// Token: 0x0400474B RID: 18251
		private uint m_SystemID;

		// Token: 0x0400474C RID: 18252
		private ItemUseButtonList.RowData m_RowData;

		// Token: 0x0400474D RID: 18253
		private bool m_biShowPutInBtn;

		// Token: 0x0400474E RID: 18254
		private List<int> m_EndlessabyssShopItem;
	}
}
