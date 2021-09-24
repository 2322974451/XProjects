using System;
using System.Collections.Generic;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactDeityStoveDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactDeityStoveDocument.uuID;
			}
		}

		public static ArtifactDeityStoveDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactDeityStoveDocument.uuID) as ArtifactDeityStoveDocument;
			}
		}

		public XNewItemTipsMgr NewItems
		{
			get
			{
				return this.m_newItems;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactDeityStoveDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			this.m_newItems.ClearItemType();
			this.m_newItems.Filter.AddItemType(ItemType.ARTIFACT);
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnItemChangeFinished));
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.Clear();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.RefreshUi();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		public void RefreshUi()
		{
			bool flag = this.ItemsHandler != null && this.ItemsHandler.IsVisible();
			if (flag)
			{
				this.ItemsHandler.RefreshUi();
			}
		}

		public List<XItem> GetArtifactByTabLevel()
		{
			return this.GetArtifactByTabLevel(this.CurSelectTabLevel);
		}

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

		private bool OnItemChangeFinished(XEventArgs args)
		{
			bool flag = this.ItemsHandler != null && this.ItemsHandler.IsVisible();
			if (flag)
			{
				this.ItemsHandler.RefreshUi();
			}
			return true;
		}

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

		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			this.m_newItems.RemoveItems(xremoveItemEventArgs.uids, xremoveItemEventArgs.types, true);
			return true;
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactDeityStoveDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public int CurSelectTabLevel = 0;

		public ArtifactItemsHandler ItemsHandler;

		private List<XItem> m_itemList = new List<XItem>();

		private XNewItemTipsMgr m_newItems = new XNewItemTipsMgr();

		private Dictionary<int, int> m_levelDic = null;

		private List<int> m_tabLevels;

		private Dictionary<int, int> m_showMinLevel = null;

		private List<int> m_tempList = new List<int>();

		private XSysDefine m_sysType = XSysDefine.XSys_Artifact_Comepose;
	}
}
