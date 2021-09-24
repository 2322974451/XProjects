

using KKSG;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class GroupChatDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(GroupChatDocument));
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static GroupStageType _stageTypeReader = new GroupStageType();
        private static Dictionary<uint, uint> _stage2exps;
        public HashSet<CBrifGroupInfo> groups;
        public HashSet<CGroupPlayerInfo> players;
        public RecruitSelectGroupHandler SelectGroupHandler = (RecruitSelectGroupHandler)null;
        private bool m_bShowMotion = false;
        private List<GroupMember> m_recruitGroups;
        private List<GroupMember> m_leaderReviewList;
        private List<GroupMember> m_recruitMembers;
        private uint m_curUseGroupCount = 0;
        private uint m_curUseMemberCount = 0;

        public override uint ID => GroupChatDocument.uuID;

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
        }

        public static void Execute(OnLoadedCallback callback = null)
        {
            GroupChatDocument.AsyncLoader.AddTask("Table/GroupStageType", (CVSReader)GroupChatDocument._stageTypeReader);
            GroupChatDocument.AsyncLoader.Execute(callback);
        }

        public static void OnTableLoaded()
        {
            if (GroupChatDocument._stage2exps == null)
                return;
            GroupChatDocument._stage2exps.Clear();
            GroupChatDocument._stage2exps = (Dictionary<uint, uint>)null;
        }

        public static uint GetStageID(uint expID)
        {
            if (GroupChatDocument._stage2exps == null)
            {
                GroupChatDocument._stage2exps = new Dictionary<uint, uint>();
                int length = GroupChatDocument._stageTypeReader.Table.Length;
                for (int index = 0; index < length; ++index)
                {
                    GroupStageType.RowData rowData = GroupChatDocument._stageTypeReader.Table[index];
                    if (rowData != null && rowData.StagePerent != 0U && !GroupChatDocument._stage2exps.ContainsKey((uint)rowData.Stage2Expedition))
                        GroupChatDocument._stage2exps.Add((uint)rowData.Stage2Expedition, rowData.StageID);
                }
            }
            return !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GroupRecruit) || !GroupChatDocument._stage2exps.ContainsKey(expID) ? 0U : GroupChatDocument._stage2exps[expID];
        }

        public static GroupStageType.RowData[] GetStageTable() => GroupChatDocument._stageTypeReader.Table;

        public static GroupStageType.RowData GetGroupStage(uint stageID) => stageID == 0U ? (GroupStageType.RowData)null : GroupChatDocument._stageTypeReader.GetByStageID(stageID);

        public static bool TryGetParentStage(uint stageID, out uint parentID)
        {
            parentID = 0U;
            GroupStageType.RowData byStageId = GroupChatDocument._stageTypeReader.GetByStageID(stageID);
            if (byStageId == null)
                return false;
            parentID = byStageId.StagePerent;
            return parentID > 0U;
        }

        public CBrifGroupInfo currGroup
        {
            get
            {
                if (this.groups != null)
                {
                    HashSet<CBrifGroupInfo>.Enumerator enumerator = this.groups.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if ((long)enumerator.Current.id == (long)DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId)
                            return enumerator.Current;
                    }
                }
                return (CBrifGroupInfo)null;
            }
        }

        public bool TryGetGroupInMine(ref List<CBrifGroupInfo> list)
        {
            if (this.groups == null)
                return false;
            HashSet<CBrifGroupInfo>.Enumerator enumerator = this.groups.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if ((long)enumerator.Current.leaderid == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                    list.Add(enumerator.Current);
            }
            return true;
        }

        public void AddChat2Group(ChatInfo chatInfo)
        {
            if (this.groups == null)
                this.groups = new HashSet<CBrifGroupInfo>();
            if (!this.ContainGroup(chatInfo.group.groupchatID))
            {
                CBrifGroupInfo cbrifGroupInfo = new CBrifGroupInfo();
                cbrifGroupInfo.id = chatInfo.group.groupchatID;
                cbrifGroupInfo.msgtime = chatInfo.mTime;
                cbrifGroupInfo.name = chatInfo.group.groupchatName;
                cbrifGroupInfo.memberCnt = chatInfo.group.rolecount;
                cbrifGroupInfo.createtype = chatInfo.group.createtype;
                cbrifGroupInfo.LoopID = XSingleton<XCommon>.singleton.XHash(cbrifGroupInfo.name + (object)cbrifGroupInfo.id + (object)cbrifGroupInfo.memberCnt);
                cbrifGroupInfo.captain = (long)chatInfo.group.leaderRoleID == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
                cbrifGroupInfo.chat = chatInfo.mContent;
                cbrifGroupInfo.rolename = chatInfo.mSenderName;
                cbrifGroupInfo.leaderid = chatInfo.group.leaderRoleID;
                cbrifGroupInfo.createTime = chatInfo.group.groupcreatetime;
                if (!this.groups.Add(cbrifGroupInfo))
                    XSingleton<XDebug>.singleton.AddErrorLog("exits group id: ", chatInfo.group.groupchatID.ToString());
                DlgBase<XChatView, XChatBehaviour>.singleton.ProcessGroupMsg();
            }
            else
            {
                HashSet<CBrifGroupInfo>.Enumerator enumerator = this.groups.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if ((long)enumerator.Current.id == (long)chatInfo.group.groupchatID)
                    {
                        enumerator.Current.chat = chatInfo.mContent;
                        enumerator.Current.msgtime = chatInfo.mTime;
                        enumerator.Current.rolename = chatInfo.mSenderName;
                        enumerator.Current.memberCnt = chatInfo.group.rolecount;
                        enumerator.Current.LoopID = XSingleton<XCommon>.singleton.XHash(enumerator.Current.name + (object)enumerator.Current.id + (object)enumerator.Current.memberCnt);
                        break;
                    }
                }
            }
            if (!DlgBase<RecruitGroupPublishView, RecruitGroupPublishBehaviour>.singleton.IsVisible())
                return;
            DlgBase<RecruitGroupPublishView, RecruitGroupPublishBehaviour>.singleton.Refresh();
        }

        private bool ContainGroup(ulong groupid)
        {
            if (this.groups == null)
                return false;
            HashSet<CBrifGroupInfo>.Enumerator enumerator = this.groups.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if ((long)enumerator.Current.id == (long)groupid)
                    return true;
            }
            return false;
        }

        public bool ReqCreateGroupChat(string groupname, uint type = 1)
        {
            groupname = groupname.Trim();
            string pattern1 = "^[0-9a-fA-F]{6}$";
            string pattern2 = "^[0-9a-fA-F]{2}$";
            if (string.IsNullOrEmpty(groupname) || groupname.Equals(XStringDefineProxy.GetString("CHAT_GROUP_DEF")))
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_GROUP_LEFT"), "fece00");
                return false;
            }
            if (Regex.IsMatch(groupname, pattern1) || Regex.IsMatch(groupname, pattern2) || groupname.Contains("[") || groupname.Contains("]"))
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_INVALID"), "fece00");
                return false;
            }
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatCreate()
            {
                oArg = {
          groupchatName = groupname,
          createtype = type
        }
            });
            return true;
        }

        public void ResCreateGroupChat(GroupChatCreateC2S arg, GroupChatCreateS2C res)
        {
            if (this.SelectGroupHandler == null || !this.SelectGroupHandler.IsVisible())
                return;
            this.SelectGroupHandler.SetupSelectGroup(res.groupchatID);
        }

        public void ReqClearGroup() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatClear());

        public void ReqGetGroupInfo(ulong groupid) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatGetGroupInfo()
        {
            oArg = {
        groupchatID = groupid
      }
        });

        public void ResGroupInfo(List<GroupChatPlayerInfo> playerlist)
        {
            if (this.players == null)
                this.players = new HashSet<CGroupPlayerInfo>();
            else
                this.players.Clear();
            int index1 = 0;
            for (int count = playerlist.Count; index1 < count; ++index1)
            {
                GroupChatPlayerInfo groupChatPlayerInfo = playerlist[index1];
                CGroupPlayerInfo cgroupPlayerInfo = new CGroupPlayerInfo();
                cgroupPlayerInfo.roleid = groupChatPlayerInfo.roleid;
                cgroupPlayerInfo.rolename = groupChatPlayerInfo.rolename;
                cgroupPlayerInfo.level = groupChatPlayerInfo.level;
                cgroupPlayerInfo.ppt = groupChatPlayerInfo.fighting;
                cgroupPlayerInfo.profession = groupChatPlayerInfo.profession;
                cgroupPlayerInfo.degree = -1;
                cgroupPlayerInfo.uid = groupChatPlayerInfo.uid;
                cgroupPlayerInfo.guild = groupChatPlayerInfo.guild;
                if (!this.players.Add(cgroupPlayerInfo))
                    XSingleton<XDebug>.singleton.AddErrorLog("exist player: ", cgroupPlayerInfo.roleid.ToString());
            }
            List<XFriendData> friendData = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendData();
            int index2 = 0;
            for (int count = friendData.Count; index2 < count; ++index2)
            {
                if (!this.Exist(friendData[index2].roleid))
                {
                    CGroupPlayerInfo cgroupPlayerInfo = new CGroupPlayerInfo();
                    cgroupPlayerInfo.roleid = friendData[index2].roleid;
                    cgroupPlayerInfo.rolename = friendData[index2].name;
                    cgroupPlayerInfo.setid = friendData[index2].setid;
                    cgroupPlayerInfo.level = friendData[index2].level;
                    cgroupPlayerInfo.ppt = friendData[index2].powerpoint;
                    cgroupPlayerInfo.degree = (int)friendData[index2].degreeAll;
                    cgroupPlayerInfo.profession = friendData[index2].profession;
                    cgroupPlayerInfo.uid = friendData[index2].uid;
                    cgroupPlayerInfo.guild = friendData[index2].guildname;
                    if (!this.players.Add(cgroupPlayerInfo))
                        XSingleton<XDebug>.singleton.AddErrorLog("exist player: ", cgroupPlayerInfo.roleid.ToString());
                }
            }
            if (DlgBase<ChatGroupList, ChatGroupBehaviour>.singleton.IsVisible())
                DlgBase<ChatGroupList, ChatGroupBehaviour>.singleton.SetCB();
            if (!DlgBase<ChatMemberList, ChatMemberBehaviour>.singleton.IsVisible())
                return;
            DlgBase<ChatMemberList, ChatMemberBehaviour>.singleton.Refresh();
        }

        private bool Exist(ulong uid)
        {
            HashSet<CGroupPlayerInfo>.Enumerator enumerator = this.players.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if ((long)enumerator.Current.roleid == (long)uid)
                    return true;
            }
            return false;
        }

        public void ReqChangePlayer(ulong groupid, List<ulong> add, List<ulong> remove)
        {
            RpcC2M_GroupChatManager groupChatManager = new RpcC2M_GroupChatManager();
            groupChatManager.oArg.groupchatID = groupid;
            if (add != null)
            {
                groupChatManager.oArg.addrolelist.Clear();
                int index = 0;
                for (int count = add.Count; index < count; ++index)
                    groupChatManager.oArg.addrolelist.Add(add[index]);
            }
            if (remove != null)
            {
                groupChatManager.oArg.subrolelist.Clear();
                int index = 0;
                for (int count = remove.Count; index < count; ++index)
                    groupChatManager.oArg.subrolelist.Add(remove[index]);
            }
            XSingleton<XClientNetwork>.singleton.Send((Rpc)groupChatManager);
        }

        public void ResChangePlayer(GroupChatManagerPtc res)
        {
            if (this.players == null)
                this.players = new HashSet<CGroupPlayerInfo>();
            CGroupPlayerInfo cgroupPlayerInfo1 = (CGroupPlayerInfo)null;
            int index1 = 0;
            for (int count = res.subrolelist.Count; index1 < count; ++index1)
            {
                if ((long)res.subrolelist[index1] == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                {
                    this.ResQuitGroup(res.groupchatID);
                    return;
                }
                HashSet<CGroupPlayerInfo>.Enumerator enumerator = this.players.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if ((long)enumerator.Current.roleid == (long)res.subrolelist[index1])
                    {
                        cgroupPlayerInfo1 = enumerator.Current;
                        break;
                    }
                }
                if (cgroupPlayerInfo1 != null)
                {
                    if (DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(cgroupPlayerInfo1.roleid))
                        cgroupPlayerInfo1.degree = (int)DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDegreeAll(cgroupPlayerInfo1.roleid);
                    else
                        this.players.Remove(cgroupPlayerInfo1);
                }
            }
            int index2 = 0;
            for (int count = res.addrolelist.Count; index2 < count; ++index2)
            {
                GroupChatPlayerInfo groupChatPlayerInfo = res.addrolelist[index2];
                this.TryRmOriginPlayer(groupChatPlayerInfo.roleid);
                CGroupPlayerInfo cgroupPlayerInfo2 = new CGroupPlayerInfo();
                cgroupPlayerInfo2.roleid = groupChatPlayerInfo.roleid;
                cgroupPlayerInfo2.rolename = groupChatPlayerInfo.rolename;
                cgroupPlayerInfo2.level = groupChatPlayerInfo.level;
                cgroupPlayerInfo2.guild = groupChatPlayerInfo.guild;
                cgroupPlayerInfo2.uid = groupChatPlayerInfo.uid;
                cgroupPlayerInfo2.degree = -1;
                cgroupPlayerInfo2.ppt = groupChatPlayerInfo.fighting;
                cgroupPlayerInfo2.profession = groupChatPlayerInfo.profession;
                if (!this.players.Add(cgroupPlayerInfo2))
                    XSingleton<XDebug>.singleton.AddErrorLog("exist player: ", cgroupPlayerInfo2.roleid.ToString());
            }
            if (!DlgBase<ChatGroupList, ChatGroupBehaviour>.singleton.IsVisible())
                return;
            DlgBase<ChatGroupList, ChatGroupBehaviour>.singleton.Refresh();
        }

        private void TryRmOriginPlayer(ulong roleid)
        {
            CGroupPlayerInfo cgroupPlayerInfo = (CGroupPlayerInfo)null;
            HashSet<CGroupPlayerInfo>.Enumerator enumerator = this.players.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if ((long)enumerator.Current.roleid == (long)roleid)
                {
                    cgroupPlayerInfo = enumerator.Current;
                    break;
                }
            }
            if (cgroupPlayerInfo == null)
                return;
            this.players.Remove(cgroupPlayerInfo);
        }

        public void ReqQuitGroup(ulong groupid) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatQuit()
        {
            oArg = {
        groupchatID = groupid
      }
        });

        public void ResQuitGroup(ulong groupid)
        {
            if (this.groups == null)
                return;
            CBrifGroupInfo cbrifGroupInfo = (CBrifGroupInfo)null;
            HashSet<CBrifGroupInfo>.Enumerator enumerator = this.groups.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if ((long)enumerator.Current.id == (long)groupid)
                {
                    cbrifGroupInfo = enumerator.Current;
                    break;
                }
            }
            if (cbrifGroupInfo != null)
                this.groups.Remove(cbrifGroupInfo);
            DlgBase<XChatView, XChatBehaviour>.singleton.ProcessGroupMsg();
            if (!DlgBase<ChatGroupList, ChatGroupBehaviour>.singleton.IsVisible())
                return;
            DlgBase<ChatGroupList, ChatGroupBehaviour>.singleton.SetVisible(false, true);
        }

        public void ResDismissGroup(ulong groupid, ulong roleid)
        {
            if (this.groups != null)
            {
                if (roleid != 0UL)
                    ;
                CBrifGroupInfo cbrifGroupInfo = (CBrifGroupInfo)null;
                HashSet<CBrifGroupInfo>.Enumerator enumerator = this.groups.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if ((long)enumerator.Current.id == (long)groupid)
                    {
                        cbrifGroupInfo = enumerator.Current;
                        break;
                    }
                }
                if (cbrifGroupInfo != null)
                    this.groups.Remove(cbrifGroupInfo);
            }
            DlgBase<XChatView, XChatBehaviour>.singleton.ProcessGroupMsg();
        }

        public bool bShowMotion
        {
            get => this.m_bShowMotion;
            set
            {
                if (this.m_bShowMotion == value)
                    return;
                this.m_bShowMotion = value;
                XSingleton<XDebug>.singleton.AddGreenLog("bShowMotion:" + value.ToString());
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GroupRecruitAuthorize);
                XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID).RefreshRedPoint();
                if (DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                    DlgBase<RecruitView, RecruitBehaviour>.singleton.RefreshRedPoint();
            }
        }

        public List<GroupMember> LeaderReviewList => this.m_leaderReviewList;

        public List<GroupMember> RecruitGroup => this.m_recruitGroups;

        public List<GroupMember> RecruitMember => this.m_recruitMembers;

        public uint CurUserMemberCount => this.m_curUseMemberCount;

        public uint CurGroupCount => this.m_curUseGroupCount;

        public void SysnGroupChatIssueCount(GroupChatIssueCountNtf ntf)
        {
            this.m_curUseGroupCount = ntf.groupcount;
            this.m_curUseMemberCount = ntf.rolecount;
            if (!DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                return;
            DlgBase<RecruitView, RecruitBehaviour>.singleton.Refresh();
        }

        public void SendGroupChatFindTeamInfoList(uint index = 0)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(SendGroupChatFindTeamInfoList));
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatFindTeamInfoList()
            {
                oArg = {
          type = index
        }
            });
        }

        public void ReceiveGroupChatFindTeamInfoList(GroupChatFindTeamInfoListS2C res)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(ReceiveGroupChatFindTeamInfoList));
            this.SetupMemberList(ref this.m_recruitGroups);
            int index = 0;
            for (int count = res.teamlist.Count; index < count; ++index)
            {
                GroupMember groupMember = GroupMember.Get();
                groupMember.Setup(res.teamlist[index]);
                this.m_recruitGroups.Add(groupMember);
            }
            if (!DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                return;
            DlgBase<RecruitView, RecruitBehaviour>.singleton.Refresh();
        }

        public void SendGroupChatFindRoleInfoList(uint index = 0)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(SendGroupChatFindRoleInfoList));
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatFindRoleInfoList()
            {
                oArg = {
          type = index
        }
            });
        }

        public void ReceiveGroupChatFindRoleInfoList(GroupChatFindRoleInfoListS2C res)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(ReceiveGroupChatFindRoleInfoList));
            this.SetupMemberList(ref this.m_recruitMembers);
            int index = 0;
            for (int count = res.rolelist.Count; index < count; ++index)
            {
                GroupMember groupMember = GroupMember.Get();
                groupMember.Setup(res.rolelist[index]);
                this.m_recruitMembers.Add(groupMember);
            }
            if (!DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                return;
            DlgBase<RecruitView, RecruitBehaviour>.singleton.Refresh();
        }

        public bool TryGetGroupMember(ulong issueIndex, out GroupMember member)
        {
            member = (GroupMember)null;
            if (this.m_recruitMembers == null || issueIndex == 0UL)
                return false;
            int index = 0;
            for (int count = this.m_recruitMembers.Count; index < count; ++index)
            {
                if ((long)this.m_recruitMembers[index].issueIndex == (long)issueIndex)
                {
                    member = this.m_recruitMembers[index];
                    return true;
                }
            }
            return false;
        }

        public void SendGroupChatPlayerInfo(GroupChatFindRoleInfo info)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(SendGroupChatPlayerInfo));
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatPlayerIssueInfo()
            {
                oArg = {
          roleinfo = info
        }
            });
        }

        public void ReceiveGroupChatPlayerInfo(GroupChatPlayerIssueInfoS2C s2c)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(ReceiveGroupChatPlayerInfo));
            if ((uint)s2c.errorcode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(s2c.errorcode);
            }
            else
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_SUCCESS);
                if (!DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                    return;
                DlgBase<RecruitView, RecruitBehaviour>.singleton.ReSelect();
            }
        }

        public void SendGroupChatLeaderInfo(GroupChatFindTeamInfo info) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatLeaderIssueInfo()
        {
            oArg = {
        teaminfo = info
      }
        });

        public void ReceiveGroupChatLeaderInfo(GroupChatLeaderIssueInfoS2C s2c)
        {
            if ((uint)s2c.errorcode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(s2c.errorcode);
            }
            else
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_SUCCESS);
                if (!DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                    return;
                DlgBase<RecruitView, RecruitBehaviour>.singleton.ReSelect();
            }
        }

        public void SendGroupChatPlayerApply(ulong index)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(SendGroupChatPlayerApply));
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatPlayerApply()
            {
                oArg = {
          issueIndex = index
        }
            });
        }

        public void ReceiveGroupChatPlayerApply(
          GroupChatPlayerApplyC2S arg,
          GroupChatPlayerApplyS2C s2c)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(ReceiveGroupChatPlayerApply));
            if ((uint)s2c.errorcode > 0U)
            {
                this.SynGroupState(arg.issueIndex, 0U);
                XSingleton<UiUtility>.singleton.ShowSystemTip(s2c.errorcode);
            }
            else
                this.SynGroupState(arg.issueIndex);
            if (!DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                return;
            DlgBase<RecruitView, RecruitBehaviour>.singleton.Refresh();
        }

        public void SendZMLeaderAddRole(ulong index, ulong groupID)
        {
            GroupMember member;
            if (!this.TryGetGroupMember(index, out member))
                return;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatLeaderAddRole()
            {
                oArg = {
          roleIssueIndex = index,
          groupchatID = groupID,
          roleid = member.userID
        }
            });
        }

        public void RecevieZMLeaderAddRole(GroupChatLeaderAddRoleC2S c2s, GroupChatLeaderAddRoleS2C s2c)
        {
            if ((uint)s2c.errorcode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(s2c.errorcode);
            }
            else
            {
                if (this.m_recruitGroups == null)
                    return;
                int index = 0;
                for (int count = this.m_recruitMembers.Count; index < count; ++index)
                {
                    if ((long)this.m_recruitMembers[index].issueIndex == (long)c2s.roleIssueIndex)
                    {
                        this.m_recruitMembers[index].Release();
                        this.m_recruitMembers.RemoveAt(index);
                        break;
                    }
                }
                if (!DlgBase<RecruitView, RecruitBehaviour>.singleton.IsVisible())
                    return;
                DlgBase<RecruitView, RecruitBehaviour>.singleton.Refresh();
            }
        }

        private void SynGroupState(ulong index, uint state = 1)
        {
            if (this.m_recruitGroups == null)
                return;
            int index1 = 0;
            for (int count = this.m_recruitGroups.Count; index1 < count; ++index1)
            {
                if ((long)this.m_recruitGroups[index1].issueIndex == (long)index)
                {
                    this.m_recruitGroups[index1].state = state;
                    break;
                }
            }
        }

        public void SendGroupChatLeaderReviewList()
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(SendGroupChatLeaderReviewList));
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GroupChatLeaderReviewList());
        }

        public void ReceiveGroupChatLeaderReviewList(GroupChatLeaderReviewListS2C s2c)
        {
            XSingleton<XDebug>.singleton.AddGreenLog(nameof(ReceiveGroupChatLeaderReviewList));
            if ((uint)s2c.errorcode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(s2c.errorcode);
            }
            else
            {
                this.SetupMemberList(ref this.m_leaderReviewList);
                int index = 0;
                for (int count = s2c.roleinfolist.Count; index < count; ++index)
                {
                    GroupMember groupMember = GroupMember.Get();
                    groupMember.Setup(s2c.roleinfolist[index]);
                    this.m_leaderReviewList.Add(groupMember);
                }
                if (!DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>.singleton.IsVisible())
                    return;
                DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>.singleton.RefreshData();
            }
        }

        public void SendGroupChatLeaderReview(int index, bool isAgree)
        {
            if (this.m_leaderReviewList == null || index >= this.m_leaderReviewList.Count)
                return;
            RpcC2M_GroupChatLeaderReview chatLeaderReview = new RpcC2M_GroupChatLeaderReview();
            GroupMember leaderReview = this.m_leaderReviewList[index];
            chatLeaderReview.oArg.groupchatID = leaderReview.groupID;
            chatLeaderReview.oArg.issueIndex = leaderReview.issueIndex;
            chatLeaderReview.oArg.roleid = leaderReview.userID;
            chatLeaderReview.oArg.isAgree = isAgree;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)chatLeaderReview);
        }

        public void ReceiveGroupChatLeaderReview(
          GroupChatLeaderReviewC2S arg,
          GroupChatLeaderReviewS2C s2c)
        {
            if ((uint)s2c.errorcode > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(s2c.errorcode);
            }
            else
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_SUCCESS);
                if (this.m_leaderReviewList != null && this.m_leaderReviewList.Count > 0)
                {
                    int index = 0;
                    for (int count = this.m_leaderReviewList.Count; index < count; ++index)
                    {
                        if ((long)this.m_leaderReviewList[index].issueIndex == (long)arg.issueIndex)
                        {
                            this.m_leaderReviewList[index].Release();
                            this.m_leaderReviewList.RemoveAt(index);
                            break;
                        }
                    }
                }
                if (!DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>.singleton.IsVisible())
                    return;
                DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>.singleton.RefreshData();
            }
        }

        private void SetupMemberList(ref List<GroupMember> memberList)
        {
            if (memberList == null)
                memberList = new List<GroupMember>();
            if (memberList.Count <= 0)
                return;
            int index = 0;
            for (int count = memberList.Count; index < count; ++index)
                memberList[index].Release();
            memberList.Clear();
        }
    }
}
