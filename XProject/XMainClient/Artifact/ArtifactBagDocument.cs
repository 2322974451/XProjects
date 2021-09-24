using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactBagDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactBagDocument.uuID;
			}
		}

		public static ArtifactBagDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactBagDocument.uuID) as ArtifactBagDocument;
			}
		}

		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this.m_newItems;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactBagDocument.AsyncLoader.AddTask("Table/ArtifactEffect", ArtifactBagDocument.m_artifactEffectTable, false);
			ArtifactBagDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.m_newItems.ClearItemType();
			this.m_newItems.Filter.AddItemType(ItemType.ARTIFACT);
			XSingleton<XCombatEffectManager>.singleton.Init();
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
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.BagHandler != null && this.BagHandler.IsVisible();
			if (flag)
			{
				this.BagHandler.RefreshData();
				XSingleton<XCombatEffectManager>.singleton.SetDirty();
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			XSingleton<XCombatEffectManager>.singleton.ArrangeEffectData();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		private void ProcessSuitUnEquiped(uint itemid)
		{
			ArtifactSuit suitByArtifactId = ArtifactDocument.SuitMgr.GetSuitByArtifactId(itemid);
			bool flag = suitByArtifactId == null;
			if (flag)
			{
			}
		}

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

		public void UpdateRedPoints()
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.UpdateRedPoints(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
		}

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

		public EquipCompare IsEquipMorePowerful(ulong uid)
		{
			return this.IsEquipMorePowerful(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(uid) as XArtifactItem);
		}

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

		public void OnUseItem(UseItemArg oArg, UseItemRes oRes)
		{
		}

		public void RefreshBag()
		{
			bool flag = this.BagHandler != null && this.BagHandler.IsVisible();
			if (flag)
			{
				this.BagHandler.Refresh();
			}
		}

		public List<XItem> GetArtifacts()
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT);
			this.m_ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_ItemList);
			return this.m_ItemList;
		}

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

		public bool GetArtifactEffectPath(uint quanlity, uint attrType, out string path)
		{
			ulong key = this.MakeKey(quanlity, attrType);
			return this.GetArtifactEffectPath(key, out path);
		}

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

		public ulong MakeKey(uint quanlity, uint attrType)
		{
			return (ulong)(quanlity * 1000U + attrType);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactBagDocument");

		private ArtifactBagHandler m_bagHandler;

		private List<XItem> m_ItemList = new List<XItem>();

		private XNewItemTipsMgr m_newItems = new XNewItemTipsMgr();

		private bool m_shouldUpdateRedPoints = false;

		private bool m_shouldCalcMorePowerfulTip = false;

		private bool m_canBePowerful = false;

		private Dictionary<ulong, string> m_quantityEffectPath;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ArtifactEffect m_artifactEffectTable = new ArtifactEffect();

		private List<string> m_suitEffectPosNames;
	}
}
