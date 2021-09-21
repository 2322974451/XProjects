using System;
using System.Collections.Generic;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C2 RID: 2242
	internal class ArtifactDeityStoveDocument : XDocComponent
	{
		// Token: 0x17002A74 RID: 10868
		// (get) Token: 0x0600878C RID: 34700 RVA: 0x00116498 File Offset: 0x00114698
		public override uint ID
		{
			get
			{
				return ArtifactDeityStoveDocument.uuID;
			}
		}

		// Token: 0x17002A75 RID: 10869
		// (get) Token: 0x0600878D RID: 34701 RVA: 0x001164B0 File Offset: 0x001146B0
		public static ArtifactDeityStoveDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactDeityStoveDocument.uuID) as ArtifactDeityStoveDocument;
			}
		}

		// Token: 0x17002A76 RID: 10870
		// (get) Token: 0x0600878E RID: 34702 RVA: 0x001164DC File Offset: 0x001146DC
		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this.m_newItems;
			}
		}

		// Token: 0x17002A77 RID: 10871
		// (get) Token: 0x0600878F RID: 34703 RVA: 0x001164F4 File Offset: 0x001146F4
		public Dictionary<int, int> LevelDic
		{
			get
			{
				bool flag = this.m_levelDic == null;
				if (flag)
				{
					this.m_levelDic = new Dictionary<int, int>();
					int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ArtifactLevelMax");
					for (int i = 0; i < @int; i++)
					{
						int targetLevel = this.GetTargetLevel(i, this.TabLevels);
						this.m_levelDic.Add(i, targetLevel);
					}
				}
				return this.m_levelDic;
			}
		}

		// Token: 0x17002A78 RID: 10872
		// (get) Token: 0x06008790 RID: 34704 RVA: 0x0011656C File Offset: 0x0011476C
		private List<int> TabLevels
		{
			get
			{
				bool flag = this.m_tabLevels == null;
				if (flag)
				{
					this.m_tabLevels = XSingleton<XGlobalConfig>.singleton.GetIntList("ArtifactLevels");
				}
				return this.m_tabLevels;
			}
		}

		// Token: 0x17002A79 RID: 10873
		// (get) Token: 0x06008791 RID: 34705 RVA: 0x001165A8 File Offset: 0x001147A8
		private Dictionary<int, int> ShowMinLevel
		{
			get
			{
				bool flag = this.m_showMinLevel == null;
				if (flag)
				{
					this.m_showMinLevel = new Dictionary<int, int>();
					SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("TabMinLevel", true);
					for (int i = 0; i < (int)sequenceList.Count; i++)
					{
						this.m_showMinLevel.Add(sequenceList[i, 0], sequenceList[i, 1]);
					}
				}
				return this.m_showMinLevel;
			}
		}

		// Token: 0x06008792 RID: 34706 RVA: 0x00116620 File Offset: 0x00114820
		public List<int> GetTabLevels()
		{
			this.m_tempList.Clear();
			int num = 0;
			this.ShowMinLevel.TryGetValue(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.m_sysType), out num);
			for (int i = 0; i < this.TabLevels.Count; i++)
			{
				int num2 = this.TabLevels[i];
				bool flag = num2 >= num;
				if (flag)
				{
					this.m_tempList.Add(num2);
				}
			}
			return this.m_tempList;
		}

		// Token: 0x17002A7A RID: 10874
		// (get) Token: 0x06008794 RID: 34708 RVA: 0x001166B0 File Offset: 0x001148B0
		// (set) Token: 0x06008793 RID: 34707 RVA: 0x001166A6 File Offset: 0x001148A6
		public XSysDefine SysType
		{
			get
			{
				return this.m_sysType;
			}
			set
			{
				this.m_sysType = value;
			}
		}

		// Token: 0x06008795 RID: 34709 RVA: 0x001166C8 File Offset: 0x001148C8
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactDeityStoveDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008796 RID: 34710 RVA: 0x001166D7 File Offset: 0x001148D7
		public override void OnAttachToHost(XObject host)
		{
			this.m_newItems.ClearItemType();
			this.m_newItems.Filter.AddItemType(ItemType.ARTIFACT);
			base.OnAttachToHost(host);
		}

		// Token: 0x06008797 RID: 34711 RVA: 0x00116704 File Offset: 0x00114904
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnItemChangeFinished));
		}

		// Token: 0x06008798 RID: 34712 RVA: 0x0011676D File Offset: 0x0011496D
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.Clear();
		}

		// Token: 0x06008799 RID: 34713 RVA: 0x0011677E File Offset: 0x0011497E
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.RefreshUi();
		}

		// Token: 0x0600879A RID: 34714 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600879B RID: 34715 RVA: 0x00116788 File Offset: 0x00114988
		public void Additem(ulong uid)
		{
			bool flag = uid == 0UL;
			if (!flag)
			{
				switch (this.m_sysType)
				{
				case XSysDefine.XSys_Artifact_Comepose:
					ArtifactComposeDocument.Doc.Additem(uid);
					break;
				case XSysDefine.XSys_Artifact_Recast:
					ArtifactRecastDocument.Doc.AddItem(uid);
					break;
				case XSysDefine.XSys_Artifact_Fuse:
					ArtifactFuseDocument.Doc.AddItem(uid);
					break;
				case XSysDefine.XSys_Artifact_Inscription:
					ArtifactInscriptionDocument.Doc.AddItem(uid);
					break;
				case XSysDefine.XSys_Artifact_Refined:
					ArtifactRefinedDocument.Doc.AddItem(uid);
					break;
				}
			}
		}

		// Token: 0x0600879C RID: 34716 RVA: 0x00116818 File Offset: 0x00114A18
		public void TakeOut(ulong uid)
		{
			bool flag = uid == 0UL;
			if (!flag)
			{
				switch (this.m_sysType)
				{
				case XSysDefine.XSys_Artifact_Comepose:
					ArtifactComposeDocument.Doc.ToggleItemSelect(uid);
					break;
				case XSysDefine.XSys_Artifact_Recast:
					ArtifactRecastDocument.Doc.TakeOut(uid);
					break;
				case XSysDefine.XSys_Artifact_Fuse:
					ArtifactFuseDocument.Doc.TakeOut(uid);
					break;
				case XSysDefine.XSys_Artifact_Inscription:
					ArtifactInscriptionDocument.Doc.TakeOut(uid);
					break;
				case XSysDefine.XSys_Artifact_Refined:
					ArtifactRefinedDocument.Doc.TakeOut(uid);
					break;
				}
			}
		}

		// Token: 0x0600879D RID: 34717 RVA: 0x001168A8 File Offset: 0x00114AA8
		public void ResetSelection(bool isRefreshUi)
		{
			switch (this.m_sysType)
			{
			case XSysDefine.XSys_Artifact_Comepose:
				ArtifactComposeDocument.Doc.ResetSelection(isRefreshUi);
				break;
			case XSysDefine.XSys_Artifact_Recast:
				ArtifactRecastDocument.Doc.ResetSelectUid(isRefreshUi);
				break;
			case XSysDefine.XSys_Artifact_Fuse:
				ArtifactFuseDocument.Doc.ResetSelectUid(isRefreshUi, FuseEffectType.None);
				break;
			case XSysDefine.XSys_Artifact_Inscription:
				ArtifactInscriptionDocument.Doc.ResetSelectUid(isRefreshUi);
				break;
			case XSysDefine.XSys_Artifact_Refined:
				ArtifactRefinedDocument.Doc.ResetSelectUid(isRefreshUi);
				break;
			}
		}

		// Token: 0x0600879E RID: 34718 RVA: 0x00116930 File Offset: 0x00114B30
		public bool IsSelected(ulong uid)
		{
			switch (this.m_sysType)
			{
			case XSysDefine.XSys_Artifact_Comepose:
				return ArtifactComposeDocument.Doc.IsSelected(uid);
			case XSysDefine.XSys_Artifact_Recast:
				return ArtifactRecastDocument.Doc.IsSelectUid(uid);
			case XSysDefine.XSys_Artifact_Fuse:
				return ArtifactFuseDocument.Doc.IsSelectUid(uid);
			case XSysDefine.XSys_Artifact_Inscription:
				return ArtifactInscriptionDocument.Doc.IsSelectUid(uid);
			case XSysDefine.XSys_Artifact_Refined:
				return ArtifactRefinedDocument.Doc.IsSelectUid(uid);
			}
			return false;
		}

		// Token: 0x0600879F RID: 34719 RVA: 0x001169BC File Offset: 0x00114BBC
		public void RefreshAllHandlerUi()
		{
			switch (this.m_sysType)
			{
			case XSysDefine.XSys_Artifact_Comepose:
				ArtifactComposeDocument.Doc.RefreshUi();
				break;
			case XSysDefine.XSys_Artifact_Recast:
				ArtifactRecastDocument.Doc.RefreshUi();
				break;
			case XSysDefine.XSys_Artifact_Fuse:
				ArtifactFuseDocument.Doc.RefreshUi(FuseEffectType.None);
				break;
			case XSysDefine.XSys_Artifact_Inscription:
				ArtifactInscriptionDocument.Doc.RefreshUi();
				break;
			case XSysDefine.XSys_Artifact_Refined:
				ArtifactRefinedDocument.Doc.RefreshUi();
				break;
			}
		}

		// Token: 0x060087A0 RID: 34720 RVA: 0x00116A40 File Offset: 0x00114C40
		public void RefreshUi()
		{
			bool flag = this.ItemsHandler != null && this.ItemsHandler.IsVisible();
			if (flag)
			{
				this.ItemsHandler.RefreshUi();
			}
		}

		// Token: 0x060087A1 RID: 34721 RVA: 0x00116A74 File Offset: 0x00114C74
		public List<XItem> GetArtifactByTabLevel()
		{
			return this.GetArtifactByTabLevel(this.CurSelectTabLevel);
		}

		// Token: 0x060087A2 RID: 34722 RVA: 0x00116A94 File Offset: 0x00114C94
		public List<XItem> GetArtifactByTabLevel(int level)
		{
			this.m_itemList.Clear();
			XBag itemBag = XBagDocument.BagDoc.ItemBag;
			ulong filter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT);
			switch (this.m_sysType)
			{
			case XSysDefine.XSys_Artifact_Comepose:
				this.GetComposeItems(level, itemBag, filter);
				break;
			case XSysDefine.XSys_Artifact_Recast:
				this.GetEquipedArtifacts(level);
				this.GetRecastItems(level, itemBag, filter);
				break;
			case XSysDefine.XSys_Artifact_Fuse:
				this.GetEquipedArtifacts(level);
				this.GetFuseItems(level, itemBag, filter);
				break;
			case XSysDefine.XSys_Artifact_Inscription:
				this.GetEquipedArtifacts(level);
				this.GetInscriptionItems(level, itemBag, filter);
				break;
			case XSysDefine.XSys_Artifact_Refined:
				this.GetEquipedArtifacts(level);
				this.GetRefinedItems(level, itemBag, filter);
				break;
			}
			return this.m_itemList;
		}

		// Token: 0x060087A3 RID: 34723 RVA: 0x00116B60 File Offset: 0x00114D60
		public bool IsSelectUid(ulong uid)
		{
			bool result;
			switch (this.m_sysType)
			{
			case XSysDefine.XSys_Artifact_Recast:
				result = (ArtifactRecastDocument.Doc.LastSelectUid == uid);
				break;
			case XSysDefine.XSys_Artifact_Fuse:
				result = (ArtifactFuseDocument.Doc.LastSelectUid == uid);
				break;
			case XSysDefine.XSys_Artifact_Inscription:
				result = (ArtifactInscriptionDocument.Doc.LastSelectUid == uid);
				break;
			default:
				result = true;
				break;
			}
			return result;
		}

		// Token: 0x060087A4 RID: 34724 RVA: 0x00116BC4 File Offset: 0x00114DC4
		private void GetEquipedArtifacts(int level)
		{
			int num = 0;
			for (int i = 0; i < XBagDocument.BagDoc.ArtifactBag.Length; i++)
			{
				XItem xitem = XBagDocument.BagDoc.ArtifactBag[i];
				bool flag = xitem == null || xitem.itemConf == null;
				if (!flag)
				{
					bool flag2 = this.LevelDic.TryGetValue((int)xitem.itemConf.ReqLevel, out num);
					if (flag2)
					{
						bool flag3 = num == level;
						if (flag3)
						{
							ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)xitem.itemID);
							bool flag4 = artifactListRowData != null && artifactListRowData.IsCanFuse == 1U;
							if (flag4)
							{
								this.m_itemList.Add(xitem);
							}
						}
					}
				}
			}
		}

		// Token: 0x060087A5 RID: 34725 RVA: 0x00116C80 File Offset: 0x00114E80
		private void GetComposeItems(int level, XBag bag, ulong filter)
		{
			int num = 0;
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("CanComposeArtifactQuanlity");
			for (int i = 0; i < bag.Count; i++)
			{
				bool flag = bag[i] == null;
				if (!flag)
				{
					bool flag2 = this.LevelDic.TryGetValue((int)bag[i].itemConf.ReqLevel, out num);
					if (flag2)
					{
						ulong num2 = 1UL << (int)bag[i].type;
						bool flag3 = (num2 & filter) > 0UL && num == level;
						if (flag3)
						{
							bool flag4 = bag[i].itemConf != null && intList.Contains((int)bag[i].itemConf.ItemQuality);
							if (flag4)
							{
								this.m_itemList.Add(bag[i]);
							}
						}
					}
				}
			}
		}

		// Token: 0x060087A6 RID: 34726 RVA: 0x00116D6C File Offset: 0x00114F6C
		private void GetRecastItems(int level, XBag bag, ulong filter)
		{
			int num = 0;
			for (int i = 0; i < bag.Count; i++)
			{
				bool flag = bag[i] == null;
				if (!flag)
				{
					bool flag2 = this.LevelDic.TryGetValue((int)bag[i].itemConf.ReqLevel, out num);
					if (flag2)
					{
						ulong num2 = 1UL << (int)bag[i].type;
						bool flag3 = (num2 & filter) > 0UL && num == level;
						if (flag3)
						{
							ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)bag[i].itemID);
							bool flag4 = artifactListRowData != null && artifactListRowData.IsCanRecast == 1U;
							if (flag4)
							{
								this.m_itemList.Add(bag[i]);
							}
						}
					}
				}
			}
		}

		// Token: 0x060087A7 RID: 34727 RVA: 0x00116E40 File Offset: 0x00115040
		private void GetFuseItems(int level, XBag bag, ulong filter)
		{
			int num = 0;
			for (int i = 0; i < bag.Count; i++)
			{
				bool flag = bag[i] == null;
				if (!flag)
				{
					bool flag2 = this.LevelDic.TryGetValue((int)bag[i].itemConf.ReqLevel, out num);
					if (flag2)
					{
						ulong num2 = 1UL << (int)bag[i].type;
						bool flag3 = (num2 & filter) > 0UL && num == level;
						if (flag3)
						{
							ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)bag[i].itemID);
							bool flag4 = artifactListRowData != null && artifactListRowData.IsCanFuse == 1U;
							if (flag4)
							{
								this.m_itemList.Add(bag[i]);
							}
						}
					}
				}
			}
		}

		// Token: 0x060087A8 RID: 34728 RVA: 0x00116F14 File Offset: 0x00115114
		private void GetInscriptionItems(int level, XBag bag, ulong filter)
		{
			int num = 0;
			ulong num2 = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.Inscription);
			for (int i = 0; i < bag.Count; i++)
			{
				bool flag = bag[i] == null;
				if (!flag)
				{
					bool flag2 = this.LevelDic.TryGetValue((int)bag[i].itemConf.ReqLevel, out num);
					if (flag2)
					{
						ulong num3 = 1UL << (int)bag[i].type;
						bool flag3 = (num3 & num2) > 0UL && num == level;
						if (flag3)
						{
							this.m_itemList.Add(bag[i]);
						}
						else
						{
							num3 = 1UL << (int)bag[i].type;
							bool flag4 = (num3 & filter) > 0UL && num == level;
							if (flag4)
							{
								ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)bag[i].itemID);
								bool flag5 = artifactListRowData != null && artifactListRowData.IsCanFuse == 1U;
								if (flag5)
								{
									this.m_itemList.Add(bag[i]);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060087A9 RID: 34729 RVA: 0x00117040 File Offset: 0x00115240
		private void GetRefinedItems(int level, XBag bag, ulong filter)
		{
			int num = 0;
			for (int i = 0; i < bag.Count; i++)
			{
				bool flag = bag[i] == null;
				if (!flag)
				{
					bool flag2 = this.LevelDic.TryGetValue((int)bag[i].itemConf.ReqLevel, out num);
					if (flag2)
					{
						ulong num2 = 1UL << (int)bag[i].type;
						bool flag3 = (num2 & filter) > 0UL && num == level;
						if (flag3)
						{
							ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)bag[i].itemID);
							bool flag4 = artifactListRowData != null && artifactListRowData.IsCanRefined == 1;
							if (flag4)
							{
								this.m_itemList.Add(bag[i]);
							}
						}
					}
				}
			}
		}

		// Token: 0x060087AA RID: 34730 RVA: 0x00117114 File Offset: 0x00115314
		private List<int> GetQuanlityList()
		{
			List<int> result;
			switch (this.m_sysType)
			{
			case XSysDefine.XSys_Artifact_Recast:
				result = XSingleton<XGlobalConfig>.singleton.GetIntList("CanReCastArtifactQuanlity");
				break;
			case XSysDefine.XSys_Artifact_Fuse:
				result = XSingleton<XGlobalConfig>.singleton.GetIntList("CanFuseArtifactQuanlity");
				break;
			case XSysDefine.XSys_Artifact_Inscription:
				result = XSingleton<XGlobalConfig>.singleton.GetIntList("CanInscriptionArtifactQuanlity");
				break;
			default:
				result = new List<int>();
				break;
			}
			return result;
		}

		// Token: 0x060087AB RID: 34731 RVA: 0x00117184 File Offset: 0x00115384
		private int GetTargetLevel(int level, List<int> lst)
		{
			bool flag = lst == null || lst.Count == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int count = lst.Count;
				int i = 0;
				while (i < count)
				{
					bool flag2 = level < lst[i];
					if (flag2)
					{
						bool flag3 = i == 0;
						if (flag3)
						{
							return lst[i];
						}
						return lst[i - 1];
					}
					else
					{
						i++;
					}
				}
				result = lst[count - 1];
			}
			return result;
		}

		// Token: 0x060087AC RID: 34732 RVA: 0x00117204 File Offset: 0x00115404
		private void Clear()
		{
			bool flag = this.m_tabLevels != null;
			if (flag)
			{
				this.m_tabLevels.Clear();
				this.m_tabLevels = null;
			}
			bool flag2 = this.m_levelDic != null;
			if (flag2)
			{
				this.m_levelDic.Clear();
				this.m_levelDic = null;
			}
		}

		// Token: 0x060087AD RID: 34733 RVA: 0x00117258 File Offset: 0x00115458
		private bool OnItemChangeFinished(XEventArgs args)
		{
			bool flag = this.ItemsHandler != null && this.ItemsHandler.IsVisible();
			if (flag)
			{
				this.ItemsHandler.RefreshUi();
			}
			return true;
		}

		// Token: 0x060087AE RID: 34734 RVA: 0x00117294 File Offset: 0x00115494
		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			bool flag = this.ItemsHandler != null && this.ItemsHandler.IsVisible();
			bool result;
			if (flag)
			{
				bool bNew = xaddItemEventArgs.bNew;
				if (bNew)
				{
					this.m_newItems.AddItems(xaddItemEventArgs.items, false);
				}
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060087AF RID: 34735 RVA: 0x001172EC File Offset: 0x001154EC
		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this.m_newItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			return true;
		}

		// Token: 0x060087B0 RID: 34736 RVA: 0x00117320 File Offset: 0x00115520
		protected bool OnUpdateItem(XEventArgs args)
		{
			XUpdateItemEventArgs xupdateItemEventArgs = args as XUpdateItemEventArgs;
			bool flag = this.ItemsHandler != null && this.ItemsHandler.IsVisible() && xupdateItemEventArgs.item != null;
			if (flag)
			{
				bool flag2 = this.IsSelectUid(xupdateItemEventArgs.item.uid);
				if (flag2)
				{
					this.m_newItems.AddItem(xupdateItemEventArgs.item, false);
				}
			}
			return true;
		}

		// Token: 0x04002AC0 RID: 10944
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactDeityStoveDocument");

		// Token: 0x04002AC1 RID: 10945
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002AC2 RID: 10946
		public int CurSelectTabLevel = 0;

		// Token: 0x04002AC3 RID: 10947
		public ArtifactItemsHandler ItemsHandler;

		// Token: 0x04002AC4 RID: 10948
		private List<XItem> m_itemList = new List<XItem>();

		// Token: 0x04002AC5 RID: 10949
		private XNewItemTipsMgr m_newItems = new XNewItemTipsMgr();

		// Token: 0x04002AC6 RID: 10950
		private Dictionary<int, int> m_levelDic = null;

		// Token: 0x04002AC7 RID: 10951
		private List<int> m_tabLevels;

		// Token: 0x04002AC8 RID: 10952
		private Dictionary<int, int> m_showMinLevel = null;

		// Token: 0x04002AC9 RID: 10953
		private List<int> m_tempList = new List<int>();

		// Token: 0x04002ACA RID: 10954
		private XSysDefine m_sysType = XSysDefine.XSys_Artifact_Comepose;
	}
}
