

using KKSG;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XSpriteSystemDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SpriteSystemDocument");
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static SpriteTable _spriteTable = new SpriteTable();
        private static SpriteLevel _spriteLevelTable = new SpriteLevel();
        private static SpriteEvolution _spriteEvolutionTable = new SpriteEvolution();
        private static SpriteSkill _spriteSkillTable = new SpriteSkill();
        private static SpritePreviewTable _spritePreviewTable = new SpritePreviewTable();
        private List<SpriteInfo> _spriteList = new List<SpriteInfo>();
        private List<SpriteInfo> _resolveList = new List<SpriteInfo>();
        private List<ulong> _fightingList = new List<ulong>();
        private List<bool> _bookList = new List<bool>();
        private HashSet<ulong> _fightHash = new HashSet<ulong>();
        private HashSet<ulong> _redPointSpriteHash = new HashSet<ulong>();
        private static Dictionary<uint, uint> _levelUpExpDict = new Dictionary<uint, uint>();
        private static Dictionary<short, List<SpriteSkill.RowData>> _spriteSkillDict = new Dictionary<short, List<SpriteSkill.RowData>>();
        private static Dictionary<int, List<uint>> _spriteEggIllustrationDict = new Dictionary<int, List<uint>>();
        private static List<uint> _spriteShowInIllustration = new List<uint>();
        public List<uint> PositionLevelCondition = new List<uint>();
        private uint _maxFightNum;
        private static readonly uint K_LEVELUPQUALITY = 10000;
        public static List<uint> MAXSTARLEVEL = new List<uint>()
    {
      0U,
      0U,
      0U,
      0U,
      0U,
      0U
    };
        public static uint MOONWORTH = 6;
        public string[] NAMECOLOR = new string[6];
        private int SpriteRedPointShowIntervel;
        private uint _timerToken;
        private double _showExpTime;
        private uint _expTotal = 0;
        public SeqList<int> FoodList;
        public SpriteHandlerTag CurrentTag;
        private uint GroupRatio;
        private int _starUpLimitLevel;
        public List<ItemBrief> CachedLotteryResult = new List<ItemBrief>();
        public List<uint> CachedLotteryPPT = new List<uint>();
        public List<bool> ResultShowList = new List<bool>();
        private float LastLotteryTime = 0.0f;
        public SpriteInfo _AwakeSpriteData = (SpriteInfo)null;

        public override uint ID => XSpriteSystemDocument.uuID;

        public XOutlookSprite OutLookData => XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.sprite;

        public uint CurrentLotteryType { get; set; }

        public uint NormalMaxCount { get; set; }

        public uint NormalCoolDown { get; set; }

        public uint NormalFreeCount { get; set; }

        public uint SpecialCoolDown { get; set; }

        public uint SpecialSafeCount { get; set; }

        public bool AutoShowEpicSprite { get; set; }

        public SpritePreviewTable _SpritePreviewTable => XSpriteSystemDocument._spritePreviewTable;

        public List<uint> SpriteShowInIllustration => XSpriteSystemDocument._spriteShowInIllustration;

        public Dictionary<int, List<uint>> _SpriteEggPreviewDict => XSpriteSystemDocument._spriteEggIllustrationDict;

        public SpriteTable _SpriteTable => XSpriteSystemDocument._spriteTable;

        public SpriteLevel _SpriteLevelTable => XSpriteSystemDocument._spriteLevelTable;

        public SpriteEvolution _SpriteEvolutionTable => XSpriteSystemDocument._spriteEvolutionTable;

        public SpriteSkill _SpriteSkillTable => XSpriteSystemDocument._spriteSkillTable;

        public List<SpriteInfo> SpriteList => this._spriteList;

        public List<SpriteInfo> ResolveList => this._resolveList;

        public List<ulong> FightingList => this._fightingList;

        public List<bool> BookList => this._bookList;

        public uint MaxFightNum => this._maxFightNum;

        public static void Execute(OnLoadedCallback callback = null)
        {
            XSpriteSystemDocument.AsyncLoader.AddTask("Table/SpriteTable", (CVSReader)XSpriteSystemDocument._spriteTable);
            XSpriteSystemDocument.AsyncLoader.AddTask("Table/SpriteLevel", (CVSReader)XSpriteSystemDocument._spriteLevelTable);
            XSpriteSystemDocument.AsyncLoader.AddTask("Table/SpriteEvolution", (CVSReader)XSpriteSystemDocument._spriteEvolutionTable);
            XSpriteSystemDocument.AsyncLoader.AddTask("Table/SpriteSkill", (CVSReader)XSpriteSystemDocument._spriteSkillTable);
            XSpriteSystemDocument.AsyncLoader.AddTask("Table/SpritePreviewTable", (CVSReader)XSpriteSystemDocument._spritePreviewTable);
            XSpriteSystemDocument.AsyncLoader.Execute(callback);
        }

        public static void OnTableLoaded()
        {
            XSpriteSystemDocument._levelUpExpDict.Clear();
            for (int index = 0; index < XSpriteSystemDocument._spriteLevelTable.Table.Length; ++index)
            {
                SpriteLevel.RowData rowData = XSpriteSystemDocument._spriteLevelTable.Table[index];
                XSpriteSystemDocument._levelUpExpDict[rowData.Quality * XSpriteSystemDocument.K_LEVELUPQUALITY + rowData.Level] = rowData.Exp;
            }
            XSpriteSystemDocument._spriteSkillDict.Clear();
            for (int index = 0; index < XSpriteSystemDocument._spriteSkillTable.Table.Length; ++index)
            {
                short skillId = XSpriteSystemDocument._spriteSkillTable.Table[index].SkillID;
                List<SpriteSkill.RowData> rowDataList;
                if (!XSpriteSystemDocument._spriteSkillDict.TryGetValue(skillId, out rowDataList))
                {
                    rowDataList = new List<SpriteSkill.RowData>();
                    XSpriteSystemDocument._spriteSkillDict.Add(skillId, rowDataList);
                }
                XSpriteSystemDocument._spriteSkillDict[skillId].Add(XSpriteSystemDocument._spriteSkillTable.Table[index]);
            }
            XSpriteSystemDocument._spriteShowInIllustration.Clear();
            for (int index = 0; index < XSpriteSystemDocument._spriteTable.Table.Length; ++index)
            {
                if (XSpriteSystemDocument._spriteTable.Table[index].IllustrationShow == 1)
                    XSpriteSystemDocument._spriteShowInIllustration.Add(XSpriteSystemDocument._spriteTable.Table[index].SpriteID);
            }
            XSpriteSystemDocument._spriteEggIllustrationDict.Clear();
            for (int index1 = 0; index1 < XSpriteSystemDocument._spritePreviewTable.Table.Length; ++index1)
            {
                int[] spriteShow = XSpriteSystemDocument._spritePreviewTable.Table[index1].SpriteShow;
                if (spriteShow != null)
                {
                    for (int index2 = 0; index2 < spriteShow.Length; ++index2)
                    {
                        int key = spriteShow[index2];
                        List<uint> uintList;
                        if (!XSpriteSystemDocument._spriteEggIllustrationDict.TryGetValue(key, out uintList))
                        {
                            uintList = new List<uint>();
                            XSpriteSystemDocument._spriteEggIllustrationDict[key] = uintList;
                        }
                        uintList.Add(XSpriteSystemDocument._spritePreviewTable.Table[index1].ItemID);
                    }
                }
            }
            for (int index = 0; index < XSpriteSystemDocument._spriteEvolutionTable.Table.Length; ++index)
            {
                if ((uint)XSpriteSystemDocument._spriteEvolutionTable.Table[index].EvolutionLevel > XSpriteSystemDocument.MAXSTARLEVEL[(int)XSpriteSystemDocument._spriteEvolutionTable.Table[index].Quality])
                    XSpriteSystemDocument.MAXSTARLEVEL[(int)XSpriteSystemDocument._spriteEvolutionTable.Table[index].Quality] = (uint)XSpriteSystemDocument._spriteEvolutionTable.Table[index].EvolutionLevel;
            }
        }

        public SpriteSkill.RowData GetMySpriteInitiativeSkill()
        {
            if (this._fightingList.Count == 0 || this._fightingList[0] == 0UL)
                return (SpriteSkill.RowData)null;
            int indexByUid = this.GetIndexByUid(this._fightingList[0]);
            return this.GetSpriteInitiativeSkill(this._spriteList[indexByUid].SpriteID, this._spriteList[indexByUid].EvolutionLevel);
        }

        public SpriteSkill.RowData GetSpriteInitiativeSkill(uint spriteID, uint star) => this.GetSpriteSkillData((short)XSpriteSystemDocument._spriteTable.GetBySpriteID(spriteID).SpriteSkillID, true, star);

        public override void OnEnterSceneFinally()
        {
            if (this._maxFightNum != 0U)
                return;
            this.DealWithPositionLevelCondition();
        }

        private int Compare(SpriteInfo x, SpriteInfo y)
        {
            if ((long)x.uid == (long)y.uid)
                return 0;
            return this.isSpriteFight(x.uid) != this.isSpriteFight(y.uid) ? (this.isSpriteFight(x.uid) ? -1 : 1) : (int)y.PowerPoint - (int)x.PowerPoint;
        }

        public void SortList()
        {
            this._spriteList.Sort(new Comparison<SpriteInfo>(this.Compare));
            this.CalNeed2FightSprite();
            this._resolveList.Sort(new Comparison<SpriteInfo>(this.Compare));
        }

        public SpriteSkill.RowData GetSpriteSkillData(
          short skillID,
          bool mainSkill,
          uint starLevel)
        {
            List<SpriteSkill.RowData> rowDataList;
            if (XSpriteSystemDocument._spriteSkillDict.TryGetValue(skillID, out rowDataList))
            {
                if (!mainSkill)
                {
                    if (rowDataList.Count > 0)
                        return rowDataList[0];
                }
                else
                {
                    uint num = starLevel + 1U;
                    for (int index = 0; index < rowDataList.Count; ++index)
                    {
                        if ((int)rowDataList[index].SkillQuality == (int)num)
                            return rowDataList[index];
                    }
                }
            }
            return (SpriteSkill.RowData)null;
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this.SpriteRedPointShowIntervel = XSingleton<XGlobalConfig>.singleton.GetInt("SpriteRedPointShowIntervel");
            for (int index = 0; index < 6; ++index)
                this.NAMECOLOR[index] = XSingleton<XGlobalConfig>.singleton.GetValue(string.Format("Quality{0}Color", (object)index));
            for (int index = 0; index < 4; ++index)
                this._fightingList.Add(0UL);
            this.GroupRatio = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("SpriteGrowUpRatio");
            this.NormalMaxCount = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("SpriteGoldDrawFreeDayCount");
            this._showExpTime = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteExpShowTime"));
            this.FoodList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("SpriteFoodExp", false);
            this._starUpLimitLevel = XSingleton<XGlobalConfig>.singleton.GetInt("SpriteEvolutionMinLevel");
            XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID).GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce);
        }

        protected override void EventSubscribe()
        {
            base.EventSubscribe();
            this.RegisterEvent(XEventDefine.XEvent_BuffChange, new XComponent.XEventHandler(this._OnBuffChange));
            this.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
            this.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
            this.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
        }

        protected bool OnAddItem(XEventArgs args)
        {
            XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
            for (int index = 0; index < xaddItemEventArgs.items.Count; ++index)
            {
                if (xaddItemEventArgs.items[index].Type == ItemType.SPRITEFOOD)
                {
                    this.CalSpriteMainRedPoint();
                    return true;
                }
            }
            return true;
        }

        protected bool OnRemoveItem(XEventArgs args)
        {
            XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
            for (int index = 0; index < xremoveItemEventArgs.types.Count; ++index)
            {
                if (xremoveItemEventArgs.types[index] == ItemType.SPRITEFOOD)
                {
                    this.CalSpriteMainRedPoint();
                    return true;
                }
            }
            return true;
        }

        public int GetIndexByUid(ulong uid)
        {
            for (int index = 0; index < this._spriteList.Count; ++index)
            {
                if ((long)this._spriteList[index].uid == (long)uid)
                    return index;
            }
            XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Can't find the index by uid = {0}", (object)uid));
            return -1;
        }

        protected override void OnReconnected(XReconnectedEventArgs arg) => this.SetAllInfo(arg.PlayerInfo.SpriteRecord);

        public void DealWithPositionLevelCondition()
        {
            this.PositionLevelCondition = XSingleton<XGlobalConfig>.singleton.GetUIntList("SpritePositionLevel");
            if (this.PositionLevelCondition.Count != 4)
                XSingleton<XDebug>.singleton.AddErrorLog("Error! get PositionLevelCondition's cout from globalconfig error! the cout isn't 4");
            uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
            this._maxFightNum = 4U;
            for (int index = 0; index < this.PositionLevelCondition.Count; ++index)
            {
                if (this.PositionLevelCondition[index] > level)
                {
                    this._maxFightNum = (uint)index;
                    break;
                }
            }
            this.CalNeed2FightSprite();
            if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame == null)
                return;
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame.RefreshPosition();
        }

        private void CalNeed2FightSprite()
        {
            this._redPointSpriteHash.Clear();
            int num = (int)this._maxFightNum - this._fightHash.Count;
            if (num <= 0)
            {
                this.CalSpriteFightRedPoint();
            }
            else
            {
                HashSet<ulong> ulongSet = new HashSet<ulong>();
                for (int index1 = 0; index1 < num; ++index1)
                {
                    int index2 = -1;
                    for (int index3 = 0; index3 < this._spriteList.Count; ++index3)
                    {
                        if (!this._fightHash.Contains(this._spriteList[index3].uid) && !ulongSet.Contains(this._spriteList[index3].uid))
                        {
                            if (index2 == -1)
                                index2 = index3;
                            else if (this._spriteList[index3].PowerPoint > this._spriteList[index2].PowerPoint)
                                index2 = index3;
                        }
                    }
                    if (index2 != -1)
                    {
                        ulongSet.Add(this._spriteList[index2].uid);
                        this._redPointSpriteHash.Add(this._spriteList[index2].uid);
                    }
                    else
                        break;
                }
                this.CalSpriteFightRedPoint();
            }
        }

        public void SetAllInfo(SpriteRecord data)
        {
            if (data == null)
            {
                this._bookList = new List<bool>((IEnumerable<bool>)new bool[XSpriteSystemDocument._spriteTable.Table.Length]);
                XSingleton<XDebug>.singleton.AddLog("Get sprite Info from server is null.");
            }
            else
            {
                this._bookList = data.Books;
                this._spriteList = data.SpriteData;
                this._AwakeSpriteData = data.NewAwake;
                this.SetFightList(data.InFight);
                this.SortList();
                this.CheckView();
            }
        }

        private void SetOutLookData()
        {
            if (this._fightingList[0] == 0UL)
            {
                if (this.OutLookData.leaderid == 0U)
                    return;
                XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.SetSpriteData(0U);
            }
            else
            {
                int indexByUid = this.GetIndexByUid(this._fightingList[0]);
                if ((int)this.OutLookData.leaderid == (int)this._spriteList[indexByUid].SpriteID)
                    return;
                XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.SetSpriteData(this._spriteList[indexByUid].SpriteID);
            }
            if (XSingleton<XEntityMgr>.singleton.Player == null)
                return;
            XSingleton<X3DAvatarMgr>.singleton.OnSpriteChanged((XEntity)XSingleton<XEntityMgr>.singleton.Player, (XSingleton<XEntityMgr>.singleton.Player.GetXComponent(XEquipComponent.uuID) as XEquipComponent).SpriteFromAttr());
        }

        private void SetFightList(List<ulong> list)
        {
            if (list.Count != 4)
            {
                this._fightingList.Clear();
                for (int index = 0; index < 4; ++index)
                    this._fightingList.Add(0UL);
            }
            else
                this._fightingList = list;
            this.SetOutLookData();
            this.FightHashChange();
        }

        private void FightHashChange()
        {
            this._fightHash.Clear();
            for (int index = 0; index < this._fightingList.Count; ++index)
            {
                if (this._fightingList[index] > 0UL)
                    this._fightHash.Add(this._fightingList[index]);
            }
            this.DealWithResolveList();
        }

        public bool isSpriteFight(ulong uid) => this._fightHash.Contains(uid);

        public bool isFightFull() => (long)this._fightHash.Count == (long)this._maxFightNum;

        public bool isSpriteNeed2Fight(int index) => this._redPointSpriteHash.Contains(this._spriteList[index].uid);

        public void CalSpriteFightRedPoint()
        {
            XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_SpriteSystem_Fight, (uint)this._redPointSpriteHash.Count > 0U);
            XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_SpriteSystem);
            this.CalSpriteMainRedPoint();
        }

        public void CalSpriteMainRedPoint()
        {
            XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_SpriteSystem_Main, !this.isSpriteFoodEmpty() && this.isFightSpriteNeed2Feed(true));
            XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_SpriteSystem);
        }

        public uint GetSpriteQuality(int index) => XSpriteSystemDocument._spriteTable.GetBySpriteID(this._spriteList[index].SpriteID).SpriteQuality;

        public uint GetSpriteLevelUpExp(int index)
        {
            uint num = 0;
            uint key = this.GetSpriteQuality(index) * XSpriteSystemDocument.K_LEVELUPQUALITY + this._spriteList[index].Level;
            if (!XSpriteSystemDocument._levelUpExpDict.TryGetValue(key, out num))
                XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Can't find the sprite's exp, quality = {0}, level = {1}.", (object)this.GetSpriteQuality(index), (object)this._spriteList[index].Level));
            return num;
        }

        public uint GetSpriteLevelUpExpByLevel(int index, int level)
        {
            uint num = 0;
            uint key = (uint)((int)this.GetSpriteQuality(index) * (int)XSpriteSystemDocument.K_LEVELUPQUALITY + level);
            if (!XSpriteSystemDocument._levelUpExpDict.TryGetValue(key, out num))
                XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Can't find the sprite's exp, quality = {0}, level = {1}.", (object)this.GetSpriteQuality(index), (object)this._spriteList[index].Level));
            return num;
        }

        public SpriteEvolution.RowData GetStarUpData(uint quality, uint star)
        {
            for (int index = 0; index < XSpriteSystemDocument._spriteEvolutionTable.Table.Length; ++index)
            {
                SpriteEvolution.RowData rowData = XSpriteSystemDocument._spriteEvolutionTable.Table[index];
                if ((int)rowData.Quality == (int)quality && (int)rowData.EvolutionLevel == (int)star + 1)
                    return rowData;
            }
            XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Can't find the sprite starUp's condition from SpriteEvolution.txt, quality = {0}, star = {1}.", (object)quality, (object)(uint)((int)star + 1)));
            return (SpriteEvolution.RowData)null;
        }

        public double CalAptitude(uint AttrID, double AttrValue, XAttributes attributes = null) => XSingleton<XPowerPointCalculator>.singleton.GetPPT(AttrID, AttrValue, prof: 0) * (double)this.GroupRatio;

        public double GetMaxAptitude(uint spriteID, int index)
        {
            SpriteTable.RowData bySpriteId = XSpriteSystemDocument._spriteTable.GetBySpriteID(spriteID);
            switch (index)
            {
                case 0:
                    return this.CalAptitude(bySpriteId.AttrID1, (double)bySpriteId.Range1[1]);
                case 1:
                    return this.CalAptitude(bySpriteId.AttrID2, (double)bySpriteId.Range2[1]);
                case 2:
                    return this.CalAptitude(bySpriteId.AttrID3, (double)bySpriteId.Range3[1]);
                case 3:
                    return this.CalAptitude(bySpriteId.AttrID4, (double)bySpriteId.Range4[1]);
                case 4:
                    return this.CalAptitude(bySpriteId.AttrID5, (double)bySpriteId.Range5[1]);
                default:
                    XSingleton<XDebug>.singleton.AddErrorLog("GetMaxAptitude error. index is out of the range. index = ", index.ToString());
                    return 0.0;
            }
        }

        public void OnSpriteChange(PtcG2C_SpriteChangedNtf ptc)
        {
            if ((uint)ptc.Data.NewSprites.Count > 0U)
                this.DealWithSpriteAdd(ptc.Data.NewSprites);
            if ((uint)ptc.Data.ChangedSprites.Count > 0U)
                this.DealWithSpriteChange(ptc.Data.ChangedSprites);
            if ((uint)ptc.Data.RemovedSprites.Count > 0U)
                this.DealWithSpriteRemove(ptc.Data.RemovedSprites);
            this.CalNeed2FightSprite();
            this.CheckView();
        }

        private void DealWithSpriteAdd(List<SpriteInfo> list)
        {
            for (int index1 = 0; index1 < list.Count; ++index1)
            {
                this._spriteList.Add(list[index1]);
                int index2 = -1;
                for (int index3 = 0; index3 < XSpriteSystemDocument._spriteTable.Table.Length; ++index3)
                {
                    if ((int)list[index1].SpriteID == (int)XSpriteSystemDocument._spriteTable.Table[index3].SpriteID)
                    {
                        index2 = index3;
                        break;
                    }
                }
                if (index2 < this._bookList.Count && index2 >= 0)
                    this._bookList[index2] = true;
            }
            this.DealWithResolveList();
        }

        private void DealWithSpriteChange(List<SpriteInfo> list)
        {
            Dictionary<ulong, SpriteInfo> dictionary = new Dictionary<ulong, SpriteInfo>();
            for (int index = 0; index < list.Count; ++index)
                dictionary[list[index].uid] = list[index];
            SpriteInfo spriteInfo = (SpriteInfo)null;
            for (int index = 0; index < this._spriteList.Count; ++index)
            {
                if (dictionary.TryGetValue(this._spriteList[index].uid, out spriteInfo))
                    this._spriteList[index] = spriteInfo;
            }
        }

        private void DealWithSpriteRemove(List<ulong> list)
        {
            List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();
            HashSet<ulong> ulongSet = new HashSet<ulong>();
            for (int index = 0; index < list.Count; ++index)
                ulongSet.Add(list[index]);
            for (int index = 0; index < this._spriteList.Count; ++index)
            {
                if (!ulongSet.Contains(this._spriteList[index].uid))
                    spriteInfoList.Add(this._spriteList[index]);
            }
            this._spriteList = spriteInfoList;
            this.DealWithResolveList();
        }

        public void DealWithResolveList()
        {
            this._resolveList.Clear();
            for (int index = 0; index < this._spriteList.Count; ++index)
            {
                if (!this.isSpriteFight(this._spriteList[index].uid))
                    this._resolveList.Add(this._spriteList[index]);
            }
        }

        private void LevelUp()
        {
            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLevelUpTips"), "fece00");
            if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.IsVisible())
                return;
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame._SpriteSelectHandler.SetSpriteList(this._spriteList, false);
        }

        public bool QueryFeedSprite(int index, uint feedItemID)
        {
            if (index > this._spriteList.Count)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteNull"), "fece00");
                return false;
            }
            if (this.SpriteList[index].Level >= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_SPRITE_LEVELMAX"), "fece00");
                return false;
            }
            if (XBagDocument.BagDoc.GetItemCount((int)feedItemID) <= 0UL)
            {
                XSingleton<UiUtility>.singleton.ShowItemAccess((int)feedItemID, (AccessCallback)null);
                return false;
            }
            XSingleton<XDebug>.singleton.AddLog(string.Format("Feed sprite index : {0},  food : {1}", (object)index, (object)feedItemID));
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
            {
                oArg = {
          Type = SpriteType.Sprite_Feed,
          uid = this._spriteList[index].uid,
          FeedItemID = feedItemID
        }
            });
            return true;
        }

        public void QueryTrain(int index, List<uint> lockAttrList)
        {
            RpcC2G_SpriteOperation gSpriteOperation = new RpcC2G_SpriteOperation();
            gSpriteOperation.oArg.Type = SpriteType.Sprite_Train;
            gSpriteOperation.oArg.uid = this._spriteList[index].uid;
            for (int index1 = 0; index1 < lockAttrList.Count; ++index1)
                gSpriteOperation.oArg.notToChoose.Add(lockAttrList[index1]);
            XSingleton<XClientNetwork>.singleton.Send((Rpc)gSpriteOperation);
        }

        public void QueryResetTrain(int index, SpriteType type, uint costChoose = 0) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
        {
            oArg = {
        Type = type,
        uid = this._spriteList[index].uid,
        resetTrainChoose = costChoose
      }
        });

        public void QueryStarUp(int index) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
        {
            oArg = {
        Type = SpriteType.Sprite_Evolution,
        uid = this._spriteList[index].uid
      }
        });

        public void QueryFightOut(ulong uid) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
        {
            oArg = {
        Type = SpriteType.Sprite_OutFight,
        uid = uid
      }
        });

        public void QueryFightIn(ulong uid) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
        {
            oArg = {
        Type = SpriteType.Sprite_InFight,
        uid = uid
      }
        });

        public void QuerySwapTeamLeader(ulong uid) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
        {
            oArg = {
        Type = SpriteType.Sprite_SwapLeader,
        uid = uid
      }
        });

        public void QueryOpenStarUpWindow(ulong uid)
        {
            if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (long)this._starUpLimitLevel)
                XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("SpriteStarUpLevelLimit"), (object)this._starUpLimitLevel), "fece00");
            else
                XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
                {
                    oArg = {
            Type = SpriteType.Sprite_QueryEvolutionPPT,
            uid = uid
          }
                });
        }

        public void QueryResolveSprite(List<SpriteInfo> list)
        {
            RpcC2G_SpriteOperation gSpriteOperation = new RpcC2G_SpriteOperation();
            gSpriteOperation.oArg.Type = SpriteType.Sprite_Decompose;
            gSpriteOperation.oArg.uids.Clear();
            for (int index = 0; index < list.Count; ++index)
                gSpriteOperation.oArg.uids.Add(list[index].uid);
            XSingleton<XClientNetwork>.singleton.Send((Rpc)gSpriteOperation);
        }

        public void CheckView()
        {
            if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame != null && DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.IsVisible())
                DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame._SpriteSelectHandler.SetSpriteList(this._spriteList, false);
            if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame != null && DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame.IsVisible())
                DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame._SpriteSelectHandler.SetSpriteList(this._resolveList);
            if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.IsVisible() || DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.CurrentClick >= this.SpriteList.Count)
                return;
            SpriteInfo sprite = this.SpriteList[DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.CurrentClick];
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame._SpritePropertyHandler.SetSpriteAttributeInfo(sprite, (XAttributes)XSingleton<XAttributeMgr>.singleton.XPlayerData);
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame._SpriteAvatarHandler.SetSpriteInfo(sprite, (XAttributes)XSingleton<XAttributeMgr>.singleton.XPlayerData, 0, showLevel: false);
        }

        public void SendLotteryRpc(uint lotteryType)
        {
            if ((double)Time.time - (double)this.LastLotteryTime < 3.0)
                return;
            this.LastLotteryTime = Time.time;
            this.CurrentLotteryType = lotteryType;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_DrawLottery()
            {
                oArg = {
          type = lotteryType
        }
            });
        }

        public void SendBuySpriteEggRpc(uint lotteryType) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_BuySpriteEgg()
        {
            oArg = {
        type = lotteryType
      }
        });

        public void QueryBuyEggCD() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_QueryLotteryCD());

        public void OnQueryLotteryCD(
          uint normalCoolDown,
          uint specialCoolDown,
          uint normalFreeCount,
          uint specialSafeCount)
        {
            this.SpecialSafeCount = specialSafeCount;
            this.SetBuyEggData(normalCoolDown, specialCoolDown, normalFreeCount);
            this.RefreshSafeCountUI();
        }

        public void SetBuyEggData(uint normalCoolDown, uint specialCoolDown, uint normalFreeCount)
        {
            this.NormalCoolDown = normalCoolDown;
            this.NormalFreeCount = normalFreeCount;
            this.SpecialCoolDown = specialCoolDown;
            XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_SpriteSystem_Shop, this.NormalCoolDown == 0U && (int)this.NormalFreeCount != (int)this.NormalMaxCount || this.SpecialCoolDown == 0U);
            XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_SpriteSystem_Shop);
            if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteShopHandler == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteShopHandler.IsVisible())
                return;
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteShopHandler.RefreshLotteryFrame();
        }

        public void SetBuyEggItem(List<ItemBrief> item)
        {
            if (!DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.IsVisible() || DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteShopHandler == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteShopHandler.IsVisible())
                return;
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteShopHandler.ShowResultFrame(item);
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.CheckSpriteSummonRedpoint();
        }

        public void SetLotteryData(uint specialSafeCount)
        {
            this.SpecialSafeCount = specialSafeCount;
            this.RefreshSafeCountUI();
        }

        private void RefreshSafeCountUI()
        {
            if (!DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.IsVisible() || DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteLotteryHandler == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteLotteryHandler.IsVisible())
                return;
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteLotteryHandler.RefreshSafeCountUI();
        }

        public void SetLotteryResultData(
          List<ItemBrief> itemList,
          List<uint> spritePPT,
          LotteryType type)
        {
            this.CachedLotteryResult.Clear();
            this.ResultShowList.Clear();
            this.CachedLotteryPPT.Clear();
            int index1 = 0;
            for (int index2 = 0; index2 < itemList.Count; ++index2)
            {
                this.CachedLotteryResult.Add(itemList[index2]);
                ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemList[index2].itemID);
                this.ResultShowList.Add(itemConf != null && itemConf.ItemType == (byte)18 && itemConf.ItemQuality > (byte)2);
                if (itemConf != null && itemConf.ItemType == (byte)18 && index1 < spritePPT.Count)
                {
                    this.CachedLotteryPPT.Add(spritePPT[index1]);
                    ++index1;
                }
                else
                    this.CachedLotteryPPT.Add(0U);
            }
            if (!DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.IsVisible() || DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteLotteryHandler == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteLotteryHandler.IsVisible())
                return;
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.CheckSpriteSummonRedpoint();
            switch (type)
            {
                case LotteryType.Sprite_Draw_One:
                case LotteryType.Sprite_Draw_Ten:
                case LotteryType.Sprite_Draw_One_Free:
                    this.PlayLotteryCutscene("CutScene/Spirit_lottery_cutscene_fall_diamond", false, true);
                    break;
                case LotteryType.Sprite_GoldDraw_One:
                case LotteryType.Sprite_GoldDraw_Ten:
                case LotteryType.Sprite_GoldDraw_One_Free:
                    this.PlayLotteryCutscene("CutScene/Spirit_lottery_cutscene_fall_gold", false, true);
                    break;
            }
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(XSingleton<XCutScene>.singleton.Length - 0.05f, new XTimerMgr.ElapsedEventHandler(this.RestoreLotteryUI), (object)null);
        }

        public void EpicSpriteShow(int id)
        {
            this.ResultShowList[id] = false;
            this.PlayLotteryCutscene("CutScene/Spirit_lottery_cutscene_short", false, false);
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(XSingleton<XCutScene>.singleton.Length - 0.05f, new XTimerMgr.ElapsedEventHandler(this.RestoreLotteryResultUI), (object)id);
        }

        private void PlayLotteryCutscene(string path, bool bFadeAtBegin, bool bFadeAtEnd)
        {
            XSingleton<XCutScene>.singleton.Start(path, bFadeAtBegin, bFadeAtEnd);
            XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = true;
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.05f, new XTimerMgr.ElapsedEventHandler(this.HideAllUIWithOutCall), (object)null);
        }

        private void RestoreUI(object o = null)
        {
            XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = false;
            XSingleton<UIManager>.singleton.RestoreAllUIWithOutCall();
        }

        private void HideAllUIWithOutCall(object o) => XSingleton<UIManager>.singleton.HideAllUIWithOutCall();

        private void SendWorldNotice(uint itemid) => XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_OpenSpriteEggNtf()
        {
            Data = {
        itemid = itemid
      }
        });

        private void RestoreLotteryUI(object o)
        {
            this.RestoreUI();
            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteLotteryHandler.ShowResultFrame();
        }

        private void RestoreLotteryResultUI(object o)
        {
            int index = (int)o;
            this.SendWorldNotice(this.CachedLotteryResult[index].itemID);
            this.RestoreUI();
            DlgBase<XSpriteShowView, XSpriteShowBehaviour>.singleton.ShowDetail(this.CachedLotteryResult[index].itemID, this.CachedLotteryPPT[index], true);
        }

        public bool isSpriteFoodEmpty()
        {
            ulong num = 0;
            for (int index = 0; index < (int)this.FoodList.Count; ++index)
                num += XBagDocument.BagDoc.GetItemCount(this.FoodList[index, 0]);
            return num == 0UL;
        }

        public bool isFightSpriteNeed2Feed(bool outView)
        {
            for (int index = 0; index < this._fightingList.Count; ++index)
            {
                if (this._fightingList[index] != 0UL && this.isSpriteNeed2Feed(this._fightingList[index], outView))
                    return true;
            }
            return false;
        }

        public bool isSpriteNeed2Feed(ulong uid, bool outView)
        {
            int indexByUid = this.GetIndexByUid(uid);
            return outView ? (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (long)this._spriteList[indexByUid].Level + (long)this.SpriteRedPointShowIntervel && this.isSpriteCanLevelUp(indexByUid) : XSingleton<XAttributeMgr>.singleton.XPlayerData.Level > this._spriteList[indexByUid].Level && this.isSpriteCanLevelUp(indexByUid);
        }

        private bool isSpriteCanLevelUp(int index)
        {
            int num = 0;
            for (int index1 = 0; index1 < (int)this.FoodList.Count; ++index1)
                num += (int)XBagDocument.BagDoc.GetItemCount(this.FoodList[index1, 0]) * this.FoodList[index1, 1];
            return this._spriteList[index].Exp + (uint)num >= this.GetSpriteLevelUpExp(index);
        }

        public XFx CreateAndPlayFx(string path, Transform parent)
        {
            XFx fx = XSingleton<XFxMgr>.singleton.CreateFx(path);
            if (fx == null)
                return (XFx)null;
            fx.Play(parent, Vector3.zero, Vector3.one, follow: true);
            return fx;
        }

        public void DestroyFx(XFx fx)
        {
            if (fx == null)
                return;
            XSingleton<XFxMgr>.singleton.DestroyFx(fx);
        }

        public void ReqSpriteOperation(SpriteType type)
        {
            int currentClick = DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.CurrentClick;
            if (currentClick >= this.SpriteList.Count)
                return;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SpriteOperation()
            {
                oArg = {
          Type = type,
          uid = this.SpriteList[currentClick].uid
        }
            });
        }

        public void OnSpriteOperation(SpriteOperationArg oArg, SpriteOperationRes oRes)
        {
            if ((uint)oRes.ErrorCode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode);
                if (oRes.ErrorCode != ErrorCode.ERR_SPRITE_EVOLUTION_LACKOFCOST)
                    return;
                if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow != null && DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.IsVisible())
                    DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.SetVisible(false);
                XSingleton<UiUtility>.singleton.ShowItemAccess(XSingleton<XGlobalConfig>.singleton.GetInt("SpriteStarUpItemID"), (AccessCallback)null);
            }
            else
            {
                switch (oArg.Type)
                {
                    case SpriteType.Sprite_Feed:
                        for (int index = 0; index < this._spriteList.Count; ++index)
                        {
                            if ((long)this._spriteList[index].uid == (long)oArg.uid)
                            {
                                this._spriteList[index].Exp = oRes.Exp;
                                break;
                            }
                        }
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame != null)
                            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.OnServerReturn(oArg.uid);
                        XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
                        for (int index = 0; index < (int)this.FoodList.Count; ++index)
                        {
                            if (this.FoodList[index, 0] == (int)oArg.FeedItemID)
                            {
                                this._expTotal += (uint)this.FoodList[index, 1];
                                break;
                            }
                        }
                        XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
                        this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)this._showExpTime, new XTimerMgr.ElapsedEventHandler(this.ShowGetExp), (object)null);
                        break;
                    case SpriteType.Sprite_Evolution:
                    case SpriteType.Sprite_Train:
                    case SpriteType.Sprite_ResetTrain:
                    case SpriteType.Sprite_Rebirth:
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.IsVisible())
                            break;
                        if (oArg.Type == SpriteType.Sprite_Train)
                        {
                            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.LastAttrList.Clear();
                            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.LastValueList.Clear();
                            for (int index = 0; index < oRes.LastTrainAttrID.Count; ++index)
                            {
                                DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.LastAttrList.Add((int)oRes.LastTrainAttrID[index]);
                                DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.LastValueList.Add((int)oRes.LastTrainAttrValue[index]);
                            }
                        }
                        DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._StarUpWindow.OnServerReturn(oArg.Type);
                        break;
                    case SpriteType.Sprite_Awake:
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow.IsVisible())
                            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.Awake);
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow != null)
                            DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow.SetSpritesInfo(oRes.AwakeSpriteBefore, oRes.AwakeSprite);
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame == null)
                            break;
                        DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.RefreshAwakeBtn();
                        break;
                    case SpriteType.Sprite_Awake_Retain:
                    case SpriteType.Sprite_Awake_Replace:
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow == null)
                            break;
                        DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow.SetVisible(false);
                        break;
                    case SpriteType.Sprite_InFight:
                    case SpriteType.Sprite_OutFight:
                    case SpriteType.Sprite_SwapLeader:
                        this.SetFightList(oRes.InFight);
                        this.CalNeed2FightSprite();
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame.IsVisible() || DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame._SpriteSelectHandler == null)
                            break;
                        DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame._SpriteSelectHandler.SetSpriteList(this._spriteList, false);
                        DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteFightFrame.RefreshFightList();
                        break;
                    case SpriteType.Sprite_Decompose:
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame.IsVisible())
                            break;
                        DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteResolveFrame.Clean();
                        break;
                    case SpriteType.Sprite_QueryEvolutionPPT:
                        if (DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame == null || !DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.IsVisible())
                            break;
                        DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.StarUp);
                        break;
                }
            }
        }

        public double GetSpriteLevelRatio(uint quality, uint level)
        {
            for (int index = 0; index < this._SpriteLevelTable.Table.Length; ++index)
            {
                SpriteLevel.RowData rowData = this._SpriteLevelTable.Table[index];
                if ((int)rowData.Quality == (int)level && (int)rowData.Level == (int)level)
                    return rowData.Ratio;
            }
            return 0.0;
        }

        private void ShowGetExp(object o = null)
        {
            XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
            XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("SpriteExpTips"), (object)this._expTotal), "fece00");
            this._expTotal = 0U;
        }

        public void ShowGetSpriteWithAnimation(uint spriteID, uint ppt) => DlgBase<XSpriteShowView, XSpriteShowBehaviour>.singleton.ShowDetail(spriteID, ppt);

        private bool _OnBuffChange(XEventArgs args)
        {
            XBuffChangeEventArgs xbuffChangeEventArgs = args as XBuffChangeEventArgs;
            if (xbuffChangeEventArgs.addBuff != null && xbuffChangeEventArgs.addBuff.buffInfo != null && XBuff.HasTag(xbuffChangeEventArgs.addBuff.buffInfo, XBuffTag.BT_SpriteEffect))
                XSpriteSystemDocument.SpriteSkillCast(xbuffChangeEventArgs.entity);
            return true;
        }

        public static void SpriteSkillCast(XEntity entity)
        {
            if (!entity.IsPlayer)
                return;
            uint leaderid = entity.Attributes.Outlook.sprite.leaderid;
            SpriteTable.RowData bySpriteId = XSpriteSystemDocument._spriteTable.GetBySpriteID(leaderid);
            if (bySpriteId != null)
            {
                SpriteSkill.RowData spriteInitiativeSkill = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID).GetMySpriteInitiativeSkill();
                if (spriteInitiativeSkill != null)
                {
                    if (!XSingleton<XGame>.singleton.SyncMode && (uint)spriteInitiativeSkill.ShowNotice[0] > 0U)
                    {
                        NoticeTable.RowData noticeData = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID).GetNoticeData(NoticeType.NT_SPRITE_SKILLCAST);
                        if (noticeData == null)
                            return;
                        StringBuilder sb = new StringBuilder(noticeData.info);
                        sb.Replace("$R", XStringDefineProxy.GetString("YOU"));
                        int startIndex1 = XSpriteSystemDocument._Find(sb, "$C");
                        if (startIndex1 != -1)
                            sb.Replace("$C", bySpriteId.SpriteName, startIndex1, 2);
                        int startIndex2 = XSpriteSystemDocument._Find(sb, "$C");
                        if (startIndex2 != -1)
                            sb.Replace("$C", spriteInitiativeSkill.SkillName, startIndex2, 2);
                        int startIndex3 = XSpriteSystemDocument._Find(sb, "$C");
                        if (startIndex3 != -1)
                            sb.Replace("$C", spriteInitiativeSkill.NoticeDetail, startIndex3, 2);
                        XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID).HandlerReceiveChatInfo(new KKSG.ChatInfo()
                        {
                            info = sb.ToString(),
                            channel = (uint)noticeData.channel
                        });
                    }
                    if ((uint)spriteInitiativeSkill.ShowNotice[1] > 0U)
                    {
                        XAffiliate xaffiliate = (XAffiliate)null;
                        if (!entity.IsTransform && entity.Equipment != null)
                            xaffiliate = entity.Equipment.Sprite;
                        if (xaffiliate != null)
                        {
                            if (!(xaffiliate.GetXComponent(XBubbleComponent.uuID) is XBubbleComponent))
                                XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)xaffiliate, XBubbleComponent.uuID);
                            XBubbleEventArgs xbubbleEventArgs = XEventPool<XBubbleEventArgs>.GetEvent();
                            xbubbleEventArgs.bubbletext = spriteInitiativeSkill.SkillName;
                            xbubbleEventArgs.existtime = 3f;
                            xbubbleEventArgs.Firer = (XObject)xaffiliate;
                            xbubbleEventArgs.speaker = string.Empty;
                            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xbubbleEventArgs);
                        }
                    }
                    if (!string.IsNullOrEmpty(spriteInitiativeSkill.Audio))
                        XSingleton<XAudioMgr>.singleton.PlaySound((XObject)entity, AudioChannel.Action, spriteInitiativeSkill.Audio);
                }
            }
        }

        private static int _Find(StringBuilder sb, string s)
        {
            int num = sb.Length - s.Length + 1;
            for (int index1 = 0; index1 < num; ++index1)
            {
                bool flag = true;
                int index2 = index1;
                for (int index3 = 0; index2 < num && index3 < s.Length; ++index3)
                {
                    if ((int)sb[index2] != (int)s[index3])
                    {
                        flag = false;
                        break;
                    }
                    ++index2;
                }
                if (flag)
                    return index1;
            }
            return -1;
        }

        private bool OnPlayerLevelChange(XEventArgs arg)
        {
            this.DealWithPositionLevelCondition();
            return true;
        }
    }
}
