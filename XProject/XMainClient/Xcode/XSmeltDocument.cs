using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSmeltDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSmeltDocument.uuID;
			}
		}

		public static XSmeltDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XSmeltDocument.uuID) as XSmeltDocument;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XSmeltDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_LoadEquip, new XComponent.XEventHandler(this.OnLoadEquip));
			base.RegisterEvent(XEventDefine.XEvent_UnloadEquip, new XComponent.XEventHandler(this.OnUnloadEquip));
			base.RegisterEvent(XEventDefine.XEvent_SwapItem, new XComponent.XEventHandler(this.OnSwapItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnItemChangedFinished));
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.Clear();
			this.View = null;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.MesIsBack = true;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.UpdateUi(false);
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshUi(false);
			}
			return true;
		}

		public bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshUi(false);
			}
			this.m_emblemRedDotDataIsDirty = true;
			this.m_equipRedDotDataIsDirty = true;
			this.IsHadCanSmeltBodyEmblem();
			return true;
		}

		public bool OnSwapItem(XEventArgs args)
		{
			XSwapItemEventArgs xswapItemEventArgs = args as XSwapItemEventArgs;
			bool flag = xswapItemEventArgs.itemNowOnBody.Type == ItemType.EMBLEM;
			if (flag)
			{
				this.m_emblemRedDotDataIsDirty = true;
			}
			else
			{
				bool flag2 = xswapItemEventArgs.itemNowOnBody.Type == ItemType.EQUIP;
				if (flag2)
				{
					this.m_equipRedDotDataIsDirty = true;
				}
			}
			return true;
		}

		public bool OnLoadEquip(XEventArgs args)
		{
			XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
			bool flag = xloadEquipEventArgs.item.Type == ItemType.EMBLEM;
			if (flag)
			{
				this.m_emblemRedDotDataIsDirty = true;
			}
			else
			{
				bool flag2 = xloadEquipEventArgs.item.Type == ItemType.EQUIP;
				if (flag2)
				{
					this.m_equipRedDotDataIsDirty = true;
				}
			}
			return true;
		}

		public bool OnUnloadEquip(XEventArgs args)
		{
			XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
			bool flag = xunloadEquipEventArgs.item.Type == ItemType.EMBLEM;
			if (flag)
			{
				this.m_emblemRedDotDataIsDirty = true;
			}
			else
			{
				bool flag2 = xunloadEquipEventArgs.item.Type == ItemType.EQUIP;
				if (flag2)
				{
					this.m_equipRedDotDataIsDirty = true;
				}
			}
			return true;
		}

		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
			{
				bool flag = xaddItemEventArgs.items[i].Type == ItemType.EMBLEM;
				if (flag)
				{
					this.m_emblemRedDotDataIsDirty = true;
				}
				else
				{
					bool flag2 = xaddItemEventArgs.items[i].Type == ItemType.EQUIP;
					if (flag2)
					{
						this.m_equipRedDotDataIsDirty = true;
					}
				}
			}
			this.IsHadCanSmeltBodyEmblem();
			return true;
		}

		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			for (int i = 0; i < xremoveItemEventArgs.ids.Count; i++)
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID((ulong)((long)xremoveItemEventArgs.ids[i]));
				bool flag = itemByUID == null;
				if (!flag)
				{
					bool flag2 = itemByUID.Type == ItemType.EMBLEM;
					if (flag2)
					{
						this.m_emblemRedDotDataIsDirty = true;
					}
					else
					{
						bool flag3 = itemByUID.Type == ItemType.EQUIP;
						if (flag3)
						{
							this.m_equipRedDotDataIsDirty = true;
						}
					}
				}
			}
			this.IsHadCanSmeltBodyEmblem();
			return true;
		}

		public bool OnItemChangedFinished(XEventArgs args)
		{
			this.m_emblemRedDotDataIsDirty = true;
			this.m_equipRedDotDataIsDirty = true;
			bool emblemRedDotDataIsDirty = this.m_emblemRedDotDataIsDirty;
			if (emblemRedDotDataIsDirty)
			{
				this.IsHadCanSmeltBodyEmblem();
				this.m_emblemRedDotDataIsDirty = false;
			}
			bool equipRedDotDataIsDirty = this.m_equipRedDotDataIsDirty;
			if (equipRedDotDataIsDirty)
			{
				this.IsHadCanSmeltBodyEquip();
				XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
				specificDocument.UpdateRedPoints();
				this.m_equipRedDotDataIsDirty = false;
			}
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.UpdateUi(false);
			}
			return true;
		}

		public void ReqSmelt()
		{
			uint num = 0U;
			bool flag = this.m_smeltAttrList != null && (long)this.m_smeltAttrList.Count > (long)((ulong)num);
			if (flag)
			{
				num = this.m_smeltAttrList[this.SelectIndex].Index;
			}
			RpcC2G_SmeltItem rpcC2G_SmeltItem = new RpcC2G_SmeltItem();
			rpcC2G_SmeltItem.oArg.uid = this.m_curUid;
			rpcC2G_SmeltItem.oArg.slot = num;
			rpcC2G_SmeltItem.oArg.isForge = this.m_smeltAttrList[this.SelectIndex].IsForge;
			this.SetLastAttr(this.SelectIndex);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SmeltItem);
			this.MesIsBack = false;
		}

		public void ReqSmeltReturn(ulong uid)
		{
			RpcC2G_ReturnSmeltStone rpcC2G_ReturnSmeltStone = new RpcC2G_ReturnSmeltStone();
			rpcC2G_ReturnSmeltStone.oArg.uid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReturnSmeltStone);
		}

		public void OnSmeltBack(SmeltItemRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				this.MesIsBack = true;
			}
			else
			{
				this.m_smeltAttrList[this.SelectIndex].SmeltResult = oRes.result;
				bool flag2 = (ulong)this.m_smeltAttrList[this.SelectIndex].SmeltResult > (ulong)((long)this.m_smeltAttrList[this.SelectIndex].LastValue);
				if (flag2)
				{
					this.m_smeltAttrList[this.SelectIndex].RealValue = oRes.result;
					this.m_smeltAttrList[this.SelectIndex].IsReplace = true;
					this.RefreshData();
				}
				else
				{
					this.m_smeltAttrList[this.SelectIndex].IsReplace = false;
				}
				bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler.IsVisible();
				if (flag3)
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler.ShowEquipments();
				}
				bool flag4 = this.View != null && this.View.IsVisible();
				if (flag4)
				{
					this.View.RefreshUi(true);
				}
				this.MesIsBack = true;
			}
		}

		public void SmeltReturnBack(ReturnSmeltStoneRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		public List<int> MorePowerfulEquips
		{
			get
			{
				return this.m_morePowerfulEquips;
			}
		}

		private List<int> EquipAttackSmeltExchanged
		{
			get
			{
				bool flag = this.m_equipAttackSmeltExchanged == null;
				if (flag)
				{
					this.m_equipAttackSmeltExchanged = XSingleton<XGlobalConfig>.singleton.GetIntList("EquipAttackSmeltExchanged");
				}
				return this.m_equipAttackSmeltExchanged;
			}
		}

		private List<int> EquipDefenseSmeltExchanged
		{
			get
			{
				bool flag = this.m_equipDefenseSmeltExchanged == null;
				if (flag)
				{
					this.m_equipDefenseSmeltExchanged = XSingleton<XGlobalConfig>.singleton.GetIntList("EquipDefenseSmeltExchanged");
				}
				return this.m_equipDefenseSmeltExchanged;
			}
		}

		private List<int> EmblemSmeltExchanged
		{
			get
			{
				bool flag = this.m_emblemSmeltExchanged == null;
				if (flag)
				{
					this.m_emblemSmeltExchanged = XSingleton<XGlobalConfig>.singleton.GetIntList("EmblemSmeltExchanged");
				}
				return this.m_emblemSmeltExchanged;
			}
		}

		public bool EmblemCanBePower
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Emblem_Smelting) & this.emblemCanBePower;
			}
			set
			{
				bool flag = this.emblemCanBePower != value;
				if (flag)
				{
					this.emblemCanBePower = value;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Char_Emblem, true);
				}
			}
		}

		public List<XTuple<int, int>> GetShouldShowItems(int baseItemId, int needCount, ref int totalNum)
		{
			totalNum = 0;
			List<XTuple<int, int>> list = new List<XTuple<int, int>>();
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.CurUid);
			bool flag = itemByUID == null;
			List<XTuple<int, int>> result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find uid : ", this.CurUid.ToString(), null, null, null, null);
				result = list;
			}
			else
			{
				bool flag2 = itemByUID.Type == ItemType.EQUIP;
				bool flag3 = flag2;
				if (flag3)
				{
					bool flag4 = this.ExchangedDataDispose(this.EquipAttackSmeltExchanged, baseItemId, needCount, ref list, ref totalNum);
					bool flag5 = !flag4;
					if (flag5)
					{
						this.ExchangedDataDispose(this.EquipDefenseSmeltExchanged, baseItemId, needCount, ref list, ref totalNum);
					}
				}
				else
				{
					this.ExchangedDataDispose(this.EmblemSmeltExchanged, baseItemId, needCount, ref list, ref totalNum);
				}
				bool flag6 = totalNum < needCount;
				if (flag6)
				{
					list.Clear();
					totalNum = (int)XBagDocument.BagDoc.GetItemCount(baseItemId);
					XTuple<int, int> item = new XTuple<int, int>(baseItemId, totalNum);
					list.Add(item);
				}
				else
				{
					totalNum = needCount;
				}
				result = list;
			}
			return result;
		}

		private bool ExchangedDataDispose(List<int> sourceList, int baseItemId, int needCount, ref List<XTuple<int, int>> lst, ref int totalNum)
		{
			bool flag = false;
			lst.Clear();
			int i = 0;
			while (i < sourceList.Count)
			{
				int num = sourceList[i];
				bool flag2 = num == baseItemId;
				if (flag2)
				{
					flag = true;
				}
				bool flag3 = flag;
				if (flag3)
				{
					int num2 = (int)XBagDocument.BagDoc.GetItemCount(num);
					bool flag4 = num2 == 0;
					if (!flag4)
					{
						bool flag5 = totalNum + num2 > needCount;
						if (flag5)
						{
							num2 = needCount - totalNum;
						}
						totalNum += num2;
						XTuple<int, int> item = new XTuple<int, int>(num, num2);
						lst.Add(item);
						bool flag6 = totalNum >= needCount;
						if (flag6)
						{
							break;
						}
					}
				}
				IL_8D:
				i++;
				continue;
				goto IL_8D;
			}
			return flag;
		}

		public bool EquipCanBePower
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Smelting) & this.equipCanBePower;
			}
			set
			{
				bool flag = this.equipCanBePower != value;
				if (flag)
				{
					this.equipCanBePower = value;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Item_Equip, true);
				}
			}
		}

		public ulong CurUid
		{
			get
			{
				return this.m_curUid;
			}
			set
			{
				this.m_curUid = value;
				bool flag = this.m_curUid > 0UL;
				if (flag)
				{
					this.Init();
				}
			}
		}

		private void Init()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_curUid);
			bool flag = itemByUID == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find uid : ", this.m_curUid.ToString(), null, null, null, null);
			}
			else
			{
				this.m_smeltAttrList = new List<SmeltAttr>();
				bool flag2 = itemByUID.Type == ItemType.EQUIP;
				if (flag2)
				{
					XEquipItem item = itemByUID as XEquipItem;
					this.GetEquipSmeltAttr(item);
				}
				else
				{
					bool flag3 = itemByUID.Type == ItemType.EMBLEM;
					if (flag3)
					{
						XAttrItem item2 = itemByUID as XAttrItem;
						this.GetEmblemSmeltAttr(item2);
					}
				}
			}
		}

		private void GetEquipSmeltAttr(XEquipItem item)
		{
			EquipSlotAttrDatas attrData = XCharacterEquipDocument.RandomAttrMgr.GetAttrData((uint)item.itemID);
			EquipSlotAttrDatas attrData2 = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)item.itemID);
			int count = item.randAttrInfo.RandAttr.Count;
			List<XItemChangeAttr> list = new List<XItemChangeAttr>();
			for (int i = 0; i < count; i++)
			{
				list.Add(item.randAttrInfo.RandAttr[i]);
			}
			for (int j = 0; j < item.forgeAttrInfo.ForgeAttr.Count; j++)
			{
				list.Add(item.forgeAttrInfo.ForgeAttr[j]);
			}
			for (int k = 0; k < list.Count; k++)
			{
				bool flag = list[k].AttrID <= 0U;
				if (!flag)
				{
					bool flag2 = XAttributeCommon.IsPercentRange((int)list[k].AttrID);
					if (!flag2)
					{
						bool flag3 = k < count;
						EquipSlotAttrDatas equipSlotAttrDatas;
						int num;
						if (flag3)
						{
							equipSlotAttrDatas = attrData;
							num = k + 1;
						}
						else
						{
							equipSlotAttrDatas = attrData2;
							num = count - k + 1;
						}
						bool flag4 = equipSlotAttrDatas == null;
						if (!flag4)
						{
							EquipAttrData attrData3 = equipSlotAttrDatas.GetAttrData(num, list[k]);
							bool flag5 = attrData3 != null;
							if (flag5)
							{
								SmeltAttr smeltAttr = new SmeltAttr(attrData3.AttrId, (uint)attrData3.RangValue.Min, (uint)attrData3.RangValue.Max, (uint)(num - 1), attrData3.Slot, k >= count);
								smeltAttr.IsCanSmelt = attrData3.IsCanSmelt;
								smeltAttr.RealValue = list[k].AttrValue;
								smeltAttr.ColorStr = equipSlotAttrDatas.GetColor((int)smeltAttr.Slot, list[k]);
								this.m_smeltAttrList.Add(smeltAttr);
							}
							else
							{
								XSingleton<XDebug>.singleton.AddGreenLog("data inconformity", null, null, null, null, null);
							}
						}
					}
				}
			}
		}

		private void GetEmblemSmeltAttr(XAttrItem item)
		{
			int num;
			int endIndex;
			XEquipCreateDocument.GetEmblemAttrDataByID((uint)item.itemID, out num, out endIndex);
			bool flag = num >= 0;
			if (flag)
			{
				for (int i = 0; i < item.changeAttr.Count; i++)
				{
					XItemChangeAttr xitemChangeAttr = item.changeAttr[i];
					bool flag2 = XAttributeCommon.IsPercentRange((int)xitemChangeAttr.AttrID);
					if (!flag2)
					{
						AttributeEmblem.RowData rowData = XEquipCreateDocument.FindAttr(num, endIndex, i, xitemChangeAttr.AttrID);
						bool flag3 = rowData != null;
						if (flag3)
						{
							SmeltAttr smeltAttr = new SmeltAttr((uint)rowData.AttrID, rowData.Range[0], rowData.Range[1], (uint)i, (uint)rowData.Position, false);
							smeltAttr.RealValue = xitemChangeAttr.AttrValue;
							smeltAttr.ColorStr = XEquipCreateDocument.GetPrefixColor(rowData, xitemChangeAttr.AttrValue);
							this.m_smeltAttrList.Add(smeltAttr);
						}
						else
						{
							XSingleton<XDebug>.singleton.AddErrorLog("data inconformity", null, null, null, null, null);
						}
					}
				}
			}
		}

		private void RefreshData()
		{
			SmeltAttr smeltAttr = this.GetSmeltAttr(this.SelectIndex);
			bool flag = smeltAttr == null;
			if (!flag)
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_curUid);
				bool flag2 = itemByUID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("not find uid : ", this.m_curUid.ToString(), null, null, null, null);
				}
				else
				{
					bool flag3 = itemByUID.Type == ItemType.EQUIP;
					if (flag3)
					{
						XItemChangeAttr attr = default(XItemChangeAttr);
						attr.AttrID = smeltAttr.AttrID;
						attr.AttrValue = smeltAttr.RealValue;
						this.IsHadCanSmeltBodyEquip();
						bool flag4 = !smeltAttr.IsForge;
						EquipSlotAttrDatas attrData;
						if (flag4)
						{
							attrData = XCharacterEquipDocument.RandomAttrMgr.GetAttrData((uint)itemByUID.itemID);
						}
						else
						{
							attrData = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)itemByUID.itemID);
						}
						bool flag5 = attrData == null;
						if (flag5)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("not find id : ", itemByUID.itemID.ToString(), null, null, null, null);
						}
						else
						{
							smeltAttr.ColorStr = attrData.GetColor((int)smeltAttr.Slot, attr);
						}
					}
					else
					{
						this.IsHadCanSmeltBodyEmblem();
						int num;
						int endIndex;
						XEquipCreateDocument.GetEmblemAttrDataByID((uint)itemByUID.itemID, out num, out endIndex);
						bool flag6 = num >= 0;
						if (flag6)
						{
							smeltAttr.ColorStr = XEquipCreateDocument.GetPrefixColor(num, endIndex, (int)smeltAttr.Index, smeltAttr.AttrID, smeltAttr.RealValue);
						}
					}
				}
			}
		}

		public List<SmeltAttr> SmeltAttrList
		{
			get
			{
				return this.m_smeltAttrList;
			}
		}

		public SmeltAttr GetSmeltAttr(int index)
		{
			bool flag = this.m_smeltAttrList == null || this.m_smeltAttrList.Count == 0;
			SmeltAttr result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = this.m_smeltAttrList.Count > index;
				if (flag2)
				{
					result = this.m_smeltAttrList[index];
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("data is null", null, null, null, null, null);
					result = null;
				}
			}
			return result;
		}

		public void Clear()
		{
			this.SelectIndex = 0;
			this.m_curUid = 0UL;
			this.SmeltResult = null;
			this.MesIsBack = true;
		}

		public void SelectEquip(ulong uid)
		{
			bool flag = uid == 0UL;
			if (!flag)
			{
				bool flag2 = uid == this.m_curUid;
				if (!flag2)
				{
					XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
					bool flag3 = itemByUID == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("cannot find this item uid = {0}", uid), null, null, null, null, null);
					}
					else
					{
						bool flag4 = itemByUID.Type == ItemType.EMBLEM;
						if (flag4)
						{
							XEmblemItem xemblemItem = itemByUID as XEmblemItem;
							bool bIsSkillEmblem = xemblemItem.bIsSkillEmblem;
							if (bIsSkillEmblem)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SkillEmblemCannotSmelt"), "fece00");
								return;
							}
							bool flag5 = xemblemItem.changeAttr.Count <= 0;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NoCanSmelt"), "fece00");
								return;
							}
							ItemList.RowData itemConf = XBagDocument.GetItemConf(itemByUID.itemID);
							int @int = XSingleton<XGlobalConfig>.singleton.GetInt("SmeltEmblemMinLevel");
							bool flag6 = itemConf == null || (int)itemConf.ReqLevel < @int;
							if (flag6)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("EmblemSmeltLevel"), @int), "fece00");
								return;
							}
						}
						else
						{
							bool flag7 = itemByUID.Type == ItemType.EQUIP;
							if (flag7)
							{
								XEquipItem xequipItem = itemByUID as XEquipItem;
								bool flag8 = xequipItem.randAttrInfo.RandAttr.Count <= 0 && xequipItem.forgeAttrInfo.ForgeAttr.Count <= 0;
								if (flag8)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NoCanSmelt"), "fece00");
									return;
								}
								EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
								bool flag9 = equipConf == null || !equipConf.IsCanSmelt;
								if (flag9)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NoCanSmelt"), "fece00");
									return;
								}
								ItemList.RowData itemConf2 = XBagDocument.GetItemConf(itemByUID.itemID);
								int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("SmeltEquipMinLevel");
								bool flag10 = itemConf2 == null || (int)itemConf2.ReqLevel < int2;
								if (flag10)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("EquipSmeltLevel"), int2), "fece00");
									return;
								}
							}
						}
						this.CurUid = uid;
						bool flag11 = !DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
						if (!flag11)
						{
							bool flag12 = this.View != null && this.View.IsVisible();
							if (flag12)
							{
								this.View.ShowUi();
							}
							else
							{
								DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowRightPopView(DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._SmeltMainHandler);
							}
							bool flag13 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
							if (flag13)
							{
								DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(uid);
							}
						}
					}
				}
			}
		}

		public void SetLastAttr(int index)
		{
			bool flag = this.m_smeltAttrList == null || index >= this.m_smeltAttrList.Count;
			if (!flag)
			{
				this.m_smeltAttrList[index].LastValue = (int)this.m_smeltAttrList[index].RealValue;
			}
		}

		public SeqListRef<uint> GetNeedItem()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_curUid);
			bool flag = itemByUID == null;
			SeqListRef<uint> result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find uid : ", this.m_curUid.ToString(), null, null, null, null);
				result = default(SeqListRef<uint>);
			}
			else
			{
				result = this.NeedItem(itemByUID);
			}
			return result;
		}

		public uint GetNeedGold()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_curUid);
			bool flag = itemByUID == null;
			uint result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find uid : ", this.m_curUid.ToString(), null, null, null, null);
				result = 0U;
			}
			else
			{
				result = this.NeedGold(itemByUID);
			}
			return result;
		}

		private SeqListRef<uint> NeedItem(XItem item)
		{
			bool flag = item.Type == ItemType.EQUIP;
			SeqListRef<uint> result;
			if (flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
				result = equipConf.SmeltNeedItem;
			}
			else
			{
				bool flag2 = item.Type == ItemType.EMBLEM;
				if (flag2)
				{
					EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(item.itemID);
					result = emblemConf.SmeltNeedItem;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("the maybe Type cannot be anything but EQUIP or EMBLEM! Please check the type of [CurType].", null, null, null, null, null);
					result = default(SeqListRef<uint>);
				}
			}
			return result;
		}

		private uint NeedGold(XItem item)
		{
			bool flag = item.Type == ItemType.EQUIP;
			uint result;
			if (flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
				result = equipConf.SmeltNeedMoney;
			}
			else
			{
				bool flag2 = item.Type == ItemType.EMBLEM;
				if (flag2)
				{
					EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(item.itemID);
					result = emblemConf.SmeltNeedMoney;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("the maybe Type cannot be anything but EQUIP or EMBLEM! Please check the type of [CurType].", null, null, null, null, null);
					result = 0U;
				}
			}
			return result;
		}

		public void InitEquipAndEmblemRedDot()
		{
			this.IsHadCanSmeltBodyEquip();
			this.IsHadCanSmeltBodyEmblem();
		}

		public void IsHadCanSmeltBodyEquip()
		{
			this.MorePowerfulEquips.Clear();
			for (int i = 0; i < XBagDocument.EquipMax; i++)
			{
				bool flag = XBagDocument.BagDoc.EquipBag[i] != null;
				if (flag)
				{
					bool flag2 = this.IsHadRedDot(XBagDocument.BagDoc.EquipBag[i]);
					if (flag2)
					{
						this.EquipCanBePower = true;
						return;
					}
				}
			}
			this.EquipCanBePower = false;
		}

		public void GetRedDotEquips()
		{
			this.MorePowerfulEquips.Clear();
			for (int i = 0; i < XBagDocument.EquipMax; i++)
			{
				bool flag = XBagDocument.BagDoc.EquipBag[i] != null;
				if (flag)
				{
					bool flag2 = this.IsHadRedDot(XBagDocument.BagDoc.EquipBag[i]);
					if (flag2)
					{
						this.MorePowerfulEquips.Add(i);
					}
				}
			}
		}

		public void IsHadCanSmeltBodyEmblem()
		{
			for (int i = 0; i < XBagDocument.EmblemMax; i++)
			{
				bool flag = XBagDocument.BagDoc.EmblemBag[i] != null;
				if (flag)
				{
					bool flag2 = this.IsHadRedDot(XBagDocument.BagDoc.EmblemBag[i]);
					if (flag2)
					{
						this.EmblemCanBePower = true;
						return;
					}
				}
			}
			this.EmblemCanBePower = false;
		}

		public bool IsHadRedDot(XItem item)
		{
			bool flag = item == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = itemConf.ItemQuality < 3;
					if (flag3)
					{
						result = false;
					}
					else
					{
						uint num = this.NeedGold(item);
						bool flag4 = XBagDocument.BagDoc.GetItemCount(1) < (ulong)num;
						if (flag4)
						{
							result = false;
						}
						else
						{
							uint @int = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("SmeltMultipleFactor");
							SeqListRef<uint> seqListRef = this.NeedItem(item);
							for (int i = 0; i < seqListRef.Count; i++)
							{
								ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)seqListRef[i, 0]);
								bool flag5 = itemCount < (ulong)(seqListRef[i, 1] * @int);
								if (flag5)
								{
									return false;
								}
							}
							bool flag6 = item.Type == ItemType.EQUIP;
							if (flag6)
							{
								XEquipItem xequipItem = item as XEquipItem;
								EquipSlotAttrDatas attrData = XCharacterEquipDocument.RandomAttrMgr.GetAttrData((uint)item.itemID);
								EquipSlotAttrDatas attrData2 = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)item.itemID);
								bool flag7 = attrData == null && attrData2 == null;
								if (flag7)
								{
									return false;
								}
								bool flag8 = xequipItem.randAttrInfo.RandAttr.Count <= 0 && xequipItem.forgeAttrInfo.ForgeAttr.Count <= 0;
								if (flag8)
								{
									return false;
								}
								int count = xequipItem.randAttrInfo.RandAttr.Count;
								List<XItemChangeAttr> list = new List<XItemChangeAttr>();
								for (int j = 0; j < count; j++)
								{
									list.Add(xequipItem.randAttrInfo.RandAttr[j]);
								}
								for (int k = 0; k < xequipItem.forgeAttrInfo.ForgeAttr.Count; k++)
								{
									list.Add(xequipItem.forgeAttrInfo.ForgeAttr[k]);
								}
								for (int l = 0; l < list.Count; l++)
								{
									bool flag9 = list[l].AttrID <= 0U;
									if (!flag9)
									{
										bool flag10 = XAttributeCommon.IsPercentRange((int)list[l].AttrID);
										if (!flag10)
										{
											bool flag11 = l < count;
											EquipSlotAttrDatas equipSlotAttrDatas;
											int slot;
											if (flag11)
											{
												equipSlotAttrDatas = attrData;
												slot = l + 1;
											}
											else
											{
												equipSlotAttrDatas = attrData2;
												slot = count - l + 1;
											}
											bool flag12 = equipSlotAttrDatas == null;
											if (!flag12)
											{
												string color = equipSlotAttrDatas.GetColor(slot, list[l]);
												bool flag13 = this.QuantityIsNeedRemind(color);
												if (flag13)
												{
													return true;
												}
											}
										}
									}
								}
							}
							else
							{
								bool flag14 = item.Type == ItemType.EMBLEM;
								if (flag14)
								{
									XAttrItem xattrItem = item as XAttrItem;
									bool flag15 = xattrItem == null || xattrItem.changeAttr.Count <= 0;
									if (flag15)
									{
										return false;
									}
									int num2;
									int endIndex;
									XEquipCreateDocument.GetEmblemAttrDataByID((uint)item.itemID, out num2, out endIndex);
									bool flag16 = num2 >= 0;
									if (flag16)
									{
										for (int m = 0; m < xattrItem.changeAttr.Count; m++)
										{
											XItemChangeAttr xitemChangeAttr = xattrItem.changeAttr[m];
											bool flag17 = XAttributeCommon.IsPercentRange((int)xitemChangeAttr.AttrID);
											if (!flag17)
											{
												string color = XEquipCreateDocument.GetPrefixColor(num2, endIndex, m, xitemChangeAttr.AttrID, xitemChangeAttr.AttrValue);
												bool flag18 = this.QuantityIsNeedRemind(color);
												if (flag18)
												{
													return true;
												}
											}
										}
									}
								}
							}
							result = false;
						}
					}
				}
			}
			return result;
		}

		public bool IsShowRedDot(SmeltAttr attr)
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.CurUid);
			bool flag = itemByUID == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(itemByUID.itemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = itemConf.ItemQuality < 3;
					if (flag3)
					{
						result = false;
					}
					else
					{
						uint needGold = this.GetNeedGold();
						bool flag4 = XBagDocument.BagDoc.GetItemCount(1) < (ulong)needGold;
						if (flag4)
						{
							result = false;
						}
						else
						{
							uint @int = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("SmeltMultipleFactor");
							SeqListRef<uint> needItem = this.GetNeedItem();
							for (int i = 0; i < needItem.Count; i++)
							{
								ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)needItem[i, 0]);
								bool flag5 = itemCount < (ulong)(needItem[i, 1] * @int);
								if (flag5)
								{
									return false;
								}
							}
							result = this.QuantityIsNeedRemind(attr.ColorStr);
						}
					}
				}
			}
			return result;
		}

		private bool QuantityIsNeedRemind(string color)
		{
			return color == XSingleton<XGlobalConfig>.singleton.GetValue("Quality0Color") || color == XSingleton<XGlobalConfig>.singleton.GetValue("Quality1Color") || color == XSingleton<XGlobalConfig>.singleton.GetValue("Quality2Color");
		}

		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_SMELTSTONE_EXCHANGED, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_SMELTSTONE_EXCHANGED_CONFIRM, 0, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSmeltDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public bool MesIsBack = true;

		private bool m_emblemRedDotDataIsDirty = false;

		private bool m_equipRedDotDataIsDirty = false;

		private bool emblemCanBePower = false;

		private bool equipCanBePower = false;

		private List<int> m_morePowerfulEquips = new List<int>();

		private List<int> m_equipAttackSmeltExchanged;

		private List<int> m_equipDefenseSmeltExchanged;

		private List<int> m_emblemSmeltExchanged;

		private ulong m_curUid = 0UL;

		private List<SmeltAttr> m_smeltAttrList;

		public SmeltMainHandler View = null;

		public int SelectIndex = 0;

		public uint[] SmeltResult = null;
	}
}
