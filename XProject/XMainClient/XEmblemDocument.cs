using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009EB RID: 2539
	internal class XEmblemDocument : XDocComponent
	{
		// Token: 0x17002E2E RID: 11822
		// (get) Token: 0x06009B2E RID: 39726 RVA: 0x0018ABC8 File Offset: 0x00188DC8
		public override uint ID
		{
			get
			{
				return XEmblemDocument.uuID;
			}
		}

		// Token: 0x17002E2F RID: 11823
		// (get) Token: 0x06009B2F RID: 39727 RVA: 0x0018ABE0 File Offset: 0x00188DE0
		public EmblemSlotStatus[] EquipLock
		{
			get
			{
				bool flag = this.m_equipLock == null;
				if (flag)
				{
					this.m_equipLock = new EmblemSlotStatus[XEmblemDocument.Position_TotalEnd - XEmblemDocument.Position_TotalStart];
					for (int i = XEmblemDocument.Position_TotalStart; i < XEmblemDocument.Position_TotalEnd; i++)
					{
						this.m_equipLock[i] = new EmblemSlotStatus(i);
					}
				}
				return this.m_equipLock;
			}
		}

		// Token: 0x17002E30 RID: 11824
		// (get) Token: 0x06009B30 RID: 39728 RVA: 0x0018AC48 File Offset: 0x00188E48
		// (set) Token: 0x06009B31 RID: 39729 RVA: 0x0018AC70 File Offset: 0x00188E70
		public bool bCanBePowerful
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Char_Emblem) & this._bCanBePowerful;
			}
			set
			{
				this._bCanBePowerful = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Char_Emblem, true);
			}
		}

		// Token: 0x17002E31 RID: 11825
		// (get) Token: 0x06009B32 RID: 39730 RVA: 0x0018AC8C File Offset: 0x00188E8C
		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		// Token: 0x06009B33 RID: 39731 RVA: 0x0018ACA4 File Offset: 0x00188EA4
		public static bool isFullLevel(uint level)
		{
			return (ulong)level >= (ulong)((long)(XEmblemDocument.Level_Count - 1));
		}

		// Token: 0x06009B34 RID: 39732 RVA: 0x0018ACC8 File Offset: 0x00188EC8
		public static string GetDisplayLevel(uint level)
		{
			bool flag = XEmblemDocument.isFullLevel(level);
			string result;
			if (flag)
			{
				result = "MAX";
			}
			else
			{
				result = (level + 1U).ToString();
			}
			return result;
		}

		// Token: 0x06009B35 RID: 39733 RVA: 0x0018ACF8 File Offset: 0x00188EF8
		public static SkillEmblem.RowData GetEmblemSkillConf(uint dwItemId)
		{
			return XEmblemDocument._emblemSkillReader.GetByEmblemID(dwItemId);
		}

		// Token: 0x06009B36 RID: 39734 RVA: 0x0018AD18 File Offset: 0x00188F18
		public static string GetEmblemSkillAttrString(uint dwItemId)
		{
			bool flag = string.IsNullOrEmpty(XEmblemDocument.emblemSkillAttrFmt);
			if (flag)
			{
				XEmblemDocument.emblemSkillAttrFmt = XStringDefineProxy.GetString("TOOLTIP_EMBLEM_IDENTIFY_SKILL_FMT");
			}
			SkillEmblem.RowData byEmblemID = XEmblemDocument._emblemSkillReader.GetByEmblemID(dwItemId);
			bool flag2 = byEmblemID != null;
			string result;
			if (flag2)
			{
				result = string.Format(XEmblemDocument.emblemSkillAttrFmt, byEmblemID.SkillScript, XStringDefineProxy.GetString("TOOLTIP_EMBLEM_IDENTIFY_SKILL_" + byEmblemID.SkillType), byEmblemID.SkillPercent);
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06009B37 RID: 39735 RVA: 0x0018AD99 File Offset: 0x00188F99
		public static void Execute(OnLoadedCallback callback = null)
		{
			XEmblemDocument.AsyncLoader.AddTask("Table/SkillEmblem", XEmblemDocument._emblemSkillReader, false);
			XEmblemDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009B38 RID: 39736 RVA: 0x0018ADC0 File Offset: 0x00188FC0
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.emblemSlotUnlockLevel.Clear();
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("AttributeEmblemSlotLevelLimit").Split(XGlobalConfig.ListSeparator);
			int num = 0;
			while (num < array.Length && num < XEmblemDocument.Position_AttrEnd)
			{
				this.emblemSlotUnlockLevel.Add(uint.Parse(array[num]));
				num++;
			}
			array = XSingleton<XGlobalConfig>.singleton.GetValue("SkillEmblemSlotLevelLimit").Split(XGlobalConfig.ListSeparator);
			int num2 = 0;
			while (num2 < array.Length && num2 < XEmblemDocument.Position_NoPaySkillEnd - XEmblemDocument.Position_NoPaySkillStart + 1)
			{
				this.emblemSlotUnlockLevel.Add(uint.Parse(array[num2]));
				num2++;
			}
			array = XSingleton<XGlobalConfig>.singleton.GetValue("ExtraSkillEmblemSlotLevelLimit").Split(XGlobalConfig.ListSeparator);
			int num3 = 0;
			while (num3 < array.Length && num3 < XEmblemDocument.Position_PaySkillEnd - XEmblemDocument.Position_PaySkillStart + 1)
			{
				this.emblemSlotUnlockLevel.Add(uint.Parse(array[num3]));
				num3++;
			}
			array = XSingleton<XGlobalConfig>.singleton.GetValue("ExtraSkillEmblemSlotDragonCoin").Split(XGlobalConfig.ListSeparator);
			int num4 = 0;
			while (num4 < array.Length && num4 < XEmblemDocument.Position_PaySkillEnd - XEmblemDocument.Position_PaySkillStart + 1)
			{
				this.m_needMoneyList.Add(int.Parse(array[num4]));
				num4++;
			}
			this._NewItems.ClearItemType();
			this._NewItems.Filter.AddItemType(ItemType.EMBLEM);
		}

		// Token: 0x06009B39 RID: 39737 RVA: 0x0018AF58 File Offset: 0x00189158
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_LoadEquip, new XComponent.XEventHandler(this.OnLoadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_SwapItem, new XComponent.XEventHandler(this.OnSwapItem));
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnItemChangedFinished));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x06009B3A RID: 39738 RVA: 0x0018B030 File Offset: 0x00189230
		public int SlottingNeedMoney(int slot)
		{
			int num = slot - XEmblemDocument.Position_PaySkillStart;
			bool flag = num < 0 || num >= this.m_needMoneyList.Count;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = this.m_needMoneyList[num];
			}
			return result;
		}

		// Token: 0x06009B3B RID: 39739 RVA: 0x0018B078 File Offset: 0x00189278
		public int IsCanSlotting(int slot)
		{
			bool flag = XEmblemDocument.HadSlottingNum >= XEmblemDocument.Position_PaySkillEnd - XEmblemDocument.Position_PaySkillStart;
			int result;
			if (flag)
			{
				result = 2;
			}
			else
			{
				int num = slot - XEmblemDocument.Position_PaySkillStart + 1;
				bool flag2 = num == 1;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					bool flag3 = num == XEmblemDocument.HadSlottingNum + 1;
					if (flag3)
					{
						result = 0;
					}
					else
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06009B3C RID: 39740 RVA: 0x0018B0D4 File Offset: 0x001892D4
		public void ReqEmbleSlotting(ulong slot)
		{
			RpcC2G_BuyExtraSkillEmblemSlot rpc = new RpcC2G_BuyExtraSkillEmblemSlot();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009B3D RID: 39741 RVA: 0x0018B0F4 File Offset: 0x001892F4
		public void OnEmbleSlottingBack(BuyExtraSkillEmblemSlotRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XEmblemDocument.HadSlottingNum = (int)oRes.extraSkillEmblemSlot;
					bool flag3 = this._EquipHandler != null && this._EquipHandler.IsVisible();
					if (flag3)
					{
						this._EquipHandler.ShowEquipments();
						this._EquipHandler.PlayBuySlotFx(XEmblemDocument.HadSlottingNum + XEmblemDocument.Position_PaySkillStart - 1);
					}
				}
			}
		}

		// Token: 0x06009B3E RID: 39742 RVA: 0x0018B1A4 File Offset: 0x001893A4
		public void InitWhenCreateRole(uint playerLevel)
		{
			this.UpdateEquipLockState(playerLevel);
			this.UpdateEquipSlottingState();
			this.UpdateRedPoints(playerLevel);
		}

		// Token: 0x06009B3F RID: 39743 RVA: 0x0018B1C0 File Offset: 0x001893C0
		public void UpdateEquipLockState(uint playerLevel)
		{
			for (int i = XEmblemDocument.Position_TotalStart; i < XEmblemDocument.Position_TotalEnd; i++)
			{
				bool flag = playerLevel >= this.emblemSlotUnlockLevel[i];
				if (flag)
				{
					this.EquipLock[i].LevelIsdOpen = true;
				}
				else
				{
					this.EquipLock[i].LevelIsdOpen = false;
				}
			}
		}

		// Token: 0x06009B40 RID: 39744 RVA: 0x0018B220 File Offset: 0x00189420
		public void UpdateEquipSlottingState()
		{
			for (int i = XEmblemDocument.Position_TotalStart; i < XEmblemDocument.Position_NoPaySkillEnd; i++)
			{
				this.EquipLock[i].HadSlotting = true;
			}
			for (int j = XEmblemDocument.Position_PaySkillStart; j < XEmblemDocument.Position_PaySkillEnd; j++)
			{
				int num = j - XEmblemDocument.Position_PaySkillStart;
				bool flag = XEmblemDocument.HadSlottingNum > num;
				if (flag)
				{
					this.EquipLock[j].HadSlotting = true;
				}
				else
				{
					this.EquipLock[j].HadSlotting = false;
				}
			}
		}

		// Token: 0x06009B41 RID: 39745 RVA: 0x0018B2AC File Offset: 0x001894AC
		public List<XItem> GetEmblemItems()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM);
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			bool flag = this.currentEmblemUID > 0UL;
			if (flag)
			{
				foreach (XItem xitem in this.m_ItemList)
				{
					bool flag2 = this.currentEmblemUID == xitem.uid;
					if (flag2)
					{
						this.m_ItemList.Remove(xitem);
						break;
					}
				}
			}
			return this.m_ItemList;
		}

		// Token: 0x17002E32 RID: 11826
		// (get) Token: 0x06009B42 RID: 39746 RVA: 0x0018B374 File Offset: 0x00189574
		public bool IsEquipEmblem
		{
			get
			{
				XBodyBag emblemBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag;
				for (int i = 0; i < emblemBag.Length; i++)
				{
					bool flag = emblemBag[i] != null && emblemBag[i].itemID != 0 && (ulong)emblemBag[i].type == (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM));
					if (flag)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06009B43 RID: 39747 RVA: 0x0018B3F0 File Offset: 0x001895F0
		public bool IsEquipThisSkillEmblem(uint skillHash, ref List<SkillEmblem.RowData> row)
		{
			row.Clear();
			XBodyBag emblemBag = XBagDocument.BagDoc.EmblemBag;
			bool flag = emblemBag == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = XEmblemDocument.Position_SkillStart;
				while (i < XEmblemDocument.Position_SkillEnd)
				{
					bool flag2 = emblemBag[i] != null && emblemBag[i].uid > 0UL;
					if (flag2)
					{
						SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)emblemBag[i].itemID);
						bool flag3 = emblemSkillConf == null;
						if (!flag3)
						{
							uint skillID = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(emblemSkillConf.SkillName, 0U);
							bool flag4 = skillID == skillHash;
							if (flag4)
							{
								row.Add(emblemSkillConf);
							}
							bool flag5 = emblemSkillConf.ExSkillScript != string.Empty;
							if (flag5)
							{
								skillID = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(emblemSkillConf.ExSkillScript, 0U);
								bool flag6 = skillID == skillHash;
								if (flag6)
								{
									bool flag7 = !row.Contains(emblemSkillConf);
									if (flag7)
									{
										row.Add(emblemSkillConf);
									}
								}
							}
						}
					}
					IL_F2:
					i++;
					continue;
					goto IL_F2;
				}
				result = (row.Count > 0);
			}
			return result;
		}

		// Token: 0x06009B44 RID: 39748 RVA: 0x0018B518 File Offset: 0x00189718
		public List<ShowAttriData> AttriDataList()
		{
			this.ShowAttriDataLst = new List<ShowAttriData>();
			XBodyBag emblemBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag;
			for (int i = XEmblemDocument.Position_TotalStart; i < XEmblemDocument.Position_TotalEnd; i++)
			{
				bool flag = emblemBag[i] == null || emblemBag[i].itemID == 0 || emblemBag[i].Type != ItemType.EMBLEM;
				if (!flag)
				{
					XEmblemItem xemblemItem = emblemBag[i] as XEmblemItem;
					EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(xemblemItem.itemID);
					bool flag2 = emblemConf != null;
					if (flag2)
					{
						bool flag3 = XEmblemDocument.IsSkillEmblem(emblemConf.EmblemType);
						if (flag3)
						{
							ShowAttriData showAttriData = new ShowAttriData(emblemConf);
							this.ShowAttriDataLst.Add(showAttriData);
						}
						else
						{
							XAttrItem xattrItem = emblemBag[i] as XAttrItem;
							for (int j = 0; j < xattrItem.changeAttr.Count; j++)
							{
								ShowAttriData showAttriData = this.FindTheSameAttri(xattrItem.changeAttr[j].AttrID);
								bool flag4 = showAttriData == null;
								if (flag4)
								{
									showAttriData = new ShowAttriData((uint)emblemBag[i].itemID, xattrItem.changeAttr[j]);
									this.ShowAttriDataLst.Add(showAttriData);
								}
								else
								{
									showAttriData.Add(xattrItem.changeAttr[j].AttrValue);
								}
							}
						}
					}
				}
			}
			return this.ShowAttriDataLst;
		}

		// Token: 0x06009B45 RID: 39749 RVA: 0x0018B6B0 File Offset: 0x001898B0
		public ShowAttriData FindTheSameAttri(uint nameId)
		{
			for (int i = 0; i < this.ShowAttriDataLst.Count; i++)
			{
				bool flag = this.ShowAttriDataLst[i].NameId == nameId;
				if (flag)
				{
					return this.ShowAttriDataLst[i];
				}
			}
			return null;
		}

		// Token: 0x06009B46 RID: 39750 RVA: 0x0018B708 File Offset: 0x00189908
		public void RefreshBag()
		{
			bool flag = this._BagHandler != null && this._BagHandler.IsVisible();
			if (flag)
			{
				this._BagHandler.Refresh();
			}
		}

		// Token: 0x06009B47 RID: 39751 RVA: 0x0018B73C File Offset: 0x0018993C
		public void ShowIdentifySucEffect()
		{
			bool flag = this._BagHandler != null && this._BagHandler.IsVisible();
			if (flag)
			{
				this._BagHandler.ShowEmblemIdentifyEffect();
			}
		}

		// Token: 0x06009B48 RID: 39752 RVA: 0x0018B770 File Offset: 0x00189970
		public bool OnLoadEquip(XEventArgs args)
		{
			bool flag = this._EquipHandler == null || !this._EquipHandler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
				DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(true);
				this._bShouldUpdateRedPoints = true;
				this._EquipHandler.SetSlot(xloadEquipEventArgs.slot, xloadEquipEventArgs.item, null);
				result = true;
			}
			return result;
		}

		// Token: 0x06009B49 RID: 39753 RVA: 0x0018B7D8 File Offset: 0x001899D8
		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			bool flag = this._BagHandler == null || !this._BagHandler.active;
			bool result;
			if (flag)
			{
				bool bNew = xaddItemEventArgs.bNew;
				if (bNew)
				{
					this._bShouldUpdateRedPoints = (this._NewItems.AddItems(xaddItemEventArgs.items, false) || this._bShouldUpdateRedPoints);
				}
				result = false;
			}
			else
			{
				this._BagHandler.OnAddItem();
				result = true;
			}
			return result;
		}

		// Token: 0x06009B4A RID: 39754 RVA: 0x0018B850 File Offset: 0x00189A50
		public bool OnUnloadEquip(XEventArgs args)
		{
			bool flag = this._EquipHandler == null || !this._EquipHandler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
				DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(true);
				this._bShouldUpdateRedPoints = true;
				this._EquipHandler.SetSlot(xunloadEquipEventArgs.slot, null, null);
				result = true;
			}
			return result;
		}

		// Token: 0x06009B4B RID: 39755 RVA: 0x0018B8B4 File Offset: 0x00189AB4
		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this._bShouldUpdateRedPoints = (this._NewItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true) || this._bShouldUpdateRedPoints);
			bool flag = this._BagHandler == null || !this._BagHandler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._BagHandler.OnRemoveItem();
				foreach (ulong num in xremoveItemEventArgs.uids)
				{
					bool flag2 = num == DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.MainItemUID;
					if (flag2)
					{
						DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(false);
						break;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06009B4C RID: 39756 RVA: 0x0018B98C File Offset: 0x00189B8C
		public bool OnItemNumChanged(XEventArgs args)
		{
			bool flag = this._BagHandler == null || !this._BagHandler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
				this._BagHandler.OnItemCountChanged(xitemNumChangedEventArgs.item);
				result = true;
			}
			return result;
		}

		// Token: 0x06009B4D RID: 39757 RVA: 0x0018B9DC File Offset: 0x00189BDC
		public bool OnSwapItem(XEventArgs args)
		{
			bool flag = this._EquipHandler == null || !this._EquipHandler.active || this._BagHandler == null || !this._BagHandler.active;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSwapItemEventArgs xswapItemEventArgs = args as XSwapItemEventArgs;
				this._NewItems.RemoveItem(xswapItemEventArgs.itemNowOnBody.uid, xswapItemEventArgs.itemNowOnBody.Type, false);
				DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(true);
				this._EquipHandler.SetSlot(xswapItemEventArgs.slot, xswapItemEventArgs.itemNowOnBody, null);
				this._BagHandler.OnSwapItem(xswapItemEventArgs.itemNowOnBody, xswapItemEventArgs.itemNowInBag, xswapItemEventArgs.slot);
				this._bShouldUpdateRedPoints = true;
				result = true;
			}
			return result;
		}

		// Token: 0x06009B4E RID: 39758 RVA: 0x0018BA9C File Offset: 0x00189C9C
		public bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			XItem item = xupdateItemEventArgs.item;
			bool flag = item.Type != ItemType.EMBLEM;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._bShouldUpdateRedPoints = true;
				bool flag2 = this._EquipHandler == null || !this._EquipHandler.active || this._BagHandler == null || !this._BagHandler.active;
				if (flag2)
				{
					result = false;
				}
				else
				{
					int slot;
					bool flag3 = !XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag.GetItemPos(item.uid, out slot);
					if (flag3)
					{
						this._BagHandler.OnUpdateItem(item);
					}
					else
					{
						this._EquipHandler.SetSlot(slot, item, null);
					}
					bool flag4 = item.uid == DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.MainItemUID;
					if (flag4)
					{
						DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06009B4F RID: 39759 RVA: 0x0018BB8C File Offset: 0x00189D8C
		public bool OnItemChangedFinished(XEventArgs args)
		{
			bool bShouldUpdateRedPoints = this._bShouldUpdateRedPoints;
			if (bShouldUpdateRedPoints)
			{
				this.UpdateRedPoints();
				this._bShouldUpdateRedPoints = false;
			}
			return true;
		}

		// Token: 0x06009B50 RID: 39760 RVA: 0x0018BBBC File Offset: 0x00189DBC
		public bool IsEmblemMorePowerful(ulong uid)
		{
			return this.IsEmblemMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XEmblemItem, XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

		// Token: 0x06009B51 RID: 39761 RVA: 0x0018BC00 File Offset: 0x00189E00
		public bool IsEmblemMorePowerful(XEmblemItem emblem, uint playerLevel)
		{
			bool flag = emblem == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(emblem.itemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = (long)itemConf.ReqLevel > (long)((ulong)playerLevel);
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = XBagDocument.IsProfMatched(emblem.Prof);
						bool flag5 = !flag4;
						if (flag5)
						{
							result = false;
						}
						else
						{
							XBagDocument xbagDoc = XSingleton<XGame>.singleton.Doc.XBagDoc;
							XEmblemItem xemblemItem = XEmblemDocument.CheckEquipedEmblemsAttrs(xbagDoc.EmblemBag, emblem) as XEmblemItem;
							EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(emblem.itemID);
							bool flag6 = xemblemItem == null && emblemConf != null;
							if (flag6)
							{
								int num;
								bool firstEmptyEmblemSlot = XEmblemDocument.GetFirstEmptyEmblemSlot(xbagDoc.EmblemBag, emblemConf.EmblemType, out num);
								bool flag7 = !firstEmptyEmblemSlot;
								if (flag7)
								{
									result = false;
								}
								else
								{
									bool flag8 = XEmblemDocument.IsSkillEmblem(emblemConf.EmblemType);
									if (flag8)
									{
										XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
										SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)emblem.itemID);
										bool flag9 = emblemSkillConf != null && emblemSkillConf.SkillPPT > 0U;
										if (flag9)
										{
											List<string> skillNames = new List<string>
											{
												emblemSkillConf.SkillName,
												emblemSkillConf.ExSkillScript
											};
											result = specificDocument.IsEquipThisSkill(skillNames);
										}
										else
										{
											result = false;
										}
									}
									else
									{
										result = (xbagDoc.GetItemPPT(emblem, ItemAttrCompareType.IACT_SELF) > 0U);
									}
								}
							}
							else
							{
								bool flag10 = emblemConf != null && XEmblemDocument.IsSkillEmblem(emblemConf.EmblemType);
								if (flag10)
								{
									SkillEmblem.RowData emblemSkillConf2 = XEmblemDocument.GetEmblemSkillConf((uint)emblem.itemID);
									SkillEmblem.RowData emblemSkillConf3 = XEmblemDocument.GetEmblemSkillConf((uint)xemblemItem.itemID);
									bool flag11 = emblemSkillConf2 != null && emblemSkillConf3 != null;
									if (flag11)
									{
										XSkillTreeDocument specificDocument2 = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
										List<string> list = new List<string>
										{
											emblemSkillConf2.SkillName,
											emblemSkillConf2.ExSkillScript
										};
										bool flag12 = specificDocument2.IsEquipThisSkill(list);
										list.Clear();
										list.Add(emblemSkillConf3.SkillName);
										list.Add(emblemSkillConf3.ExSkillScript);
										bool flag13 = specificDocument2.IsEquipThisSkill(list);
										bool flag14 = flag12;
										if (flag14)
										{
											bool flag15 = flag13;
											result = (!flag15 || emblemSkillConf2.SkillPPT > emblemSkillConf3.SkillPPT);
										}
										else
										{
											result = false;
										}
									}
									else
									{
										XSingleton<XDebug>.singleton.AddErrorLog("skillRowData == null || equipedSkillRowData == null, id = ", emblem.itemID.ToString(), " and ", xemblemItem.itemID.ToString(), null, null);
										result = false;
									}
								}
								else
								{
									result = (xbagDoc.IsAttrMorePowerful(emblem, xemblemItem, ItemAttrCompareType.IACT_SELF) == ItemAttrCompareResult.IACR_LARGER);
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06009B52 RID: 39762 RVA: 0x0018BEA3 File Offset: 0x0018A0A3
		public void UpdateRedPoints()
		{
			this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

		// Token: 0x06009B53 RID: 39763 RVA: 0x0018BEBC File Offset: 0x0018A0BC
		public void UpdateRedPoints(uint playerLevel)
		{
			this._bCanBePowerful = false;
			List<XItem> emblemItems = this.GetEmblemItems();
			for (int i = 0; i < emblemItems.Count; i++)
			{
				XEmblemItem xemblemItem = emblemItems[i] as XEmblemItem;
				bool flag = xemblemItem == null;
				if (!flag)
				{
					bool flag2 = this.IsEmblemMorePowerful(xemblemItem, playerLevel);
					bool flag3 = flag2;
					if (flag3)
					{
						this.bCanBePowerful = true;
						break;
					}
				}
			}
			bool flag4 = !this._bCanBePowerful;
			if (flag4)
			{
				this.bCanBePowerful = false;
			}
		}

		// Token: 0x06009B54 RID: 39764 RVA: 0x0018BF3C File Offset: 0x0018A13C
		public void RefreshTips(ulong uid)
		{
			bool flag = this._BagHandler != null && this._BagHandler.IsVisible();
			if (flag)
			{
				this._BagHandler.RefreshTips(uid);
			}
		}

		// Token: 0x06009B55 RID: 39765 RVA: 0x0018BF74 File Offset: 0x0018A174
		public static bool GetFirstEmptyEmblemSlot(XBodyBag bag, short emblemType, out int pos)
		{
			XEmblemDocument specificDocument = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			EmblemSlotStatus[] equipLock = specificDocument.EquipLock;
			bool flag = !XEmblemDocument.IsSkillEmblem(emblemType);
			int num;
			int num2;
			if (flag)
			{
				num = XEmblemDocument.Position_AttrStart;
				num2 = XEmblemDocument.Position_AttrEnd;
			}
			else
			{
				num = XEmblemDocument.Position_SkillStart;
				num2 = XEmblemDocument.Position_PaySkillEnd;
			}
			for (int i = num; i < num2; i++)
			{
				bool flag2 = !equipLock[i - XEmblemDocument.Position_TotalStart].IsLock && (bag[i] == null || bag[i].uid == 0UL);
				if (flag2)
				{
					pos = i;
					return true;
				}
			}
			pos = XEmblemDocument.Position_TotalEnd;
			return false;
		}

		// Token: 0x06009B56 RID: 39766 RVA: 0x0018C02C File Offset: 0x0018A22C
		public static XItem CheckEquipedEmblemsAttrs(XBodyBag bag, XItem newItem)
		{
			XEmblemItem xemblemItem = newItem as XEmblemItem;
			bool flag = xemblemItem == null;
			XItem result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = xemblemItem.changeAttr.Count > 0;
				if (flag2)
				{
					XItemChangeAttr xitemChangeAttr = xemblemItem.changeAttr[0];
					int i = XEmblemDocument.Position_TotalStart;
					while (i < XEmblemDocument.Position_TotalEnd)
					{
						bool flag3 = bag[i] != null && bag[i].uid > 0UL;
						if (flag3)
						{
							XEmblemItem xemblemItem2 = bag[i] as XEmblemItem;
							bool flag4 = xemblemItem2 == null || xemblemItem2.changeAttr.Count == 0;
							if (!flag4)
							{
								XItemChangeAttr xitemChangeAttr2 = xemblemItem2.changeAttr[0];
								bool flag5 = xitemChangeAttr2.AttrID == xitemChangeAttr.AttrID;
								if (flag5)
								{
									return xemblemItem2;
								}
							}
						}
						IL_C9:
						i++;
						continue;
						goto IL_C9;
					}
				}
				else
				{
					SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)xemblemItem.itemID);
					bool flag6 = emblemSkillConf != null;
					if (flag6)
					{
						for (int j = XEmblemDocument.Position_TotalStart; j < XEmblemDocument.Position_TotalEnd; j++)
						{
							bool flag7 = bag[j] != null && bag[j].uid > 0UL;
							if (flag7)
							{
								XEmblemItem xemblemItem3 = bag[j] as XEmblemItem;
								bool flag8 = xemblemItem3 != null;
								if (flag8)
								{
									SkillEmblem.RowData emblemSkillConf2 = XEmblemDocument.GetEmblemSkillConf((uint)xemblemItem3.itemID);
									bool flag9 = emblemSkillConf2 != null;
									if (flag9)
									{
										bool flag10 = emblemSkillConf2.SkillScript == emblemSkillConf.SkillScript;
										if (flag10)
										{
											return xemblemItem3;
										}
									}
								}
							}
						}
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06009B57 RID: 39767 RVA: 0x0018C1E8 File Offset: 0x0018A3E8
		public static float GetSkillCDRatio(XBodyBag EmblemBag, uint skillID)
		{
			return XEmblemDocument.GetSkillEffectRatio(EmblemBag, skillID, 2U);
		}

		// Token: 0x06009B58 RID: 39768 RVA: 0x0018C204 File Offset: 0x0018A404
		public static float GetSkillDamageRatio(XBodyBag EmblemBag, uint skillID)
		{
			return XEmblemDocument.GetSkillEffectRatio(EmblemBag, skillID, 1U);
		}

		// Token: 0x06009B59 RID: 39769 RVA: 0x0018C220 File Offset: 0x0018A420
		public static float GetSkillEffectRatio(XBodyBag EmblemBag, uint skillID, uint type)
		{
			bool flag = EmblemBag == null || !XSingleton<XCombatEffectManager>.singleton.IsSkillEmblemEnabled() || skillID == 0U;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num = 0f;
				int i = XEmblemDocument.Position_SkillStart;
				while (i < XEmblemDocument.Position_SkillEnd)
				{
					bool flag2 = EmblemBag[i] != null && EmblemBag[i].uid > 0UL;
					if (flag2)
					{
						SkillEmblem.RowData byEmblemID = XEmblemDocument._emblemSkillReader.GetByEmblemID((uint)EmblemBag[i].itemID);
						bool flag3 = byEmblemID != null && (uint)byEmblemID.SkillType == type;
						if (flag3)
						{
							uint num2 = XSingleton<XCommon>.singleton.XHash(byEmblemID.SkillName);
							bool flag4 = num2 != skillID;
							if (flag4)
							{
								uint num3 = XSingleton<XCommon>.singleton.XHash(byEmblemID.ExSkillScript);
								bool flag5 = num3 != skillID;
								if (flag5)
								{
									goto IL_102;
								}
							}
							num = (float)byEmblemID.SkillPercent / 100f;
							bool flag6 = byEmblemID.SkillType != 1;
							if (flag6)
							{
								num = -num;
							}
							return num;
						}
					}
					IL_102:
					i++;
					continue;
					goto IL_102;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06009B5A RID: 39770 RVA: 0x0018C34C File Offset: 0x0018A54C
		public static bool IsSkillEmblem(short type)
		{
			return type > 1000;
		}

		// Token: 0x06009B5B RID: 39771 RVA: 0x0018C368 File Offset: 0x0018A568
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.UpdateEquipLockState(xplayerLevelChangedEventArgs.level);
			return true;
		}

		// Token: 0x06009B5C RID: 39772 RVA: 0x0018C38F File Offset: 0x0018A58F
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.InitWhenCreateRole(arg.PlayerInfo.Brief.level);
		}

		// Token: 0x040035A1 RID: 13729
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EmblemDocument");

		// Token: 0x040035A2 RID: 13730
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040035A3 RID: 13731
		public static int Position_AttrStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_START);

		// Token: 0x040035A4 RID: 13732
		public static int Position_AttrEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMIX);

		// Token: 0x040035A5 RID: 13733
		public static int Position_SkillStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMIX);

		// Token: 0x040035A6 RID: 13734
		public static int Position_SkillEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		// Token: 0x040035A7 RID: 13735
		public static int Position_NoPaySkillStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMIX);

		// Token: 0x040035A8 RID: 13736
		public static int Position_NoPaySkillEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMXIII);

		// Token: 0x040035A9 RID: 13737
		public static int Position_PaySkillStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMXIII);

		// Token: 0x040035AA RID: 13738
		public static int Position_PaySkillEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		// Token: 0x040035AB RID: 13739
		public static int Position_TotalStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_START);

		// Token: 0x040035AC RID: 13740
		public static int Position_TotalEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		// Token: 0x040035AD RID: 13741
		public EmblemBagView _BagHandler = null;

		// Token: 0x040035AE RID: 13742
		public EmblemEquipView _EquipHandler = null;

		// Token: 0x040035AF RID: 13743
		private static SkillEmblem _emblemSkillReader = new SkillEmblem();

		// Token: 0x040035B0 RID: 13744
		private static string emblemSkillAttrFmt = "";

		// Token: 0x040035B1 RID: 13745
		private List<uint>[] _emblemLevels = new List<uint>[6];

		// Token: 0x040035B2 RID: 13746
		private List<int> m_needMoneyList = new List<int>();

		// Token: 0x040035B3 RID: 13747
		private EmblemSlotStatus[] m_equipLock;

		// Token: 0x040035B4 RID: 13748
		public List<uint> emblemSlotUnlockLevel = new List<uint>();

		// Token: 0x040035B5 RID: 13749
		public static int Level_Count = 0;

		// Token: 0x040035B6 RID: 13750
		public HashSet<ulong> selectedItems = new HashSet<ulong>();

		// Token: 0x040035B7 RID: 13751
		public uint selectedItemsTotalExp = 0U;

		// Token: 0x040035B8 RID: 13752
		public ulong currentEmblemUID = 0UL;

		// Token: 0x040035B9 RID: 13753
		private bool _bCanBePowerful = false;

		// Token: 0x040035BA RID: 13754
		private bool _bShouldUpdateRedPoints = false;

		// Token: 0x040035BB RID: 13755
		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		// Token: 0x040035BC RID: 13756
		private List<XItem> m_ItemList = new List<XItem>();

		// Token: 0x040035BD RID: 13757
		public static int HadSlottingNum = 0;

		// Token: 0x040035BE RID: 13758
		private List<ShowAttriData> ShowAttriDataLst;
	}
}
