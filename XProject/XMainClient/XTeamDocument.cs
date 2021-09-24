

using KKSG;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XTeamDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TeamDocument");
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static PveProfessionTable m_pveProfessionTables = new PveProfessionTable();
        private static Dictionary<string, PveProfessionTable.RowData> m_pveProfessions = new Dictionary<string, PveProfessionTable.RowData>();
        public XTeamListHandler TeamListView;
        public XMyTeamHandler MyTeamView;
        private List<XTeamBriefData> _TeamList = new List<XTeamBriefData>();
        public XTeamListView AllListView;
        public XTeamDungeonSelectorHandler DungeonSelector;
        public ExpeditionTable.RowData currentExpInfo;
        public uint currentDungeonID;
        public string currentCategoryName;
        public string currentDungeonName;
        public TeamLevelType currentDungeonType = TeamLevelType.TeamLevelNone;
        public string teamLeagueName;
        private XExpeditionDocument m_ExpDoc = (XExpeditionDocument)null;
        public SceneTable.RowData currentSceneData;
        public string password = "";
        private bool _bVoting;
        private bool m_bAutoMatching = false;
        private KMatchType m_SoloMatchType = KMatchType.KMT_NONE;
        private XTeam _MyTeam;
        private bool bTryAutoJoin = false;
        private static bool bFromHyperLink = false;
        private float m_fMatchingTime = -1f;
        private int m_nMatchingTime = -1;
        private int m_AutoSelectFloatingLevel = -10;
        private int m_TeamListSortDirection = 1;
        private TeamBriefSortType m_TeamListSortType = TeamBriefSortType.TBST_MEMBER_COUNT;
        private HashSet<int> m_TeamListSelectedCategories = new HashSet<int>();
        private uint _tarja = 0;
        private bool m_bReqTeamListJustTarget;
        private static ButtonClickEventHandler _EnterHandler = (ButtonClickEventHandler)null;
        private static IXUIButton _EnterButton = (IXUIButton)null;
        private static bool _bCanEnter = false;
        private static EventDelegate _EventDel;

        public override uint ID => XTeamDocument.uuID;

        public List<XTeamBriefData> TeamList => this._TeamList;

        public XExpeditionDocument ExpDoc
        {
            get
            {
                if (this.m_ExpDoc == null)
                    this.m_ExpDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
                return this.m_ExpDoc;
            }
        }

        public bool bVoting => this._bVoting;

        public bool bAutoMatching
        {
            get => this.m_bAutoMatching;
            set => this.m_bAutoMatching = value;
        }

        public KMatchType SoloMatchType => this.m_SoloMatchType;

        public bool bSoloMatching => (uint)this.m_SoloMatchType > 0U;

        public bool bMatching => this.bInTeam ? (uint)this._MyTeam.teamBrief.matchType > 0U : this.bSoloMatching;

        public XTeam MyTeam
        {
            get => this._MyTeam;
            set => this._MyTeam = value;
        }

        public bool bInTeam => this._MyTeam != null;

        public bool bIsLeader => this._MyTeam != null && this._MyTeam.myData != null && this._MyTeam.myData.bIsLeader;

        public bool bIsHelper => this._MyTeam != null && this._MyTeam.myData != null && this._MyTeam.myData.bIsHelper;

        public bool bIsTecket => this._MyTeam != null && this._MyTeam.myData != null && this._MyTeam.myData.bIsTicket;

        public int MatchingTime => this.m_nMatchingTime;

        public TeamBriefSortType TeamListSortType
        {
            get => this.m_TeamListSortType;
            set
            {
                this.m_TeamListSortDirection = this.m_TeamListSortType == value ? -this.m_TeamListSortDirection : XTeamBriefData.DefaultSortDirection[XFastEnumIntEqualityComparer<TeamBriefSortType>.ToInt(value)];
                this.m_TeamListSortType = value;
            }
        }

        public int TeamListSortDirection => this.m_TeamListSortDirection;

        public void SortTeamListAndShow()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(XSingleton<XGlobalConfig>.singleton.GetValue("Culture"));
            if (this.m_bReqTeamListJustTarget)
            {
                XTeamBriefData.dir = 1;
                XTeamBriefData.sortType = TeamBriefSortType.TBST_MAX;
                this._TeamList.Sort(new Comparison<XTeamBriefData>(XTeamBriefData.CompareToAccordingToRelation));
            }
            else
            {
                XTeamBriefData.dir = this.m_TeamListSortDirection;
                XTeamBriefData.sortType = this.m_TeamListSortType;
                this._TeamList.Sort();
            }
            Thread.CurrentThread.CurrentCulture = currentCulture;
            if (this.TeamListView != null && this.TeamListView.IsVisible())
                this.TeamListView.RefreshPage();
            if (this.AllListView == null || !this.AllListView.IsVisible())
                return;
            this.AllListView.RefreshPage();
        }

        public HashSet<int> TeamListSelectedCategories => this.m_TeamListSelectedCategories;

        public static void Execute(OnLoadedCallback callback = null)
        {
            XTeamDocument.AsyncLoader.AddTask("Table/PveProfession", (CVSReader)XTeamDocument.m_pveProfessionTables);
            XTeamDocument.AsyncLoader.Execute(callback);
        }

        public static string GetProfessionKey(uint profession, uint sceneid) => XSingleton<XCommon>.singleton.StringCombine(profession.ToString(), "_", sceneid.ToString());

        public static void OnTableLoaded()
        {
            XTeamDocument.m_pveProfessions.Clear();
            int index = 0;
            for (int length = XTeamDocument.m_pveProfessionTables.Table.Length; index < length; ++index)
                XTeamDocument.m_pveProfessions.Add(XTeamDocument.GetProfessionKey((uint)XTeamDocument.m_pveProfessionTables.Table[index].ProfessionID, XTeamDocument.m_pveProfessionTables.Table[index].SceneID), XTeamDocument.m_pveProfessionTables.Table[index]);
        }

        public void SetTarja(uint tarja)
        {
            XSingleton<XDebug>.singleton.AddGreenLog("SetTarja:", tarja.ToString());
            this._tarja = tarja;
            if (this.MyTeamView != null && this.MyTeamView.IsVisible())
                this.MyTeamView.RefreshPage();
            if (this.TeamListView != null && this.TeamListView.IsVisible())
                this.TeamListView.RefreshPage();
            if (this.AllListView != null && this.AllListView.IsVisible())
                this.AllListView.RefreshPage();
            if (this.DungeonSelector == null || !this.DungeonSelector.IsVisible())
                return;
            this.DungeonSelector.RefreshData();
        }

        public bool IsTarja => this._tarja > 0U;

        public static PveProfessionTable.RowData GetPveProfession(
          uint sceneID,
          uint profession)
        {
            if (sceneID == 0U || profession == 0U)
                return (PveProfessionTable.RowData)null;
            string professionKey = XTeamDocument.GetProfessionKey(profession, sceneID);
            return !XTeamDocument.m_pveProfessions.ContainsKey(professionKey) ? (PveProfessionTable.RowData)null : XTeamDocument.m_pveProfessions[professionKey];
        }

        public bool InTarja(uint profession) => XTeamDocument.InTarja(this.currentDungeonID, profession);

        public static bool InTarja(uint dungeonID, uint profession) => XTeamDocument.GetPveProfession(dungeonID, profession) != null;

        public bool ShowTarja(uint dungeonID)
        {
            if (!this.IsTarja)
                return this.IsTarja;
            if (XTeamDocument.GetPveProfession(dungeonID, XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID) == null)
                return false;
            ExpeditionTable.RowData expeditionDataById = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID).GetExpeditionDataByID((int)dungeonID);
            return expeditionDataById != null && XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic) < (double)expeditionDataById.DisplayPPT;
        }

        public bool ShowTarja() => this.ShowTarja(this.currentDungeonID);

        public bool TryGetPveProfessionPPT(bool isTarja, uint profression, ref uint ppt)
        {
            if (!isTarja || XTeamDocument.GetPveProfession(this.currentDungeonID, profression) == null)
                return false;
            ExpeditionTable.RowData expeditionDataById = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID).GetExpeditionDataByID((int)this.currentDungeonID);
            if (expeditionDataById == null || ppt >= expeditionDataById.DisplayPPT)
                return false;
            ppt = expeditionDataById.DisplayPPT;
            return true;
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this._TeamList.Clear();
            this.currentExpInfo = (ExpeditionTable.RowData)null;
            this.currentDungeonID = 0U;
            this.currentDungeonName = string.Empty;
            this.currentCategoryName = string.Empty;
            this.currentDungeonType = TeamLevelType.TeamLevelNone;
            this.m_nMatchingTime = -1;
            this.m_AutoSelectFloatingLevel = XSingleton<XGlobalConfig>.singleton.GetInt("TeamAutoSelectFloatingLevel");
            this.m_SoloMatchType = KMatchType.KMT_NONE;
            this.m_bAutoMatching = false;
            this.TeamListSelectedCategories.Clear();
            this.TeamListSelectedCategories.Add(0);
        }

        protected override void EventSubscribe()
        {
            base.EventSubscribe();
            this.RegisterEvent(XEventDefine.XEvent_JoinTeam, new XComponent.XEventHandler(this._OnJoinTeam));
            this.RegisterEvent(XEventDefine.XEvent_LeaveTeam, new XComponent.XEventHandler(this._OnLeaveTeam));
            this.RegisterEvent(XEventDefine.XEvent_FriendInfoChange, new XComponent.XEventHandler(this._OnFriendInfoChanged));
        }

        public void InitTeamListSelection()
        {
            if (!this.TeamListSelectedCategories.Contains(0) || this.TeamListSelectedCategories.Count != 1)
                return;
            List<XTeamCategory> categories = this.ExpDoc.TeamCategoryMgr.m_Categories;
            for (int index = 0; index < categories.Count; ++index)
                this.TeamListSelectedCategories.Add(categories[index].category);
        }

        private bool _OnJoinTeam(XEventArgs e)
        {
            DlgBase<XTeamConfirmView, XTeamConfirmBehaviour>.singleton.ClearInviteList();
            return true;
        }

        private bool _OnLeaveTeam(XEventArgs e)
        {
            this.m_nMatchingTime = -1;
            this.ToggleVoting(false);
            if (DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible())
                DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
            this._UpdateOtherUI();
            return true;
        }

        private bool _OnFriendInfoChanged(XEventArgs e)
        {
            this.RefreshMyTeamView();
            return true;
        }

        public override void OnEnterSceneFinally()
        {
            base.OnEnterSceneFinally();
            if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall)
            {
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.SetTeamMatching(this.bSoloMatching);
                if (this.bInTeam)
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.SetTeamMemberCount(this.MyTeam.members.Count);
                else
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.SetTeamMemberCount(0);
            }
            else
            {
                if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.World || !this.bInTeam || this.currentDungeonID == 2101U || this.currentDungeonID == 2102U || this.currentDungeonID == 2103U)
                    return;
                XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Team);
            }
        }

        public bool TryChangeToExpID(int expID)
        {
            if ((long)this.currentDungeonID == (long)expID)
                return false;
            if (this.bInTeam)
            {
                if (!this.bIsLeader)
                    return false;
                this.ReqTeamOp(TeamOperate.TEAM_CHANGE_EPXTEAMID, (ulong)expID);
                return true;
            }
            bool flag = this.currentDungeonID > 0U;
            this._SetCurrentDungeon(expID);
            if (flag)
                this.CancelMatch();
            if (this.TeamListView != null && this.TeamListView.IsVisible())
                this.TeamListView.OnCurrentDungeonChanged();
            return true;
        }

        public void TryAutoSelectExp()
        {
            if ((uint)this.SoloMatchType > 0U)
            {
                TeamLevelType type = XTeamDocument.MatchType2TeamType(this.SoloMatchType);
                if ((uint)type > 0U)
                {
                    List<ExpeditionTable.RowData> expeditionList = this.ExpDoc.GetExpeditionList(type);
                    if (expeditionList != null && expeditionList.Count > 0 && this.TryChangeToExpID(expeditionList[0].DNExpeditionID))
                        return;
                }
            }
            if (this.currentDungeonID > 0U)
                return;
            uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
            int expID = 0;
            int num1 = int.MaxValue;
            int num2 = int.MaxValue;
            for (int index1 = 0; index1 < this.ExpDoc.TeamCategoryMgr.m_Categories.Count; ++index1)
            {
                XTeamCategory category = this.ExpDoc.TeamCategoryMgr.m_Categories[index1];
                for (int index2 = 0; index2 < category.expList.Count; ++index2)
                {
                    ExpeditionTable.RowData exp = category.expList[index2];
                    if (exp != null)
                    {
                        int num3 = Math.Abs((int)exp.DisplayLevel - (int)level);
                        if (num2 >= num3 && (num3 != num2 || num1 >= exp.AutoSelectPriority) && category.IsExpOpened(exp))
                        {
                            num2 = num3;
                            num1 = exp.AutoSelectPriority;
                            expID = exp.DNExpeditionID;
                        }
                    }
                }
            }
            if ((uint)expID <= 0U)
                return;
            this.TryChangeToExpID(expID);
        }

        private void _SetCurrentDungeon(int dungeonID)
        {
            ExpeditionTable.RowData expeditionDataById = this.ExpDoc.GetExpeditionDataByID(dungeonID);
            if (expeditionDataById == null)
                return;
            TeamLevelType type = (TeamLevelType)expeditionDataById.Type;
            this._SetCurrentTeamInfo(expeditionDataById);
            this.currentSceneData = (SceneTable.RowData)null;
            this.currentSceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.ExpDoc.GetSceneIDByExpID(dungeonID));
            if (type == TeamLevelType.TeamLevelTeamTower)
                this.ExpDoc.ExpeditionId = expeditionDataById.DNExpeditionID;
        }

        private void _SetCurrentTeamInfo(ExpeditionTable.RowData rowData)
        {
            if ((int)this.currentDungeonID != rowData.DNExpeditionID)
            {
                bool flag = this.currentDungeonID == 0U;
                this.currentExpInfo = rowData;
                this.currentDungeonID = (uint)rowData.DNExpeditionID;
                this.currentDungeonName = XExpeditionDocument.GetFullName(rowData);
                this.currentDungeonType = (TeamLevelType)rowData.Type;
                this.currentCategoryName = XTeamCategory.GetCategoryName(rowData.Category);
                if (!flag && this.bInTeam && !this.bIsLeader)
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_LEADER_CHANGE_EXP", (object)this.currentDungeonName), "fece00");
            }
            if (this.MyTeamView != null && this.MyTeamView.IsVisible())
                this.MyTeamView.RefreshButtonStates();
            if (this.DungeonSelector == null || !this.DungeonSelector.IsVisible())
                return;
            this.DungeonSelector.SetCurrentDungeon(true);
        }

        public XTeamBriefData GetTeamBriefByIndex(int index) => index >= this._TeamList.Count ? (XTeamBriefData)null : this._TeamList[index];

        public XTeamBriefData GetTeamBriefByID(int teamID)
        {
            for (int index = 0; index < this._TeamList.Count; ++index)
            {
                if (this._TeamList[index].teamID == teamID)
                    return this._TeamList[index];
            }
            return (XTeamBriefData)null;
        }

        public void ReqTeamList(bool bJustTarget)
        {
            this.m_bReqTeamListJustTarget = bJustTarget;
            if (bJustTarget)
            {
                if (this.currentDungeonID <= 0U)
                    return;
                XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_FetchTeamListC2M()
                {
                    oArg = {
            expID = this.currentDungeonID
          }
                });
            }
            else if (this.m_TeamListSelectedCategories.Count > 0)
            {
                RpcC2M_FetchTeamListC2M fetchTeamListC2M = new RpcC2M_FetchTeamListC2M();
                foreach (int selectedCategory in this.m_TeamListSelectedCategories)
                {
                    if ((uint)selectedCategory > 0U)
                        fetchTeamListC2M.oArg.categoryID.Add((uint)selectedCategory);
                }
                XSingleton<XClientNetwork>.singleton.Send((Rpc)fetchTeamListC2M);
            }
            else
            {
                this.ClearTeamList();
                this.SortTeamListAndShow();
            }
        }

        public void ClearTeamList()
        {
            for (int index = 0; index < this._TeamList.Count; ++index)
                this._TeamList[index].Recycle();
            this._TeamList.Clear();
        }

        public void OnGetTeamList(FetchTeamListRes oRes)
        {
            this.ClearTeamList();
            for (int index = 0; index < oRes.TheTeams.Count; ++index)
            {
                TeamFullDataNtf theTeam = oRes.TheTeams[index];
                if (theTeam.teamBrief.teamState != 1)
                {
                    XTeamBriefData data = XDataPool<XTeamBriefData>.GetData();
                    data.SetData(theTeam.teamBrief, this.ExpDoc);
                    data.SetMembers(theTeam.members);
                    this._TeamList.Add(data);
                }
            }
            this.SortTeamListAndShow();
            if (!this.bTryAutoJoin)
                return;
            this._AutoJoin();
        }

        public void OnTeamInfoChanged(TeamChanged data)
        {
            XSingleton<XDebug>.singleton.AddGreenLog("TeamInfoChanged");
            XTeamDocument.XPreviousTeamData previousData = new XTeamDocument.XPreviousTeamData(this);
            previousData.bNewTeam = false;
            if (this._MyTeam == null)
            {
                this._MyTeam = new XTeam();
                previousData.bNewTeam = true;
            }
            previousData.PreserveTeamData(this._MyTeam);
            this._MyTeam.PreUpdate();
            this._MyTeam.teamBrief.SetData(data.teamBrief, this.ExpDoc);
            if (this._MyTeam.teamBrief.rowData == null)
            {
                if (!previousData.bNewTeam && previousData.expData == null)
                    return;
                XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("LeaveTeamSinceNoConfig"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
                this.ReqTeamOp(TeamOperate.TEAM_LEAVE);
            }
            else
            {
                ulong memberId;
                for (int index = 0; index < data.leaveMember.Count; ++index)
                {
                    XDebug singleton = XSingleton<XDebug>.singleton;
                    memberId = data.leaveMember[index];
                    string log2 = memberId.ToString();
                    singleton.AddGreenLog("Try Leave Teammember ", log2);
                    string str = this._MyTeam.RemoveMember(data.leaveMember[index]);
                    if (this._MyTeam.teamBrief.matchType != KMatchType.KMT_NONE && this._MyTeam.teamBrief.matchType != KMatchType.KMT_EXP)
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_LEAVE_TEAM_MATCH", (object)str), "fece00");
                    else
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_LEAVE_TEAM", (object)str), "fece00");
                }
                for (int index = 0; index < data.addMember.Count; ++index)
                {
                    XDebug singleton = XSingleton<XDebug>.singleton;
                    memberId = data.addMember[index].memberID;
                    string log2 = memberId.ToString();
                    singleton.AddGreenLog("Try Add Teammember ", log2);
                    this._MyTeam.AddMember(data.addMember[index]);
                    if (!previousData.bNewTeam)
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_ADD_TEAM", (object)data.addMember[index].name), "fece00");
                }
                for (int index = 0; index < data.chgstateMember.Count; ++index)
                    this._MyTeam.UpdateMember(data.chgstateMember[index]);
                this._MyTeam.PostUpdate();
                if (this.MyTeam.members.Count > 1)
                    XSingleton<XTutorialHelper>.singleton.HasTeam = true;
                this._MyTeam.members.Sort();
                this._PostTeamInfoChanged(previousData, data.teamBrief);
                int num = data.addMember.Count - data.leaveMember.Count;
                if ((uint)num <= 0U)
                    return;
                XTeamMemberCountChangedEventArgs changedEventArgs = XEventPool<XTeamMemberCountChangedEventArgs>.GetEvent();
                changedEventArgs.oldCount = (uint)(this._MyTeam.members.Count - num);
                changedEventArgs.newCount = (uint)this._MyTeam.members.Count;
                changedEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)changedEventArgs);
            }
        }

        private void _PostTeamInfoChanged(XTeamDocument.XPreviousTeamData previousData, TeamBrief brief)
        {
            this.teamLeagueName = brief.extrainfo.league_teamname;
            if (previousData.bNewTeam || (int)this.currentDungeonID != (int)this._MyTeam.teamBrief.dungeonID || this._MyTeam.bLeaderChanged)
                this._SetCurrentDungeon((int)this._MyTeam.teamBrief.dungeonID);
            if (previousData.bNewTeam)
            {
                if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && !XSingleton<XGame>.singleton.switchScene)
                {
                    if (this.AllListView != null && this.AllListView.IsVisible())
                        this.AllListView.SetVisibleWithAnimation(false, new DlgBase<XTeamListView, XTeamListBehaviour>.OnAnimationOver(DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView));
                    else if (DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>.singleton.IsVisible())
                    {
                        DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>.singleton.SetVisibleWithAnimation(false, new DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>.OnAnimationOver(DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView));
                    }
                    else
                    {
                        ExpeditionTable.RowData expeditionDataById = this.ExpDoc.GetExpeditionDataByID((int)this.currentDungeonID);
                        if (expeditionDataById != null && XSingleton<XScene>.singleton.SceneType != SceneType.SKYCITY_WAITING && (expeditionDataById.fastmatch == 0 || DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible()))
                            DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
                    }
                    XSingleton<XVirtualTab>.singleton.Cancel();
                }
                this.password = brief.password;
                XJoinTeamEventArgs xjoinTeamEventArgs = XEventPool<XJoinTeamEventArgs>.GetEvent();
                xjoinTeamEventArgs.dungeonID = this._MyTeam.teamBrief.dungeonID;
                xjoinTeamEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xjoinTeamEventArgs);
            }
            previousData.CheckNewTeamData(this._MyTeam);
            this.RefreshMyTeamView();
            if (this.bVoting)
                DlgBase<XTeamBattleConfirmView, XTeamBattleConfirmBehaviour>.singleton.RefreshFightVote();
            if (this.bMatching)
            {
                if (this.m_nMatchingTime < 0)
                {
                    this.m_nMatchingTime = 0;
                    this.m_fMatchingTime = Time.time;
                }
            }
            else
                this.m_nMatchingTime = -1;
            this._UpdateOtherUI();
        }

        public void ReqTeamOp(
          TeamOperate op,
          ulong param = 0,
          object o = null,
          TeamMemberType memberType = TeamMemberType.TMT_NORMAL,
          string account = null)
        {
            XTeamDocument.bFromHyperLink = false;
            if (this._MyTeam == null)
            {
                if (op == TeamOperate.TEAM_LEAVE || op == TeamOperate.TEAM_TOGGLE_READY)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("Not in a team.");
                    return;
                }
            }
            else if (this._MyTeam != null && (op == TeamOperate.TEAM_CREATE || op == TeamOperate.TEAM_JOIN))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Already in a team.");
                return;
            }
            RpcC2M_TeamRequestC2M c2MTeamRequestC2M = new RpcC2M_TeamRequestC2M();
            switch (op)
            {
                case TeamOperate.TEAM_CREATE:
                    c2MTeamRequestC2M.oArg.expID = this.currentDungeonID;
                    c2MTeamRequestC2M.oArg.param = param;
                    c2MTeamRequestC2M.oArg.password = this.password;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_JOIN:
                    c2MTeamRequestC2M.oArg.teamID = (int)param;
                    XTeamBriefData teamBriefById = this.GetTeamBriefByID((int)param);
                    if (teamBriefById != null)
                        c2MTeamRequestC2M.oArg.expID = teamBriefById.dungeonID;
                    c2MTeamRequestC2M.oArg.password = this.password;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_LEAVE:
                    c2MTeamRequestC2M.oArg.param = param;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_QUERYCOUNT:
                    c2MTeamRequestC2M.oArg.request = op;
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)c2MTeamRequestC2M);
                    break;
                case TeamOperate.TEAM_KICK:
                case TeamOperate.TEAM_TRAHS_LEADER:
                    c2MTeamRequestC2M.oArg.roleid = param;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_START_BATTLE:
                    if (o != null)
                    {
                        c2MTeamRequestC2M.oArg.extrainfo = new TeamExtraInfo()
                        {
                            league_teamname = o as string
                        };
                        goto case TeamOperate.TEAM_QUERYCOUNT;
                    }
                    else
                        goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_CHANGE_EPXTEAMID:
                    c2MTeamRequestC2M.oArg.expID = (uint)param;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_INVITE:
                    c2MTeamRequestC2M.oArg.roleid = param;
                    c2MTeamRequestC2M.oArg.account = account;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_START_MATCH:
                case TeamOperate.TEAM_STOP_MATCH:
                case TeamOperate.TEAM_DOWN_MATCH:
                    c2MTeamRequestC2M.oArg.expID = this.currentDungeonID;
                    c2MTeamRequestC2M.oArg.param = param;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_PPTLIMIT:
                case TeamOperate.TEAM_COSTTYPE:
                    if (!(o is TeamExtraInfo teamExtraInfo2))
                        break;
                    c2MTeamRequestC2M.oArg.extrainfo = teamExtraInfo2;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_CHANGE_PASSWORD:
                    c2MTeamRequestC2M.oArg.password = o as string;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                case TeamOperate.TEAM_MEMBER_TYPE:
                    c2MTeamRequestC2M.oArg.membertype = memberType;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
                default:
                    if (this._MyTeam == null)
                        break;
                    c2MTeamRequestC2M.oArg.teamID = this._MyTeam.teamBrief.teamID;
                    c2MTeamRequestC2M.oArg.expID = this._MyTeam.teamBrief.dungeonID;
                    goto case TeamOperate.TEAM_QUERYCOUNT;
            }
        }

        private string _GetRoleName(ulong roleID)
        {
            if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == (long)roleID)
                return XStringDefineProxy.GetString("YOU");
            if (this.MyTeam == null)
                return string.Empty;
            XTeamMember member = this.MyTeam.FindMember(roleID);
            return member != null ? member.name : XStringDefineProxy.GetString("THIS_ROLE");
        }

        public void ProcessTeamOPErrorCode(ErrorCode errcode, ulong roleID)
        {
            switch (errcode)
            {
                case ErrorCode.ERR_TEAM_NEED_ATLEAST_2_MEMBER:
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(string.Format("TEAM_{0}", (object)errcode.ToString()), (object)this.currentExpInfo.PlayerLeastNumber), "fece00");
                    break;
                case ErrorCode.ERR_TEAM_SERVER_OPEN_TIME:
                    break;
                default:
                    if (roleID > 0UL)
                    {
                        string roleName = this._GetRoleName(roleID);
                        if (string.IsNullOrEmpty(roleName))
                        {
                            XSingleton<UiUtility>.singleton.ShowSystemTip(errcode);
                            break;
                        }
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(string.Format("TEAM_{0}", (object)errcode.ToString()), (object)roleName), "fece00");
                        break;
                    }
                    XSingleton<UiUtility>.singleton.ShowSystemTip(errcode);
                    break;
            }
        }

        public void OnGetTeamOp(TeamOPArg oArg, TeamOPRes oRes)
        {
            if ((uint)oRes.result > 0U)
            {
                this.ProcessTeamOPErrorCode(oRes.result, oRes.problem_roleid);
                switch (oRes.result)
                {
                    case ErrorCode.ERR_SCENE_NOFATIGUE:
                        if (oRes.problem_roleid == 0UL || (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == (long)oRes.problem_roleid)
                        {
                            DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase();
                            break;
                        }
                        break;
                    case ErrorCode.ERR_SCENE_TODYCOUNTLIMIT:
                    case ErrorCode.ERR_TEAM_NEST_DAYCOUNT:
                        if (oRes.problem_roleid == 0UL || (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == (long)oRes.problem_roleid)
                        {
                            ExpeditionTable.RowData expeditionDataById = this.ExpDoc.GetExpeditionDataByID((int)oArg.expID);
                            if (expeditionDataById != null)
                                DlgBase<XBuyCountView, XBuyCountBehaviour>.singleton.PassiveShow((TeamLevelType)expeditionDataById.Type);
                            break;
                        }
                        break;
                    case ErrorCode.ERR_TEAM_SERVER_OPEN_TIME:
                        string str = this._GetRoleName(oRes.problem_roleid) ?? string.Empty;
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)oRes.opentime, XStringDefineProxy.GetString("TEAM_ERR_TEAM_SERVER_OPEN_TIME", (object)str), true), "fece00");
                        break;
                }
                if (oArg.request != TeamOperate.TEAM_START_MATCH)
                    return;
                this.m_bAutoMatching = false;
            }
            else
            {
                switch (oArg.request)
                {
                    case TeamOperate.TEAM_CREATE:
                        if (oArg.param > 0UL)
                            this.ReqTeamOp(TeamOperate.TEAM_INVITE, oArg.param);
                        this.ExpDoc.TryShowPveAttrTips(oArg.expID);
                        break;
                    case TeamOperate.TEAM_JOIN:
                        this.TryChangeToExpID((int)oArg.expID);
                        break;
                    case TeamOperate.TEAM_LEAVE:
                        if (oArg.param > 0UL)
                        {
                            bool bHasPwd = (oArg.param & 4294967296UL) > 0UL;
                            XTeamView.TryJoinTeam((int)(oArg.param & (ulong)uint.MaxValue), bHasPwd);
                            break;
                        }
                        break;
                    case TeamOperate.TEAM_CHANGE_EPXTEAMID:
                        this._SetCurrentDungeon((int)oArg.expID);
                        break;
                    case TeamOperate.TEAM_INVITE:
                        if (!oArg.accountSpecified || string.IsNullOrEmpty(oArg.account))
                        {
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_INVITE_SUCCESS"), "fece00");
                            break;
                        }
                        break;
                    case TeamOperate.TEAM_START_MATCH:
                        if (this.m_bAutoMatching)
                            DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BEGIN_MATCH"), "fece00");
                        break;
                    case TeamOperate.TEAM_STOP_MATCH:
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CANCEL_MATCH"), "fece00");
                        break;
                    case TeamOperate.TEAM_CHANGE_PASSWORD:
                        if (string.IsNullOrEmpty(oArg.password))
                        {
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_REMOVE_PWD"), "fece00");
                            break;
                        }
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_SET_PWD"), "fece00");
                        break;
                    case TeamOperate.TEAM_MEMBER_TYPE:
                        if (TeamMemberType.TMT_USETICKET == oArg.membertype)
                        {
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TEAM_TICKET_SUCCESS"), "fece00");
                            break;
                        }
                        if (TeamMemberType.TMT_HELPER == oArg.membertype)
                        {
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SWITCH_TO_HELPER"), "fece00");
                            break;
                        }
                        break;
                }
                if (!XTeamDocument.bFromHyperLink)
                    return;
                DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
            }
        }

        public void OnLeaveTeam(LeaveTeamType errType)
        {
            if (this._MyTeam == null)
            {
                if (errType == LeaveTeamType.LTT_MS_CRASH)
                    return;
                XSingleton<XDebug>.singleton.AddErrorLog("Not in team now. Shouldnt receive leave team ptc.");
            }
            else
            {
                switch (errType)
                {
                    case LeaveTeamType.LTT_BY_SELF:
                        if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall)
                        {
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_LEAVE_TEAM", (object)XStringDefineProxy.GetString("YOU")), "fece00");
                            goto case LeaveTeamType.LTT_DEL_ROBOT;
                        }
                        else
                            goto case LeaveTeamType.LTT_DEL_ROBOT;
                    case LeaveTeamType.LTT_DEL_ROBOT:
                    case LeaveTeamType.LTT_MS_CRASH:
                        XLeaveTeamEventArgs xleaveTeamEventArgs = XEventPool<XLeaveTeamEventArgs>.GetEvent();
                        xleaveTeamEventArgs.dungeonID = this._MyTeam.teamBrief.dungeonID;
                        xleaveTeamEventArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                        this._MyTeam = (XTeam)null;
                        this.password = "";
                        XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xleaveTeamEventArgs);
                        break;
                    default:
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(errType.ToString()), "fece00");
                        goto case LeaveTeamType.LTT_DEL_ROBOT;
                }
            }
        }

        public void RefreshMyTeamView()
        {
            if (this.MyTeamView == null || !this.MyTeamView.IsVisible())
                return;
            this.MyTeamView.RefreshPage();
        }

        public void RefreshRedPoint() => this._UpdateOtherUI();

        private void _UpdateOtherUI()
        {
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_PVP && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HEROBATTLE)
                DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TeamInfoChangeOnBattle(this._MyTeam);
            if (!DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible() || DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.IsShowingTaskTab)
                return;
            DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.TeamHandler.TeamInfoChange(this._MyTeam);
        }

        public override void Update(float fDeltaT)
        {
            base.Update(fDeltaT);
            if (this.MyTeam != null)
                this.MyTeam.OnUpdate();
            if (this.m_nMatchingTime < 0)
                return;
            int num = (int)((double)Time.time - (double)this.m_fMatchingTime);
            if (num > this.m_nMatchingTime)
                this.m_nMatchingTime = num;
        }

        private void _AutoJoin()
        {
            this.bTryAutoJoin = false;
            foreach (XTeamBriefData team in this._TeamList)
            {
                if (team.state == XTeamState.TS_NOT_FULL)
                {
                    this.ReqTeamOp(TeamOperate.TEAM_JOIN, (ulong)team.teamID);
                    return;
                }
            }
            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_AUTOJOIN_FAILED"), "fece00");
        }

        public void ToggleVoting(bool bVote)
        {
            this._bVoting = bVote;
            if (this._bVoting)
            {
                DlgBase<XTeamBattleConfirmView, XTeamBattleConfirmBehaviour>.singleton.StartFightVote();
            }
            else
            {
                if (this.bInTeam && this.MyTeam.teamBrief.actualState == TeamState.TEAM_IN_BATTLE || !DlgBase<XTeamBattleConfirmView, XTeamBattleConfirmBehaviour>.singleton.IsVisible())
                    return;
                DlgBase<XTeamBattleConfirmView, XTeamBattleConfirmBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XTeamBattleConfirmView, XTeamBattleConfirmBehaviour>.OnAnimationOver)null);
            }
        }

        public static KMatchType TeamType2MatchType(TeamLevelType type)
        {
            switch (type)
            {
                case TeamLevelType.TeamLevelCaptainPVP:
                    return KMatchType.KMT_PVP;
                case TeamLevelType.TeamLevelHeroBattle:
                    return KMatchType.KMT_HERO;
                case TeamLevelType.TeamLevelTeamLeague:
                    return KMatchType.KMT_LEAGUE;
                case TeamLevelType.TeamLevelMultiPK:
                    return KMatchType.KMT_PKTWO;
                case TeamLevelType.TeamLevelWeekendParty:
                    return KMatchType.KMT_WEEKEND_ACT;
                case TeamLevelType.TeamLevelMoba:
                    return KMatchType.KMT_MOBA;
                case TeamLevelType.TeamLevelCustomPKTwo:
                    return KMatchType.KMT_CUSTOM_PKTWO;
                default:
                    return KMatchType.KMT_EXP;
            }
        }

        public static TeamLevelType MatchType2TeamType(KMatchType type)
        {
            switch (type)
            {
                case KMatchType.KMT_PVP:
                    return TeamLevelType.TeamLevelCaptainPVP;
                case KMatchType.KMT_HERO:
                    return TeamLevelType.TeamLevelHeroBattle;
                case KMatchType.KMT_LEAGUE:
                    return TeamLevelType.TeamLevelTeamLeague;
                case KMatchType.KMT_PKTWO:
                    return TeamLevelType.TeamLevelMultiPK;
                case KMatchType.KMT_MOBA:
                    return TeamLevelType.TeamLevelMoba;
                case KMatchType.KMT_WEEKEND_ACT:
                    return TeamLevelType.TeamLevelWeekendParty;
                case KMatchType.KMT_CUSTOM_PKTWO:
                    return TeamLevelType.TeamLevelCustomPKTwo;
                default:
                    return TeamLevelType.TeamLevelNone;
            }
        }

        public bool IsSoloMatching(TeamLevelType type) => this.SoloMatchType == XTeamDocument.TeamType2MatchType(type);

        public bool IsMatching(TeamLevelType type) => this.bInTeam ? this._MyTeam.teamBrief.matchType == XTeamDocument.TeamType2MatchType(type) : this.IsSoloMatching(type);

        public void CancelMatch()
        {
            if (this.bInTeam || !this.bSoloMatching || this.SoloMatchType != KMatchType.KMT_EXP && XTeamDocument.MatchType2TeamType(this.SoloMatchType) == this.currentDungeonType)
                return;
            switch (this.SoloMatchType)
            {
                case KMatchType.KMT_EXP:
                    this.ReqTeamOp(TeamOperate.TEAM_STOP_MATCH);
                    break;
                case KMatchType.KMT_PVP:
                case KMatchType.KMT_HERO:
                    this.ReqMatchStateChange(this.SoloMatchType, KMatchOp.KMATCH_OP_STOP, false);
                    break;
            }
        }

        public void ForceMatching(bool matching)
        {
            if (!matching)
            {
                this.ReqTeamOp(TeamOperate.TEAM_STOP_MATCH);
                this.m_bAutoMatching = false;
            }
            else
            {
                this.ReqTeamOp(TeamOperate.TEAM_START_MATCH);
                this.m_bAutoMatching = true;
            }
        }

        public void SetAndMatch(int expid)
        {
            this.TryChangeToExpID(expid);
            DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
        }

        public void ToggleMatching()
        {
            if (this.IsMatching(this.currentDungeonType))
                this.ReqTeamOp(TeamOperate.TEAM_STOP_MATCH);
            else if (this.currentDungeonType == TeamLevelType.TeamLevelTeamTower && this.ExpDoc.EnlargeMatch)
                this.ReqTeamOp(TeamOperate.TEAM_DOWN_MATCH);
            else
                this.ReqTeamOp(TeamOperate.TEAM_START_MATCH);
            this.m_bAutoMatching = false;
        }

        private bool _ForceStart(IXUIButton btn)
        {
            this.ReqTeamOp(TeamOperate.TEAM_START_BATTLE_REMOVE_DISAGREE_MEMBER);
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            return true;
        }

        public int GetCurrentDayMaxCount() => this.ExpDoc.GetDayMaxCount(this.currentDungeonType, this.currentSceneData);

        public int GetMyDayCount() => this.ExpDoc.GetDayCount(this.currentDungeonType, this.currentSceneData);

        public void ReqSceneDayCount()
        {
            RpcC2G_QuerySceneDayCount querySceneDayCount = new RpcC2G_QuerySceneDayCount();
            querySceneDayCount.oArg.type = 1U;
            List<XTeamCategory> categories = this.ExpDoc.TeamCategoryMgr.m_Categories;
            for (int index1 = 0; index1 < categories.Count; ++index1)
            {
                if (categories[index1].HasOpened())
                {
                    List<ExpeditionTable.RowData> expList = categories[index1].expList;
                    for (int index2 = 0; index2 < expList.Count; ++index2)
                    {
                        uint sceneIdByExpId = this.ExpDoc.GetSceneIDByExpID(expList[index2].DNExpeditionID);
                        if (sceneIdByExpId != 0U)
                            querySceneDayCount.oArg.groupid.Add(sceneIdByExpId);
                        else
                            break;
                    }
                }
            }
            XSingleton<XClientNetwork>.singleton.Send((Rpc)querySceneDayCount);
        }

        public void OnGetSceneDayCount(QuerySceneDayCountRes oRes)
        {
            if (!DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible())
                return;
            this.TryAutoSelectExp();
        }

        protected override void OnReconnected(XReconnectedEventArgs arg) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_TeamRequestC2M()
        {
            oArg = {
        request = TeamOperate.TEAM_GET_FULL_DATA
      }
        });

        public void OnTeamFullDataNotify(TeamFullDataNtf data)
        {
            XSingleton<XDebug>.singleton.AddGreenLog("Team reconnect");
            if (!data.hasTeam && this.bInTeam)
            {
                this.OnLeaveTeam(LeaveTeamType.LTT_BY_SELF);
            }
            else
            {
                if (!data.hasTeam)
                    return;
                XTeamDocument.XPreviousTeamData previousData = new XTeamDocument.XPreviousTeamData(this);
                if (this.MyTeam == null)
                {
                    this._MyTeam = new XTeam();
                    previousData.bNewTeam = true;
                }
                previousData.PreserveTeamData(this._MyTeam);
                this._MyTeam.Reset();
                this._MyTeam.PreUpdate();
                this._MyTeam.teamBrief.SetData(data.teamBrief, this.ExpDoc);
                if (this._MyTeam.teamBrief.rowData == null)
                {
                    XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("LeaveTeamSinceNoConfig"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
                    this.ReqTeamOp(TeamOperate.TEAM_LEAVE);
                }
                else
                {
                    for (int index = 0; index < data.members.Count; ++index)
                        this._MyTeam.AddMember(data.members[index]);
                    this._MyTeam.PostUpdate();
                    if (this.MyTeam.members.Count > 1)
                        XSingleton<XTutorialHelper>.singleton.HasTeam = true;
                    this._MyTeam.members.Sort();
                    this._PostTeamInfoChanged(previousData, data.teamBrief);
                }
            }
        }

        public void ReqMatchStateChange(KMatchType type, KMatchOp op, bool isTeamMatch)
        {
            XSingleton<XDebug>.singleton.AddGreenLog("KKSG.KMatchType:" + (object)type + "   KKSG.KMatchOp:" + (object)op + "\nisTeamMatch:" + isTeamMatch.ToString());
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_KMatchCommonReq()
            {
                oArg = {
          type = type,
          op = op,
          isteam = isTeamMatch
        }
            });
        }

        public void OnRoleMatchStateNotify(RoleStateMatch matchData)
        {
            if ((uint)matchData.matchtype > 0U)
            {
                if (this.m_SoloMatchType != matchData.matchtype)
                {
                    this.m_nMatchingTime = 0;
                    this.m_fMatchingTime = Time.time;
                }
            }
            else
                this.m_nMatchingTime = -1;
            this.m_SoloMatchType = matchData.matchtype;
            if (this.TeamListView != null && this.TeamListView.IsVisible())
                this.TeamListView.RefreshPage();
            if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsLoaded())
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.SetTeamMatching(this.bSoloMatching);
            if (DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.IsVisible())
                DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.RefreshButtonState();
            if (DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible())
                DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.Refresh();
            if (DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.IsVisible())
                DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.RefreshMatch();
            if (DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible())
                DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.RefreshMatch2v2Btn();
            if (!DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>.singleton.IsVisible())
                return;
            DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>.singleton.RefreshMatchBtn();
        }

        public static bool GoSingleBattleBeforeNeed(ButtonClickEventHandler handler, IXUIButton btn)
        {
            XTeamDocument._EventDel = (EventDelegate)null;
            XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            if (XTeamDocument._bCanEnter)
            {
                XTeamDocument._bCanEnter = false;
                return false;
            }
            XTeamDocument._EnterButton = btn;
            XTeamDocument._EnterHandler = handler;
            return specificDocument.bInTeam ? XTeamDocument.ShouldLeaveTeamFirst() : XTeamDocument.ShouldTips();
        }

        public static bool GoSingleBattleBeforeNeed(EventDelegate del)
        {
            XTeamDocument._EnterHandler = (ButtonClickEventHandler)null;
            XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            if (XTeamDocument._bCanEnter)
            {
                XTeamDocument._bCanEnter = false;
                return false;
            }
            XTeamDocument._EventDel = del;
            return specificDocument.bInTeam ? XTeamDocument.ShouldLeaveTeamFirst() : XTeamDocument.ShouldTips();
        }

        public static bool ShouldTips()
        {
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SKYCITY_WAITING && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HORSE && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BIGMELEE_READY && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BATTLEFIELD_READY)
                return false;
            XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("SKY_ARENA_LEAVE_SINGLE_TIP"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(XTeamDocument._Enter));
            return true;
        }

        public static bool ShouldLeaveTeamFirst()
        {
            XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<XScene>.singleton.SceneType != SceneType.SKYCITY_WAITING ? XStringDefineProxy.GetString("TEAM_SHOULD_LEAVE_TEAM_CONFIRM") : XStringDefineProxy.GetString("SKY_ARENA_LEAVE_TEAM_TIP"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(XTeamDocument._LeaveAndEnter));
            return true;
        }

        private static bool _Enter(IXUIButton button)
        {
            XTeamDocument._bCanEnter = true;
            if (XTeamDocument._EnterHandler != null)
            {
                int num = XTeamDocument._EnterHandler(XTeamDocument._EnterButton) ? 1 : 0;
                XTeamDocument._EnterHandler = (ButtonClickEventHandler)null;
            }
            if (XTeamDocument._EventDel != null)
            {
                XTeamDocument._EventDel();
                XTeamDocument._EventDel = (EventDelegate)null;
            }
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            return true;
        }

        private static bool _LeaveAndEnter(IXUIButton button)
        {
            XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            if (specificDocument.bInTeam)
                specificDocument.ReqTeamOp(TeamOperate.TEAM_LEAVE);
            XTeamDocument._bCanEnter = true;
            if (XTeamDocument._EnterHandler != null)
            {
                int num = XTeamDocument._EnterHandler(XTeamDocument._EnterButton) ? 1 : 0;
                XTeamDocument._EnterHandler = (ButtonClickEventHandler)null;
            }
            if (XTeamDocument._EventDel != null)
            {
                XTeamDocument._EventDel();
                XTeamDocument._EventDel = (EventDelegate)null;
            }
            XSingleton<UiUtility>.singleton.CloseModalDlg();
            return true;
        }

        public static void OnTeamHyperLinkClick(string param)
        {
            if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                return;
            XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            if (specificDocument.bInTeam)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAM_ALREADY_INTEAM);
            }
            else
            {
                int teamid = 0;
                uint expid = 0;
                if (!XLabelSymbolHelper.ParseTeamParam(param, ref teamid, ref expid))
                    return;
                ExpeditionTable.RowData expeditionDataById = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID).GetExpeditionDataByID((int)expid);
                if (expeditionDataById == null)
                    XSingleton<XDebug>.singleton.AddErrorLog("Invalid expedi ID ", expid.ToString());
                else if ((long)expeditionDataById.RequiredLevel > (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAM_LEVEL_REQUARE);
                }
                else
                {
                    XTeamDocument.bFromHyperLink = true;
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_TeamRequestC2M()
                    {
                        oArg = {
              expID = expid,
              teamID = teamid,
              request = TeamOperate.TEAM_JOIN
            }
                    });
                    specificDocument._SetCurrentTeamInfo(expeditionDataById);
                }
            }
        }

        private struct XPreviousTeamData
        {
            public TeamState state;
            public int goldGroupIndex;
            public int goldGroupItemID;
            public bool bNewTeam;
            public string leaderName;
            public ExpeditionTable.RowData expData;
            private XTeamDocument doc;

            public XPreviousTeamData(XTeamDocument _doc)
            {
                this.doc = _doc;
                this.state = TeamState.TEAM_WAITING;
                this.goldGroupIndex = -1;
                this.goldGroupItemID = 0;
                this.bNewTeam = false;
                this.leaderName = (string)null;
                this.expData = (ExpeditionTable.RowData)null;
            }

            public void PreserveTeamData(XTeam team)
            {
                this.state = team.teamBrief.actualState;
                this.goldGroupIndex = team.teamBrief.goldGroup.index;
                this.goldGroupItemID = team.teamBrief.goldGroup.itemid;
                this.leaderName = team.teamBrief.leaderName;
                this.expData = team.teamBrief.rowData;
            }

            public void CheckNewTeamData(XTeam team)
            {
                if (this.state != team.teamBrief.actualState)
                    this.doc.ToggleVoting(team.teamBrief.actualState == TeamState.TEAM_VOTE);
                if (this.bNewTeam || this.goldGroupIndex == team.teamBrief.goldGroup.index)
                    return;
                int index = team.teamBrief.goldGroup.index;
                if (this.doc.currentExpInfo != null)
                {
                    if (index < 0)
                    {
                        if (!(this.doc.MyTeam.myData.name == this.leaderName))
                            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TeamGoldGroupTurnedOff"), "fece00");
                    }
                    else
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TeamGoldGroupTurnedOn", (object)XGoldGroupData.GetName(ref this.doc.currentExpInfo.CostType, index)), "fece00");
                }
            }
        }
    }
}
