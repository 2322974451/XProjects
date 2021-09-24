using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEmblemDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XEmblemDocument.uuID;
			}
		}

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

		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		public static bool isFullLevel(uint level)
		{
			return (ulong)level >= (ulong)((long)(XEmblemDocument.Level_Count - 1));
		}

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

		public static SkillEmblem.RowData GetEmblemSkillConf(uint dwItemId)
		{
			return XEmblemDocument._emblemSkillReader.GetByEmblemID(dwItemId);
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XEmblemDocument.AsyncLoader.AddTask("Table/SkillEmblem", XEmblemDocument._emblemSkillReader, false);
			XEmblemDocument.AsyncLoader.Execute(callback);
		}

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

		public void ReqEmbleSlotting(ulong slot)
		{
			RpcC2G_BuyExtraSkillEmblemSlot rpc = new RpcC2G_BuyExtraSkillEmblemSlot();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void InitWhenCreateRole(uint playerLevel)
		{
			this.UpdateEquipLockState(playerLevel);
			this.UpdateEquipSlottingState();
			this.UpdateRedPoints(playerLevel);
		}

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

		public void RefreshBag()
		{
			bool flag = this._BagHandler != null && this._BagHandler.IsVisible();
			if (flag)
			{
				this._BagHandler.Refresh();
			}
		}

		public void ShowIdentifySucEffect()
		{
			bool flag = this._BagHandler != null && this._BagHandler.IsVisible();
			if (flag)
			{
				this._BagHandler.ShowEmblemIdentifyEffect();
			}
		}

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

		public bool IsEmblemMorePowerful(ulong uid)
		{
			return this.IsEmblemMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XEmblemItem, XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

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

		public void UpdateRedPoints()
		{
			this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
		}

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

		public void RefreshTips(ulong uid)
		{
			bool flag = this._BagHandler != null && this._BagHandler.IsVisible();
			if (flag)
			{
				this._BagHandler.RefreshTips(uid);
			}
		}

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

		public static float GetSkillCDRatio(XBodyBag EmblemBag, uint skillID)
		{
			return XEmblemDocument.GetSkillEffectRatio(EmblemBag, skillID, 2U);
		}

		public static float GetSkillDamageRatio(XBodyBag EmblemBag, uint skillID)
		{
			return XEmblemDocument.GetSkillEffectRatio(EmblemBag, skillID, 1U);
		}

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

		public static bool IsSkillEmblem(short type)
		{
			return type > 1000;
		}

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.UpdateEquipLockState(xplayerLevelChangedEventArgs.level);
			return true;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.InitWhenCreateRole(arg.PlayerInfo.Brief.level);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EmblemDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static int Position_AttrStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_START);

		public static int Position_AttrEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMIX);

		public static int Position_SkillStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMIX);

		public static int Position_SkillEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		public static int Position_NoPaySkillStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMIX);

		public static int Position_NoPaySkillEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMXIII);

		public static int Position_PaySkillStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEMXIII);

		public static int Position_PaySkillEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		public static int Position_TotalStart = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_START);

		public static int Position_TotalEnd = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		public EmblemBagView _BagHandler = null;

		public EmblemEquipView _EquipHandler = null;

		private static SkillEmblem _emblemSkillReader = new SkillEmblem();

		private static string emblemSkillAttrFmt = "";

		private List<uint>[] _emblemLevels = new List<uint>[6];

		private List<int> m_needMoneyList = new List<int>();

		private EmblemSlotStatus[] m_equipLock;

		public List<uint> emblemSlotUnlockLevel = new List<uint>();

		public static int Level_Count = 0;

		public HashSet<ulong> selectedItems = new HashSet<ulong>();

		public uint selectedItemsTotalExp = 0U;

		public ulong currentEmblemUID = 0UL;

		private bool _bCanBePowerful = false;

		private bool _bShouldUpdateRedPoints = false;

		private XNewItemTipsMgr _NewItems = new XNewItemTipsMgr();

		private List<XItem> m_ItemList = new List<XItem>();

		public static int HadSlottingNum = 0;

		private List<ShowAttriData> ShowAttriDataLst;
	}
}
