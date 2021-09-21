using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C0 RID: 2240
	internal class ArtifactBagDocument : XDocComponent
	{
		// Token: 0x17002A68 RID: 10856
		// (get) Token: 0x0600874B RID: 34635 RVA: 0x00114DD0 File Offset: 0x00112FD0
		public override uint ID
		{
			get
			{
				return ArtifactBagDocument.uuID;
			}
		}

		// Token: 0x17002A69 RID: 10857
		// (get) Token: 0x0600874C RID: 34636 RVA: 0x00114DE8 File Offset: 0x00112FE8
		public static ArtifactBagDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactBagDocument.uuID) as ArtifactBagDocument;
			}
		}

		// Token: 0x17002A6A RID: 10858
		// (get) Token: 0x0600874D RID: 34637 RVA: 0x00114E14 File Offset: 0x00113014
		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this.m_newItems;
			}
		}

		// Token: 0x17002A6B RID: 10859
		// (get) Token: 0x0600874E RID: 34638 RVA: 0x00114E2C File Offset: 0x0011302C
		// (set) Token: 0x0600874F RID: 34639 RVA: 0x00114E44 File Offset: 0x00113044
		public ArtifactBagHandler BagHandler
		{
			get
			{
				return this.m_bagHandler;
			}
			set
			{
				this.m_bagHandler = value;
			}
		}

		// Token: 0x17002A6C RID: 10860
		// (get) Token: 0x06008750 RID: 34640 RVA: 0x00114E50 File Offset: 0x00113050
		// (set) Token: 0x06008751 RID: 34641 RVA: 0x00114E68 File Offset: 0x00113068
		public bool CanBePowerful
		{
			get
			{
				return this.m_canBePowerful;
			}
			set
			{
				this.m_canBePowerful = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Artifact, true);
			}
		}

		// Token: 0x17002A6D RID: 10861
		// (get) Token: 0x06008752 RID: 34642 RVA: 0x00114E84 File Offset: 0x00113084
		public List<string> SuitEffectPosNames
		{
			get
			{
				bool flag = this.m_suitEffectPosNames == null;
				if (flag)
				{
					this.m_suitEffectPosNames = XSingleton<XGlobalConfig>.singleton.GetStringList("ArtifactSuitEffectNames");
					bool flag2 = this.m_suitEffectPosNames.Count < XBagDocument.ArtifactMax;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("artifact pos effect length not enough,at last need {0},but it only had {1}", XBagDocument.ArtifactMax, this.m_suitEffectPosNames.Count), null, null, null, null, null);
					}
				}
				return this.m_suitEffectPosNames;
			}
		}

		// Token: 0x06008753 RID: 34643 RVA: 0x00114F0C File Offset: 0x0011310C
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactBagDocument.AsyncLoader.AddTask("Table/ArtifactEffect", ArtifactBagDocument.m_artifactEffectTable, false);
			ArtifactBagDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008754 RID: 34644 RVA: 0x00114F31 File Offset: 0x00113131
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.m_newItems.ClearItemType();
			this.m_newItems.Filter.AddItemType(ItemType.ARTIFACT);
			XSingleton<XCombatEffectManager>.singleton.Init();
		}

		// Token: 0x06008755 RID: 34645 RVA: 0x00114F68 File Offset: 0x00113168
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
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
		}

		// Token: 0x06008756 RID: 34646 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008757 RID: 34647 RVA: 0x00115028 File Offset: 0x00113228
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.BagHandler != null && this.BagHandler.IsVisible();
			if (flag)
			{
				this.BagHandler.RefreshData();
				XSingleton<XCombatEffectManager>.singleton.SetDirty();
			}
		}

		// Token: 0x06008758 RID: 34648 RVA: 0x00115069 File Offset: 0x00113269
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			XSingleton<XCombatEffectManager>.singleton.ArrangeEffectData();
		}

		// Token: 0x06008759 RID: 34649 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600875A RID: 34650 RVA: 0x00115080 File Offset: 0x00113280
		protected bool OnLoadEquip(XEventArgs args)
		{
			XLoadEquipEventArgs xloadEquipEventArgs = args as XLoadEquipEventArgs;
			bool flag = xloadEquipEventArgs.item.Type == ItemType.ARTIFACT;
			if (flag)
			{
				this.m_shouldUpdateRedPoints = true;
				this.m_shouldCalcMorePowerfulTip = true;
				XSingleton<XCombatEffectManager>.singleton.SetDirty();
				bool flag2 = this.BagHandler != null && this.BagHandler.IsVisible();
				if (flag2)
				{
					this.BagHandler.LoadEquip(xloadEquipEventArgs.item, xloadEquipEventArgs.slot);
				}
				this.ProcessSuitEquiped((uint)xloadEquipEventArgs.item.itemID);
			}
			return true;
		}

		// Token: 0x0600875B RID: 34651 RVA: 0x0011510C File Offset: 0x0011330C
		protected bool OnUnloadEquip(XEventArgs args)
		{
			XUnloadEquipEventArgs xunloadEquipEventArgs = args as XUnloadEquipEventArgs;
			bool flag = xunloadEquipEventArgs.type == ItemType.ARTIFACT;
			if (flag)
			{
				this.m_shouldUpdateRedPoints = true;
				this.m_shouldCalcMorePowerfulTip = true;
				XSingleton<XCombatEffectManager>.singleton.SetDirty();
				bool flag2 = this.BagHandler != null && this.BagHandler.active;
				if (flag2)
				{
					this.BagHandler.UnloadEquip(xunloadEquipEventArgs.slot);
				}
				this.ProcessSuitUnEquiped((uint)xunloadEquipEventArgs.item.itemID);
			}
			return true;
		}

		// Token: 0x0600875C RID: 34652 RVA: 0x00115190 File Offset: 0x00113390
		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			this.m_shouldUpdateRedPoints = this.m_newItems.AddItems(xaddItemEventArgs.items, !xaddItemEventArgs.bNew);
			this.m_shouldCalcMorePowerfulTip = this.m_shouldUpdateRedPoints;
			bool flag = this.BagHandler == null || !this.BagHandler.IsVisible();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.BagHandler.AddItem(xaddItemEventArgs.items);
				result = true;
			}
			return result;
		}

		// Token: 0x0600875D RID: 34653 RVA: 0x0011520C File Offset: 0x0011340C
		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this.m_newItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			this.m_shouldUpdateRedPoints = this.m_newItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			this.m_shouldCalcMorePowerfulTip = this.m_shouldUpdateRedPoints;
			bool flag = this.BagHandler == null || !this.BagHandler.IsVisible();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.BagHandler.RemoveItem(xremoveItemEventArgs.uids);
				result = true;
			}
			return result;
		}

		// Token: 0x0600875E RID: 34654 RVA: 0x0011529C File Offset: 0x0011349C
		protected bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = xupdateItemEventArgs.item.Type == ItemType.ARTIFACT;
			if (flag)
			{
				this.m_shouldUpdateRedPoints = true;
				this.m_shouldCalcMorePowerfulTip = true;
				XSingleton<XCombatEffectManager>.singleton.SetDirty();
			}
			bool flag2 = this.BagHandler == null || !this.BagHandler.IsVisible();
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				this.BagHandler.UpdateItem(xupdateItemEventArgs.item);
				result = true;
			}
			return result;
		}

		// Token: 0x0600875F RID: 34655 RVA: 0x00115318 File Offset: 0x00113518
		protected bool OnItemNumChanged(XEventArgs args)
		{
			bool flag = this.BagHandler == null || !this.BagHandler.IsVisible();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
				this.BagHandler.ItemNumChanged(xitemNumChangedEventArgs.item);
				result = true;
			}
			return result;
		}

		// Token: 0x06008760 RID: 34656 RVA: 0x00115368 File Offset: 0x00113568
		protected bool OnSwapItem(XEventArgs args)
		{
			XSwapItemEventArgs xswapItemEventArgs = args as XSwapItemEventArgs;
			bool flag = xswapItemEventArgs.itemNowOnBody.Type != ItemType.ARTIFACT;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<XCombatEffectManager>.singleton.SetDirty();
				this.m_newItems.RemoveItem(xswapItemEventArgs.itemNowOnBody.uid, ItemType.ARTIFACT, false);
				bool flag2 = this.BagHandler != null && this.BagHandler.IsVisible();
				if (flag2)
				{
					this.BagHandler.SwapItem(xswapItemEventArgs.itemNowOnBody, xswapItemEventArgs.itemNowInBag, xswapItemEventArgs.slot);
				}
				bool flag3 = ArtifactDocument.SuitMgr.WillChangeEquipedCount(xswapItemEventArgs.itemNowInBag.itemID, xswapItemEventArgs.itemNowOnBody.itemID) || ArtifactDocument.SuitMgr.WillChangeEquipedCount(xswapItemEventArgs.itemNowOnBody.itemID, xswapItemEventArgs.itemNowInBag.itemID);
				if (flag3)
				{
					this.ProcessSuitUnEquiped((uint)xswapItemEventArgs.itemNowInBag.itemID);
					this.ProcessSuitEquiped((uint)xswapItemEventArgs.itemNowOnBody.itemID);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06008761 RID: 34657 RVA: 0x00115470 File Offset: 0x00113670
		public bool OnFinishItemChange(XEventArgs args)
		{
			bool shouldUpdateRedPoints = this.m_shouldUpdateRedPoints;
			if (shouldUpdateRedPoints)
			{
				this.UpdateRedPoints();
				this.m_shouldUpdateRedPoints = false;
			}
			bool shouldCalcMorePowerfulTip = this.m_shouldCalcMorePowerfulTip;
			if (shouldCalcMorePowerfulTip)
			{
				bool flag = this.BagHandler != null && this.BagHandler.IsVisible();
				if (flag)
				{
					this.BagHandler.Refresh();
				}
				this.m_shouldCalcMorePowerfulTip = false;
			}
			return true;
		}

		// Token: 0x06008762 RID: 34658 RVA: 0x001154D8 File Offset: 0x001136D8
		private void ProcessSuitEquiped(uint itemid)
		{
			ArtifactSuit suitByArtifactId = ArtifactDocument.SuitMgr.GetSuitByArtifactId(itemid);
			bool flag = suitByArtifactId == null;
			if (!flag)
			{
				List<int> artifactSuitPos = suitByArtifactId.GetArtifactSuitPos(XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag);
				bool flag2 = artifactSuitPos != null && suitByArtifactId.IsEffectJustActivated(artifactSuitPos.Count);
				if (flag2)
				{
					this.ShowSuitEffectTip(suitByArtifactId, artifactSuitPos.Count, true);
					bool flag3 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						ArtifactFrameHandler artifactFrameHandler = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._ArtifactFrameHandler;
						bool flag4 = artifactFrameHandler != null && artifactFrameHandler.IsVisible();
						if (flag4)
						{
							artifactFrameHandler.PlaySuitFx(suitByArtifactId.Id);
						}
					}
				}
			}
		}

		// Token: 0x06008763 RID: 34659 RVA: 0x00115584 File Offset: 0x00113784
		private void ProcessSuitUnEquiped(uint itemid)
		{
			ArtifactSuit suitByArtifactId = ArtifactDocument.SuitMgr.GetSuitByArtifactId(itemid);
			bool flag = suitByArtifactId == null;
			if (flag)
			{
			}
		}

		// Token: 0x06008764 RID: 34660 RVA: 0x001155A8 File Offset: 0x001137A8
		private void ShowSuitEffectTip(ArtifactSuit suit, int effectIndex, bool active)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int count = suit.effects[effectIndex].Count;
			for (int i = 0; i < count; i++)
			{
				SeqListRef<uint> seqListRef = suit.effects[effectIndex];
				stringBuilder.Append(XAttributeCommon.GetAttrStr((int)seqListRef[i, 0]) + " " + XAttributeCommon.GetAttrValueStr((int)seqListRef[i, 0], seqListRef[i, 1]));
				bool flag = i != count;
				if (flag)
				{
					stringBuilder.Append("\n");
				}
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SUIT_EFFECT_CHANGED", new object[]
			{
				suit.Name,
				effectIndex,
				stringBuilder.ToString(),
				XStringDefineProxy.GetString(active ? "HAS_EFFECT" : "NO_EFFECT")
			}), "fece00");
		}

		// Token: 0x06008765 RID: 34661 RVA: 0x00115694 File Offset: 0x00113894
		public void UpdateRedPoints()
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
		}

		// Token: 0x06008766 RID: 34662 RVA: 0x001156CC File Offset: 0x001138CC
		public void UpdateRedPoints(uint playerLevel)
		{
			this.m_canBePowerful = false;
			List<XItem> artifacts = this.GetArtifacts();
			for (int i = 0; i < artifacts.Count; i++)
			{
				XArtifactItem artifact = artifacts[i] as XArtifactItem;
				bool flag = artifacts == null;
				if (!flag)
				{
					EquipCompare equipCompare = this.IsEquipMorePowerful(artifact);
					bool flag2 = (equipCompare & EquipCompare.EC_MORE_POWERFUL) > EquipCompare.EC_NONE;
					if (flag2)
					{
						this.CanBePowerful = true;
						break;
					}
				}
			}
			bool flag3 = !this.m_canBePowerful;
			if (flag3)
			{
				this.CanBePowerful = false;
			}
		}

		// Token: 0x06008767 RID: 34663 RVA: 0x00115750 File Offset: 0x00113950
		public EquipCompare IsEquipMorePowerful(ulong uid)
		{
			return this.IsEquipMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XArtifactItem);
		}

		// Token: 0x06008768 RID: 34664 RVA: 0x00115784 File Offset: 0x00113984
		public EquipCompare IsEquipMorePowerful(XArtifactItem artifact)
		{
			bool flag = artifact == null;
			EquipCompare result;
			if (flag)
			{
				result = EquipCompare.EC_NONE;
			}
			else
			{
				ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)artifact.itemID);
				bool flag2 = artifactListRowData == null;
				if (flag2)
				{
					result = EquipCompare.EC_NONE;
				}
				else
				{
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && artifact.itemConf != null;
					if (flag3)
					{
						bool flag4 = (long)artifact.itemConf.ReqLevel > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
						if (flag4)
						{
							return EquipCompare.EC_NONE;
						}
					}
					int artifactPos = (int)artifactListRowData.ArtifactPos;
					XBagDocument xbagDoc = XSingleton<XGame>.singleton.Doc.XBagDoc;
					XArtifactItem xartifactItem = xbagDoc.ArtifactBag[artifactPos] as XArtifactItem;
					bool flag5 = xartifactItem == null;
					if (flag5)
					{
						result = EquipCompare.EC_MORE_POWERFUL;
					}
					else
					{
						result = EquipCompare.EC_NONE;
					}
				}
			}
			return result;
		}

		// Token: 0x06008769 RID: 34665 RVA: 0x00115848 File Offset: 0x00113A48
		public static EquipCompare GetFinal(EquipCompare mix)
		{
			bool flag = (mix & EquipCompare.EC_MORE_POWERFUL) > EquipCompare.EC_NONE;
			EquipCompare result;
			if (flag)
			{
				result = EquipCompare.EC_MORE_POWERFUL;
			}
			else
			{
				bool flag2 = (mix & EquipCompare.EC_CAN_EQUIP) > EquipCompare.EC_NONE;
				if (flag2)
				{
					result = EquipCompare.EC_CAN_EQUIP;
				}
				else
				{
					bool flag3 = (mix & EquipCompare.EC_CAN_SMELT) > EquipCompare.EC_NONE;
					if (flag3)
					{
						result = EquipCompare.EC_CAN_SMELT;
					}
					else
					{
						result = EquipCompare.EC_NONE;
					}
				}
			}
			return result;
		}

		// Token: 0x0600876A RID: 34666 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnUseItem(UseItemArg oArg, UseItemRes oRes)
		{
		}

		// Token: 0x0600876B RID: 34667 RVA: 0x00115888 File Offset: 0x00113A88
		public void RefreshBag()
		{
			bool flag = this.BagHandler != null && this.BagHandler.IsVisible();
			if (flag)
			{
				this.BagHandler.Refresh();
			}
		}

		// Token: 0x0600876C RID: 34668 RVA: 0x001158C0 File Offset: 0x00113AC0
		public List<XItem> GetArtifacts()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT);
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			return this.m_ItemList;
		}

		// Token: 0x0600876D RID: 34669 RVA: 0x00115910 File Offset: 0x00113B10
		public bool IsHadThisPosArtifact(uint position)
		{
			bool flag = this.m_ItemList.Count == 0;
			if (flag)
			{
				ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT);
				XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			}
			for (int i = 0; i < this.m_ItemList.Count; i++)
			{
				ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)this.m_ItemList[i].itemID);
				bool flag2 = artifactListRowData != null && artifactListRowData.ArtifactPos == position;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600876E RID: 34670 RVA: 0x001159B4 File Offset: 0x00113BB4
		public bool GetArtifactEffectPath(uint quanlity, uint attrType, out string path)
		{
			ulong key = this.MakeKey(quanlity, attrType);
			return this.GetArtifactEffectPath(key, out path);
		}

		// Token: 0x0600876F RID: 34671 RVA: 0x001159D8 File Offset: 0x00113BD8
		public bool GetArtifactEffectPath(ulong key, out string path)
		{
			bool flag = this.m_quantityEffectPath == null;
			if (flag)
			{
				this.m_quantityEffectPath = new Dictionary<ulong, string>();
				for (int i = 0; i < ArtifactBagDocument.m_artifactEffectTable.Table.Length; i++)
				{
					ArtifactEffect.RowData rowData = ArtifactBagDocument.m_artifactEffectTable.Table[i];
					bool flag2 = rowData != null;
					if (flag2)
					{
						ulong key2 = this.MakeKey(rowData.Quanlity, rowData.AttrTyte);
						bool flag3 = !this.m_quantityEffectPath.ContainsKey(key2);
						if (flag3)
						{
							this.m_quantityEffectPath.Add(key2, rowData.Path);
						}
					}
				}
			}
			bool flag4 = this.m_quantityEffectPath.ContainsKey(key);
			bool result;
			if (flag4)
			{
				path = this.m_quantityEffectPath[key];
				result = true;
			}
			else
			{
				path = string.Empty;
				result = false;
			}
			return result;
		}

		// Token: 0x06008770 RID: 34672 RVA: 0x00115AB0 File Offset: 0x00113CB0
		public ulong MakeKey(uint quanlity, uint attrType)
		{
			return (ulong)(quanlity * 1000U + attrType);
		}

		// Token: 0x04002AAE RID: 10926
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactBagDocument");

		// Token: 0x04002AAF RID: 10927
		private ArtifactBagHandler m_bagHandler;

		// Token: 0x04002AB0 RID: 10928
		private List<XItem> m_ItemList = new List<XItem>();

		// Token: 0x04002AB1 RID: 10929
		private XNewItemTipsMgr m_newItems = new XNewItemTipsMgr();

		// Token: 0x04002AB2 RID: 10930
		private bool m_shouldUpdateRedPoints = false;

		// Token: 0x04002AB3 RID: 10931
		private bool m_shouldCalcMorePowerfulTip = false;

		// Token: 0x04002AB4 RID: 10932
		private bool m_canBePowerful = false;

		// Token: 0x04002AB5 RID: 10933
		private Dictionary<ulong, string> m_quantityEffectPath;

		// Token: 0x04002AB6 RID: 10934
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002AB7 RID: 10935
		private static ArtifactEffect m_artifactEffectTable = new ArtifactEffect();

		// Token: 0x04002AB8 RID: 10936
		private List<string> m_suitEffectPosNames;
	}
}
