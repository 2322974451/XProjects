

using KKSG;
using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XGuildResContentionBuffDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildResContentionBuffDocument");
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static GuildBuffTable _guildBuffTable = new GuildBuffTable();
        private static GuildMineralStorage _guildMineralStorageTable = new GuildMineralStorage();
        private List<GuildBuffInfo> _myGuildOwnedBuffs = new List<GuildBuffInfo>();
        private List<GuildBuffInfo> _myselfOwnedBuffs = new List<GuildBuffInfo>();
        private List<GuildUsingBuffInfo> _mySelfActingBuffList = new List<GuildUsingBuffInfo>();
        private List<GuildBuffUsedRecordItem> _guildBuffUsedRecords = new List<GuildBuffUsedRecordItem>();
        private List<WarResGuildInfo> _guildInfoList = new List<WarResGuildInfo>();
        private Dictionary<ulong, List<GuildUsingBuffInfo>> _guildsBuffedInfos = new Dictionary<ulong, List<GuildUsingBuffInfo>>();
        private uint _guildBuffCDTime = 0;
        private ulong _guildID = 0;
        private uint _guildCdTimerID = 0;
        private uint _guildMaxResource = 1;

        public override uint ID => XGuildResContentionBuffDocument.uuID;

        public static XGuildResContentionBuffDocument Doc => XSingleton<XGame>.singleton.Doc.GetXComponent(XGuildResContentionBuffDocument.uuID) as XGuildResContentionBuffDocument;

        public static GuildBuffTable GuildBuffData => XGuildResContentionBuffDocument._guildBuffTable;

        public static GuildMineralStorage GuildMineralStorageTable => XGuildResContentionBuffDocument._guildMineralStorageTable;

        public static void Execute(OnLoadedCallback callback = null)
        {
            XGuildResContentionBuffDocument.AsyncLoader.AddTask("Table/GuildBuff", (CVSReader)XGuildResContentionBuffDocument._guildBuffTable);
            XGuildResContentionBuffDocument.AsyncLoader.AddTask("Table/GuildMineralStorage", (CVSReader)XGuildResContentionBuffDocument._guildMineralStorageTable);
            XGuildResContentionBuffDocument.AsyncLoader.Execute(callback);
        }

        public override void OnAttachToHost(XObject host) => base.OnAttachToHost(host);

        protected override void EventSubscribe() => base.EventSubscribe();

        public override void OnDetachFromHost() => base.OnDetachFromHost();

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
        }

        public override void OnEnterSceneFinally() => base.OnEnterSceneFinally();

        public uint GuildBuffCDTime
        {
            get => this._guildBuffCDTime;
            set => this._guildBuffCDTime = value;
        }

        public ulong GuildID
        {
            get => this._guildID;
            set => this._guildID = value;
        }

        public List<GuildBuffUsedRecordItem> MineUsedBuffRecordList
        {
            get => this._guildBuffUsedRecords;
            set => this._guildBuffUsedRecords = value;
        }

        public uint GuildMaxResource
        {
            get => this._guildMaxResource;
            set => this._guildMaxResource = value;
        }

        public List<GuildBuffInfo> MyselfOwnedBuffs
        {
            get => this._myselfOwnedBuffs;
            set => this._myselfOwnedBuffs = value;
        }

        public List<GuildUsingBuffInfo> MySelfActingBuffList
        {
            get => this._mySelfActingBuffList;
            set => this._mySelfActingBuffList = value;
        }

        public List<GuildBuffInfo> MyGuildOwnedBuffs
        {
            get => this._myGuildOwnedBuffs;
            set => this._myGuildOwnedBuffs = value;
        }

        public GuildBuffTable.RowData GetGuildBuffDataByItemID(uint itemID)
        {
            for (int index = 0; index < XGuildResContentionBuffDocument._guildBuffTable.Table.Length; ++index)
            {
                if ((int)XGuildResContentionBuffDocument._guildBuffTable.Table[index].itemid == (int)itemID)
                    return XGuildResContentionBuffDocument._guildBuffTable.Table[index];
            }
            return (GuildBuffTable.RowData)null;
        }

        public GuildBuffTable.RowData GetGuildBuffDataByBuffID(uint buffID)
        {
            for (int index = 0; index < XGuildResContentionBuffDocument._guildBuffTable.Table.Length; ++index)
            {
                if ((int)XGuildResContentionBuffDocument._guildBuffTable.Table[index].id == (int)buffID)
                    return XGuildResContentionBuffDocument._guildBuffTable.Table[index];
            }
            return (GuildBuffTable.RowData)null;
        }

        public GuildMineralStorage.RowData GetMineralStorageByID(uint id)
        {
            for (int index = 0; index < XGuildResContentionBuffDocument._guildMineralStorageTable.Table.Length; ++index)
            {
                if ((int)XGuildResContentionBuffDocument._guildMineralStorageTable.Table[index].itemid == (int)id)
                    return XGuildResContentionBuffDocument._guildMineralStorageTable.Table[index];
            }
            return (GuildMineralStorage.RowData)null;
        }

        public void SendGuildBuffReq(ulong guildID, uint itemID) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_UseGuildBuff()
        {
            oArg = {
        guildid = guildID,
        itemid = itemID
      }
        });

        public void SendPersonalBuffOpReq(ulong entityID, uint itemID, PersonalBuffOpType opType) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_ItemBuffOp()
        {
            oArg = {
        itemcount = 1U,
        itemid = itemID,
        op = (uint) opType
      }
        });

        public void OnGetUseGuildBuffResult(UseGuildBuffArg oArg, UseGuildBuffRes oRes)
        {
            if (oRes.error == ErrorCode.ERR_SUCCESS)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("BuffUseSuc"), "fece00");
                this._guildBuffCDTime = oRes.cd;
                DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshOwnedBuffItem(oArg.itemid, this._guildBuffCDTime);
            }
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error);
        }

        public void OnGetPersonalBuffOperationResult(ItemBuffOpArg oArg, ItemBuffOpRes oRes)
        {
            if (oRes.errorcode == ErrorCode.ERR_SUCCESS)
            {
                if (oArg.op == 0U)
                {
                    this._myselfOwnedBuffs.Clear();
                    for (int index = 0; index < oRes.itemid.Count; ++index)
                        this._myselfOwnedBuffs.Add(new GuildBuffInfo()
                        {
                            itemID = oRes.itemid[index],
                            count = oRes.itemcount[index]
                        });
                }
                else if (oArg.op == 1U)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("BuffUseSuc"), "fece00");
                    for (int index = 0; index < this._myselfOwnedBuffs.Count; ++index)
                    {
                        if ((int)this._myselfOwnedBuffs[index].itemID == (int)oArg.itemid)
                        {
                            if (this._myselfOwnedBuffs[index].count <= 1U)
                            {
                                this._myselfOwnedBuffs.RemoveAt(index);
                                break;
                            }
                            --this._myselfOwnedBuffs[index].count;
                            break;
                        }
                    }
                    ItemBuffTable.RowData itembuffDataById = XHomeCookAndPartyDocument.Doc.GetItembuffDataByID(oArg.itemid);
                    if (itembuffDataById != null)
                    {
                        for (int index1 = 0; index1 < itembuffDataById.Buffs.Count; ++index1)
                        {
                            BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)itembuffDataById.Buffs[index1, 0], (int)itembuffDataById.Buffs[index1, 1]);
                            if ((double)buffData.BuffDuration > 0.0)
                            {
                                bool flag = false;
                                for (int index2 = 0; index2 < this._mySelfActingBuffList.Count; ++index2)
                                {
                                    if ((long)this._mySelfActingBuffList[index2].buffID == (long)buffData.BuffID)
                                    {
                                        this._mySelfActingBuffList[index2].time = (uint)buffData.BuffDuration;
                                        flag = true;
                                        break;
                                    }
                                }
                                if (!flag)
                                    this._mySelfActingBuffList.Add(new GuildUsingBuffInfo()
                                    {
                                        buffID = (uint)buffData.BuffID,
                                        time = (uint)buffData.BuffDuration
                                    });
                            }
                        }
                    }
                    if (!DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible())
                        return;
                    DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshOwnedBuffItem(oArg.itemid, 0U);
                    DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshMySelfActingBuff();
                }
                else if (oArg.op == 2U)
                {
                    this.MySelfActingBuffList.Clear();
                    for (int index = 0; index < oRes.buffid.Count; ++index)
                        this._mySelfActingBuffList.Add(new GuildUsingBuffInfo()
                        {
                            buffID = oRes.buffid[index],
                            time = oRes.lefttime[index]
                        });
                    if (!DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible())
                        return;
                    DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshMySelfActingBuff();
                }
                else
                {
                    if (oArg.op != 3U)
                        return;
                    if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HORSE_RACE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING)
                        XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID).UseDoodad(oArg, oRes);
                    else if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_SURVIVE)
                        ;
                }
            }
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode);
        }

        public void OnGetBuffAllInfo(ResWarGuildBrief res)
        {
            if (res == null || res.error != ErrorCode.ERR_SUCCESS)
                return;
            this.GuildBuffCDTime = res.cardcd;
            this.GuildID = res.guildid;
            this.GuildMaxResource = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("GuildResMax");
            List<GuildBuffItem> buffItems = res.item;
            if (buffItems != null)
                this.UpdateOwnedBuffList(buffItems);
            this.OnGetGuildInfoList(res.rankinfo);
            this.OnGetGuildBuffList(res.buffinfo);
            this.UpdateBuffRecords(res.chatinfo);
        }

        public WarResGuildInfo GetPKGuildInfos(int index) => index < this._guildInfoList.Count ? this._guildInfoList[index] : (WarResGuildInfo)null;

        public List<WarResGuildInfo> GetAllGuildInfos() => this._guildInfoList;

        public List<GuildUsingBuffInfo> GetGuildUsedBuffList(ulong guildID)
        {
            List<GuildUsingBuffInfo> guildUsingBuffInfoList = (List<GuildUsingBuffInfo>)null;
            foreach (KeyValuePair<ulong, List<GuildUsingBuffInfo>> guildsBuffedInfo in this._guildsBuffedInfos)
            {
                if ((long)guildsBuffedInfo.Key == (long)guildID)
                {
                    guildUsingBuffInfoList = this._guildsBuffedInfos[guildsBuffedInfo.Key];
                    return guildUsingBuffInfoList;
                }
            }
            return guildUsingBuffInfoList;
        }

        public GuildBuffInfo GetGuildOwnedSomeCardInfo(uint itemID)
        {
            for (int index = 0; index < this.MyGuildOwnedBuffs.Count; ++index)
            {
                if ((int)this.MyGuildOwnedBuffs[index].itemID == (int)itemID && this.MyGuildOwnedBuffs[index].count > 0U)
                    return this.MyGuildOwnedBuffs[index];
            }
            return (GuildBuffInfo)null;
        }

        public GuildBuffInfo GetMyOwnedSomeCardInfo(uint itemID)
        {
            for (int index = 0; index < this._myselfOwnedBuffs.Count; ++index)
            {
                if ((int)this._myselfOwnedBuffs[index].itemID == (int)itemID)
                    return this._myselfOwnedBuffs[index];
            }
            return (GuildBuffInfo)null;
        }

        public void StartCDTimer()
        {
            this.StopCDTimer();
            this._guildCdTimerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(1f, new XTimerMgr.AccurateElapsedEventHandler(this.RefreshCardCD), (object)null);
        }

        public void StopCDTimer()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._guildCdTimerID);
            this._guildCdTimerID = 0U;
        }

        private void RefreshCardCD(object param, float delay)
        {
            this.MinusGuildBuffCDTime();
            this.RefreshUICD();
            this.StartCDTimer();
        }

        private void RefreshUICD()
        {
            if (DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible())
            {
                DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshGuildBuffCD();
                DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshMySelfActingBuff();
            }
            GuildBuffOperationHandler guildBuffHandler = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.GuildBuffHandler;
            if (guildBuffHandler == null || !guildBuffHandler.IsVisible())
                return;
            guildBuffHandler.RefreshCardCd();
        }

        private void MinusGuildBuffCDTime()
        {
            this._guildBuffCDTime = this._guildBuffCDTime > 0U ? this._guildBuffCDTime - 1U : 0U;
            foreach (List<GuildUsingBuffInfo> guildUsingBuffInfoList in this._guildsBuffedInfos.Values)
            {
                for (int index = 0; index < guildUsingBuffInfoList.Count; ++index)
                    guildUsingBuffInfoList[index].time = guildUsingBuffInfoList[index].time > 0U ? guildUsingBuffInfoList[index].time - 1U : 0U;
            }
            for (int index = this._mySelfActingBuffList.Count - 1; index >= 0; --index)
            {
                if (this._mySelfActingBuffList[index].time == 0U)
                    this._mySelfActingBuffList.RemoveAt(index);
                else
                    --this._mySelfActingBuffList[index].time;
            }
        }

        private void UpdateOwnedBuffList(List<GuildBuffItem> buffItems)
        {
            if (buffItems == null)
                return;
            this.MyGuildOwnedBuffs.Clear();
            for (int index = 0; index < buffItems.Count; ++index)
                this.MyGuildOwnedBuffs.Add(new GuildBuffInfo()
                {
                    itemID = buffItems[index].itemid,
                    count = buffItems[index].count
                });
        }

        private void UpdateBuffRecords(List<KKSG.ChatInfo> usedBuffs)
        {
            if (usedBuffs == null)
                return;
            this._guildBuffUsedRecords.Clear();
            XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            for (int index = 0; index < usedBuffs.Count; ++index)
                this._guildBuffUsedRecords.Add(new GuildBuffUsedRecordItem()
                {
                    MainMessage = specificDocument.ProcessText(usedBuffs[index])
                });
        }

        internal void OnGetGuildBuffList(List<GuildBuffSimpleInfo> buffs)
        {
            if (buffs == null)
                return;
            this._guildsBuffedInfos.Clear();
            for (int index1 = 0; index1 < buffs.Count; ++index1)
            {
                GuildBuffSimpleInfo buff = buffs[index1];
                this._guildsBuffedInfos.Add(buff.guildid, new List<GuildUsingBuffInfo>());
                for (int index2 = 0; index2 < buff.buff.Count; ++index2)
                    this._guildsBuffedInfos[buff.guildid].Add(new GuildUsingBuffInfo()
                    {
                        buffID = buff.buff[index2].id,
                        time = buff.buff[index2].time
                    });
            }
            if (!DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible())
                return;
            DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshTopRightBuffs();
        }

        internal void OnGetGuildInfoList(ResWarRankSimpleInfo infos)
        {
            if (infos.rank == null)
                return;
            this._guildInfoList.Clear();
            List<ResWarRank> rank = infos.rank;
            for (int index = 0; index < rank.Count; ++index)
            {
                ResWarRank resWarRank = rank[index];
                WarResGuildInfo warResGuildInfo = new WarResGuildInfo()
                {
                    guildID = resWarRank.id,
                    guildName = resWarRank.name,
                    resValue = resWarRank.value,
                    guildIcon = resWarRank.icon
                };
                this.GuildMaxResource = Math.Max(this.GuildMaxResource, resWarRank.value);
                this._guildInfoList.Add(warResGuildInfo);
                if ((long)warResGuildInfo.guildID == (long)this._guildID)
                {
                    this._guildInfoList[index] = this._guildInfoList[0];
                    this._guildInfoList[0] = warResGuildInfo;
                }
            }
        }

        internal void OnGetOwnedGuildBuffList(PtcM2C_GuildBuffSimpleItemNtf roPtc)
        {
            if (roPtc.Data == null || (long)roPtc.Data.guildid != (long)this._guildID)
                return;
            this.UpdateOwnedBuffList(roPtc.Data.item);
            this.UpdateBuffRecords(roPtc.Data.chatinfo);
            if (DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible())
                DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshBuffsRecord();
        }

        public void OnGetGuildResUpdate(ResWarMineData data)
        {
            if (data == null)
                return;
            for (int index = 0; index < this._guildInfoList.Count; ++index)
            {
                if ((long)this._guildInfoList[index].guildID == (long)data.guildid)
                {
                    this.GuildMaxResource = Math.Max(this.GuildMaxResource, data.mine);
                    this._guildInfoList[index].resValue = data.mine;
                    if (!DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible())
                        break;
                    DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshTopRightBuffs();
                    break;
                }
            }
        }

        public void OnGetGuildBuffCD(GuildBuffCDParam data)
        {
            this._guildBuffCDTime = data.param;
            if (this._guildBuffCDTime <= 0U)
                return;
            GuildBuffOperationHandler guildBuffHandler = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.GuildBuffHandler;
            if (guildBuffHandler != null && guildBuffHandler.IsVisible())
            {
                guildBuffHandler.FoldByHasGuildBuffCd();
                guildBuffHandler.RefreshCardCd();
            }
        }
    }
}
