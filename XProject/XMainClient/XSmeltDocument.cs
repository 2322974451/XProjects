using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C45 RID: 3141
	internal class XSmeltDocument : XDocComponent
	{
		// Token: 0x17003177 RID: 12663
		// (get) Token: 0x0600B215 RID: 45589 RVA: 0x00224848 File Offset: 0x00222A48
		public override uint ID
		{
			get
			{
				return XSmeltDocument.uuID;
			}
		}

		// Token: 0x17003178 RID: 12664
		// (get) Token: 0x0600B216 RID: 45590 RVA: 0x00224860 File Offset: 0x00222A60
		public static XSmeltDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XSmeltDocument.uuID) as XSmeltDocument;
			}
		}

		// Token: 0x0600B217 RID: 45591 RVA: 0x0022488B File Offset: 0x00222A8B
		public static void Execute(OnLoadedCallback callback = null)
		{
			XSmeltDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B218 RID: 45592 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600B219 RID: 45593 RVA: 0x0022489C File Offset: 0x00222A9C
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

		// Token: 0x0600B21A RID: 45594 RVA: 0x00224959 File Offset: 0x00222B59
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.Clear();
			this.View = null;
		}

		// Token: 0x0600B21B RID: 45595 RVA: 0x00224974 File Offset: 0x00222B74
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.MesIsBack = true;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.UpdateUi(false);
			}
		}

		// Token: 0x0600B21C RID: 45596 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600B21D RID: 45597 RVA: 0x002249B4 File Offset: 0x00222BB4
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

		// Token: 0x0600B21E RID: 45598 RVA: 0x002249F8 File Offset: 0x00222BF8
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

		// Token: 0x0600B21F RID: 45599 RVA: 0x00224A50 File Offset: 0x00222C50
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

		// Token: 0x0600B220 RID: 45600 RVA: 0x00224AA0 File Offset: 0x00222CA0
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

		// Token: 0x0600B221 RID: 45601 RVA: 0x00224AF0 File Offset: 0x00222CF0
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

		// Token: 0x0600B222 RID: 45602 RVA: 0x00224B40 File Offset: 0x00222D40
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

		// Token: 0x0600B223 RID: 45603 RVA: 0x00224BC4 File Offset: 0x00222DC4
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

		// Token: 0x0600B224 RID: 45604 RVA: 0x00224C58 File Offset: 0x00222E58
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

		// Token: 0x0600B225 RID: 45605 RVA: 0x00224CEC File Offset: 0x00222EEC
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

		// Token: 0x0600B226 RID: 45606 RVA: 0x00224D9C File Offset: 0x00222F9C
		public void ReqSmeltReturn(ulong uid)
		{
			RpcC2G_ReturnSmeltStone rpcC2G_ReturnSmeltStone = new RpcC2G_ReturnSmeltStone();
			rpcC2G_ReturnSmeltStone.oArg.uid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReturnSmeltStone);
		}

		// Token: 0x0600B227 RID: 45607 RVA: 0x00224DCC File Offset: 0x00222FCC
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

		// Token: 0x0600B228 RID: 45608 RVA: 0x00224F18 File Offset: 0x00223118
		public void SmeltReturnBack(ReturnSmeltStoneRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		// Token: 0x17003179 RID: 12665
		// (get) Token: 0x0600B229 RID: 45609 RVA: 0x00224F4C File Offset: 0x0022314C
		public List<int> MorePowerfulEquips
		{
			get
			{
				return this.m_morePowerfulEquips;
			}
		}

		// Token: 0x1700317A RID: 12666
		// (get) Token: 0x0600B22A RID: 45610 RVA: 0x00224F64 File Offset: 0x00223164
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

		// Token: 0x1700317B RID: 12667
		// (get) Token: 0x0600B22B RID: 45611 RVA: 0x00224FA0 File Offset: 0x002231A0
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

		// Token: 0x1700317C RID: 12668
		// (get) Token: 0x0600B22C RID: 45612 RVA: 0x00224FDC File Offset: 0x002231DC
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

		// Token: 0x1700317D RID: 12669
		// (get) Token: 0x0600B22E RID: 45614 RVA: 0x00225050 File Offset: 0x00223250
		// (set) Token: 0x0600B22D RID: 45613 RVA: 0x00225018 File Offset: 0x00223218
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

		// Token: 0x0600B22F RID: 45615 RVA: 0x00225078 File Offset: 0x00223278
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

		// Token: 0x0600B230 RID: 45616 RVA: 0x00225170 File Offset: 0x00223370
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

		// Token: 0x1700317E RID: 12670
		// (get) Token: 0x0600B232 RID: 45618 RVA: 0x00225260 File Offset: 0x00223460
		// (set) Token: 0x0600B231 RID: 45617 RVA: 0x00225228 File Offset: 0x00223428
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

		// Token: 0x1700317F RID: 12671
		// (get) Token: 0x0600B234 RID: 45620 RVA: 0x002252B4 File Offset: 0x002234B4
		// (set) Token: 0x0600B233 RID: 45619 RVA: 0x00225288 File Offset: 0x00223488
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

		// Token: 0x0600B235 RID: 45621 RVA: 0x002252CC File Offset: 0x002234CC
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

		// Token: 0x0600B236 RID: 45622 RVA: 0x00225364 File Offset: 0x00223564
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

		// Token: 0x0600B237 RID: 45623 RVA: 0x00225578 File Offset: 0x00223778
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

		// Token: 0x0600B238 RID: 45624 RVA: 0x0022568C File Offset: 0x0022388C
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

		// Token: 0x17003180 RID: 12672
		// (get) Token: 0x0600B239 RID: 45625 RVA: 0x002257F8 File Offset: 0x002239F8
		public List<SmeltAttr> SmeltAttrList
		{
			get
			{
				return this.m_smeltAttrList;
			}
		}

		// Token: 0x0600B23A RID: 45626 RVA: 0x00225810 File Offset: 0x00223A10
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

		// Token: 0x0600B23B RID: 45627 RVA: 0x0022587B File Offset: 0x00223A7B
		public void Clear()
		{
			this.SelectIndex = 0;
			this.m_curUid = 0UL;
			this.SmeltResult = null;
			this.MesIsBack = true;
		}

		// Token: 0x0600B23C RID: 45628 RVA: 0x0022589C File Offset: 0x00223A9C
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

		// Token: 0x0600B23D RID: 45629 RVA: 0x00225B88 File Offset: 0x00223D88
		public void SetLastAttr(int index)
		{
			bool flag = this.m_smeltAttrList == null || index >= this.m_smeltAttrList.Count;
			if (!flag)
			{
				this.m_smeltAttrList[index].LastValue = (int)this.m_smeltAttrList[index].RealValue;
			}
		}

		// Token: 0x0600B23E RID: 45630 RVA: 0x00225BDC File Offset: 0x00223DDC
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

		// Token: 0x0600B23F RID: 45631 RVA: 0x00225C3C File Offset: 0x00223E3C
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

		// Token: 0x0600B240 RID: 45632 RVA: 0x00225C94 File Offset: 0x00223E94
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

		// Token: 0x0600B241 RID: 45633 RVA: 0x00225D10 File Offset: 0x00223F10
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

		// Token: 0x0600B242 RID: 45634 RVA: 0x00225D81 File Offset: 0x00223F81
		public void InitEquipAndEmblemRedDot()
		{
			this.IsHadCanSmeltBodyEquip();
			this.IsHadCanSmeltBodyEmblem();
		}

		// Token: 0x0600B243 RID: 45635 RVA: 0x00225D94 File Offset: 0x00223F94
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

		// Token: 0x0600B244 RID: 45636 RVA: 0x00225E0C File Offset: 0x0022400C
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

		// Token: 0x0600B245 RID: 45637 RVA: 0x00225E80 File Offset: 0x00224080
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

		// Token: 0x0600B246 RID: 45638 RVA: 0x00225EEC File Offset: 0x002240EC
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

		// Token: 0x0600B247 RID: 45639 RVA: 0x002262A8 File Offset: 0x002244A8
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

		// Token: 0x0600B248 RID: 45640 RVA: 0x002263B0 File Offset: 0x002245B0
		private bool QuantityIsNeedRemind(string color)
		{
			return color == XSingleton<XGlobalConfig>.singleton.GetValue("Quality0Color") || color == XSingleton<XGlobalConfig>.singleton.GetValue("Quality1Color") || color == XSingleton<XGlobalConfig>.singleton.GetValue("Quality2Color");
		}

		// Token: 0x0600B249 RID: 45641 RVA: 0x00226414 File Offset: 0x00224614
		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_SMELTSTONE_EXCHANGED, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_SMELTSTONE_EXCHANGED_CONFIRM, 0, true);
		}

		// Token: 0x04004498 RID: 17560
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSmeltDocument");

		// Token: 0x04004499 RID: 17561
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400449A RID: 17562
		public bool MesIsBack = true;

		// Token: 0x0400449B RID: 17563
		private bool m_emblemRedDotDataIsDirty = false;

		// Token: 0x0400449C RID: 17564
		private bool m_equipRedDotDataIsDirty = false;

		// Token: 0x0400449D RID: 17565
		private bool emblemCanBePower = false;

		// Token: 0x0400449E RID: 17566
		private bool equipCanBePower = false;

		// Token: 0x0400449F RID: 17567
		private List<int> m_morePowerfulEquips = new List<int>();

		// Token: 0x040044A0 RID: 17568
		private List<int> m_equipAttackSmeltExchanged;

		// Token: 0x040044A1 RID: 17569
		private List<int> m_equipDefenseSmeltExchanged;

		// Token: 0x040044A2 RID: 17570
		private List<int> m_emblemSmeltExchanged;

		// Token: 0x040044A3 RID: 17571
		private ulong m_curUid = 0UL;

		// Token: 0x040044A4 RID: 17572
		private List<SmeltAttr> m_smeltAttrList;

		// Token: 0x040044A5 RID: 17573
		public SmeltMainHandler View = null;

		// Token: 0x040044A6 RID: 17574
		public int SelectIndex = 0;

		// Token: 0x040044A7 RID: 17575
		public uint[] SmeltResult = null;
	}
}
