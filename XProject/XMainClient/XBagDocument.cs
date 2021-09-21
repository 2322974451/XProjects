// Decompiled with JetBrains decompiler
// Type: XMainClient.XBagDocument
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XBagDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(XBagDocument));
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static ItemList m_ItemTable = new ItemList();
        private static DropList m_DropTable = new DropList();
        private static ChestList m_ChestTable = new ChestList();
        private static EquipList m_EquipTable = new EquipList();
        private static EmblemBasic m_EmblemTable = new EmblemBasic();
        private static FashionList m_FashionTable = new FashionList();
        private static PandoraHeart m_PandoraHeartTable = new PandoraHeart();
        private static BagExpandItemListTable m_BagExpandItemListTable = new BagExpandItemListTable();
        private static Dictionary<int, List<ChestList.RowData>> m_ChestRange = new Dictionary<int, List<ChestList.RowData>>();
        private static Dictionary<uint, List<ItemList.RowData>> m_AuctionRange = new Dictionary<uint, List<ItemList.RowData>>();
        public XBag ItemBag;
        public static readonly int EquipMax = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END);
        public static readonly int FashionMax = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_END);
        public static readonly int EmblemMax = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);
        public static readonly int VirtualItemMax = XBagDocument.BodyPosition<ItemEnum>(ItemEnum.VIRTUAL_ITEM_MAX);
        public static readonly int ArtifactMax = XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_END);
        private static readonly uint ITEM_PROFESSION_MASK = 100000;
        public static readonly int QualityCount = 6;
        public XBodyBag EquipBag = new XBodyBag(XBagDocument.EquipMax);
        public XBodyBag EmblemBag = new XBodyBag(XBagDocument.EmblemMax);
        public XBodyBag ArtifactBag = new XBodyBag(XBagDocument.ArtifactMax);
        public ulong[] VirtualItems = new ulong[XBagDocument.VirtualItemMax];
        public ulong TearsCount = 0;
        public List<BagExpandData> BagExpandDataList = new List<BagExpandData>()
    {
      new BagExpandData(BagType.ItemBag),
      new BagExpandData(BagType.EmblemBag),
      new BagExpandData(BagType.EquipBag),
      new BagExpandData(BagType.ArtifactBag)
    };
        public static CVSReader.RowDataCompare<DropList.RowData, int> comp = new CVSReader.RowDataCompare<DropList.RowData, int>(XBagDocument.DropDataCompare);
        private BagExpandItemListTable.RowData m_usedBagExpandRow = (BagExpandItemListTable.RowData)null;
        private Dictionary<ulong, uint> basicAttrPool = new Dictionary<ulong, uint>();
        private Dictionary<ulong, uint> equipAdditionalAttrPool = new Dictionary<ulong, uint>();
        private bool getallEquip = false;
        private int fashionIndex = 0;
        private float fashionTime = 0.0f;

        public override uint ID => XBagDocument.uuID;

        public static DropList DropTable => XBagDocument.m_DropTable;

        public static XBagDocument BagDoc => XSingleton<XGame>.singleton.Doc.XBagDoc;

        public void GetItemsByType(ulong typeFilter, ref List<XItem> list)
        {
            for (int key = 0; key < this.ItemBag.Count; ++key)
            {
                if ((1UL << (int)this.ItemBag[key].type & typeFilter) > 0UL)
                    list.Add(this.ItemBag[key]);
            }
        }

        public List<XItem> GetNotBindItemsByType(int typeFilter)
        {
            List<XItem> xitemList = new List<XItem>();
            for (int key = 0; key < this.ItemBag.Count; ++key)
            {
                if (!this.ItemBag[key].bBinding && (1 << (int)this.ItemBag[key].type & typeFilter) > 0)
                    xitemList.Add(this.ItemBag[key]);
            }
            return xitemList;
        }

        public List<XItem> GetItemsByTypeAndQuality(ulong typeFilter, ItemQuality quality)
        {
            List<XItem> xitemList = new List<XItem>();
            for (int key = 0; key < this.ItemBag.Count; ++key)
            {
                if ((1UL << (int)this.ItemBag[key].type & typeFilter) > 0UL && (ItemQuality)this.ItemBag[key].itemConf.ItemQuality == quality)
                    xitemList.Add(this.ItemBag[key]);
            }
            return xitemList;
        }

        public static void Execute(OnLoadedCallback callback = null)
        {
            XBagDocument.AsyncLoader.AddTask("Table/ItemList", (CVSReader)XBagDocument.m_ItemTable);
            XBagDocument.AsyncLoader.AddTask("Table/ChestList", (CVSReader)XBagDocument.m_ChestTable);
            XBagDocument.AsyncLoader.AddTask("Table/EquipList", (CVSReader)XBagDocument.m_EquipTable);
            XBagDocument.AsyncLoader.AddTask("Table/FashionList", (CVSReader)XBagDocument.m_FashionTable);
            XBagDocument.AsyncLoader.AddTask("Table/EmblemBasic", (CVSReader)XBagDocument.m_EmblemTable);
            XBagDocument.AsyncLoader.AddTask("Table/DropList", (CVSReader)XBagDocument.m_DropTable);
            XBagDocument.AsyncLoader.AddTask("Table/PandoraHeart", (CVSReader)XBagDocument.m_PandoraHeartTable);
            XBagDocument.AsyncLoader.AddTask("Table/BagExpandItemList", (CVSReader)XBagDocument.m_BagExpandItemListTable);
            XBagDocument.AsyncLoader.Execute(callback);
            XBagDocument.m_ChestRange.Clear();
            XBagDocument.m_AuctionRange.Clear();
        }

        public static void OnTableLoaded()
        {
            XBagDocument.BuildChestTable();
            XBagDocument.BuildAuctionRange();
        }

        public static void BuildAuctionRange()
        {
            ItemList.RowData[] table = XBagDocument.m_ItemTable.Table;
            int index1 = 0;
            for (int length1 = table.Length; index1 < length1; ++index1)
            {
                ItemList.RowData rowData = table[index1];
                if (rowData.CanTrade && rowData.AuctionType != null)
                {
                    int index2 = 0;
                    for (int length2 = rowData.AuctionType.Length; index2 < length2; ++index2)
                    {
                        List<ItemList.RowData> rowDataList;
                        if (!XBagDocument.m_AuctionRange.TryGetValue((uint)rowData.AuctionType[index2], out rowDataList))
                        {
                            rowDataList = new List<ItemList.RowData>();
                            XBagDocument.m_AuctionRange.Add((uint)rowData.AuctionType[index2], rowDataList);
                        }
                        rowDataList.Add(rowData);
                    }
                }
            }
        }

        public static void BuildChestTable()
        {
            int index = 0;
            for (int length = XBagDocument.m_ChestTable.Table.Length; index < length; ++index)
            {
                List<ChestList.RowData> rowDataList;
                if (!XBagDocument.m_ChestRange.TryGetValue(XBagDocument.m_ChestTable.Table[index].ItemID, out rowDataList))
                {
                    rowDataList = new List<ChestList.RowData>();
                    XBagDocument.m_ChestRange.Add(XBagDocument.m_ChestTable.Table[index].ItemID, rowDataList);
                }
                rowDataList.Add(XBagDocument.m_ChestTable.Table[index]);
            }
        }

        public static bool TryGetAuctionList(uint auctionID, out List<ItemList.RowData> list) => XBagDocument.m_AuctionRange.TryGetValue(auctionID, out list);

        public static uint GetItemProf(int itemid)
        {
            ItemList.RowData byItemId = XBagDocument.m_ItemTable.GetByItemID(itemid);
            return byItemId == null ? 0U : (uint)byItemId.Profession;
        }

        public static int ConvertTemplate(ItemList.RowData rowData)
        {
            if (rowData == null)
                return 0;
            return rowData.ItemType == (byte)12 ? rowData.ItemID + (int)XItemDrawerParam.DefaultProfession * (int)XBagDocument.ITEM_PROFESSION_MASK : rowData.ItemID;
        }

        public static int ConvertTemplate(int itemid)
        {
            ItemList.RowData byItemId = XBagDocument.m_ItemTable.GetByItemID(itemid);
            return byItemId == null ? itemid : XBagDocument.ConvertTemplate(byItemId);
        }

        public static bool IsProfMatched(uint prof) => prof == 0U || (int)(prof % 10U) == (int)XItemDrawerParam.DefaultProfession;

        public static bool IsProfMatchedFeable(uint prof, uint profecssion, bool feable = false) => prof == 0U || (feable ? (int)(prof % 10U) == (int)(profecssion % 10U) : (int)prof == (int)profecssion);

        public static bool IsProfMatchedWithFeable(uint prof) => prof == 0U || (int)prof == (int)XItemDrawerParam.DefaultProfession;

        public static bool IsProfEqual(uint prof) => (int)(prof % 10U) == (int)XItemDrawerParam.DefaultProfession;

        public static string GetItemSmallIcon(int itemid, uint profession = 0)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemid);
            return itemConf == null ? string.Empty : XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon1, profession);
        }

        public static void GetItemBigIconAndAtlas(
          int itemid,
          out string icon,
          out string atlas,
          uint profession = 0)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemid);
            if (itemConf == null)
            {
                icon = string.Empty;
                atlas = string.Empty;
            }
            else
            {
                icon = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon, profession);
                atlas = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemAtlas, profession);
            }
        }

        public static void GetItemSmallIconAndAtlas(
          int itemid,
          out string icon,
          out string atlas,
          uint profession = 0)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemid);
            if (itemConf == null)
            {
                icon = string.Empty;
                atlas = string.Empty;
            }
            else
            {
                icon = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon1, profession);
                atlas = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemAtlas1, profession);
            }
        }

        public static uint GetAuctionRecommendPrice(int itemID) => XBagDocument.m_ItemTable.GetByItemID(itemID).AuctPriceRecommend;

        public static FashionList.RowData GetFashionConf(int itemID) => XBagDocument.m_FashionTable.GetByItemID(itemID);

        public static ItemList.RowData GetItemConf(int itemID) => XBagDocument.m_ItemTable.GetByItemID(itemID);

        public static EquipList.RowData GetEquipConf(int itemID) => XBagDocument.m_EquipTable.GetByItemID(itemID);

        public static BagExpandItemListTable.RowData GetExpandItemConf(uint itemId) => XBagDocument.m_BagExpandItemListTable.GetByItemId(itemId);

        public static BagExpandItemListTable.RowData GetExpandItemConfByType(
          uint itemId)
        {
            return XBagDocument.m_BagExpandItemListTable.GetByType(itemId);
        }

        public static PandoraHeart PandoraHeartTable => XBagDocument.m_PandoraHeartTable;

        public static PandoraHeart.RowData GetPandoraHeartConf(int itemID, uint profID)
        {
            for (int index = 0; index < XBagDocument.m_PandoraHeartTable.Table.Length; ++index)
            {
                if (((long)itemID == (long)XBagDocument.m_PandoraHeartTable.Table[index].PandoraID || (long)itemID == (long)XBagDocument.m_PandoraHeartTable.Table[index].FireID) && ((int)profID == (int)XBagDocument.m_PandoraHeartTable.Table[index].ProfID || XBagDocument.m_PandoraHeartTable.Table[index].ProfID == 0U))
                    return XBagDocument.m_PandoraHeartTable.Table[index];
            }
            return (PandoraHeart.RowData)null;
        }

        public static EmblemBasic.RowData GetEmblemConf(int emblemID) => XBagDocument.m_EmblemTable.GetByEmblemID((uint)emblemID);

        public static ChestList.RowData GetChestConf(int itemID)
        {
            for (int index = 0; index < XBagDocument.m_ChestTable.Table.Length; ++index)
            {
                if (XBagDocument.m_ChestTable.Table[index].ItemID == itemID)
                    return XBagDocument.m_ChestTable.Table[index];
            }
            return (ChestList.RowData)null;
        }

        public static bool TryGetChestListConf(int itemID, out List<ChestList.RowData> chestList) => XBagDocument.m_ChestRange.TryGetValue(itemID, out chestList);

        private static int DropDataCompare(DropList.RowData rowData, int dropID) => dropID.CompareTo(rowData.DropID);

        public static bool TryGetDropConf(uint[] dropIDs, ref List<DropList.RowData> dropList)
        {
            if (dropIDs != null)
            {
                for (int index1 = 0; index1 < dropIDs.Length; ++index1)
                {
                    int startIndex;
                    int endIndex;
                    CVSReader.GetRowDataListByField<DropList.RowData, int>(XBagDocument.DropTable.Table, (int)dropIDs[index1], out startIndex, out endIndex, XBagDocument.comp);
                    if (startIndex >= 0)
                    {
                        for (int index2 = startIndex; index2 <= endIndex; ++index2)
                            dropList.Add(XBagDocument.DropTable.Table[index2]);
                    }
                }
            }
            return dropList.Count > 0;
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this.ItemBag = new XBag();
        }

        protected override void EventSubscribe()
        {
            base.EventSubscribe();
            this.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
            this.RegisterEvent(XEventDefine.XEvent_UpdateItem, new XComponent.XEventHandler(this.OnUpdateItem));
        }

        protected bool OnRemoveItem(XEventArgs args)
        {
            foreach (ulong uid in (args as XRemoveItemEventArgs).uids)
                this._RemoveCompareAttrsFromPool(uid);
            return true;
        }

        protected bool OnUpdateItem(XEventArgs args)
        {
            this._RemoveCompareAttrsFromPool((args as XUpdateItemEventArgs).item.uid);
            return true;
        }

        public override void OnLeaveScene()
        {
            base.OnLeaveScene();
            this.basicAttrPool.Clear();
            this.equipAdditionalAttrPool.Clear();
            this.getallEquip = false;
        }

        public BagExpandData GetBagExpandData(BagType type)
        {
            for (int index = 0; index < this.BagExpandDataList.Count; ++index)
            {
                if (this.BagExpandDataList[index].Type == type)
                    return this.BagExpandDataList[index];
            }
            return (BagExpandData)null;
        }

        public void SwapItem(ulong uid1, ulong uid2)
        {
            int index = 0;
            XItem xitem1 = (XItem)null;
            XItem xitem2 = (XItem)null;
            if (uid1 != 0UL && this.ItemBag.FindItem(uid1, out index))
                xitem1 = this.ItemBag[index];
            int pos = 0;
            XBodyBag bag = (XBodyBag)null;
            bool isEquip = false;
            if (uid2 != 0UL && this.GetBodyPosByUID(uid2, out pos, out bag, out isEquip))
                xitem2 = bag[pos];
            if (xitem1 != null && xitem2 != null)
            {
                if ((int)xitem1.type != (int)xitem2.type)
                    return;
                this.ItemBag[index] = xitem2;
                bag[pos] = xitem1;
                this.ItemBag.SortItem();
                XSwapItemEventArgs xswapItemEventArgs = XEventPool<XSwapItemEventArgs>.GetEvent();
                xswapItemEventArgs.itemNowOnBody = xitem1;
                xswapItemEventArgs.itemNowInBag = xitem2;
                xswapItemEventArgs.slot = pos;
                xswapItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xswapItemEventArgs);
            }
            else if (xitem1 != null)
            {
                XBodyBag bodyBag = xitem1.Description.BodyBag;
                if (bodyBag == null)
                    return;
                switch (xitem1.Type)
                {
                    case ItemType.EQUIP:
                        pos = (int)XBagDocument.GetEquipConf(xitem1.itemID).EquipPos;
                        isEquip = true;
                        break;
                    case ItemType.EMBLEM:
                        if (!XEmblemDocument.GetFirstEmptyEmblemSlot(this.EmblemBag, XBagDocument.GetEmblemConf(xitem1.itemID).EmblemType, out pos))
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog("Failed to equip emblem cause it's full.");
                            return;
                        }
                        break;
                    case ItemType.ARTIFACT:
                        pos = (int)ArtifactDocument.GetArtifactListRowData((uint)xitem1.itemID).ArtifactPos;
                        isEquip = true;
                        break;
                }
                bodyBag[pos] = xitem1;
                this.ItemBag.RemoveIndex(index);
                XRemoveItemEventArgs xremoveItemEventArgs = XEventPool<XRemoveItemEventArgs>.GetEvent();
                xremoveItemEventArgs.uids.Add(uid1);
                xremoveItemEventArgs.types.Add(xitem1.Type);
                xremoveItemEventArgs.ids.Add(xitem1.itemID);
                xremoveItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xremoveItemEventArgs);
                XLoadEquipEventArgs xloadEquipEventArgs = XEventPool<XLoadEquipEventArgs>.GetEvent();
                xloadEquipEventArgs.item = xitem1;
                xloadEquipEventArgs.slot = pos;
                xloadEquipEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xloadEquipEventArgs);
            }
            else
            {
                if (xitem2 == null)
                    return;
                bag[pos] = (XItem)null;
                this.ItemBag.AddItem(xitem2, true);
                XAddItemEventArgs xaddItemEventArgs = XEventPool<XAddItemEventArgs>.GetEvent();
                xaddItemEventArgs.items.Add(xitem2);
                xaddItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                xaddItemEventArgs.bNew = false;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaddItemEventArgs);
                XUnloadEquipEventArgs xunloadEquipEventArgs = XEventPool<XUnloadEquipEventArgs>.GetEvent();
                xunloadEquipEventArgs.slot = pos;
                xunloadEquipEventArgs.item = xitem2;
                xunloadEquipEventArgs.type = xitem2.Type;
                xunloadEquipEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xunloadEquipEventArgs);
            }
        }

        public void UseItem(XItem item, uint opType = 0) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_UseItem()
        {
            oArg = {
        uid = item.uid,
        count = 1U,
        OpType = opType,
        itemID = (uint) item.itemID
      }
        });

        public void UseItem(XItem item, uint opType, uint count) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_UseItem()
        {
            oArg = {
        uid = item.uid,
        count = count,
        OpType = opType
      }
        });

        private static void MakeXEquipItem(ref XItem item, Item KKSGItem)
        {
            if (item == null)
                item = (XItem)XDataPool<XEquipItem>.GetData();
            if (!(item is XEquipItem xequipItem))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Cant create XEquipItem");
            }
            else
            {
                xequipItem.smeltDegreeNum = KKSGItem.smeltCount;
                xequipItem.enhanceInfo.EnhanceLevel = KKSGItem.EnhanceLevel;
                xequipItem.enhanceInfo.EnhanceTimes = KKSGItem.EnhanceCount;
                if (KKSGItem.AttrID.Count != KKSGItem.AttrValue.Count)
                {
                    XSingleton<XDebug>.singleton.AddLog("KKSGItem.EnhanceInfo.AttrID.Count != KKSGItem.EnhanceInfo.AttrValue.Count");
                }
                else
                {
                    for (int index = 0; index < KKSGItem.EnhanceAttrId.Count; ++index)
                    {
                        XItemChangeAttr xitemChangeAttr;
                        xitemChangeAttr.AttrID = KKSGItem.EnhanceAttrId[index];
                        xitemChangeAttr.AttrValue = KKSGItem.EnhanceAttrValue[index];
                        xequipItem.enhanceInfo.EnhanceAttr.Add(xitemChangeAttr);
                    }
                    xequipItem.changeAttr.Clear();
                    EquipList.RowData equipConf = XBagDocument.GetEquipConf((int)KKSGItem.ItemID);
                    if (equipConf != null)
                    {
                        for (int index = 0; index < (int)equipConf.Attributes.count; ++index)
                        {
                            XItemChangeAttr xitemChangeAttr;
                            xitemChangeAttr.AttrID = (uint)equipConf.Attributes[index, 0];
                            xitemChangeAttr.AttrValue = (uint)equipConf.Attributes[index, 1];
                            xequipItem.changeAttr.Add(xitemChangeAttr);
                        }
                    }
                    if (KKSGItem.ItemJade != null)
                    {
                        for (int index1 = 0; index1 < KKSGItem.ItemJade.ItemJadeSingle.Count; ++index1)
                        {
                            ItemJadeSingle itemJadeSingle = KKSGItem.ItemJade.ItemJadeSingle[index1];
                            XJadeItem data = XDataPool<XJadeItem>.GetData();
                            data.itemID = (int)itemJadeSingle.ItemId;
                            data.type = (uint)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.JADE);
                            data.uid = 0UL;
                            data.itemCount = 1;
                            data.bBinding = true;
                            for (int index2 = 0; index2 < itemJadeSingle.AttrId.Count; ++index2)
                            {
                                uint num = itemJadeSingle.AttrId[index2];
                                XItemChangeAttr xitemChangeAttr;
                                xitemChangeAttr.AttrID = num;
                                xitemChangeAttr.AttrValue = itemJadeSingle.AttrValue[index2];
                                data.changeAttr.Add(xitemChangeAttr);
                            }
                            xequipItem.jadeInfo.jades[(int)itemJadeSingle.SlotPos] = data;
                        }
                    }
                    xequipItem.attrType = AttrType.None;
                    if (KKSGItem.randAttr != null)
                    {
                        for (int index = 0; index < KKSGItem.randAttr.attrs.Count; ++index)
                        {
                            XItemChangeAttr xitemChangeAttr;
                            xitemChangeAttr.AttrID = KKSGItem.randAttr.attrs[index].id;
                            xitemChangeAttr.AttrValue = KKSGItem.randAttr.attrs[index].value;
                            xequipItem.randAttrInfo.RandAttr.Add(xitemChangeAttr);
                            if ((uint)xequipItem.attrType <= 0U)
                            {
                                if (xitemChangeAttr.AttrID == 11U)
                                    xequipItem.attrType = AttrType.Physics;
                                else if (xitemChangeAttr.AttrID == 21U)
                                    xequipItem.attrType = AttrType.Magic;
                            }
                        }
                    }
                    if (KKSGItem.forge != null)
                    {
                        for (int index = 0; index < KKSGItem.forge.attrs.Count; ++index)
                        {
                            XItemChangeAttr xitemChangeAttr;
                            xitemChangeAttr.AttrID = KKSGItem.forge.attrs[index].id;
                            xitemChangeAttr.AttrValue = KKSGItem.forge.attrs[index].value;
                            xequipItem.forgeAttrInfo.ForgeAttr.Add(xitemChangeAttr);
                        }
                        if (KKSGItem.forge.unReplacedAttr != null)
                        {
                            xequipItem.forgeAttrInfo.UnSavedAttrid = KKSGItem.forge.unReplacedAttr.id;
                            xequipItem.forgeAttrInfo.UnSavedAttrValue = KKSGItem.forge.unReplacedAttr.value;
                        }
                        else
                        {
                            xequipItem.forgeAttrInfo.UnSavedAttrid = 0U;
                            xequipItem.forgeAttrInfo.UnSavedAttrValue = 0U;
                        }
                    }
                    if (KKSGItem.enchant != null)
                    {
                        xequipItem.enchantInfo.ChooseAttr = KKSGItem.enchant.chooseAttrid;
                        if (KKSGItem.enchant.chooseAttrid > 0U)
                        {
                            for (int index = 0; index < KKSGItem.enchant.allAttrs.Count; ++index)
                            {
                                XItemChangeAttr xitemChangeAttr;
                                xitemChangeAttr.AttrID = KKSGItem.enchant.allAttrs[index].id;
                                xitemChangeAttr.AttrValue = KKSGItem.enchant.allAttrs[index].value;
                                xequipItem.enchantInfo.AttrList.Add(xitemChangeAttr);
                            }
                            if (KKSGItem.enchant.enchantids.Count > 0)
                                xequipItem.enchantInfo.EnchantIDList = new List<uint>((IEnumerable<uint>)KKSGItem.enchant.enchantids);
                        }
                        xequipItem.enchantInfo.EnchantItemID = (int)KKSGItem.enchant.enchantid;
                    }
                    if (KKSGItem.fuse == null)
                        return;
                    xequipItem.fuseInfo.BreakNum = KKSGItem.fuse.fuseLevel;
                    xequipItem.fuseInfo.FuseExp = KKSGItem.fuse.fuseExpCount;
                }
            }
        }

        private static void MakeXArtifactItem(ref XItem item, Item KKSGItem)
        {
            if (item == null)
                item = (XItem)XDataPool<XArtifactItem>.GetData();
            if (!(item is XArtifactItem xartifactItem))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Can not create artifactItem");
            }
            else
            {
                xartifactItem.RandAttrInfo.RandAttr.Clear();
                for (int index = 0; index < KKSGItem.AttrID.Count; ++index)
                {
                    XItemChangeAttr xitemChangeAttr;
                    xitemChangeAttr.AttrID = KKSGItem.AttrID[index];
                    xitemChangeAttr.AttrValue = KKSGItem.AttrValue[index];
                    xartifactItem.RandAttrInfo.RandAttr.Add(xitemChangeAttr);
                }
                if (KKSGItem.artifact != null)
                {
                    for (int index = 0; index < KKSGItem.artifact.unReplacedAttr.Count; ++index)
                        xartifactItem.UnSavedAttr.Add(new XItemChangeAttr()
                        {
                            AttrID = KKSGItem.artifact.unReplacedAttr[index].id,
                            AttrValue = KKSGItem.artifact.unReplacedAttr[index].value
                        });
                }
                xartifactItem.EffectInfoList.Clear();
                for (int index1 = 0; index1 < KKSGItem.effects.Count; ++index1)
                {
                    EffectData effect = KKSGItem.effects[index1];
                    XArtifactEffectInfo xartifactEffectInfo = new XArtifactEffectInfo();
                    xartifactEffectInfo.Init();
                    xartifactEffectInfo.EffectId = effect.effectID;
                    xartifactEffectInfo.SetBaseProf(effect.effectID);
                    xartifactEffectInfo.IsValid = effect.isWork;
                    xartifactItem.EffectInfoList.Add(xartifactEffectInfo);
                    for (int index2 = 0; index2 < effect.multiParams.Count; ++index2)
                    {
                        EffectMultiParams multiParam = effect.multiParams[index2];
                        if (multiParam != null)
                        {
                            XArtifactBuffInfo xartifactBuffInfo = new XArtifactBuffInfo();
                            xartifactBuffInfo.Init();
                            xartifactBuffInfo.SetData(effect.effectID, multiParam.IDType, multiParam.ID, multiParam.effectParams);
                            if (xartifactEffectInfo.BuffInfoList.Count == 0)
                            {
                                xartifactEffectInfo.BuffInfoList.Add(xartifactBuffInfo);
                            }
                            else
                            {
                                for (int index3 = 0; index3 < xartifactEffectInfo.BuffInfoList.Count; ++index3)
                                {
                                    int sortId1 = (int)xartifactBuffInfo.SortId;
                                    XArtifactBuffInfo buffInfo = xartifactEffectInfo.BuffInfoList[xartifactEffectInfo.BuffInfoList.Count - 1];
                                    int sortId2 = (int)buffInfo.SortId;
                                    if ((uint)sortId1 > (uint)sortId2)
                                    {
                                        xartifactEffectInfo.BuffInfoList.Add(xartifactBuffInfo);
                                        break;
                                    }
                                    int sortId3 = (int)xartifactBuffInfo.SortId;
                                    buffInfo = xartifactEffectInfo.BuffInfoList[index3];
                                    int sortId4 = (int)buffInfo.SortId;
                                    if ((uint)sortId3 < (uint)sortId4)
                                    {
                                        xartifactEffectInfo.BuffInfoList.Insert(index3, xartifactBuffInfo);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MakeXEmblemItem(ref XItem item, Item KKSGItem)
        {
            if (item == null)
                item = (XItem)XDataPool<XEmblemItem>.GetData();
            XBagDocument.MakeXAttrItem(ref item, KKSGItem);
            if (!(item is XEmblemItem xemblemItem))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Cant create XEmblemItem");
            }
            else
            {
                xemblemItem.smeltDegreeNum = KKSGItem.smeltCount;
                xemblemItem.emblemInfo.thirdslot = KKSGItem.EmblemThirdSlot;
            }
        }

        private static void MakeXFashionItem(ref XItem item, Item KKSGItem)
        {
            if (item == null)
                item = (XItem)XDataPool<XFashionItem>.GetData();
            (item as XFashionItem).fashionLevel = KKSGItem.FashionLevel;
        }

        private static void MakeXJadeItem(ref XItem item, Item KKSGItem)
        {
            if (item == null)
                item = (XItem)XDataPool<XJadeItem>.GetData();
            XBagDocument.MakeXAttrItem(ref item, KKSGItem);
            if (item is XJadeItem)
                return;
            XSingleton<XDebug>.singleton.AddErrorLog("Cant create XJadeItem");
        }

        private static void MakeXAttrItem(ref XItem item, Item KKSGItem)
        {
            if (item == null)
                XSingleton<XDebug>.singleton.AddErrorLog("XItem == null");
            else if (!(item is XAttrItem xattrItem2))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Cant create XAttrItem");
            }
            else
            {
                xattrItem2.changeAttr.Clear();
                for (int index = 0; index < KKSGItem.AttrID.Count; ++index)
                {
                    uint num = KKSGItem.AttrID[index];
                    XItemChangeAttr xitemChangeAttr;
                    xitemChangeAttr.AttrID = num;
                    xitemChangeAttr.AttrValue = KKSGItem.AttrValue[index];
                    xattrItem2.changeAttr.Add(xitemChangeAttr);
                }
            }
        }

        private static void MakeXLotteryBoxItem(ref XItem item, Item KKSGItem)
        {
            if (item == null)
                item = (XItem)XDataPool<XLotteryBoxItem>.GetData();
            XLotteryBoxItem xlotteryBoxItem = item as XLotteryBoxItem;
            for (int index = 0; index < KKSGItem.circleDrawDatas.Count && index < XLotteryBoxItem.POOL_SIZE; ++index)
            {
                CircleDrawData circleDrawData = KKSGItem.circleDrawDatas[index];
                if ((long)circleDrawData.index < (long)XLotteryBoxItem.POOL_SIZE)
                {
                    XItem xitem = xlotteryBoxItem.itemList[(int)circleDrawData.index];
                    xitem.itemID = (int)circleDrawData.itemid;
                    xitem.itemCount = (int)circleDrawData.itemcount;
                }
            }
        }

        public static XItem MakeXItem(int itemID, bool bBinding = false)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
            XItem xitem = (XItem)null;
            if (itemConf != null)
            {
                ItemType itemType = (ItemType)itemConf.ItemType;
                switch (itemType)
                {
                    case ItemType.EQUIP:
                        xitem = (XItem)XDataPool<XEquipItem>.GetData();
                        break;
                    case ItemType.FASHION:
                        xitem = (XItem)XDataPool<XFashionItem>.GetData();
                        break;
                    case ItemType.EMBLEM:
                        xitem = (XItem)XDataPool<XEmblemItem>.GetData();
                        break;
                    case ItemType.JADE:
                        xitem = (XItem)XDataPool<XJadeItem>.GetData();
                        break;
                    case ItemType.ARTIFACT:
                        xitem = (XItem)XDataPool<XArtifactItem>.GetData();
                        break;
                    default:
                        xitem = (XItem)XDataPool<XNormalItem>.GetData();
                        break;
                }
                xitem.itemID = itemID;
                xitem.type = (uint)itemConf.ItemType;
                xitem.itemCount = (int)XBagDocument.BagDoc.GetItemCount(itemID);
                xitem.bBinding = bBinding;
                xitem.blocking = 0.0;
                xitem.itemConf = itemConf;
                switch (itemType)
                {
                    case ItemType.EQUIP:
                        EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemID);
                        if (equipConf != null)
                        {
                            XEquipItem xequipItem = xitem as XEquipItem;
                            for (int index = 0; index < equipConf.Attributes.Count; ++index)
                            {
                                XItemChangeAttr xitemChangeAttr;
                                xitemChangeAttr.AttrID = (uint)equipConf.Attributes[index, 0];
                                xitemChangeAttr.AttrValue = (uint)equipConf.Attributes[index, 1];
                                xequipItem.changeAttr.Add(xitemChangeAttr);
                            }
                            xequipItem.randAttrInfo.bPreview = true;
                            xequipItem.forgeAttrInfo.bPreview = true;
                            break;
                        }
                        break;
                    case ItemType.FASHION:
                        SeqListRef<uint> fashionAttr = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID).GetFashionAttr(itemID, 0);
                        XFashionItem xfashionItem = xitem as XFashionItem;
                        xfashionItem.itemCount = 1;
                        for (int index = 0; index < fashionAttr.Count; ++index)
                        {
                            XItemChangeAttr xitemChangeAttr;
                            xitemChangeAttr.AttrID = fashionAttr[index, 0];
                            xitemChangeAttr.AttrValue = fashionAttr[index, 1];
                            xfashionItem.changeAttr.Add(xitemChangeAttr);
                        }
                        break;
                    case ItemType.EMBLEM:
                        XEmblemItem xemblemItem = xitem as XEmblemItem;
                        xemblemItem.emblemInfo.thirdslot = 10U;
                        xemblemItem.emblemInfo.level = (uint)itemConf.ReqLevel;
                        int startIndex;
                        int endIndex;
                        XEquipCreateDocument.GetEmblemAttrDataByID((uint)xitem.itemID, out startIndex, out endIndex);
                        if (startIndex >= 0)
                        {
                            for (int index = startIndex; index < endIndex; ++index)
                            {
                                AttributeEmblem.RowData attributeEmblem = XEquipCreateDocument.GetAttributeEmblem(index);
                                if (attributeEmblem.Position == (byte)1 || attributeEmblem.Position == (byte)2)
                                {
                                    XItemChangeAttr xitemChangeAttr;
                                    xitemChangeAttr.AttrID = (uint)attributeEmblem.AttrID;
                                    xitemChangeAttr.AttrValue = attributeEmblem.Range[0];
                                    xemblemItem.changeAttr.Add(xitemChangeAttr);
                                }
                            }
                            break;
                        }
                        break;
                    case ItemType.JADE:
                        JadeTable.RowData byJadeId = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID).jadeTable.GetByJadeID((uint)itemID);
                        if (byJadeId != null)
                        {
                            XJadeItem xjadeItem = xitem as XJadeItem;
                            for (int index = 0; index < byJadeId.JadeAttributes.Count; ++index)
                            {
                                XItemChangeAttr xitemChangeAttr;
                                xitemChangeAttr.AttrID = byJadeId.JadeAttributes[index, 0];
                                xitemChangeAttr.AttrValue = byJadeId.JadeAttributes[index, 1];
                                xjadeItem.changeAttr.Add(xitemChangeAttr);
                            }
                            break;
                        }
                        break;
                    case ItemType.ARTIFACT:
                        (xitem as XArtifactItem).RandAttrInfo.bPreview = true;
                        break;
                }
            }
            else
                XSingleton<XDebug>.singleton.AddErrorLog("Cant find item config for id: " + itemID.ToString());
            return xitem;
        }

        public static XItem MakeXItem(Item KKSGItem)
        {
            XItem xitem = (XItem)null;
            switch ((ItemType)KKSGItem.ItemType)
            {
                case ItemType.EQUIP:
                    XBagDocument.MakeXEquipItem(ref xitem, KKSGItem);
                    break;
                case ItemType.FASHION:
                    XBagDocument.MakeXFashionItem(ref xitem, KKSGItem);
                    break;
                case ItemType.EMBLEM:
                    XBagDocument.MakeXEmblemItem(ref xitem, KKSGItem);
                    break;
                case ItemType.JADE:
                    XBagDocument.MakeXJadeItem(ref xitem, KKSGItem);
                    break;
                case ItemType.LOTTERY_BOX:
                    XBagDocument.MakeXLotteryBoxItem(ref xitem, KKSGItem);
                    break;
                case ItemType.ARTIFACT:
                    XBagDocument.MakeXArtifactItem(ref xitem, KKSGItem);
                    break;
                default:
                    xitem = (XItem)XDataPool<XNormalItem>.GetData();
                    break;
            }
            xitem.uid = KKSGItem.uid;
            xitem.type = KKSGItem.ItemType;
            xitem.itemID = (int)KKSGItem.ItemID;
            xitem.itemCount = (int)KKSGItem.ItemCount;
            xitem.bBinding = KKSGItem.isbind;
            xitem.itemConf = XBagDocument.GetItemConf(xitem.itemID);
            if (xitem.itemConf == null && xitem.uid > 0UL)
                XSingleton<XDebug>.singleton.AddGreenLog("Cant find item config for id: ", xitem.itemID.ToString(), ", uid = ", xitem.uid.ToString());
            xitem.bexpirationTime = KKSGItem.expirationTime;
            double num = 0.0;
            if (KKSGItem.cooldown > 0U)
            {
                num = XSingleton<UiUtility>.singleton.TimeFormatLastTime((double)KKSGItem.cooldown, true);
                if (num < 0.0)
                    num = 0.0;
            }
            xitem.blocking = num;
            return xitem;
        }

        public static XItem MakeFasionItemById(uint id)
        {
            XItem data = (XItem)XDataPool<XFashionItem>.GetData();
            data.uid = 0UL;
            data.type = 5U;
            data.itemID = (int)id;
            data.itemCount = 1;
            return data;
        }

        public bool GetBodyPosByUID(ulong uid, out int pos, out XBodyBag bag, out bool isEquip)
        {
            if (this.EquipBag.GetItemPos(uid, out pos))
            {
                bag = this.EquipBag;
                isEquip = true;
                return true;
            }
            if (this.EmblemBag.GetItemPos(uid, out pos))
            {
                bag = this.EmblemBag;
                isEquip = false;
                return true;
            }
            if (this.ArtifactBag.GetItemPos(uid, out pos))
            {
                bag = this.ArtifactBag;
                isEquip = false;
                return true;
            }
            bag = (XBodyBag)null;
            pos = -1;
            isEquip = false;
            return false;
        }

        public XItem GetBodyItemByUID(ulong uid) => this.EquipBag.GetItemByUID(uid) ?? this.EmblemBag.GetItemByUID(uid) ?? this.ArtifactBag.GetItemByUID(uid) ?? (XItem)null;

        public XItem GetBodyItemByID(int id) => this.EquipBag.GetItemByID(id) ?? this.EmblemBag.GetItemByID(id) ?? this.ArtifactBag.GetItemByID(id) ?? (XItem)null;

        public int GetBodyItemCountByID(int id)
        {
            int itemCountById = this.EquipBag.GetItemCountByID(id);
            if (itemCountById == 0)
                itemCountById = this.EmblemBag.GetItemCountByID(id);
            if (itemCountById == 0)
                itemCountById = this.ArtifactBag.GetItemCountByID(id);
            return itemCountById;
        }

        public XItem GetBagItemByUID(ulong uid)
        {
            int index = 0;
            return this.ItemBag.FindItem(uid, out index) ? this.ItemBag[index] : (XItem)null;
        }

        public XItem GetBagItemByUID(string struid)
        {
            ulong result = 0;
            return ulong.TryParse(struid, out result) ? this.GetBagItemByUID(result) : (XItem)null;
        }

        public XItem GetItemByUID(ulong uid)
        {
            int index = 0;
            XItem bodyItemByUid = this.GetBodyItemByUID(uid);
            if (bodyItemByUid != null)
                return bodyItemByUid;
            return this.ItemBag.FindItem(uid, out index) ? this.ItemBag[index] : (XItem)null;
        }

        public XItem GetItemByUID(string struid)
        {
            ulong result = 0;
            return ulong.TryParse(struid, out result) ? this.GetItemByUID(result) : (XItem)null;
        }

        public bool GetItemByItemId(int itemId, out List<XItem> lst) => this.ItemBag.FindItemByID(itemId, out lst);

        private static int ItemType2Int(ItemType type) => XFastEnumIntEqualityComparer<ItemType>.ToInt(type);

        public static int BodyPosition<T>(T type) where T : struct => XFastEnumIntEqualityComparer<T>.ToInt(type);

        internal static void InitAddEquiptItem(ref XBodyBag bag, List<Item> list, int bagSize)
        {
            if (bag == null)
                bag = new XBodyBag(bagSize);
            for (int key = 0; key < bag.Length; ++key)
            {
                if (bag[key] != null)
                {
                    bag[key].Recycle();
                    bag[key] = (XItem)null;
                }
            }
            int num = Math.Min(list.Count, bag.Length);
            for (int index = 0; index < num; ++index)
            {
                XItem xitem = XBagDocument.MakeXItem(list[index]);
                if (xitem.itemID == 0)
                {
                    xitem.Recycle();
                    xitem = (XItem)null;
                }
                bag[index] = xitem;
            }
        }

        internal void Init(BagContent Bag)
        {
            XEmblemDocument.HadSlottingNum = (int)Bag.extraSkillEbSlotNum;
            for (int index = 0; index < Bag.expand.Count; ++index)
                this.SetBagExpandData(Bag.expand[index], false);
            XBagDocument.InitAddEquiptItem(ref this.EquipBag, Bag.Equips, XBagDocument.EquipMax);
            XBagDocument.InitAddEquiptItem(ref this.EmblemBag, Bag.Emblems, XBagDocument.EmblemMax);
            XBagDocument.InitAddEquiptItem(ref this.ArtifactBag, Bag.Artifacts, XBagDocument.ArtifactMax);
            int count = this.ItemBag.Count;
            for (int key = 0; key < count; ++key)
                this.ItemBag[key].Recycle();
            this.ItemBag.Clear();
            for (int index = 0; index < Bag.Items.Count; ++index)
                this.ItemBag.AddItem(XBagDocument.MakeXItem(Bag.Items[index]), false);
            int index1;
            for (index1 = 0; index1 < Bag.virtualitems.Count; ++index1)
                this.VirtualItems[index1] = Bag.virtualitems[index1];
            for (; index1 < this.VirtualItems.Length; ++index1)
                this.VirtualItems[index1] = 0UL;
            this.ItemBag.SortItem();
            XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID).UpdateRedPoints();
            XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID).UpdateRedPoints();
            XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID).UpdateRedPoints();
            XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.enhanceMasterLevel = Bag.enhanceSuit;
            XSingleton<XAttributeMgr>.singleton.XPlayerData.EmblemBag = this.EmblemBag;
            this.TearsCount = (ulong)this.ItemBag.GetItemCount(88);
        }

        public void SetBagExpandData(KKSG.BagExpandData data, bool isShowTip)
        {
            for (int index = 0; index < this.BagExpandDataList.Count; ++index)
            {
                if (this.BagExpandDataList[index].Type == data.type)
                {
                    this.BagExpandDataList[index].ExpandNum = data.num;
                    this.BagExpandDataList[index].ExpandTimes = data.count;
                    if (!isShowTip)
                        break;
                    switch (data.type)
                    {
                        case BagType.EquipBag:
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ExpandEquipBagSuc"), "fece00");
                            XDocuments.GetSpecificDocument<XCharacterEquipDocument>(XCharacterEquipDocument.uuID).RefreshBag();
                            break;
                        case BagType.EmblemBag:
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ExpandEmblemBagSuc"), "fece00");
                            XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID).RefreshBag();
                            break;
                        case BagType.ArtifactBag:
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ExpandArtifactBagSuc"), "fece00");
                            ArtifactBagDocument.Doc.RefreshBag();
                            break;
                        case BagType.ItemBag:
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ExpandItemBagSuc"), "fece00");
                            XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID).RefreshBag();
                            break;
                    }
                    break;
                }
            }
        }

        public void UseBagExpandTicket(BagType type)
        {
            BagExpandItemListTable.RowData expandItemConfByType = XBagDocument.GetExpandItemConfByType((uint)XFastEnumIntEqualityComparer<BagType>.ToInt(type));
            if (expandItemConfByType == null)
                return;
            this.m_usedBagExpandRow = expandItemConfByType;
            int itemId = (int)expandItemConfByType.ItemId;
            BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData((BagType)expandItemConfByType.Type);
            if (bagExpandData == null)
                return;
            if ((uint)expandItemConfByType.NeedAndOpen.count > bagExpandData.ExpandTimes)
            {
                ItemList.RowData itemConf = XBagDocument.GetItemConf(itemId);
                XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<XStringTable>.singleton.GetString("BagExpandSureTips"), (object)expandItemConfByType.NeedAndOpen[(int)bagExpandData.ExpandTimes, 0], (object)itemConf.ItemName[0], (object)expandItemConfByType.NeedAndOpen[(int)bagExpandData.ExpandTimes, 1]), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ReqUseBagExpandTicket));
            }
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<UiUtility>.singleton.GetBagExpandFullTips((BagType)expandItemConfByType.Type), "fece00");
        }

        private bool ReqUseBagExpandTicket(IXUIButton btn)
        {
            BagExpandItemListTable.RowData usedBagExpandRow = this.m_usedBagExpandRow;
            if (usedBagExpandRow == null)
                return false;
            int itemId = (int)usedBagExpandRow.ItemId;
            BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData((BagType)usedBagExpandRow.Type);
            if (bagExpandData != null)
            {
                ulong itemCount = XBagDocument.BagDoc.GetItemCount(itemId);
                if (itemCount >= (ulong)usedBagExpandRow.NeedAndOpen[(int)bagExpandData.ExpandTimes, 0] && itemCount > 0UL)
                {
                    List<XItem> lst;
                    if (this.GetItemByItemId(itemId, out lst))
                        XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(lst[0]);
                }
                else
                    XSingleton<UiUtility>.singleton.ShowItemAccess(itemId, (AccessCallback)null);
            }
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            return true;
        }

        internal ulong GetItemCount(int itemid) => itemid < XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.VIRTUAL_ITEM_MAX) ? this.GetVirtualItemCount((ItemEnum)itemid) : (ulong)this.ItemBag.GetItemCount(itemid);

        internal ulong GetItemCount(int itemid, bool isBind) => itemid < XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.VIRTUAL_ITEM_MAX) ? this.GetVirtualItemCount((ItemEnum)itemid) : (ulong)this.ItemBag.GetItemCount(itemid, isBind);

        internal ulong GetVirtualItemCount(ItemEnum t) => this.VirtualItems[XFastEnumIntEqualityComparer<ItemEnum>.ToInt(t)];

        internal ulong GetSkillPointCount(bool isAwakeSkillPoint = false) => XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex == 0U ? this.VirtualItems[XFastEnumIntEqualityComparer<ItemEnum>.ToInt(isAwakeSkillPoint ? ItemEnum.AWAKE_SKILL_POINT : ItemEnum.SKILL_POINT)] : this.VirtualItems[XFastEnumIntEqualityComparer<ItemEnum>.ToInt(isAwakeSkillPoint ? ItemEnum.AWAKE_SKILL_POINT_TWO : ItemEnum.SKILL_POINT_TWO)];

        internal void SetVirtualItemCount(int t, ulong Count)
        {
            ulong num = 0;
            if (t < XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.VIRTUAL_ITEM_MAX))
            {
                num = this.VirtualItems[t];
                this.VirtualItems[t] = Count;
            }
            else if (t == 88)
            {
                num = this.TearsCount;
                this.TearsCount = Count;
            }
            if (t == 6)
                XSingleton<XDebug>.singleton.AddLog("Set fatigue = ", Count.ToString());
            XVirtualItemChangedEventArgs changedEventArgs = XEventPool<XVirtualItemChangedEventArgs>.GetEvent();
            changedEventArgs.e = (ItemEnum)t;
            changedEventArgs.newValue = Count;
            changedEventArgs.oldValue = num;
            changedEventArgs.itemID = t;
            changedEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)changedEventArgs);
        }

        internal void UpdateItem(Item KKSGItem)
        {
            XItem xitem = XBagDocument.MakeXItem(KKSGItem);
            int index;
            if (this.ItemBag.FindItem(xitem.uid, out index))
            {
                this.ItemBag[index].Recycle();
                this.ItemBag[index] = xitem;
            }
            else if (xitem.Type == ItemType.EQUIP)
                this.EquipBag.UpdateItem(xitem);
            else if (xitem.Type == ItemType.EMBLEM)
                this.EmblemBag.UpdateItem(xitem);
            else if (xitem.Type == ItemType.ARTIFACT)
                this.ArtifactBag.UpdateItem(xitem);
            XUpdateItemEventArgs xupdateItemEventArgs = XEventPool<XUpdateItemEventArgs>.GetEvent();
            xupdateItemEventArgs.item = xitem;
            xupdateItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xupdateItemEventArgs);
        }

        internal void AddNewItem(Item KKSGItem)
        {
            XItem xitem = XBagDocument.MakeXItem(KKSGItem);
            this.ItemBag.AddItem(xitem, true);
            XAddItemEventArgs xaddItemEventArgs = XEventPool<XAddItemEventArgs>.GetEvent();
            xaddItemEventArgs.items.Add(xitem);
            xaddItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaddItemEventArgs);
        }

        internal void AddNewItem(List<Item> KKSGItems, bool bIsNew = true)
        {
            XAddItemEventArgs xaddItemEventArgs = XEventPool<XAddItemEventArgs>.GetEvent();
            xaddItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            xaddItemEventArgs.bNew = bIsNew;
            foreach (Item kksgItem in KKSGItems)
            {
                XItem xitem = XBagDocument.MakeXItem(kksgItem);
                this.ItemBag.AddItem(xitem, false);
                xaddItemEventArgs.items.Add(xitem);
            }
            if (xaddItemEventArgs.items.Count > 0)
            {
                this.ItemBag.SortItem();
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaddItemEventArgs);
            }
            else
                xaddItemEventArgs.Recycle();
        }

        internal void RemoveItem(ulong uid)
        {
            int index;
            if (!this.ItemBag.FindItem(uid, out index))
                return;
            XRemoveItemEventArgs xremoveItemEventArgs = XEventPool<XRemoveItemEventArgs>.GetEvent();
            xremoveItemEventArgs.uids.Add(uid);
            xremoveItemEventArgs.types.Add(this.ItemBag[index].Type);
            xremoveItemEventArgs.ids.Add(this.ItemBag[index].itemID);
            this.ItemBag.RemoveIndex(index);
            xremoveItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
        }

        internal void RemoveItem(List<ulong> uids)
        {
            XRemoveItemEventArgs xremoveItemEventArgs = XEventPool<XRemoveItemEventArgs>.GetEvent();
            xremoveItemEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            foreach (ulong uid in uids)
            {
                int index;
                if (this.ItemBag.FindItem(uid, out index))
                {
                    XItem xitem = this.ItemBag[index];
                    xremoveItemEventArgs.uids.Add(uid);
                    xremoveItemEventArgs.types.Add(xitem.Type);
                    xremoveItemEventArgs.ids.Add(xitem.itemID);
                    xitem.Recycle();
                    this.ItemBag.RemoveIndex(index);
                }
            }
            if (xremoveItemEventArgs.uids.Count > 0)
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xremoveItemEventArgs);
            else
                xremoveItemEventArgs.Recycle();
        }

        internal void ChangeItemCount(ulong uid, int count, bool bIsNew = true)
        {
            int index;
            if (!this.ItemBag.FindItem(uid, out index))
                return;
            XItem xitem = this.ItemBag[index];
            int itemCount = xitem.itemCount;
            xitem.itemCount = count;
            XItemNumChangedEventArgs changedEventArgs = XEventPool<XItemNumChangedEventArgs>.GetEvent();
            changedEventArgs.oldCount = itemCount;
            changedEventArgs.item = xitem;
            changedEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            changedEventArgs.bNew = bIsNew;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)changedEventArgs);
        }

        internal void FinishItemChange()
        {
            XItemChangeFinishedEventArgs finishedEventArgs = XEventPool<XItemChangeFinishedEventArgs>.GetEvent();
            finishedEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)finishedEventArgs);
        }

        private void _RemoveCompareAttrsFromPool(ulong uid)
        {
            this.basicAttrPool.Remove(uid);
            this.equipAdditionalAttrPool.Remove(uid);
        }

        public uint GetItemPPT(XAttrItem item, ItemAttrCompareType type)
        {
            if (item == null)
                return 0;
            Dictionary<ulong, uint> dictionary = (Dictionary<ulong, uint>)null;
            switch (type)
            {
                case ItemAttrCompareType.IACT_SELF:
                    dictionary = this.basicAttrPool;
                    break;
                case ItemAttrCompareType.IACT_TOTAL:
                    dictionary = this.equipAdditionalAttrPool;
                    break;
            }
            uint num1 = 0;
            ulong key = item.uid;
            if (key == 0UL)
                key = (ulong)item.itemID;
            if (!dictionary.TryGetValue(key, out num1))
            {
                XEquipItem xequipItem = item as XEquipItem;
                double num2 = 0.0;
                if ((uint)(type & ItemAttrCompareType.IACT_BASIC) > 0U)
                {
                    for (int index = 0; index < item.changeAttr.Count; ++index)
                        num2 += XSingleton<XPowerPointCalculator>.singleton.GetPPT(item.changeAttr[index]);
                }
                if (xequipItem != null && (uint)(type & ItemAttrCompareType.IACT_RANDOM) > 0U)
                {
                    for (int index = 0; index < xequipItem.randAttrInfo.RandAttr.Count; ++index)
                        num2 += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xequipItem.randAttrInfo.RandAttr[index]);
                }
                if (xequipItem != null && (uint)(type & ItemAttrCompareType.IACT_FORGE) > 0U)
                {
                    for (int index = 0; index < xequipItem.forgeAttrInfo.ForgeAttr.Count; ++index)
                        num2 += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xequipItem.forgeAttrInfo.ForgeAttr[index]);
                }
                if (xequipItem != null && (uint)(type & ItemAttrCompareType.IACT_ENHANCE) > 0U)
                {
                    for (int index = 0; index < xequipItem.enhanceInfo.EnhanceAttr.Count; ++index)
                        num2 += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xequipItem.enhanceInfo.EnhanceAttr[index]);
                }
                if (xequipItem != null && (uint)(type & ItemAttrCompareType.IACT_JADE) > 0U)
                {
                    for (int index = 0; index < xequipItem.jadeInfo.jades.Length; ++index)
                        num2 += (double)this.GetItemPPT((XAttrItem)xequipItem.jadeInfo.jades[index], ItemAttrCompareType.IACT_SELF);
                }
                num1 = (uint)num2;
                dictionary.Add(key, num1);
            }
            return num1;
        }

        public override void Update(float fDeltaT)
        {
            if (this.ItemBag == null)
                return;
            int key = 0;
            for (int count = this.ItemBag.Count; key < count; ++key)
            {
                if (!this.ItemBag[key].bBinding && this.ItemBag[key].blocking > 0.0)
                    this.ItemBag[key].blocking -= (double)fDeltaT;
            }
            if (!this.getallEquip)
                return;
            this.fashionTime += fDeltaT;
            if ((double)this.fashionTime > 0.300000011920929)
            {
                this.fashionTime = 0.0f;
                if (this.fashionIndex < XBagDocument.m_FashionTable.Table.Length)
                    XSingleton<XCommand>.singleton.ProcessCommand(string.Format("item {0} 1", (object)XBagDocument.m_FashionTable.Table[this.fashionIndex++].ItemID));
                else
                    this.getallEquip = false;
            }
        }

        public ItemAttrCompareResult IsAttrMorePowerful(
          XAttrItem left,
          XAttrItem right,
          ItemAttrCompareType type = ItemAttrCompareType.IACT_SELF)
        {
            uint itemPpt1 = this.GetItemPPT(left, type);
            uint itemPpt2 = this.GetItemPPT(right, type);
            if (itemPpt1 < itemPpt2)
                return ItemAttrCompareResult.IACR_SMALLER;
            return itemPpt1 > itemPpt2 ? ItemAttrCompareResult.IACR_LARGER : ItemAttrCompareResult.IACR_EQUAL;
        }

        public uint GetArtifactPPT(XAttrItem item)
        {
            if (item == null || !(item is XArtifactItem xartifactItem))
                return 0;
            double num = 0.0;
            for (int index = 0; index < xartifactItem.RandAttrInfo.RandAttr.Count; ++index)
            {
                if (xartifactItem.RandAttrInfo.RandAttr[index].AttrID != 0U)
                    num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xartifactItem.RandAttrInfo.RandAttr[index]);
            }
            return (uint)num;
        }

        public void ReqItemSell(ulong uid) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_ItemSell()
        {
            oArg = {
        uid = uid
      }
        });

        public void ReqItemCompose(ulong uid) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_ItemCompose()
        {
            oArg = {
        uid = uid.ToString()
      }
        });

        public static bool ItemCanShowTips(uint itemID)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemID);
            return itemConf != null && itemConf.ShowTips != (byte)0;
        }

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
            this.Init(arg.PlayerInfo.Bag);
            if (XSingleton<XEntityMgr>.singleton.Player == null || !(XSingleton<XEntityMgr>.singleton.Player.GetXComponent(XEquipComponent.uuID) is XEquipComponent xcomponent))
                return;
            xcomponent.EquipFromAttr();
        }

        public void GetAllEquip()
        {
            this.getallEquip = true;
            this.fashionIndex = 0;
            this.fashionTime = 0.4f;
        }
    }
}
